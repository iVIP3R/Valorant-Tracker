using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace Valorant_Tracker
{
    public partial class frmLogin : Form
    {
        private readonly WebView2 _browser = new WebView2 { Dock = DockStyle.Fill, Visible = false };
        private bool _handlingRedirect;

        public frmLogin()
        {
            InitializeComponent();
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
            await InitializeBrowserAsync();
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

            cmbRegions.Enabled = false;
            btnLogin.Enabled = false;
            _browser.Visible = true;
            _browser.BringToFront();
            _browser.CoreWebView2.Navigate(WebViewAuthHandler.AuthorizeUrl);
        }

        private async void Browser_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            if (_handlingRedirect || !WebViewAuthHandler.TryParseRedirect(_browser.Source, out var accessToken, out var idToken, out var expiresIn)) return;
            _handlingRedirect = true;
            try
            {
                _browser.Visible = false;
                var session = await Auth.CreateFromAccessTokenAsync(accessToken, idToken, SelectedRegion(), expiresIn);
                var main = new frmMain(session);
                main.FormClosed += (_, __) => Close();
                Hide();
                main.Show();
            }
            catch (Exception ex)
            {
                _handlingRedirect = false;
                _browser.Visible = true;
                btnLogin.Enabled = true;
                cmbRegions.Enabled = true;
                MessageBox.Show("Riot sign-in completed, but the session could not be created. Please try again.\n\n" + ex.Message,
                    "Sign-in failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}