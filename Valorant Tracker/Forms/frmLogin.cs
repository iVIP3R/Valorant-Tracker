using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;
using System.Linq;
using Valorant_Tracker.Services;
using Valorant_Tracker.Utils;

namespace Valorant_Tracker.Forms
{
    public partial class frmLogin : Form
    {
        private const string RiotLoginHost = "authenticate.riotgames.com";
        private static readonly TimeSpan HiddenAttemptTimeout = TimeSpan.FromSeconds(5);

        private readonly WebView2 _browser = new WebView2 { Dock = DockStyle.Fill, Visible = false };
        private bool _handlingRedirect;
        private bool _hiddenAttemptActive;
        private bool _unexpectedRedirectReported;
        public event EventHandler<Auth> Authenticated;

        public frmLogin()
        {
            InitializeComponent();

            Opacity = 0;
            ShowInTaskbar = false;

            Controls.Add(_browser);
            _browser.BringToFront();
            _browser.SourceChanged += Browser_SourceChanged;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cmbRegions.SelectedIndex = 0;
            txtUsername.Visible = txtPassword.Visible = chkPassword.Visible = false;
            lblUsername.Visible = lblPassword.Visible = false;
            btnLogin.Text = "Continue";

            if (RegionStore.TryLoad(out var savedRegion))
                SelectRegionInCombo(savedRegion);

            await InitializeBrowserAsync();
            if (_browser.CoreWebView2 == null)
            {
                ShowLoginForm();
                return;
            }

            if (RegionStore.TryLoad(out _) && await HasPersistentRiotSessionAsync())
            {
                Debug.WriteLine("[frmLogin] Silent re-auth attempt started (form stays transparent)");
                StartHiddenNavigation();
            }
            else
            {
                ShowLoginForm();
            }
        }

        private async Task InitializeBrowserAsync()
        {
            try
            {
                await _browser.EnsureCoreWebView2Async();
            }
            catch (Exception ex)
            {
                btnLogin.Enabled = false;
                MessageBox.Show("Microsoft Edge WebView2 Evergreen Runtime is required to sign in. Install it and restart the app.\n\n" + ex.Message,
                    "WebView2 unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> HasPersistentRiotSessionAsync()
        {
            try
            {
                var cookies = await _browser.CoreWebView2.CookieManager.GetCookiesAsync("https://auth.riotgames.com");
                if (cookies == null || cookies.Count == 0)
                {
                    Debug.WriteLine("[frmLogin] No cookies at auth.riotgames.com");
                    return false;
                }

                var ssid = cookies.FirstOrDefault(c =>
                    string.Equals(c.Name, "ssid", StringComparison.OrdinalIgnoreCase));

                if (ssid == null)
                {
                    Debug.WriteLine(
                        "[frmLogin] No ssid cookie. Available: " +
                        string.Join(", ", cookies.Select(c => c.Name)));
                    return false;
                }

                var expiresUtc = ssid.Expires.Kind == DateTimeKind.Local
                    ? ssid.Expires.ToUniversalTime()
                    : ssid.Expires;

                Debug.WriteLine(
                    $"[frmLogin] ssid expires={ssid.Expires:u} (Kind={ssid.Expires.Kind}, " +
                    $"UTC={expiresUtc:u})");

                var persistent = expiresUtc > DateTime.UtcNow.AddHours(1);
                Debug.WriteLine($"[frmLogin] persistent for silent re-auth: {persistent}");
                return persistent;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[frmLogin] Cookie check failed: {ex.Message}");
                return false;
            }
        }

        private void StartHiddenNavigation()
        {
            if (_browser.CoreWebView2 == null) return;
            _hiddenAttemptActive = true;
            _browser.CoreWebView2.Navigate(WebViewAuthHandler.AuthorizeUrl);
            _ = HiddenAttemptTimeoutAsync();
        }

        private async Task HiddenAttemptTimeoutAsync()
        {
            await Task.Delay(HiddenAttemptTimeout);
            if (!_hiddenAttemptActive || _handlingRedirect) return;
            try
            {
                BeginInvoke(new Action(() =>
                {
                    if (_hiddenAttemptActive && !_handlingRedirect)
                    {
                        Debug.WriteLine("[frmLogin] Hidden attempt timed out; revealing WebView");
                        ShowWebViewForCredentials();
                    }
                }));
            }
            catch (InvalidOperationException) { /* form disposed */ }
        }

        private void ShowLoginForm()
        {
            _hiddenAttemptActive = false;
            _browser.Visible = false;
            ShowInTaskbar = true;
            Visible = true;
            Opacity = 1;
            cmbRegions.Enabled = true;
            btnLogin.Enabled = true;
            btnLogin.Text = "Continue";
        }

        private void ShowWebViewForCredentials()
        {
            _hiddenAttemptActive = false;
            _browser.Visible = true;
            _browser.BringToFront();
            ShowInTaskbar = true;
            Visible = true;
            Opacity = 1;
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e) { }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (cmbRegions.SelectedIndex < 0)
            {
                MessageBox.Show("Select a region before continuing.", "Region required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_browser.CoreWebView2 == null)
            {
                await InitializeBrowserAsync();
                if (_browser.CoreWebView2 == null) return;
            }

            btnLogin.Enabled = false;
            cmbRegions.Enabled = false;
            btnLogin.Text = "Signing in...";
            StartHiddenNavigation();
        }

        private async void Browser_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            var uri = _browser.Source;
            if (uri == null) return;

            if (!_handlingRedirect && WebViewAuthHandler.TryParseRedirect(uri, out var accessToken, out var idToken, out var expiresIn))
            {
                _handlingRedirect = true;
                _hiddenAttemptActive = false;
                try
                {
                    _browser.Visible = false;
                    Opacity = 0;
                    Visible = false;
                    ShowInTaskbar = false;

                    var shard = SelectedRegion();
                    var session = await Auth.CreateFromAccessTokenAsync(accessToken, idToken, shard, expiresIn);
                    RegionStore.Save(shard);
                    Debug.WriteLine($"[frmLogin] Authenticated (region={shard})");
                    Authenticated?.Invoke(this, session);
                    BeginInvoke(new Action(Close));
                }
                catch (Exception ex)
                {
                    _handlingRedirect = false;
                    ShowLoginForm();
                    MessageBox.Show("Riot sign-in completed, but the session could not be created. Please try again.\n\n" + ex.Message,
                        "Sign-in failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            if (!_handlingRedirect
                && !_unexpectedRedirectReported
                && uri.Host.Equals(WebViewAuthHandler.RedirectHost, StringComparison.OrdinalIgnoreCase))
            {
                _unexpectedRedirectReported = true;
                _hiddenAttemptActive = false;
                Debug.WriteLine($"[frmLogin] Unexpected redirect to RedirectHost without token: {uri}");
                ShowLoginForm();
                MessageBox.Show(
                    "Riot's sign-in returned an unexpected response. The login flow may have changed.\n\n" +
                    $"URI: {uri}\n\n" +
                    "If this keeps happening, please report it with the URI above.",
                    "Sign-in flow changed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_hiddenAttemptActive
                && !_handlingRedirect
                && uri.Host.Equals(RiotLoginHost, StringComparison.OrdinalIgnoreCase))
            {
                Debug.WriteLine($"[frmLogin] Riot needs credentials ({uri.Host}); revealing WebView");
                ShowWebViewForCredentials();
            }
        }

        private region SelectedRegion()
        {
            return cmbRegions.SelectedItem?.ToString().Trim() switch
            {
                "North America" => region.NA,
                "Asia Pacific" => region.AP,
                "Korea" => region.KO,
                _ => region.EU
            };
        }

        private void SelectRegionInCombo(region r)
        {
            var target = r switch
            {
                region.NA => "North America",
                region.AP => "Asia Pacific",
                region.KO => "Korea",
                _ => "Europe"
            };
            for (int i = 0; i < cmbRegions.Items.Count; i++)
            {
                if (cmbRegions.Items[i]?.ToString().Trim() == target)
                {
                    cmbRegions.SelectedIndex = i;
                    return;
                }
            }
        }
    }
}