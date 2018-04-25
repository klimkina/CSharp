namespace UserControls
{
	partial class UCManageGoals
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCManageGoals));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lTaskName = new DevExpress.XtraEditors.LabelControl();
			this.pBottomPanel = new System.Windows.Forms.Panel();
			this.bDone = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lSitePrefTitle = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lTargetDate = new System.Windows.Forms.Label();
			this.dtTargetDate = new System.Windows.Forms.DateTimePicker();
			this.dtStartDate = new System.Windows.Forms.DateTimePicker();
			this.lStartDate = new System.Windows.Forms.Label();
			this.cbGoalPriority = new System.Windows.Forms.ComboBox();
			this.lPriority = new System.Windows.Forms.Label();
			this.cbFilterType = new System.Windows.Forms.ComboBox();
			this.lFilterType = new System.Windows.Forms.Label();
			this.tGoalTarget = new System.Windows.Forms.TextBox();
			this.lGoalTarget = new System.Windows.Forms.Label();
			this.cbGoalMode = new System.Windows.Forms.ComboBox();
			this.lGoalMode = new System.Windows.Forms.Label();
			this.cbGoalType = new System.Windows.Forms.ComboBox();
			this.lGoalType = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tDescription = new System.Windows.Forms.TextBox();
			this.lGoalName = new System.Windows.Forms.Label();
			this.tGoalName = new System.Windows.Forms.TextBox();
			this.ulvGoalList = new Infragistics.Win.UltraWinListView.UltraListView();
			this.bSave = new System.Windows.Forms.Button();
			this.bNew = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmDeleteTrans = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.lFilterID = new System.Windows.Forms.Label();
			this.lFilterName = new System.Windows.Forms.Label();
			this.bChooseFilter = new System.Windows.Forms.Button();
			this.lGoalEnabled = new System.Windows.Forms.Label();
			this.ckEnabled = new System.Windows.Forms.CheckBox();
			this.lLb = new System.Windows.Forms.Label();
			this.lDollar = new System.Windows.Forms.Label();
			this.lPercent = new System.Windows.Forms.Label();
			this.bGoalProgress = new System.Windows.Forms.Button();
			this.bDisplayFilter = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.pBottomPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ulvGoalList)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.panel1.Controls.Add(this.lTaskName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(765, 45);
			this.panel1.TabIndex = 253;
			// 
			// lTaskName
			// 
			this.lTaskName.Appearance.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
			this.lTaskName.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lTaskName.Appearance.Options.UseFont = true;
			this.lTaskName.Appearance.Options.UseForeColor = true;
			this.lTaskName.Location = new System.Drawing.Point(16, 1);
			this.lTaskName.Name = "lTaskName";
			this.lTaskName.Size = new System.Drawing.Size(204, 35);
			this.lTaskName.TabIndex = 198;
			this.lTaskName.Text = "Manage Goals";
			// 
			// pBottomPanel
			// 
			this.pBottomPanel.Controls.Add(this.bDone);
			this.pBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pBottomPanel.Location = new System.Drawing.Point(0, 533);
			this.pBottomPanel.Name = "pBottomPanel";
			this.pBottomPanel.Size = new System.Drawing.Size(765, 45);
			this.pBottomPanel.TabIndex = 254;
			// 
			// bDone
			// 
			this.bDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bDone.BackColor = System.Drawing.Color.White;
			this.bDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDone.Location = new System.Drawing.Point(639, 7);
			this.bDone.Name = "bDone";
			this.bDone.Size = new System.Drawing.Size(105, 29);
			this.bDone.TabIndex = 250;
			this.bDone.Text = "Done";
			this.bDone.UseVisualStyleBackColor = false;
			this.bDone.Click += new System.EventHandler(this.bDone_Click);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.LightBlue;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(347, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(378, 19);
			this.label3.TabIndex = 314;
			this.label3.Text = "Goal Specifications";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lSitePrefTitle
			// 
			this.lSitePrefTitle.BackColor = System.Drawing.Color.LightBlue;
			this.lSitePrefTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lSitePrefTitle.Location = new System.Drawing.Point(13, 57);
			this.lSitePrefTitle.Name = "lSitePrefTitle";
			this.lSitePrefTitle.Size = new System.Drawing.Size(290, 19);
			this.lSitePrefTitle.TabIndex = 313;
			this.lSitePrefTitle.Text = "Goals List for Current Site";
			this.lSitePrefTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(13, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 16);
			this.label2.TabIndex = 312;
			this.label2.Text = "Goals for [current]:";
			// 
			// lTargetDate
			// 
			this.lTargetDate.AutoSize = true;
			this.lTargetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lTargetDate.Location = new System.Drawing.Point(336, 190);
			this.lTargetDate.Name = "lTargetDate";
			this.lTargetDate.Size = new System.Drawing.Size(164, 16);
			this.lTargetDate.TabIndex = 311;
			this.lTargetDate.Text = "*Targeted Completion:";
			// 
			// dtTargetDate
			// 
			this.dtTargetDate.Location = new System.Drawing.Point(497, 188);
			this.dtTargetDate.Name = "dtTargetDate";
			this.dtTargetDate.Size = new System.Drawing.Size(200, 20);
			this.dtTargetDate.TabIndex = 310;
			this.dtTargetDate.ValueChanged += new System.EventHandler(this.dtTargetDate_ValueChanged);
			// 
			// dtStartDate
			// 
			this.dtStartDate.Location = new System.Drawing.Point(497, 155);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new System.Drawing.Size(200, 20);
			this.dtStartDate.TabIndex = 309;
			this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
			// 
			// lStartDate
			// 
			this.lStartDate.AutoSize = true;
			this.lStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lStartDate.Location = new System.Drawing.Point(413, 157);
			this.lStartDate.Name = "lStartDate";
			this.lStartDate.Size = new System.Drawing.Size(87, 16);
			this.lStartDate.TabIndex = 308;
			this.lStartDate.Text = "*Start Date:";
			// 
			// cbGoalPriority
			// 
			this.cbGoalPriority.FormattingEnabled = true;
			this.cbGoalPriority.Items.AddRange(new object[] {
            "Urgent Priority",
            "High Priority",
            "Medium Priority",
            "Low Priority"});
			this.cbGoalPriority.Location = new System.Drawing.Point(497, 122);
			this.cbGoalPriority.Name = "cbGoalPriority";
			this.cbGoalPriority.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cbGoalPriority.Size = new System.Drawing.Size(146, 21);
			this.cbGoalPriority.TabIndex = 307;
			this.cbGoalPriority.Text = "cbGoalPriority";
			this.cbGoalPriority.SelectedIndexChanged += new System.EventHandler(this.cbGoalPriority_SelectedIndexChanged);
			// 
			// lPriority
			// 
			this.lPriority.AutoSize = true;
			this.lPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lPriority.Location = new System.Drawing.Point(433, 125);
			this.lPriority.Name = "lPriority";
			this.lPriority.Size = new System.Drawing.Size(67, 16);
			this.lPriority.TabIndex = 306;
			this.lPriority.Text = "*Priority:";
			// 
			// cbFilterType
			// 
			this.cbFilterType.FormattingEnabled = true;
			this.cbFilterType.Items.AddRange(new object[] {
            "Food Type Tag Filter",
            "Complex Filter"});
			this.cbFilterType.Location = new System.Drawing.Point(470, 324);
			this.cbFilterType.Name = "cbFilterType";
			this.cbFilterType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cbFilterType.Size = new System.Drawing.Size(166, 21);
			this.cbFilterType.TabIndex = 305;
			this.cbFilterType.Text = "cbFilterType";
			this.cbFilterType.SelectedIndexChanged += new System.EventHandler(this.cbFilterType_SelectedIndexChanged);
			// 
			// lFilterType
			// 
			this.lFilterType.AutoSize = true;
			this.lFilterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFilterType.Location = new System.Drawing.Point(377, 327);
			this.lFilterType.Name = "lFilterType";
			this.lFilterType.Size = new System.Drawing.Size(93, 16);
			this.lFilterType.TabIndex = 304;
			this.lFilterType.Text = "*Filter Type:";
			// 
			// tGoalTarget
			// 
			this.tGoalTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tGoalTarget.Location = new System.Drawing.Point(512, 288);
			this.tGoalTarget.Name = "tGoalTarget";
			this.tGoalTarget.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tGoalTarget.Size = new System.Drawing.Size(92, 21);
			this.tGoalTarget.TabIndex = 303;
			this.tGoalTarget.Text = "tGoalTarget";
			this.tGoalTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tGoalTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tGoalTarget_KeyPress);
			this.tGoalTarget.Validating += new System.ComponentModel.CancelEventHandler(this.tGoalTarget_Validating);
			// 
			// lGoalTarget
			// 
			this.lGoalTarget.AutoSize = true;
			this.lGoalTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lGoalTarget.Location = new System.Drawing.Point(436, 291);
			this.lGoalTarget.Name = "lGoalTarget";
			this.lGoalTarget.Size = new System.Drawing.Size(64, 16);
			this.lGoalTarget.TabIndex = 302;
			this.lGoalTarget.Text = "*Target:";
			// 
			// cbGoalMode
			// 
			this.cbGoalMode.FormattingEnabled = true;
			this.cbGoalMode.Items.AddRange(new object[] {
            "Target Percentage Change",
            "Target Specific Amount"});
			this.cbGoalMode.Location = new System.Drawing.Point(497, 256);
			this.cbGoalMode.Name = "cbGoalMode";
			this.cbGoalMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cbGoalMode.Size = new System.Drawing.Size(167, 21);
			this.cbGoalMode.TabIndex = 301;
			this.cbGoalMode.Text = "cbGoalMode";
			this.cbGoalMode.SelectedIndexChanged += new System.EventHandler(this.cbGoalMode_SelectedIndexChanged);
			// 
			// lGoalMode
			// 
			this.lGoalMode.AutoSize = true;
			this.lGoalMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lGoalMode.Location = new System.Drawing.Point(443, 259);
			this.lGoalMode.Name = "lGoalMode";
			this.lGoalMode.Size = new System.Drawing.Size(57, 16);
			this.lGoalMode.TabIndex = 300;
			this.lGoalMode.Text = "*Mode:";
			// 
			// cbGoalType
			// 
			this.cbGoalType.FormattingEnabled = true;
			this.cbGoalType.Items.AddRange(new object[] {
            "Dollar Amount",
            "Weight Amount"});
			this.cbGoalType.Location = new System.Drawing.Point(497, 221);
			this.cbGoalType.Name = "cbGoalType";
			this.cbGoalType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cbGoalType.Size = new System.Drawing.Size(167, 21);
			this.cbGoalType.TabIndex = 299;
			this.cbGoalType.Text = "cbGoalType";
			this.cbGoalType.SelectedIndexChanged += new System.EventHandler(this.cbGoalMode_SelectedIndexChanged);
			// 
			// lGoalType
			// 
			this.lGoalType.AutoSize = true;
			this.lGoalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lGoalType.Location = new System.Drawing.Point(374, 223);
			this.lGoalType.Name = "lGoalType";
			this.lGoalType.Size = new System.Drawing.Size(126, 16);
			this.lGoalType.TabIndex = 298;
			this.lGoalType.Text = "*Unit of Measure:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(413, 391);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 16);
			this.label1.TabIndex = 297;
			this.label1.Text = "Notes:";
			// 
			// tDescription
			// 
			this.tDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.tDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tDescription.Location = new System.Drawing.Point(470, 388);
			this.tDescription.Multiline = true;
			this.tDescription.Name = "tDescription";
			this.tDescription.Size = new System.Drawing.Size(253, 43);
			this.tDescription.TabIndex = 296;
			this.tDescription.Text = "tDescription";
			this.tDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDescription_KeyPress);
			// 
			// lGoalName
			// 
			this.lGoalName.AutoSize = true;
			this.lGoalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lGoalName.Location = new System.Drawing.Point(347, 90);
			this.lGoalName.Name = "lGoalName";
			this.lGoalName.Size = new System.Drawing.Size(59, 16);
			this.lGoalName.TabIndex = 295;
			this.lGoalName.Text = "*Name:";
			// 
			// tGoalName
			// 
			this.tGoalName.Location = new System.Drawing.Point(406, 89);
			this.tGoalName.Name = "tGoalName";
			this.tGoalName.Size = new System.Drawing.Size(317, 20);
			this.tGoalName.TabIndex = 294;
			this.tGoalName.Text = "tGoalName";
			this.tGoalName.TextChanged += new System.EventHandler(this.tGoalName_TextChanged);
			this.tGoalName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDescription_KeyPress);
			// 
			// ulvGoalList
			// 
			this.ulvGoalList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.ulvGoalList.Location = new System.Drawing.Point(16, 122);
			this.ulvGoalList.MinimumSize = new System.Drawing.Size(0, 124);
			this.ulvGoalList.Name = "ulvGoalList";
			this.ulvGoalList.Size = new System.Drawing.Size(287, 384);
			this.ulvGoalList.TabIndex = 293;
			this.ulvGoalList.Text = "ultraListView1";
			this.ulvGoalList.ItemSelectionChanged += new Infragistics.Win.UltraWinListView.ItemSelectionChangedEventHandler(this.ulvGoalList_ItemSelectionChanged);
			// 
			// bSave
			// 
			this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bSave.Location = new System.Drawing.Point(472, 480);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(109, 31);
			this.bSave.TabIndex = 292;
			this.bSave.Text = "Save Goal";
			this.bSave.UseVisualStyleBackColor = true;
			this.bSave.Click += new System.EventHandler(this.bSave_Click);
			// 
			// bNew
			// 
			this.bNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bNew.Location = new System.Drawing.Point(339, 480);
			this.bNew.Name = "bNew";
			this.bNew.Size = new System.Drawing.Size(109, 31);
			this.bNew.TabIndex = 291;
			this.bNew.Text = "New Goal";
			this.bNew.UseVisualStyleBackColor = true;
			this.bNew.Click += new System.EventHandler(this.bNew_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDeleteTrans});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(131, 26);
			// 
			// tsmDeleteTrans
			// 
			this.tsmDeleteTrans.Name = "tsmDeleteTrans";
			this.tsmDeleteTrans.Size = new System.Drawing.Size(130, 22);
			this.tsmDeleteTrans.Text = "Delete Tag";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "pin_yellow.ico");
			this.imageList1.Images.SetKeyName(1, "pin_red.ico");
			// 
			// lFilterID
			// 
			this.lFilterID.AutoSize = true;
			this.lFilterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFilterID.Location = new System.Drawing.Point(417, 353);
			this.lFilterID.Name = "lFilterID";
			this.lFilterID.Size = new System.Drawing.Size(53, 16);
			this.lFilterID.TabIndex = 317;
			this.lFilterID.Text = "*Filter:";
			// 
			// lFilterName
			// 
			this.lFilterName.AutoSize = true;
			this.lFilterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFilterName.Location = new System.Drawing.Point(468, 354);
			this.lFilterName.Name = "lFilterName";
			this.lFilterName.Size = new System.Drawing.Size(75, 13);
			this.lFilterName.TabIndex = 318;
			this.lFilterName.Text = "(FilterName)";
			// 
			// bChooseFilter
			// 
			this.bChooseFilter.Location = new System.Drawing.Point(648, 323);
			this.bChooseFilter.Name = "bChooseFilter";
			this.bChooseFilter.Size = new System.Drawing.Size(80, 21);
			this.bChooseFilter.TabIndex = 319;
			this.bChooseFilter.Text = "Choose Filter";
			this.bChooseFilter.UseVisualStyleBackColor = true;
			this.bChooseFilter.Click += new System.EventHandler(this.bChooseFilter_Click);
			// 
			// lGoalEnabled
			// 
			this.lGoalEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lGoalEnabled.AutoSize = true;
			this.lGoalEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lGoalEnabled.Location = new System.Drawing.Point(358, 441);
			this.lGoalEnabled.Name = "lGoalEnabled";
			this.lGoalEnabled.Size = new System.Drawing.Size(108, 16);
			this.lGoalEnabled.TabIndex = 320;
			this.lGoalEnabled.Text = "Goal is Active:";
			// 
			// ckEnabled
			// 
			this.ckEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ckEnabled.AutoSize = true;
			this.ckEnabled.Location = new System.Drawing.Point(472, 443);
			this.ckEnabled.Name = "ckEnabled";
			this.ckEnabled.Size = new System.Drawing.Size(15, 14);
			this.ckEnabled.TabIndex = 321;
			this.ckEnabled.UseVisualStyleBackColor = true;
			this.ckEnabled.CheckedChanged += new System.EventHandler(this.ckEnabled_CheckedChanged);
			// 
			// lLb
			// 
			this.lLb.AutoSize = true;
			this.lLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lLb.Location = new System.Drawing.Point(605, 291);
			this.lLb.Name = "lLb";
			this.lLb.Size = new System.Drawing.Size(20, 15);
			this.lLb.TabIndex = 322;
			this.lLb.Text = "lb.";
			// 
			// lDollar
			// 
			this.lDollar.AutoSize = true;
			this.lDollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lDollar.Location = new System.Drawing.Point(496, 291);
			this.lDollar.Name = "lDollar";
			this.lDollar.Size = new System.Drawing.Size(14, 15);
			this.lDollar.TabIndex = 323;
			this.lDollar.Text = "$";
			// 
			// lPercent
			// 
			this.lPercent.AutoSize = true;
			this.lPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lPercent.Location = new System.Drawing.Point(606, 291);
			this.lPercent.Name = "lPercent";
			this.lPercent.Size = new System.Drawing.Size(77, 15);
			this.lPercent.TabIndex = 324;
			this.lPercent.Text = "% Reduction";
			// 
			// bGoalProgress
			// 
			this.bGoalProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bGoalProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bGoalProgress.Location = new System.Drawing.Point(597, 472);
			this.bGoalProgress.Name = "bGoalProgress";
			this.bGoalProgress.Size = new System.Drawing.Size(131, 44);
			this.bGoalProgress.TabIndex = 325;
			this.bGoalProgress.Text = "Goal Progress to Date";
			this.bGoalProgress.UseVisualStyleBackColor = true;
			this.bGoalProgress.Click += new System.EventHandler(this.bGoalProgress_Click);
			// 
			// bDisplayFilter
			// 
			this.bDisplayFilter.Location = new System.Drawing.Point(648, 350);
			this.bDisplayFilter.Name = "bDisplayFilter";
			this.bDisplayFilter.Size = new System.Drawing.Size(80, 21);
			this.bDisplayFilter.TabIndex = 326;
			this.bDisplayFilter.Text = "Show Filter";
			this.bDisplayFilter.UseVisualStyleBackColor = true;
			this.bDisplayFilter.Click += new System.EventHandler(this.bDisplayFilter_Click);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(520, 441);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(200, 15);
			this.label4.TabIndex = 327;
			this.label4.Text = "(* indicates field is required to save)";
			// 
			// UCManageGoals
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lSitePrefTitle);
			this.Controls.Add(this.bDisplayFilter);
			this.Controls.Add(this.lPercent);
			this.Controls.Add(this.lDollar);
			this.Controls.Add(this.ckEnabled);
			this.Controls.Add(this.bGoalProgress);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lLb);
			this.Controls.Add(this.lGoalEnabled);
			this.Controls.Add(this.bChooseFilter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lFilterName);
			this.Controls.Add(this.lFilterID);
			this.Controls.Add(this.ulvGoalList);
			this.Controls.Add(this.lTargetDate);
			this.Controls.Add(this.dtTargetDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtStartDate);
			this.Controls.Add(this.tDescription);
			this.Controls.Add(this.lStartDate);
			this.Controls.Add(this.cbGoalPriority);
			this.Controls.Add(this.cbFilterType);
			this.Controls.Add(this.lPriority);
			this.Controls.Add(this.lFilterType);
			this.Controls.Add(this.tGoalTarget);
			this.Controls.Add(this.cbGoalMode);
			this.Controls.Add(this.lGoalTarget);
			this.Controls.Add(this.lGoalMode);
			this.Controls.Add(this.cbGoalType);
			this.Controls.Add(this.lGoalType);
			this.Controls.Add(this.lGoalName);
			this.Controls.Add(this.bSave);
			this.Controls.Add(this.tGoalName);
			this.Controls.Add(this.pBottomPanel);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.bNew);
			this.Name = "UCManageGoals";
			this.Size = new System.Drawing.Size(765, 578);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pBottomPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ulvGoalList)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private DevExpress.XtraEditors.LabelControl lTaskName;
		private System.Windows.Forms.Panel pBottomPanel;
		private System.Windows.Forms.Button bDone;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lSitePrefTitle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lTargetDate;
		private System.Windows.Forms.DateTimePicker dtTargetDate;
		private System.Windows.Forms.DateTimePicker dtStartDate;
		private System.Windows.Forms.Label lStartDate;
		private System.Windows.Forms.ComboBox cbGoalPriority;
		private System.Windows.Forms.Label lPriority;
		private System.Windows.Forms.ComboBox cbFilterType;
		private System.Windows.Forms.Label lFilterType;
		private System.Windows.Forms.TextBox tGoalTarget;
		private System.Windows.Forms.Label lGoalTarget;
		private System.Windows.Forms.ComboBox cbGoalMode;
		private System.Windows.Forms.Label lGoalMode;
		private System.Windows.Forms.ComboBox cbGoalType;
		private System.Windows.Forms.Label lGoalType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tDescription;
		private System.Windows.Forms.Label lGoalName;
		private System.Windows.Forms.TextBox tGoalName;
		private Infragistics.Win.UltraWinListView.UltraListView ulvGoalList;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.Button bNew;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem tsmDeleteTrans;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lFilterID;
		private System.Windows.Forms.Label lFilterName;
		private System.Windows.Forms.Button bChooseFilter;
		private System.Windows.Forms.Label lGoalEnabled;
		private System.Windows.Forms.CheckBox ckEnabled;
		private System.Windows.Forms.Label lLb;
		private System.Windows.Forms.Label lDollar;
		private System.Windows.Forms.Label lPercent;
		private System.Windows.Forms.Button bGoalProgress;
		private System.Windows.Forms.Button bDisplayFilter;
		private System.Windows.Forms.Label label4;
	}
}
