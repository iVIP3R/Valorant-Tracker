using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Valorant_Tracker.Services;
using Valorant_Tracker.Utils;
using Valorant_Tracker.Data;

namespace Valorant_Tracker.Forms
{
    public partial class frmMain : MetroSet_UI.Forms.MetroSetForm
    {
        private readonly Auth _session;
        private List<ValorantSeason> _acts;
        private bool _populatingActs;
        private Dictionary<string, MatchDetails> _matchDetailsCache = new Dictionary<string, MatchDetails>();

        private static readonly Dictionary<string, Image> RankImages = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase)
        {
            { "Unranked", Valorant_Tracker.Properties.Resources.Unranked },
            { "Bronze 1", Valorant_Tracker.Properties.Resources.Bronze_1 },
            { "Bronze 2", Valorant_Tracker.Properties.Resources.Bronze_2 },
            { "Bronze 3", Valorant_Tracker.Properties.Resources.Bronze_3 },
            { "Silver 1", Valorant_Tracker.Properties.Resources.Silver_1 },
            { "Silver 2", Valorant_Tracker.Properties.Resources.Silver_2 },
            { "Silver 3", Valorant_Tracker.Properties.Resources.Silver_3 },
            { "Gold 1", Valorant_Tracker.Properties.Resources.Gold_1 },
            { "Gold 2", Valorant_Tracker.Properties.Resources.Gold_2 },
            { "Gold 3", Valorant_Tracker.Properties.Resources.Gold_3 },
            { "Platinum 1", Valorant_Tracker.Properties.Resources.Platinum_1 },
            { "Platinum 2", Valorant_Tracker.Properties.Resources.Platinum_2 },
            { "Platinum 3", Valorant_Tracker.Properties.Resources.Platinum_3 },
            { "Diamond 1", Valorant_Tracker.Properties.Resources.Diamond_1 },
            { "Diamond 2", Valorant_Tracker.Properties.Resources.Diamond_2 },
            { "Diamond 3", Valorant_Tracker.Properties.Resources.Diamond_3 },
            { "Immortal 1", Valorant_Tracker.Properties.Resources.Immortal_1 },
            { "Immortal 2", Valorant_Tracker.Properties.Resources.Immortal_2 },
            { "Immortal 3", Valorant_Tracker.Properties.Resources.Immortal_3 },
            { "Radiant", Valorant_Tracker.Properties.Resources.Radiant }
        };

        public frmMain(Auth session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                var accountTask = PlayerAccountDetails.GetDetailsAsync(_session);
                var balanceTask = Balances.GetBalanceAsync(_session);
                var xpTask = AccountXP.GetDetailsAsync(_session);
                var actsTask = ValorantDataService.GetActsAsync();
                var currentActTask = ValorantDataService.GetCurrentActAsync();
                await Task.WhenAll(accountTask, balanceTask, xpTask, actsTask, currentActTask);

                var P = await accountTask;
                var B = await balanceTask;
                var A = await xpTask;
                lblGameName.Text = "Game name : " + P.GameName;
                lblTagline.Text = "Tagline : " + P.TagLine;
                lblRegion.Text = "Region : " + P.AccountRegion;
                lblLevel.Text = "Level : " + A.Progress.Level;
                lblValorantPoints.Text = "Valorant points : " + B.ValorantPoints;
                lblRadianitePoints.Text = "Radianite points : " + B.RadianitePoints;
                lblCreatedAt.Text = "Created at : " + P.CreatedAt;

                var store = await Task.Run(() => Store.GetOffers(_session));
                using var api = new ValorantApiClient(_session.ToRiotSession());

                int offerCount = store.FormattedSkinsPanelLayout.GetLength(0);
                var imageTasks = Enumerable.Range(0, offerCount)
                    .Select(i =>
                    {
                        var url = store.FormattedSkinsPanelLayout[i, 1];
                        return string.IsNullOrWhiteSpace(url)
                            ? Task.FromResult<byte[]>(null)
                            : api.GetBytesAsync(url);
                    })
                    .ToArray();

                var bytes = await Task.WhenAll(imageTasks);

                if (bytes.Length > 0) SetBackground(pbWeapon1, bytes[0]);
                if (bytes.Length > 1) SetBackground(pbWeapon2, bytes[1]);
                if (bytes.Length > 2) SetBackground(pbWeapon3, bytes[2]);
                if (bytes.Length > 3) SetBackground(pbWeapon4, bytes[3]);

                if (offerCount > 0) lblWeaponName1.Text = store.FormattedSkinsPanelLayout[0, 0] ?? "";
                if (offerCount > 1) lblWeaponName2.Text = store.FormattedSkinsPanelLayout[1, 0] ?? "";
                if (offerCount > 2) lblWeaponName3.Text = store.FormattedSkinsPanelLayout[2, 0] ?? "";
                if (offerCount > 3) lblWeaponName4.Text = store.FormattedSkinsPanelLayout[3, 0] ?? "";

                lblTimeRemaining.Text = "Offers | " + store.SkinsPanelLayout.FormattedSingleItemOffersRemainingDuration;

                _acts = new List<ValorantSeason>(await actsTask);
                var currentAct = await currentActTask;

                _populatingActs = true;
                try
                {
                    cmbAct.Items.Clear();
                    foreach (var act in _acts) cmbAct.Items.Add(act);
                    cmbAct.Refresh();

                    int idx = currentAct == null
                        ? _acts.Count - 1
                        : _acts.FindIndex(a => a.Uuid == currentAct.Uuid);
                    if (idx < 0) idx = _acts.Count - 1;
                    if (idx >= 0) cmbAct.SelectedIndex = idx;
                }
                finally
                {
                    _populatingActs = false;
                }

                if (cmbAct.SelectedIndex >= 0)
                    await LoadRankForSelectedActAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load account data. " + ex.Message, "Load failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void SetBackground(PictureBox pb, byte[] bytes)
        {
            pb.BackgroundImage = null;
            if (bytes == null || bytes.Length == 0) return;
            try { pb.BackgroundImage = ToImage(bytes); }
            catch (Exception ex) { Debug.WriteLine($"[frmMain] ToImage failed: {ex.Message}"); }
        }

        private static Image ToImage(byte[] bytes)
        {
            using var stream = new MemoryStream(bytes);
            using var image = Image.FromStream(stream);
            return new Bitmap(image);
        }

        private async void cmbAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_populatingActs) return;
            await LoadRankForSelectedActAsync();
        }

        private async Task LoadRankForSelectedActAsync()
        {
            if (_acts == null || _acts.Count == 0) return;
            if (cmbAct.SelectedIndex < 0 || cmbAct.SelectedIndex >= _acts.Count) return;

            var seasonId = _acts[cmbAct.SelectedIndex].Uuid;
            if (string.IsNullOrEmpty(seasonId)) return;

            try
            {
                Rank r = await Task.Run(() => Rank.GetDetails(_session, "competitive", seasonId));

                if (!string.IsNullOrEmpty(r.RankFormatted) && RankImages.TryGetValue(r.RankFormatted, out var rankImage))
                {
                    pbRank.Image = rankImage;
                }
                else
                {
                    pbRank.Image = RankImages["Unranked"];
                }

                lblRank.Text = r.RankFormatted;
                lblRankedRating.Text = r.RankedRating.ToString() + " RR";
                lblWinsAndLosses.Text = r.NumberOfWins.ToString() + "W " + r.NumberOfLoses + "L  " + r.WinRatio;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[frmMain] Rank load failed for season {seasonId}: {ex.Message}");
            }
        }

        private async void cmbGamemode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gameMode = "N/A";
            switch (cmbGamemode.SelectedIndex)
            {
                case 0: gameMode = GameMode.Unrated; break;
                case 1: gameMode = GameMode.Competitive; break;
                case 2: gameMode = GameMode.Spike_Rush; break;
                case 3: gameMode = GameMode.Deathmatch; break;
                case 4: gameMode = GameMode.Replication; break;
                case 5: gameMode = GameMode.Snowball_Fight; break;
                case 6: gameMode = GameMode.Escalation; break;
                case 7: gameMode = GameMode.Custom; break;
            }

            try
            {
                dgvHistory.Rows.Clear();
                _matchDetailsCache.Clear();
                lblLastNaNMatches.Text = "Loading matches...";

                MatchHistory mo = await Task.Run(() => MatchHistory.Get(_session, gameMode));

                if (mo.Total == 0)
                {
                    lblLastNaNMatches.Text = "No matches found.";
                    return;
                }

                lblLastNaNMatches.Text = $"Last {mo.Total} matches :";

                MatchHistory m = await Task.Run(() => MatchHistory.RetrieveIDs(_session, mo.Total, gameMode));

                foreach (var match in m.Histories)
                {
                    string startTime = "";
                    if (match.GameStartTime != null)
                    {
                        long unixMs = Convert.ToInt64(match.GameStartTime);
                        startTime = DateTimeOffset.FromUnixTimeMilliseconds(unixMs).LocalDateTime.ToString("g");
                    }

                    string[] Row = { match.MatchID, "Loading...", "Loading...", startTime, "Loading...", "Loading...", "Loading...", "Loading...", "Loading...", "Loading...", "Loading...", "Loading...", "Loading...", "Loading...", "Loading..." };
                    dgvHistory.Rows.Add(Row);
                }

                foreach (var match in m.Histories)
                {
                    if (_matchDetailsCache.TryGetValue(match.MatchID, out var cachedMd))
                    {
                        UpdateGridRow(match.MatchID, cachedMd);
                        continue;
                    }

                    MatchDetails md = await Task.Run(() => MatchDetails.Get(_session, match.MatchID));

                    if (md?.Details != null && md.Details.Count > 0)
                    {
                        _matchDetailsCache[match.MatchID] = md;
                        UpdateGridRow(match.MatchID, md);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load match history. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGridRow(string matchId, MatchDetails md)
        {
            if (md?.Details == null || md.Details.Count == 0) return;
            var d = md.Details[0];

            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                if (row.Cells[0].Value?.ToString() == matchId)
                {
                    row.Cells[1].Value = d.Server;
                    row.Cells[2].Value = d.MatchLength;
                    row.Cells[4].Value = d.Map;
                    row.Cells[5].Value = d.Agent;
                    row.Cells[6].Value = d.Score;
                    row.Cells[7].Value = d.KDA;
                    row.Cells[8].Value = d.KD;
                    row.Cells[9].Value = d.HS;
                    row.Cells[10].Value = d.ADR;
                    row.Cells[11].Value = d.AverageCombatScore;
                    row.Cells[12].Value = d.FirstBloods.ToString();
                    row.Cells[13].Value = d.Plants.ToString();
                    row.Cells[14].Value = d.Defuses.ToString();
                    break;
                }
            }
        }

        frmMatchDetails frmMatchDetails;

        private async void dgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.CurrentRow == null) return;
            string matchId = dgvHistory[0, dgvHistory.CurrentRow.Index].Value?.ToString();
            if (string.IsNullOrEmpty(matchId)) return;

            if (!_matchDetailsCache.TryGetValue(matchId, out var md))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    md = await Task.Run(() => MatchDetails.Get(_session, matchId));
                    _matchDetailsCache[matchId] = md;

                    UpdateGridRow(matchId, md);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load match details. " + ex.Message);
                    return;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            frmMatchDetails ??= new frmMatchDetails(_session);
            frmMatchDetails.Hide();
            frmMatchDetails.loadDetails(md);
            frmMatchDetails.Show();
        }
    }
}