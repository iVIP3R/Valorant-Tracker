using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valorant_Tracker
{
    public partial class frmMain : MetroSet_UI.Forms.MetroSetForm
    {
        private readonly Auth _session;

        public frmMain(Auth session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                var accountTask = Task.Run(() => PlayerAccountDetails.GetDetails(_session));
                var balanceTask = Task.Run(() => Balances.GetBalance(_session));
                var xpTask = Task.Run(() => AccountXP.GetDetails(_session));
                await Task.WhenAll(accountTask, balanceTask, xpTask);

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

                var imageTasks = Enumerable.Range(0, 4)
                    .Select(i =>
                    {
                        var url = store.FormattedSkinsPanelLayout[i, 1];
                        return string.IsNullOrWhiteSpace(url)
                            ? Task.FromResult<byte[]>(null)
                            : api.GetBytesAsync(url);
                    })
                    .ToArray();

                var bytes = await Task.WhenAll(imageTasks);

                SetBackground(pbWeapon1, bytes[0]);
                SetBackground(pbWeapon2, bytes[1]);
                SetBackground(pbWeapon3, bytes[2]);
                SetBackground(pbWeapon4, bytes[3]);

                lblWeaponName1.Text = store.FormattedSkinsPanelLayout[0, 0] ?? "";
                lblWeaponName2.Text = store.FormattedSkinsPanelLayout[1, 0] ?? "";
                lblWeaponName3.Text = store.FormattedSkinsPanelLayout[2, 0] ?? "";
                lblWeaponName4.Text = store.FormattedSkinsPanelLayout[3, 0] ?? "";
                lblTimeRemaining.Text = "Offers | " + store.SkinsPanelLayout.FormattedSingleItemOffersRemainingDuration;
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
            string SeasonID = "N/A";
            switch (cmbAct.SelectedIndex)
            {
                case 0:
                    SeasonID = Seasons.ClosedBeta;
                    break;
                case 1:
                    SeasonID = Seasons.Episode1_Act1;
                    break;
                case 2:
                    SeasonID = Seasons.Episode1_Act2;
                    break;
                case 3:
                    SeasonID = Seasons.Episode1_Act3;
                    break;
                case 4:
                    SeasonID = Seasons.Episode2_Act1;
                    break;
                case 5:
                    SeasonID = Seasons.Episode2_Act2;
                    break;
                case 6:
                    SeasonID = Seasons.Episode2_Act3;
                    break;
                case 7:
                    SeasonID = Seasons.Episode3_Act1;
                    break;
                case 8:
                    SeasonID = Seasons.Episode3_Act2;
                    break;
                case 9:
                    SeasonID = Seasons.Episode26_Act5;
                    break;
            }
            Rank r = await Task.Run(() => Rank.GetDetails(_session, "competitive", SeasonID));
            switch (r.RankFormatted)
            {
                case "Unranked":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Unranked;
                    break;
                case "Bronze 1":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Bronze_1;
                    break;
                case "Bronze 2":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Bronze_2;
                    break;
                case "Bronze 3":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Bronze_3;
                    break;
                case "Silver 1":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Silver_1;
                    break;
                case "Silver 2":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Silver_2;
                    break;
                case "Silver 3":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Silver_3;
                    break;
                case "Gold 1":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Gold_1;
                    break;
                case "Gold 2":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Gold_2;
                    break;
                case "Gold 3":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Gold_3;
                    break;
                case "Platinum 1":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Platinum_1;
                    break;
                case "Platinum 2":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Platinum_2;
                    break;
                case "Platinum 3":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Platinum_3;
                    break;
                case "Diamond 1":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Diamond_1;
                    break;
                case "Diamond 2":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Diamond_2;
                    break;
                case "Diamond 3":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Diamond_3;
                    break;
                case "Immortal 1":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Immortal_1;
                    break;
                case "Immortal 2":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Immortal_2;
                    break;
                case "Immortal 3":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Immortal_3;
                    break;
                case "Radiant":
                    pbRank.Image = Valorant_Tracker.Properties.Resources.Radiant;
                    break;
            }
            lblRank.Text = r.RankFormatted;
            lblRankedRating.Text = r.RankedRating.ToString() + " RR";
            lblWinsAndLosses.Text = r.NumberOfWins.ToString() + "W " + r.NumberOfLoses + "L  " + r.WinRatio;
        }

        private async void cmbGamemode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gameMode = "N/A";
            switch (cmbGamemode.SelectedIndex)
            {
                case 0:
                    gameMode = GameMode.Unrated;
                    break;
                case 1:
                    gameMode = GameMode.Competitive;
                    break;
                case 2:
                    gameMode = GameMode.Spike_Rush;
                    break;
                case 3:
                    gameMode = GameMode.Deathmatch;
                    break;
                case 4:
                    gameMode = GameMode.Replication;
                    break;
                case 5:
                    gameMode = GameMode.Snowball_Fight;
                    break;
                case 6:
                    gameMode = GameMode.Custom;
                    break;
            }

            dgvHistory.Rows.Clear();
            MatchHistory mo = await Task.Run(() => MatchHistory.Get(_session, gameMode));

            switch (mo.Total)
            {
                case 0:
                    break;
                case 1:
                    lblLastNaNMatches.Text = "Lastest match :";
                    break;
                default:
                    lblLastNaNMatches.Text = $"Last {mo.Total} matches :";
                    break;
            }

            MatchHistory m = await Task.Run(() => MatchHistory.RetrieveIDs(_session, mo.Total, gameMode));
            
            for (int i = 0; i < m.IDs.Count; i++)
            {
                MatchDetails md = await Task.Run(() => MatchDetails.Get(_session, m.IDs[i]));
                string[] Row = { m.IDs[i], md.Details[0].Server, md.Details[0].MatchLength, md.Details[0].MatchStartTime.ToString(), md.Details[0].Map, md.Details[0].Agent, md.Details[0].Score, md.Details[0].KDA, md.Details[0].KD, md.Details[0].HS, md.Details[0].ADR, md.Details[0].AverageCombatScore, md.Details[0].FirstBloods.ToString(), md.Details[0].Plants.ToString(), md.Details[0].Defuses.ToString() };
                dgvHistory.Rows.Add(Row);
            }
        }

        frmMatchDetails frmMatchDetails;

        private void dgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            frmMatchDetails ??= new frmMatchDetails(_session);
            frmMatchDetails.Hide();
            frmMatchDetails.loadDetails(dgvHistory[0, dgvHistory.CurrentRow.Index].Value.ToString());
            frmMatchDetails.Show();
        }
    }
}
