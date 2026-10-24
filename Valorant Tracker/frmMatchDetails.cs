using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Valorant_Tracker
{
    public partial class frmMatchDetails : MetroSet_UI.Forms.MetroSetForm
    {
        private readonly Auth _session;

        public frmMatchDetails(Auth session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            InitializeComponent();
        }

        // Changed signature to accept the already-loaded object
        internal void loadDetails(MatchDetails matchDetails)
        {
            dgvTeams.Rows.Clear();
            if (matchDetails == null || matchDetails.MatchOverview == null) return;

            string userTeam = matchDetails.MatchOverview
                .FirstOrDefault(x => x.IDs == _session.Subject)?.Team ?? "Blue";

            foreach (var item in matchDetails.MatchOverview)
            {
                string[] Row = {
                    item.IDs,
                    item.Agents,
                    item.Names,
                    item.AverageCombatScores.ToString(),
                    item.KDAs,
                    item.KDs.ToString(),
                    item.isPositive.ToString(),
                    item.ADRs.ToString(),
                    item.HSs,
                    item.FirstBloods.ToString(),
                    item.Plants.ToString(),
                    item.Defuses.ToString()
                };

                int rowIndex = dgvTeams.Rows.Add(Row);

                if (item.Team == userTeam)
                {
                    dgvTeams.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(25, 45, 45);
                    dgvTeams.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 65, 65);
                }
                else
                {
                    dgvTeams.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(50, 25, 25);
                    dgvTeams.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 35, 35);
                }
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