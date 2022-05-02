using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    public partial class frmMain : MetroSet_UI.Forms.MetroSetForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PlayerAccountDetails P = PlayerAccountDetails.GetDetails(frmLogin.au);
            Balances B = Balances.GetBalance(frmLogin.au);
            AccountXP A = AccountXP.GetDetails(frmLogin.au);
            lblGameName.Text = "Game name : " + P.GameName;
            lblTagline.Text = "Tagline : " + P.TagLine;
            lblRegion.Text = "Region : " + P.AccountRegion;
            lblLevel.Text = "Level : " + A.Progress.Level.ToString();
            lblValorantPoints.Text = "Valorant points : " + B.ValorantPoints.ToString();
            lblRadianitePoints.Text = "Radianite points : " + B.RadianitePoints.ToString();
            lblCreatedAt.Text = "Created at : " + P.CreatedAt.ToString();

            Store s = Store.GetOffers(frmLogin.au);
            WebClient wc = new WebClient();
            byte[] bytes1 = wc.DownloadData(s.FormattedSkinsPanelLayout[0, 1]);
            byte[] bytes2 = wc.DownloadData(s.FormattedSkinsPanelLayout[1, 1]);
            byte[] bytes3 = wc.DownloadData(s.FormattedSkinsPanelLayout[2, 1]);
            byte[] bytes4 = wc.DownloadData(s.FormattedSkinsPanelLayout[3, 1]);
            MemoryStream ms1 = new MemoryStream(bytes1);
            MemoryStream ms2 = new MemoryStream(bytes2);
            MemoryStream ms3 = new MemoryStream(bytes3);
            MemoryStream ms4 = new MemoryStream(bytes4);
            System.Drawing.Image img1 = System.Drawing.Image.FromStream(ms1);
            System.Drawing.Image img2 = System.Drawing.Image.FromStream(ms2);
            System.Drawing.Image img3 = System.Drawing.Image.FromStream(ms3);
            System.Drawing.Image img4 = System.Drawing.Image.FromStream(ms4);
            pbWeapon1.BackgroundImage = img1;
            pbWeapon2.BackgroundImage = img2;
            pbWeapon3.BackgroundImage = img3;
            pbWeapon4.BackgroundImage = img4;
            lblWeaponName1.Text = s.FormattedSkinsPanelLayout[0, 0];
            lblWeaponName2.Text = s.FormattedSkinsPanelLayout[1, 0];
            lblWeaponName3.Text = s.FormattedSkinsPanelLayout[2, 0];
            lblWeaponName4.Text = s.FormattedSkinsPanelLayout[3, 0];
            //lblWeaponPrice1.Text = s.FormattedSkinsPanelLayout[0, 3] + " VP";
            //lblWeaponPrice2.Text = s.FormattedSkinsPanelLayout[1, 3] + " VP";
            //lblWeaponPrice3.Text = s.FormattedSkinsPanelLayout[2, 3] + " VP";
            //lblWeaponPrice4.Text = s.FormattedSkinsPanelLayout[3, 3] + " VP";
            lblTimeRemaining.Text = "Offers | " + s.SkinsPanelLayout.FormattedSingleItemOffersRemainingDuration;
        }

        private void cmbAct_SelectedIndexChanged(object sender, EventArgs e)
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
            }
            Rank r = Rank.GetDetails(frmLogin.au, "competitive", SeasonID);
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

        private void cmbGamemode_SelectedIndexChanged(object sender, EventArgs e)
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

            MatchHistory mo = MatchHistory.Get(frmLogin.au, gameMode);

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

            MatchHistory m = MatchHistory.RetrieveIDs(frmLogin.au, mo.Total, gameMode);
            
            for (int i = 0; i < m.IDs.Count; i++)
            {
                MatchDetails md = MatchDetails.Get(frmLogin.au, m.IDs[i]);
                string[] Row = { m.IDs[i], md.Details[0].Server, md.Details[0].MatchLength, md.Details[0].MatchStartTime.ToString(), md.Details[0].Map, md.Details[0].Agent, md.Details[0].Score, md.Details[0].KDA, md.Details[0].KD, md.Details[0].HS, md.Details[0].ADR, md.Details[0].AverageCombatScore, md.Details[0].FirstBloods.ToString(), md.Details[0].Plants.ToString(), md.Details[0].Defuses.ToString() };
                dgvHistory.Rows.Add(Row);
            }
        }

        frmMatchDetails frmMatchDetails = new frmMatchDetails();

        private void dgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            frmMatchDetails.Hide();
            frmMatchDetails.loadDetails(dgvHistory[0, dgvHistory.CurrentRow.Index].Value.ToString());
            frmMatchDetails.Show();
        }
    }
}
