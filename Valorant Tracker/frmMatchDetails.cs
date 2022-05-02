using System;
using System.Windows.Forms;

namespace Valorant_Tracker
{
    public partial class frmMatchDetails : MetroSet_UI.Forms.MetroSetForm
    {
        public string MatchID = "N/A";
        public frmMatchDetails()
        {
            InitializeComponent();
        }

        public void loadDetails(string MatchID)
        {
            dgvTeams.Rows.Clear();
            dgvTeams.Refresh();
            MatchDetails matchDetails = MatchDetails.Get(frmLogin.au, MatchID);
            foreach (var item in matchDetails.MatchOverview)
            {
                string[] Row = { item.IDs, item.Agents, item.Names, item.AverageCombatScores.ToString(), item.KDAs, item.KDs.ToString(), item.isPositive.ToString(), item.ADRs.ToString(), item.HSs, item.FirstBloods.ToString(), item.Plants.ToString(), item.Defuses.ToString() };
                dgvTeams.Rows.Add(Row);
            }
        }

        private void frmMatchDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
    }
}
