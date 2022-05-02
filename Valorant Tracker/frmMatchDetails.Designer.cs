namespace Valorant_Tracker
{
    partial class frmMatchDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTeams = new System.Windows.Forms.DataGridView();
            this.cbMain = new MetroSet_UI.Controls.MetroSetControlBox();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvgCombatScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPositive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colADR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstBloods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlants = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefuses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeams
            // 
            this.dgvTeams.AllowUserToAddRows = false;
            this.dgvTeams.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.dgvTeams.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTeams.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(41)))));
            this.dgvTeams.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvTeams.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colAgent,
            this.colName,
            this.colAvgCombatScore,
            this.colKDA,
            this.colKD,
            this.colPositive,
            this.colADR,
            this.colHS,
            this.colFirstBloods,
            this.colPlants,
            this.colDefuses});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTeams.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTeams.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTeams.EnableHeadersVisualStyles = false;
            this.dgvTeams.Location = new System.Drawing.Point(14, 100);
            this.dgvTeams.MultiSelect = false;
            this.dgvTeams.Name = "dgvTeams";
            this.dgvTeams.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeams.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTeams.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.dgvTeams.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTeams.RowTemplate.Height = 25;
            this.dgvTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeams.Size = new System.Drawing.Size(555, 385);
            this.dgvTeams.TabIndex = 17;
            // 
            // cbMain
            // 
            this.cbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMain.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbMain.CloseHoverForeColor = System.Drawing.Color.White;
            this.cbMain.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.cbMain.DisabledForeColor = System.Drawing.Color.DimGray;
            this.cbMain.IsDerivedStyle = true;
            this.cbMain.Location = new System.Drawing.Point(481, 3);
            this.cbMain.MaximizeBox = true;
            this.cbMain.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbMain.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this.cbMain.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this.cbMain.MinimizeBox = true;
            this.cbMain.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbMain.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this.cbMain.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this.cbMain.Name = "cbMain";
            this.cbMain.Size = new System.Drawing.Size(100, 25);
            this.cbMain.Style = MetroSet_UI.Enums.Style.Light;
            this.cbMain.StyleManager = null;
            this.cbMain.TabIndex = 18;
            this.cbMain.Text = "metroSetControlBox1";
            this.cbMain.ThemeAuthor = "Narwin";
            this.cbMain.ThemeName = "MetroLite";
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colAgent
            // 
            this.colAgent.HeaderText = "Agent";
            this.colAgent.Name = "colAgent";
            this.colAgent.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colAvgCombatScore
            // 
            this.colAvgCombatScore.HeaderText = "Avg combat score";
            this.colAvgCombatScore.Name = "colAvgCombatScore";
            this.colAvgCombatScore.ReadOnly = true;
            // 
            // colKDA
            // 
            this.colKDA.HeaderText = "KDA";
            this.colKDA.Name = "colKDA";
            this.colKDA.ReadOnly = true;
            // 
            // colKD
            // 
            this.colKD.HeaderText = "KD";
            this.colKD.Name = "colKD";
            this.colKD.ReadOnly = true;
            // 
            // colPositive
            // 
            this.colPositive.HeaderText = "+/-";
            this.colPositive.Name = "colPositive";
            this.colPositive.ReadOnly = true;
            // 
            // colADR
            // 
            this.colADR.HeaderText = "ADR";
            this.colADR.Name = "colADR";
            this.colADR.ReadOnly = true;
            // 
            // colHS
            // 
            this.colHS.HeaderText = "HS%";
            this.colHS.Name = "colHS";
            this.colHS.ReadOnly = true;
            // 
            // colFirstBloods
            // 
            this.colFirstBloods.HeaderText = "First bloods";
            this.colFirstBloods.Name = "colFirstBloods";
            this.colFirstBloods.ReadOnly = true;
            // 
            // colPlants
            // 
            this.colPlants.HeaderText = "Plants";
            this.colPlants.Name = "colPlants";
            this.colPlants.ReadOnly = true;
            // 
            // colDefuses
            // 
            this.colDefuses.HeaderText = "Defuses";
            this.colDefuses.Name = "colDefuses";
            this.colDefuses.ReadOnly = true;
            // 
            // frmMatchDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(584, 500);
            this.Controls.Add(this.cbMain);
            this.Controls.Add(this.dgvTeams);
            this.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMatchDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style = MetroSet_UI.Enums.Style.Dark;
            this.Text = "Details";
            this.TextColor = System.Drawing.Color.White;
            this.ThemeName = "MetroDark";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMatchDetails_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTeams;
        private MetroSet_UI.Controls.MetroSetControlBox cbMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvgCombatScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPositive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colADR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstBloods;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlants;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefuses;
    }
}