namespace Valorant_Tracker
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            cbMain = new MetroSet_UI.Controls.MetroSetControlBox();
            tpCompetitive = new System.Windows.Forms.TabPage();
            lblLastNaNMatches = new System.Windows.Forms.Label();
            cmbGamemode = new MetroSet_UI.Controls.MetroSetComboBox();
            dgvHistory = new System.Windows.Forms.DataGridView();
            colMatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMatchLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMatchStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colKDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colKD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colADR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAvgScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFirstBloods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPlants = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDefuses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cmbAct = new MetroSet_UI.Controls.MetroSetComboBox();
            lblWinsAndLosses = new System.Windows.Forms.Label();
            lblRankedRating = new System.Windows.Forms.Label();
            lblRank = new System.Windows.Forms.Label();
            pbRank = new System.Windows.Forms.PictureBox();
            tpPlayerStore = new System.Windows.Forms.TabPage();
            lblTimeRemaining = new System.Windows.Forms.Label();
            lblWeaponPrice4 = new System.Windows.Forms.Label();
            lblWeaponPrice3 = new System.Windows.Forms.Label();
            lblWeaponPrice2 = new System.Windows.Forms.Label();
            lblWeaponPrice1 = new System.Windows.Forms.Label();
            lblWeaponName4 = new System.Windows.Forms.Label();
            lblWeaponName3 = new System.Windows.Forms.Label();
            lblWeaponName2 = new System.Windows.Forms.Label();
            lblWeaponName1 = new System.Windows.Forms.Label();
            pbWeapon1 = new System.Windows.Forms.PictureBox();
            pbWeapon2 = new System.Windows.Forms.PictureBox();
            pbWeapon3 = new System.Windows.Forms.PictureBox();
            pbWeapon4 = new System.Windows.Forms.PictureBox();
            tpAccountInformation = new System.Windows.Forms.TabPage();
            lblCreatedAt = new System.Windows.Forms.Label();
            lblTagline = new System.Windows.Forms.Label();
            lblRadianitePoints = new System.Windows.Forms.Label();
            lblValorantPoints = new System.Windows.Forms.Label();
            lblLevel = new System.Windows.Forms.Label();
            lblRegion = new System.Windows.Forms.Label();
            lblGameName = new System.Windows.Forms.Label();
            tcMain = new MetroSet_UI.Controls.MetroSetTabControl();
            tpCompetitive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbRank).BeginInit();
            tpPlayerStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbWeapon1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWeapon2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWeapon3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWeapon4).BeginInit();
            tpAccountInformation.SuspendLayout();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // cbMain
            // 
            cbMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbMain.CloseHoverBackColor = System.Drawing.Color.FromArgb(183, 40, 40);
            cbMain.CloseHoverForeColor = System.Drawing.Color.White;
            cbMain.CloseNormalForeColor = System.Drawing.Color.Gray;
            cbMain.DisabledForeColor = System.Drawing.Color.DimGray;
            cbMain.IsDerivedStyle = true;
            cbMain.Location = new System.Drawing.Point(709, 0);
            cbMain.MaximizeBox = true;
            cbMain.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            cbMain.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            cbMain.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            cbMain.MinimizeBox = true;
            cbMain.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            cbMain.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            cbMain.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            cbMain.Name = "cbMain";
            cbMain.Size = new System.Drawing.Size(100, 25);
            cbMain.Style = MetroSet_UI.Enums.Style.Light;
            cbMain.StyleManager = null;
            cbMain.TabIndex = 14;
            cbMain.Text = "metroSetControlBox1";
            cbMain.ThemeAuthor = "Narwin";
            cbMain.ThemeName = "MetroLite";
            // 
            // tpCompetitive
            // 
            tpCompetitive.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            tpCompetitive.Controls.Add(lblLastNaNMatches);
            tpCompetitive.Controls.Add(cmbGamemode);
            tpCompetitive.Controls.Add(dgvHistory);
            tpCompetitive.Controls.Add(cmbAct);
            tpCompetitive.Controls.Add(lblWinsAndLosses);
            tpCompetitive.Controls.Add(lblRankedRating);
            tpCompetitive.Controls.Add(lblRank);
            tpCompetitive.Controls.Add(pbRank);
            tpCompetitive.Location = new System.Drawing.Point(4, 42);
            tpCompetitive.Name = "tpCompetitive";
            tpCompetitive.Size = new System.Drawing.Size(771, 314);
            tpCompetitive.TabIndex = 1;
            tpCompetitive.Text = "Competitive";
            // 
            // lblLastNaNMatches
            // 
            lblLastNaNMatches.AutoSize = true;
            lblLastNaNMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblLastNaNMatches.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblLastNaNMatches.Location = new System.Drawing.Point(266, 10);
            lblLastNaNMatches.Name = "lblLastNaNMatches";
            lblLastNaNMatches.Size = new System.Drawing.Size(0, 18);
            lblLastNaNMatches.TabIndex = 22;
            // 
            // cmbGamemode
            // 
            cmbGamemode.AllowDrop = true;
            cmbGamemode.ArrowColor = System.Drawing.Color.FromArgb(110, 110, 110);
            cmbGamemode.BackColor = System.Drawing.Color.Transparent;
            cmbGamemode.BackgroundColor = System.Drawing.Color.FromArgb(34, 34, 34);
            cmbGamemode.BorderColor = System.Drawing.Color.FromArgb(110, 110, 110);
            cmbGamemode.CausesValidation = false;
            cmbGamemode.DisabledBackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            cmbGamemode.DisabledBorderColor = System.Drawing.Color.FromArgb(109, 109, 109);
            cmbGamemode.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
            cmbGamemode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            cmbGamemode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbGamemode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            cmbGamemode.FormattingEnabled = true;
            cmbGamemode.IsDerivedStyle = true;
            cmbGamemode.ItemHeight = 20;
            cmbGamemode.Items.AddRange(new object[] { "Unrated", "Competitive", "Spike rush", "Deathmatch", "Replication", "Snowball fight", "Custom" });
            cmbGamemode.Location = new System.Drawing.Point(3, 60);
            cmbGamemode.Name = "cmbGamemode";
            cmbGamemode.SelectedItemBackColor = System.Drawing.Color.FromArgb(65, 177, 225);
            cmbGamemode.SelectedItemForeColor = System.Drawing.Color.White;
            cmbGamemode.Size = new System.Drawing.Size(100, 26);
            cmbGamemode.Style = MetroSet_UI.Enums.Style.Dark;
            cmbGamemode.StyleManager = null;
            cmbGamemode.TabIndex = 21;
            cmbGamemode.ThemeAuthor = "Narwin";
            cmbGamemode.ThemeName = "MetroDark";
            cmbGamemode.SelectedIndexChanged += cmbGamemode_SelectedIndexChanged;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(44, 47, 52);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(235, 236, 241);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(235, 236, 241);
            dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(33, 36, 41);
            dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dgvHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(15, 16, 18);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(235, 236, 241);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(235, 236, 241);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colMatchID, colServer, colMatchLength, colMatchStartTime, colMap, colAgent, colScore, colKDA, colKD, colHS, colADR, colAvgScore, colFirstBloods, colPlants, colDefuses });
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(33, 36, 43);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(235, 236, 241);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.Location = new System.Drawing.Point(266, 45);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(15, 16, 18);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(235, 236, 241);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(235, 236, 241);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvHistory.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(33, 36, 43);
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(235, 236, 241);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(235, 236, 241);
            dgvHistory.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new System.Drawing.Size(485, 275);
            dgvHistory.TabIndex = 16;
            dgvHistory.SelectionChanged += dgvHistory_SelectionChanged;
            // 
            // colMatchID
            // 
            colMatchID.HeaderText = "Match ID";
            colMatchID.Name = "colMatchID";
            colMatchID.ReadOnly = true;
            colMatchID.Visible = false;
            // 
            // colServer
            // 
            colServer.HeaderText = "Server";
            colServer.Name = "colServer";
            colServer.ReadOnly = true;
            // 
            // colMatchLength
            // 
            colMatchLength.HeaderText = "Match length";
            colMatchLength.Name = "colMatchLength";
            colMatchLength.ReadOnly = true;
            // 
            // colMatchStartTime
            // 
            colMatchStartTime.HeaderText = "Match start time";
            colMatchStartTime.Name = "colMatchStartTime";
            colMatchStartTime.ReadOnly = true;
            // 
            // colMap
            // 
            colMap.HeaderText = "Map";
            colMap.Name = "colMap";
            colMap.ReadOnly = true;
            // 
            // colAgent
            // 
            colAgent.HeaderText = "Agent";
            colAgent.Name = "colAgent";
            colAgent.ReadOnly = true;
            // 
            // colScore
            // 
            colScore.HeaderText = "Score";
            colScore.Name = "colScore";
            colScore.ReadOnly = true;
            // 
            // colKDA
            // 
            colKDA.HeaderText = "KDA";
            colKDA.Name = "colKDA";
            colKDA.ReadOnly = true;
            // 
            // colKD
            // 
            colKD.HeaderText = "KD";
            colKD.Name = "colKD";
            colKD.ReadOnly = true;
            // 
            // colHS
            // 
            colHS.HeaderText = "HS%";
            colHS.Name = "colHS";
            colHS.ReadOnly = true;
            // 
            // colADR
            // 
            colADR.HeaderText = "ADR";
            colADR.Name = "colADR";
            colADR.ReadOnly = true;
            // 
            // colAvgScore
            // 
            colAvgScore.HeaderText = "Avg combat score";
            colAvgScore.Name = "colAvgScore";
            colAvgScore.ReadOnly = true;
            // 
            // colFirstBloods
            // 
            colFirstBloods.HeaderText = "First bloods";
            colFirstBloods.Name = "colFirstBloods";
            colFirstBloods.ReadOnly = true;
            // 
            // colPlants
            // 
            colPlants.HeaderText = "Plants";
            colPlants.Name = "colPlants";
            colPlants.ReadOnly = true;
            // 
            // colDefuses
            // 
            colDefuses.HeaderText = "Defuses";
            colDefuses.Name = "colDefuses";
            colDefuses.ReadOnly = true;
            // 
            // cmbAct
            // 
            cmbAct.AllowDrop = true;
            cmbAct.ArrowColor = System.Drawing.Color.FromArgb(110, 110, 110);
            cmbAct.BackColor = System.Drawing.Color.Transparent;
            cmbAct.BackgroundColor = System.Drawing.Color.FromArgb(34, 34, 34);
            cmbAct.BorderColor = System.Drawing.Color.FromArgb(110, 110, 110);
            cmbAct.CausesValidation = false;
            cmbAct.DisabledBackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            cmbAct.DisabledBorderColor = System.Drawing.Color.FromArgb(109, 109, 109);
            cmbAct.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
            cmbAct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            cmbAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAct.DropDownWidth = 180;
            cmbAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold);
            cmbAct.FormattingEnabled = true;
            cmbAct.IsDerivedStyle = true;
            cmbAct.ItemHeight = 20;
            cmbAct.Location = new System.Drawing.Point(3, 17);
            cmbAct.Name = "cmbAct";
            cmbAct.SelectedItemBackColor = System.Drawing.Color.FromArgb(65, 177, 225);
            cmbAct.SelectedItemForeColor = System.Drawing.Color.White;
            cmbAct.Size = new System.Drawing.Size(180, 26);
            cmbAct.Style = MetroSet_UI.Enums.Style.Dark;
            cmbAct.StyleManager = null;
            cmbAct.TabIndex = 20;
            cmbAct.ThemeAuthor = "Narwin";
            cmbAct.ThemeName = "MetroDark";
            cmbAct.SelectedIndexChanged += cmbAct_SelectedIndexChanged;
            // 
            // lblWinsAndLosses
            // 
            lblWinsAndLosses.AutoSize = true;
            lblWinsAndLosses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblWinsAndLosses.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblWinsAndLosses.Location = new System.Drawing.Point(109, 110);
            lblWinsAndLosses.Name = "lblWinsAndLosses";
            lblWinsAndLosses.Size = new System.Drawing.Size(0, 18);
            lblWinsAndLosses.TabIndex = 19;
            // 
            // lblRankedRating
            // 
            lblRankedRating.AutoSize = true;
            lblRankedRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblRankedRating.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblRankedRating.Location = new System.Drawing.Point(109, 85);
            lblRankedRating.Name = "lblRankedRating";
            lblRankedRating.Size = new System.Drawing.Size(0, 18);
            lblRankedRating.TabIndex = 18;
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblRank.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblRank.Location = new System.Drawing.Point(109, 60);
            lblRank.Name = "lblRank";
            lblRank.Size = new System.Drawing.Size(0, 18);
            lblRank.TabIndex = 17;
            // 
            // pbRank
            // 
            pbRank.Location = new System.Drawing.Point(3, 110);
            pbRank.Name = "pbRank";
            pbRank.Size = new System.Drawing.Size(100, 85);
            pbRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbRank.TabIndex = 16;
            pbRank.TabStop = false;
            // 
            // tpPlayerStore
            // 
            tpPlayerStore.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            tpPlayerStore.Controls.Add(lblTimeRemaining);
            tpPlayerStore.Controls.Add(lblWeaponPrice4);
            tpPlayerStore.Controls.Add(lblWeaponPrice3);
            tpPlayerStore.Controls.Add(lblWeaponPrice2);
            tpPlayerStore.Controls.Add(lblWeaponPrice1);
            tpPlayerStore.Controls.Add(lblWeaponName4);
            tpPlayerStore.Controls.Add(lblWeaponName3);
            tpPlayerStore.Controls.Add(lblWeaponName2);
            tpPlayerStore.Controls.Add(lblWeaponName1);
            tpPlayerStore.Controls.Add(pbWeapon1);
            tpPlayerStore.Controls.Add(pbWeapon2);
            tpPlayerStore.Controls.Add(pbWeapon3);
            tpPlayerStore.Controls.Add(pbWeapon4);
            tpPlayerStore.Location = new System.Drawing.Point(4, 42);
            tpPlayerStore.Name = "tpPlayerStore";
            tpPlayerStore.Size = new System.Drawing.Size(771, 314);
            tpPlayerStore.TabIndex = 2;
            tpPlayerStore.Text = "Player Store";
            // 
            // lblTimeRemaining
            // 
            lblTimeRemaining.AutoSize = true;
            lblTimeRemaining.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblTimeRemaining.Location = new System.Drawing.Point(333, 13);
            lblTimeRemaining.Name = "lblTimeRemaining";
            lblTimeRemaining.Size = new System.Drawing.Size(0, 20);
            lblTimeRemaining.TabIndex = 28;
            // 
            // lblWeaponPrice4
            // 
            lblWeaponPrice4.AutoSize = true;
            lblWeaponPrice4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblWeaponPrice4.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblWeaponPrice4.Location = new System.Drawing.Point(616, 236);
            lblWeaponPrice4.Name = "lblWeaponPrice4";
            lblWeaponPrice4.Size = new System.Drawing.Size(0, 15);
            lblWeaponPrice4.TabIndex = 27;
            // 
            // lblWeaponPrice3
            // 
            lblWeaponPrice3.AutoSize = true;
            lblWeaponPrice3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblWeaponPrice3.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblWeaponPrice3.Location = new System.Drawing.Point(416, 236);
            lblWeaponPrice3.Name = "lblWeaponPrice3";
            lblWeaponPrice3.Size = new System.Drawing.Size(0, 15);
            lblWeaponPrice3.TabIndex = 26;
            // 
            // lblWeaponPrice2
            // 
            lblWeaponPrice2.AutoSize = true;
            lblWeaponPrice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblWeaponPrice2.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblWeaponPrice2.Location = new System.Drawing.Point(216, 236);
            lblWeaponPrice2.Name = "lblWeaponPrice2";
            lblWeaponPrice2.Size = new System.Drawing.Size(0, 15);
            lblWeaponPrice2.TabIndex = 25;
            // 
            // lblWeaponPrice1
            // 
            lblWeaponPrice1.AutoSize = true;
            lblWeaponPrice1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblWeaponPrice1.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblWeaponPrice1.Location = new System.Drawing.Point(12, 236);
            lblWeaponPrice1.Name = "lblWeaponPrice1";
            lblWeaponPrice1.Size = new System.Drawing.Size(0, 15);
            lblWeaponPrice1.TabIndex = 24;
            // 
            // lblWeaponName4
            // 
            lblWeaponName4.AutoSize = true;
            lblWeaponName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblWeaponName4.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblWeaponName4.Location = new System.Drawing.Point(616, 207);
            lblWeaponName4.Name = "lblWeaponName4";
            lblWeaponName4.Size = new System.Drawing.Size(0, 15);
            lblWeaponName4.TabIndex = 23;
            // 
            // lblWeaponName3
            // 
            lblWeaponName3.AutoSize = true;
            lblWeaponName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblWeaponName3.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblWeaponName3.Location = new System.Drawing.Point(416, 207);
            lblWeaponName3.Name = "lblWeaponName3";
            lblWeaponName3.Size = new System.Drawing.Size(0, 15);
            lblWeaponName3.TabIndex = 22;
            // 
            // lblWeaponName2
            // 
            lblWeaponName2.AutoSize = true;
            lblWeaponName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblWeaponName2.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblWeaponName2.Location = new System.Drawing.Point(216, 207);
            lblWeaponName2.Name = "lblWeaponName2";
            lblWeaponName2.Size = new System.Drawing.Size(0, 15);
            lblWeaponName2.TabIndex = 21;
            // 
            // lblWeaponName1
            // 
            lblWeaponName1.AutoSize = true;
            lblWeaponName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblWeaponName1.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblWeaponName1.Location = new System.Drawing.Point(12, 207);
            lblWeaponName1.Name = "lblWeaponName1";
            lblWeaponName1.Size = new System.Drawing.Size(0, 15);
            lblWeaponName1.TabIndex = 20;
            // 
            // pbWeapon1
            // 
            pbWeapon1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pbWeapon1.Location = new System.Drawing.Point(12, 20);
            pbWeapon1.Name = "pbWeapon1";
            pbWeapon1.Size = new System.Drawing.Size(175, 175);
            pbWeapon1.TabIndex = 16;
            pbWeapon1.TabStop = false;
            // 
            // pbWeapon2
            // 
            pbWeapon2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pbWeapon2.Location = new System.Drawing.Point(216, 20);
            pbWeapon2.Name = "pbWeapon2";
            pbWeapon2.Size = new System.Drawing.Size(175, 175);
            pbWeapon2.TabIndex = 17;
            pbWeapon2.TabStop = false;
            // 
            // pbWeapon3
            // 
            pbWeapon3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pbWeapon3.Location = new System.Drawing.Point(416, 20);
            pbWeapon3.Name = "pbWeapon3";
            pbWeapon3.Size = new System.Drawing.Size(175, 175);
            pbWeapon3.TabIndex = 18;
            pbWeapon3.TabStop = false;
            // 
            // pbWeapon4
            // 
            pbWeapon4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pbWeapon4.Location = new System.Drawing.Point(616, 20);
            pbWeapon4.Name = "pbWeapon4";
            pbWeapon4.Size = new System.Drawing.Size(175, 175);
            pbWeapon4.TabIndex = 19;
            pbWeapon4.TabStop = false;
            // 
            // tpAccountInformation
            // 
            tpAccountInformation.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            tpAccountInformation.Controls.Add(lblCreatedAt);
            tpAccountInformation.Controls.Add(lblTagline);
            tpAccountInformation.Controls.Add(lblRadianitePoints);
            tpAccountInformation.Controls.Add(lblValorantPoints);
            tpAccountInformation.Controls.Add(lblLevel);
            tpAccountInformation.Controls.Add(lblRegion);
            tpAccountInformation.Controls.Add(lblGameName);
            tpAccountInformation.Location = new System.Drawing.Point(4, 42);
            tpAccountInformation.Name = "tpAccountInformation";
            tpAccountInformation.Size = new System.Drawing.Size(771, 314);
            tpAccountInformation.TabIndex = 0;
            tpAccountInformation.Text = "Account Information";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblCreatedAt.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblCreatedAt.Location = new System.Drawing.Point(12, 264);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(756, 23);
            lblCreatedAt.TabIndex = 22;
            lblCreatedAt.Text = "Created at :";
            // 
            // lblTagline
            // 
            lblTagline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblTagline.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblTagline.Location = new System.Drawing.Point(12, 64);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new System.Drawing.Size(756, 23);
            lblTagline.TabIndex = 21;
            lblTagline.Text = "Tagline :";
            // 
            // lblRadianitePoints
            // 
            lblRadianitePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblRadianitePoints.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblRadianitePoints.Location = new System.Drawing.Point(12, 224);
            lblRadianitePoints.Name = "lblRadianitePoints";
            lblRadianitePoints.Size = new System.Drawing.Size(756, 23);
            lblRadianitePoints.TabIndex = 20;
            lblRadianitePoints.Text = "Radianite points :";
            // 
            // lblValorantPoints
            // 
            lblValorantPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblValorantPoints.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblValorantPoints.Location = new System.Drawing.Point(12, 184);
            lblValorantPoints.Name = "lblValorantPoints";
            lblValorantPoints.Size = new System.Drawing.Size(756, 23);
            lblValorantPoints.TabIndex = 19;
            lblValorantPoints.Text = "Valorant points :";
            // 
            // lblLevel
            // 
            lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblLevel.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblLevel.Location = new System.Drawing.Point(12, 144);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new System.Drawing.Size(756, 23);
            lblLevel.TabIndex = 18;
            lblLevel.Text = "Level :";
            // 
            // lblRegion
            // 
            lblRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblRegion.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblRegion.Location = new System.Drawing.Point(12, 104);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new System.Drawing.Size(756, 23);
            lblRegion.TabIndex = 17;
            lblRegion.Text = "Region :";
            // 
            // lblGameName
            // 
            lblGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            lblGameName.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lblGameName.Location = new System.Drawing.Point(12, 24);
            lblGameName.Name = "lblGameName";
            lblGameName.Size = new System.Drawing.Size(756, 23);
            lblGameName.TabIndex = 16;
            lblGameName.Text = "Game name :";
            // 
            // tcMain
            // 
            tcMain.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            tcMain.AnimateTime = 200;
            tcMain.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
            tcMain.Controls.Add(tpCompetitive);
            tcMain.Controls.Add(tpAccountInformation);
            tcMain.Controls.Add(tpPlayerStore);
            tcMain.IsDerivedStyle = true;
            tcMain.ItemSize = new System.Drawing.Size(100, 38);
            tcMain.Location = new System.Drawing.Point(15, 86);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.SelectedTextColor = System.Drawing.Color.White;
            tcMain.Size = new System.Drawing.Size(779, 360);
            tcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tcMain.Speed = 100;
            tcMain.Style = MetroSet_UI.Enums.Style.Dark;
            tcMain.StyleManager = null;
            tcMain.TabIndex = 15;
            tcMain.ThemeAuthor = "Narwin";
            tcMain.ThemeName = "MetroDark";
            tcMain.UnselectedTextColor = System.Drawing.Color.Gray;
            tcMain.UseAnimation = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
            ClientSize = new System.Drawing.Size(809, 461);
            Controls.Add(tcMain);
            Controls.Add(cbMain);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            Name = "frmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Style = MetroSet_UI.Enums.Style.Dark;
            Text = "Valorant Tracker";
            TextColor = System.Drawing.Color.FromArgb(224, 224, 224);
            ThemeName = "MetroDark";
            Load += frmMain_Load;
            tpCompetitive.ResumeLayout(false);
            tpCompetitive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbRank).EndInit();
            tpPlayerStore.ResumeLayout(false);
            tpPlayerStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbWeapon1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWeapon2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWeapon3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWeapon4).EndInit();
            tpAccountInformation.ResumeLayout(false);
            tcMain.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private MetroSet_UI.Controls.MetroSetControlBox cbMain;
        private System.Windows.Forms.TabPage tpCompetitive;
        private System.Windows.Forms.TabPage tpPlayerStore;
        private System.Windows.Forms.TabPage tpAccountInformation;
        private MetroSet_UI.Controls.MetroSetTabControl tcMain;
        private System.Windows.Forms.PictureBox pbWeapon1;
        private System.Windows.Forms.PictureBox pbWeapon2;
        private System.Windows.Forms.PictureBox pbWeapon3;
        private System.Windows.Forms.PictureBox pbWeapon4;
        private System.Windows.Forms.Label lblWeaponPrice4;
        private System.Windows.Forms.Label lblWeaponPrice3;
        private System.Windows.Forms.Label lblWeaponPrice2;
        private System.Windows.Forms.Label lblWeaponPrice1;
        private System.Windows.Forms.Label lblWeaponName4;
        private System.Windows.Forms.Label lblWeaponName3;
        private System.Windows.Forms.Label lblWeaponName2;
        private System.Windows.Forms.Label lblWeaponName1;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label lblRadianitePoints;
        private System.Windows.Forms.Label lblValorantPoints;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.PictureBox pbRank;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.Label lblRankedRating;
        private System.Windows.Forms.Label lblWinsAndLosses;
        private MetroSet_UI.Controls.MetroSetComboBox cmbAct;
        private System.Windows.Forms.DataGridView dgvHistory;
        private MetroSet_UI.Controls.MetroSetComboBox cmbGamemode;
        private System.Windows.Forms.Label lblLastNaNMatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatchLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatchStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colADR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvgScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstBloods;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlants;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefuses;
    }
}

