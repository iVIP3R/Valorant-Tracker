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
            this.cbMain = new MetroSet_UI.Controls.MetroSetControlBox();
            this.tpCompetitive = new System.Windows.Forms.TabPage();
            this.lblLastNaNMatches = new System.Windows.Forms.Label();
            this.cmbGamemode = new MetroSet_UI.Controls.MetroSetComboBox();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.cmbAct = new MetroSet_UI.Controls.MetroSetComboBox();
            this.lblWinsAndLosses = new System.Windows.Forms.Label();
            this.lblRankedRating = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.pbRank = new System.Windows.Forms.PictureBox();
            this.tpPlayerStore = new System.Windows.Forms.TabPage();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.lblWeaponPrice4 = new System.Windows.Forms.Label();
            this.lblWeaponPrice3 = new System.Windows.Forms.Label();
            this.lblWeaponPrice2 = new System.Windows.Forms.Label();
            this.lblWeaponPrice1 = new System.Windows.Forms.Label();
            this.lblWeaponName4 = new System.Windows.Forms.Label();
            this.lblWeaponName3 = new System.Windows.Forms.Label();
            this.lblWeaponName2 = new System.Windows.Forms.Label();
            this.lblWeaponName1 = new System.Windows.Forms.Label();
            this.pbWeapon1 = new System.Windows.Forms.PictureBox();
            this.pbWeapon2 = new System.Windows.Forms.PictureBox();
            this.pbWeapon3 = new System.Windows.Forms.PictureBox();
            this.pbWeapon4 = new System.Windows.Forms.PictureBox();
            this.tpAccountInformation = new System.Windows.Forms.TabPage();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.lblRadianitePoints = new System.Windows.Forms.Label();
            this.lblValorantPoints = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.tcMain = new MetroSet_UI.Controls.MetroSetTabControl();
            this.colMatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatchLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatchStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colADR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvgScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstBloods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlants = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefuses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpCompetitive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRank)).BeginInit();
            this.tpPlayerStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapon4)).BeginInit();
            this.tpAccountInformation.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMain
            // 
            this.cbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMain.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbMain.CloseHoverForeColor = System.Drawing.Color.White;
            this.cbMain.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.cbMain.DisabledForeColor = System.Drawing.Color.DimGray;
            this.cbMain.IsDerivedStyle = true;
            this.cbMain.Location = new System.Drawing.Point(709, 0);
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
            this.cbMain.TabIndex = 14;
            this.cbMain.Text = "metroSetControlBox1";
            this.cbMain.ThemeAuthor = "Narwin";
            this.cbMain.ThemeName = "MetroLite";
            // 
            // tpCompetitive
            // 
            this.tpCompetitive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tpCompetitive.Controls.Add(this.lblLastNaNMatches);
            this.tpCompetitive.Controls.Add(this.cmbGamemode);
            this.tpCompetitive.Controls.Add(this.dgvHistory);
            this.tpCompetitive.Controls.Add(this.cmbAct);
            this.tpCompetitive.Controls.Add(this.lblWinsAndLosses);
            this.tpCompetitive.Controls.Add(this.lblRankedRating);
            this.tpCompetitive.Controls.Add(this.lblRank);
            this.tpCompetitive.Controls.Add(this.pbRank);
            this.tpCompetitive.Location = new System.Drawing.Point(4, 42);
            this.tpCompetitive.Name = "tpCompetitive";
            this.tpCompetitive.Size = new System.Drawing.Size(771, 314);
            this.tpCompetitive.TabIndex = 1;
            this.tpCompetitive.Text = "Competitive";
            // 
            // lblLastNaNMatches
            // 
            this.lblLastNaNMatches.AutoSize = true;
            this.lblLastNaNMatches.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLastNaNMatches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLastNaNMatches.Location = new System.Drawing.Point(266, 10);
            this.lblLastNaNMatches.Name = "lblLastNaNMatches";
            this.lblLastNaNMatches.Size = new System.Drawing.Size(0, 20);
            this.lblLastNaNMatches.TabIndex = 22;
            // 
            // cmbGamemode
            // 
            this.cmbGamemode.AllowDrop = true;
            this.cmbGamemode.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.cmbGamemode.BackColor = System.Drawing.Color.Transparent;
            this.cmbGamemode.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmbGamemode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.cmbGamemode.CausesValidation = false;
            this.cmbGamemode.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cmbGamemode.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbGamemode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbGamemode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGamemode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGamemode.Font = new System.Drawing.Font("Nunito", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbGamemode.FormattingEnabled = true;
            this.cmbGamemode.IsDerivedStyle = true;
            this.cmbGamemode.ItemHeight = 20;
            this.cmbGamemode.Items.AddRange(new object[] {
            "Unrated",
            "Competitive",
            "Spike rush",
            "Deathmatch",
            "Replication",
            "Snowball fight",
            "Custom"});
            this.cmbGamemode.Location = new System.Drawing.Point(109, 17);
            this.cmbGamemode.Name = "cmbGamemode";
            this.cmbGamemode.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmbGamemode.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmbGamemode.Size = new System.Drawing.Size(100, 26);
            this.cmbGamemode.Style = MetroSet_UI.Enums.Style.Dark;
            this.cmbGamemode.StyleManager = null;
            this.cmbGamemode.TabIndex = 21;
            this.cmbGamemode.ThemeAuthor = "Narwin";
            this.cmbGamemode.ThemeName = "MetroDark";
            this.cmbGamemode.SelectedIndexChanged += new System.EventHandler(this.cmbGamemode_SelectedIndexChanged);
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(41)))));
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatchID,
            this.colServer,
            this.colMatchLength,
            this.colMatchStartTime,
            this.colMap,
            this.colAgent,
            this.colScore,
            this.colKDA,
            this.colKD,
            this.colHS,
            this.colADR,
            this.colAvgScore,
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
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.Location = new System.Drawing.Point(266, 45);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistory.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.dgvHistory.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHistory.RowTemplate.Height = 25;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(485, 275);
            this.dgvHistory.TabIndex = 16;
            this.dgvHistory.SelectionChanged += new System.EventHandler(this.dgvHistory_SelectionChanged);
            // 
            // cmbAct
            // 
            this.cmbAct.AllowDrop = true;
            this.cmbAct.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.cmbAct.BackColor = System.Drawing.Color.Transparent;
            this.cmbAct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmbAct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.cmbAct.CausesValidation = false;
            this.cmbAct.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cmbAct.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbAct.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbAct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAct.Font = new System.Drawing.Font("Nunito", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbAct.FormattingEnabled = true;
            this.cmbAct.IsDerivedStyle = true;
            this.cmbAct.ItemHeight = 20;
            this.cmbAct.Items.AddRange(new object[] {
            "Closed beta",
            "EP1 Act 1",
            "EP1 Act 2",
            "EP1 Act 3",
            "EP2 Act 1",
            "EP2 Act 2",
            "EP2 Act 3",
            "EP3 Act 1",
            "EP3 Act 2"});
            this.cmbAct.Location = new System.Drawing.Point(3, 17);
            this.cmbAct.Name = "cmbAct";
            this.cmbAct.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmbAct.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmbAct.Size = new System.Drawing.Size(100, 26);
            this.cmbAct.Style = MetroSet_UI.Enums.Style.Dark;
            this.cmbAct.StyleManager = null;
            this.cmbAct.TabIndex = 20;
            this.cmbAct.ThemeAuthor = "Narwin";
            this.cmbAct.ThemeName = "MetroDark";
            this.cmbAct.SelectedIndexChanged += new System.EventHandler(this.cmbAct_SelectedIndexChanged);
            // 
            // lblWinsAndLosses
            // 
            this.lblWinsAndLosses.AutoSize = true;
            this.lblWinsAndLosses.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWinsAndLosses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWinsAndLosses.Location = new System.Drawing.Point(109, 110);
            this.lblWinsAndLosses.Name = "lblWinsAndLosses";
            this.lblWinsAndLosses.Size = new System.Drawing.Size(0, 20);
            this.lblWinsAndLosses.TabIndex = 19;
            // 
            // lblRankedRating
            // 
            this.lblRankedRating.AutoSize = true;
            this.lblRankedRating.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRankedRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRankedRating.Location = new System.Drawing.Point(109, 85);
            this.lblRankedRating.Name = "lblRankedRating";
            this.lblRankedRating.Size = new System.Drawing.Size(0, 20);
            this.lblRankedRating.TabIndex = 18;
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRank.Location = new System.Drawing.Point(109, 60);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(0, 20);
            this.lblRank.TabIndex = 17;
            // 
            // pbRank
            // 
            this.pbRank.Location = new System.Drawing.Point(3, 59);
            this.pbRank.Name = "pbRank";
            this.pbRank.Size = new System.Drawing.Size(100, 85);
            this.pbRank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRank.TabIndex = 16;
            this.pbRank.TabStop = false;
            // 
            // tpPlayerStore
            // 
            this.tpPlayerStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tpPlayerStore.Controls.Add(this.lblTimeRemaining);
            this.tpPlayerStore.Controls.Add(this.lblWeaponPrice4);
            this.tpPlayerStore.Controls.Add(this.lblWeaponPrice3);
            this.tpPlayerStore.Controls.Add(this.lblWeaponPrice2);
            this.tpPlayerStore.Controls.Add(this.lblWeaponPrice1);
            this.tpPlayerStore.Controls.Add(this.lblWeaponName4);
            this.tpPlayerStore.Controls.Add(this.lblWeaponName3);
            this.tpPlayerStore.Controls.Add(this.lblWeaponName2);
            this.tpPlayerStore.Controls.Add(this.lblWeaponName1);
            this.tpPlayerStore.Controls.Add(this.pbWeapon1);
            this.tpPlayerStore.Controls.Add(this.pbWeapon2);
            this.tpPlayerStore.Controls.Add(this.pbWeapon3);
            this.tpPlayerStore.Controls.Add(this.pbWeapon4);
            this.tpPlayerStore.Location = new System.Drawing.Point(4, 42);
            this.tpPlayerStore.Name = "tpPlayerStore";
            this.tpPlayerStore.Size = new System.Drawing.Size(771, 314);
            this.tpPlayerStore.TabIndex = 2;
            this.tpPlayerStore.Text = "Player Store";
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTimeRemaining.Location = new System.Drawing.Point(333, 13);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(0, 22);
            this.lblTimeRemaining.TabIndex = 28;
            // 
            // lblWeaponPrice4
            // 
            this.lblWeaponPrice4.AutoSize = true;
            this.lblWeaponPrice4.Font = new System.Drawing.Font("Nunito", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeaponPrice4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWeaponPrice4.Location = new System.Drawing.Point(616, 236);
            this.lblWeaponPrice4.Name = "lblWeaponPrice4";
            this.lblWeaponPrice4.Size = new System.Drawing.Size(0, 17);
            this.lblWeaponPrice4.TabIndex = 27;
            // 
            // lblWeaponPrice3
            // 
            this.lblWeaponPrice3.AutoSize = true;
            this.lblWeaponPrice3.Font = new System.Drawing.Font("Nunito", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeaponPrice3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWeaponPrice3.Location = new System.Drawing.Point(416, 236);
            this.lblWeaponPrice3.Name = "lblWeaponPrice3";
            this.lblWeaponPrice3.Size = new System.Drawing.Size(0, 17);
            this.lblWeaponPrice3.TabIndex = 26;
            // 
            // lblWeaponPrice2
            // 
            this.lblWeaponPrice2.AutoSize = true;
            this.lblWeaponPrice2.Font = new System.Drawing.Font("Nunito", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeaponPrice2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWeaponPrice2.Location = new System.Drawing.Point(216, 236);
            this.lblWeaponPrice2.Name = "lblWeaponPrice2";
            this.lblWeaponPrice2.Size = new System.Drawing.Size(0, 17);
            this.lblWeaponPrice2.TabIndex = 25;
            // 
            // lblWeaponPrice1
            // 
            this.lblWeaponPrice1.AutoSize = true;
            this.lblWeaponPrice1.Font = new System.Drawing.Font("Nunito", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeaponPrice1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWeaponPrice1.Location = new System.Drawing.Point(12, 236);
            this.lblWeaponPrice1.Name = "lblWeaponPrice1";
            this.lblWeaponPrice1.Size = new System.Drawing.Size(0, 17);
            this.lblWeaponPrice1.TabIndex = 24;
            // 
            // lblWeaponName4
            // 
            this.lblWeaponName4.AutoSize = true;
            this.lblWeaponName4.Font = new System.Drawing.Font("Nunito", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeaponName4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWeaponName4.Location = new System.Drawing.Point(616, 207);
            this.lblWeaponName4.Name = "lblWeaponName4";
            this.lblWeaponName4.Size = new System.Drawing.Size(0, 17);
            this.lblWeaponName4.TabIndex = 23;
            // 
            // lblWeaponName3
            // 
            this.lblWeaponName3.AutoSize = true;
            this.lblWeaponName3.Font = new System.Drawing.Font("Nunito", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeaponName3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWeaponName3.Location = new System.Drawing.Point(416, 207);
            this.lblWeaponName3.Name = "lblWeaponName3";
            this.lblWeaponName3.Size = new System.Drawing.Size(0, 17);
            this.lblWeaponName3.TabIndex = 22;
            // 
            // lblWeaponName2
            // 
            this.lblWeaponName2.AutoSize = true;
            this.lblWeaponName2.Font = new System.Drawing.Font("Nunito", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeaponName2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWeaponName2.Location = new System.Drawing.Point(216, 207);
            this.lblWeaponName2.Name = "lblWeaponName2";
            this.lblWeaponName2.Size = new System.Drawing.Size(0, 17);
            this.lblWeaponName2.TabIndex = 21;
            // 
            // lblWeaponName1
            // 
            this.lblWeaponName1.AutoSize = true;
            this.lblWeaponName1.Font = new System.Drawing.Font("Nunito", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeaponName1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWeaponName1.Location = new System.Drawing.Point(12, 207);
            this.lblWeaponName1.Name = "lblWeaponName1";
            this.lblWeaponName1.Size = new System.Drawing.Size(0, 17);
            this.lblWeaponName1.TabIndex = 20;
            // 
            // pbWeapon1
            // 
            this.pbWeapon1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbWeapon1.Location = new System.Drawing.Point(12, 20);
            this.pbWeapon1.Name = "pbWeapon1";
            this.pbWeapon1.Size = new System.Drawing.Size(175, 175);
            this.pbWeapon1.TabIndex = 16;
            this.pbWeapon1.TabStop = false;
            // 
            // pbWeapon2
            // 
            this.pbWeapon2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbWeapon2.Location = new System.Drawing.Point(216, 20);
            this.pbWeapon2.Name = "pbWeapon2";
            this.pbWeapon2.Size = new System.Drawing.Size(175, 175);
            this.pbWeapon2.TabIndex = 17;
            this.pbWeapon2.TabStop = false;
            // 
            // pbWeapon3
            // 
            this.pbWeapon3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbWeapon3.Location = new System.Drawing.Point(416, 20);
            this.pbWeapon3.Name = "pbWeapon3";
            this.pbWeapon3.Size = new System.Drawing.Size(175, 175);
            this.pbWeapon3.TabIndex = 18;
            this.pbWeapon3.TabStop = false;
            // 
            // pbWeapon4
            // 
            this.pbWeapon4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbWeapon4.Location = new System.Drawing.Point(616, 20);
            this.pbWeapon4.Name = "pbWeapon4";
            this.pbWeapon4.Size = new System.Drawing.Size(175, 175);
            this.pbWeapon4.TabIndex = 19;
            this.pbWeapon4.TabStop = false;
            // 
            // tpAccountInformation
            // 
            this.tpAccountInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tpAccountInformation.Controls.Add(this.lblCreatedAt);
            this.tpAccountInformation.Controls.Add(this.lblTagline);
            this.tpAccountInformation.Controls.Add(this.lblRadianitePoints);
            this.tpAccountInformation.Controls.Add(this.lblValorantPoints);
            this.tpAccountInformation.Controls.Add(this.lblLevel);
            this.tpAccountInformation.Controls.Add(this.lblRegion);
            this.tpAccountInformation.Controls.Add(this.lblGameName);
            this.tpAccountInformation.Location = new System.Drawing.Point(4, 42);
            this.tpAccountInformation.Name = "tpAccountInformation";
            this.tpAccountInformation.Size = new System.Drawing.Size(771, 314);
            this.tpAccountInformation.TabIndex = 0;
            this.tpAccountInformation.Text = "Account Information";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCreatedAt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCreatedAt.Location = new System.Drawing.Point(12, 264);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(756, 23);
            this.lblCreatedAt.TabIndex = 22;
            this.lblCreatedAt.Text = "Created at :";
            // 
            // lblTagline
            // 
            this.lblTagline.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTagline.Location = new System.Drawing.Point(12, 64);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(756, 23);
            this.lblTagline.TabIndex = 21;
            this.lblTagline.Text = "Tagline :";
            // 
            // lblRadianitePoints
            // 
            this.lblRadianitePoints.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRadianitePoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRadianitePoints.Location = new System.Drawing.Point(12, 224);
            this.lblRadianitePoints.Name = "lblRadianitePoints";
            this.lblRadianitePoints.Size = new System.Drawing.Size(756, 23);
            this.lblRadianitePoints.TabIndex = 20;
            this.lblRadianitePoints.Text = "Radianite points :";
            // 
            // lblValorantPoints
            // 
            this.lblValorantPoints.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValorantPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblValorantPoints.Location = new System.Drawing.Point(12, 184);
            this.lblValorantPoints.Name = "lblValorantPoints";
            this.lblValorantPoints.Size = new System.Drawing.Size(756, 23);
            this.lblValorantPoints.TabIndex = 19;
            this.lblValorantPoints.Text = "Valorant points :";
            // 
            // lblLevel
            // 
            this.lblLevel.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLevel.Location = new System.Drawing.Point(12, 144);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(756, 23);
            this.lblLevel.TabIndex = 18;
            this.lblLevel.Text = "Level :";
            // 
            // lblRegion
            // 
            this.lblRegion.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRegion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRegion.Location = new System.Drawing.Point(12, 104);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(756, 23);
            this.lblRegion.TabIndex = 17;
            this.lblRegion.Text = "Region :";
            // 
            // lblGameName
            // 
            this.lblGameName.Font = new System.Drawing.Font("Nunito", 10.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGameName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblGameName.Location = new System.Drawing.Point(12, 24);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(756, 23);
            this.lblGameName.TabIndex = 16;
            this.lblGameName.Text = "Game name :";
            // 
            // tcMain
            // 
            this.tcMain.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.tcMain.AnimateTime = 200;
            this.tcMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tcMain.Controls.Add(this.tpCompetitive);
            this.tcMain.Controls.Add(this.tpAccountInformation);
            this.tcMain.Controls.Add(this.tpPlayerStore);
            this.tcMain.IsDerivedStyle = true;
            this.tcMain.ItemSize = new System.Drawing.Size(100, 38);
            this.tcMain.Location = new System.Drawing.Point(15, 86);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.SelectedTextColor = System.Drawing.Color.White;
            this.tcMain.Size = new System.Drawing.Size(779, 360);
            this.tcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcMain.Speed = 100;
            this.tcMain.Style = MetroSet_UI.Enums.Style.Dark;
            this.tcMain.StyleManager = null;
            this.tcMain.TabIndex = 15;
            this.tcMain.ThemeAuthor = "Narwin";
            this.tcMain.ThemeName = "MetroDark";
            this.tcMain.UnselectedTextColor = System.Drawing.Color.Gray;
            this.tcMain.UseAnimation = false;
            // 
            // colMatchID
            // 
            this.colMatchID.HeaderText = "Match ID";
            this.colMatchID.Name = "colMatchID";
            this.colMatchID.ReadOnly = true;
            this.colMatchID.Visible = false;
            // 
            // colServer
            // 
            this.colServer.HeaderText = "Server";
            this.colServer.Name = "colServer";
            this.colServer.ReadOnly = true;
            // 
            // colMatchLength
            // 
            this.colMatchLength.HeaderText = "Match length";
            this.colMatchLength.Name = "colMatchLength";
            this.colMatchLength.ReadOnly = true;
            // 
            // colMatchStartTime
            // 
            this.colMatchStartTime.HeaderText = "Match start time";
            this.colMatchStartTime.Name = "colMatchStartTime";
            this.colMatchStartTime.ReadOnly = true;
            // 
            // colMap
            // 
            this.colMap.HeaderText = "Map";
            this.colMap.Name = "colMap";
            this.colMap.ReadOnly = true;
            // 
            // colAgent
            // 
            this.colAgent.HeaderText = "Agent";
            this.colAgent.Name = "colAgent";
            this.colAgent.ReadOnly = true;
            // 
            // colScore
            // 
            this.colScore.HeaderText = "Score";
            this.colScore.Name = "colScore";
            this.colScore.ReadOnly = true;
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
            // colHS
            // 
            this.colHS.HeaderText = "HS%";
            this.colHS.Name = "colHS";
            this.colHS.ReadOnly = true;
            // 
            // colADR
            // 
            this.colADR.HeaderText = "ADR";
            this.colADR.Name = "colADR";
            this.colADR.ReadOnly = true;
            // 
            // colAvgScore
            // 
            this.colAvgScore.HeaderText = "Avg combat score";
            this.colAvgScore.Name = "colAvgScore";
            this.colAvgScore.ReadOnly = true;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(809, 461);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.cbMain);
            this.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style = MetroSet_UI.Enums.Style.Dark;
            this.Text = "Valorant Tracker";
            this.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ThemeName = "MetroDark";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tpCompetitive.ResumeLayout(false);
            this.tpCompetitive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRank)).EndInit();
            this.tpPlayerStore.ResumeLayout(false);
            this.tpPlayerStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeapon4)).EndInit();
            this.tpAccountInformation.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.ResumeLayout(false);

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

