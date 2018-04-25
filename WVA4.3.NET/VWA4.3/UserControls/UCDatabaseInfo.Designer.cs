namespace UserControls
{
	partial class UCDatabaseInfo
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
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			this.lTaskTitle = new DevExpress.XtraEditors.LabelControl();
			this.lMTTitle = new System.Windows.Forms.Label();
			this.lRateWeeklyPart = new Infragistics.Win.Misc.UltraLabel();
			this.bDone = new Infragistics.Win.Misc.UltraButton();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.lFullpath = new System.Windows.Forms.Label();
			this.lFileSize = new System.Windows.Forms.Label();
			this.pTaskHdr = new System.Windows.Forms.Panel();
			this.ldbv = new System.Windows.Forms.Label();
			this.lDBVersion = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lNumSites = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lNumUserTypes = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lNumLossTypes = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lNumFoodTypes = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lNumDETs = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lNumReports = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lFoodWasteClassesUsed = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.lNonFoodWasteClassesUsed = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.lNonFoodWasteClassesAllowed = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lFoodWasteClassesAllowed = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lMaxReportsAllowed = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.lMaxDETsAllowed = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.lMaxFoodTypesAllowed = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.lMaxLossTypesAllowed = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.lMaxUserTypesAllowed = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.lMaxSitesAllowed = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.lBrowseDB = new Infragistics.Win.Misc.UltraButton();
			this.pTaskHdr.SuspendLayout();
			this.SuspendLayout();
			// 
			// lTaskTitle
			// 
			this.lTaskTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lTaskTitle.Appearance.ForeColor = System.Drawing.Color.Sienna;
			this.lTaskTitle.Appearance.Options.UseFont = true;
			this.lTaskTitle.Appearance.Options.UseForeColor = true;
			this.lTaskTitle.Location = new System.Drawing.Point(3, 3);
			this.lTaskTitle.Name = "lTaskTitle";
			this.lTaskTitle.Size = new System.Drawing.Size(322, 35);
			this.lTaskTitle.TabIndex = 55;
			this.lTaskTitle.Text = "Database Information";
			// 
			// lMTTitle
			// 
			this.lMTTitle.BackColor = System.Drawing.Color.LightBlue;
			this.lMTTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lMTTitle.Location = new System.Drawing.Point(18, 63);
			this.lMTTitle.Name = "lMTTitle";
			this.lMTTitle.Size = new System.Drawing.Size(695, 19);
			this.lMTTitle.TabIndex = 104;
			this.lMTTitle.Text = "Currently Open Database";
			this.lMTTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lRateWeeklyPart
			// 
			appearance3.TextHAlignAsString = "Center";
			appearance3.TextVAlignAsString = "Middle";
			this.lRateWeeklyPart.Appearance = appearance3;
			this.lRateWeeklyPart.AutoSize = true;
			this.lRateWeeklyPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lRateWeeklyPart.Location = new System.Drawing.Point(22, 100);
			this.lRateWeeklyPart.Name = "lRateWeeklyPart";
			this.lRateWeeklyPart.Size = new System.Drawing.Size(166, 17);
			this.lRateWeeklyPart.TabIndex = 105;
			this.lRateWeeklyPart.Text = "Database Full Pathname:";
			// 
			// bDone
			// 
			this.bDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDone.Location = new System.Drawing.Point(608, 468);
			this.bDone.Name = "bDone";
			this.bDone.Size = new System.Drawing.Size(105, 29);
			this.bDone.TabIndex = 152;
			this.bDone.Text = "Done";
			this.bDone.Click += new System.EventHandler(this.bDone_Click);
			// 
			// ultraLabel2
			// 
			appearance1.TextHAlignAsString = "Center";
			appearance1.TextVAlignAsString = "Middle";
			this.ultraLabel2.Appearance = appearance1;
			this.ultraLabel2.AutoSize = true;
			this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ultraLabel2.Location = new System.Drawing.Point(22, 155);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(129, 17);
			this.ultraLabel2.TabIndex = 153;
			this.ultraLabel2.Text = "Database File Size:";
			// 
			// lFullpath
			// 
			this.lFullpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFullpath.Location = new System.Drawing.Point(32, 116);
			this.lFullpath.Name = "lFullpath";
			this.lFullpath.Size = new System.Drawing.Size(681, 36);
			this.lFullpath.TabIndex = 155;
			this.lFullpath.Text = "c:\\\\Program Files\\etcetc";
			// 
			// lFileSize
			// 
			this.lFileSize.AutoSize = true;
			this.lFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFileSize.Location = new System.Drawing.Point(157, 155);
			this.lFileSize.Name = "lFileSize";
			this.lFileSize.Size = new System.Drawing.Size(113, 17);
			this.lFileSize.TabIndex = 156;
			this.lFileSize.Text = "File Size (bytes):";
			// 
			// pTaskHdr
			// 
			this.pTaskHdr.Controls.Add(this.lTaskTitle);
			this.pTaskHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pTaskHdr.Location = new System.Drawing.Point(0, 0);
			this.pTaskHdr.Name = "pTaskHdr";
			this.pTaskHdr.Size = new System.Drawing.Size(727, 45);
			this.pTaskHdr.TabIndex = 158;
			// 
			// ldbv
			// 
			this.ldbv.AutoSize = true;
			this.ldbv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ldbv.Location = new System.Drawing.Point(317, 157);
			this.ldbv.Name = "ldbv";
			this.ldbv.Size = new System.Drawing.Size(142, 17);
			this.ldbv.TabIndex = 159;
			this.ldbv.Text = "Database Version:";
			// 
			// lDBVersion
			// 
			this.lDBVersion.AutoSize = true;
			this.lDBVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lDBVersion.Location = new System.Drawing.Point(465, 157);
			this.lDBVersion.Name = "lDBVersion";
			this.lDBVersion.Size = new System.Drawing.Size(75, 17);
			this.lDBVersion.TabIndex = 160;
			this.lDBVersion.Text = "DBVersion";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.LightBlue;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(18, 186);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(300, 19);
			this.label1.TabIndex = 161;
			this.label1.Text = "Database Properties";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(342, 186);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(316, 19);
			this.label2.TabIndex = 162;
			this.label2.Text = "Licensed Database Properties (Limits)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lNumSites
			// 
			this.lNumSites.AutoSize = true;
			this.lNumSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lNumSites.Location = new System.Drawing.Point(213, 220);
			this.lNumSites.Name = "lNumSites";
			this.lNumSites.Size = new System.Drawing.Size(84, 17);
			this.lNumSites.TabIndex = 164;
			this.lNumSites.Text = "num of sites";
			this.lNumSites.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(32, 220);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(129, 17);
			this.label4.TabIndex = 163;
			this.label4.Text = "Number of Sites:";
			// 
			// lNumUserTypes
			// 
			this.lNumUserTypes.AutoSize = true;
			this.lNumUserTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lNumUserTypes.Location = new System.Drawing.Point(213, 295);
			this.lNumUserTypes.Name = "lNumUserTypes";
			this.lNumUserTypes.Size = new System.Drawing.Size(84, 17);
			this.lNumUserTypes.TabIndex = 166;
			this.lNumUserTypes.Text = "num of sites";
			this.lNumUserTypes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(32, 295);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(176, 17);
			this.label5.TabIndex = 165;
			this.label5.Text = "Number of User Types:";
			// 
			// lNumLossTypes
			// 
			this.lNumLossTypes.AutoSize = true;
			this.lNumLossTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lNumLossTypes.Location = new System.Drawing.Point(213, 270);
			this.lNumLossTypes.Name = "lNumLossTypes";
			this.lNumLossTypes.Size = new System.Drawing.Size(84, 17);
			this.lNumLossTypes.TabIndex = 168;
			this.lNumLossTypes.Text = "num of sites";
			this.lNumLossTypes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(32, 270);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(176, 17);
			this.label7.TabIndex = 167;
			this.label7.Text = "Number of Loss Types:";
			// 
			// lNumFoodTypes
			// 
			this.lNumFoodTypes.AutoSize = true;
			this.lNumFoodTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lNumFoodTypes.Location = new System.Drawing.Point(213, 245);
			this.lNumFoodTypes.Name = "lNumFoodTypes";
			this.lNumFoodTypes.Size = new System.Drawing.Size(84, 17);
			this.lNumFoodTypes.TabIndex = 170;
			this.lNumFoodTypes.Text = "num of sites";
			this.lNumFoodTypes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(32, 245);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(173, 17);
			this.label9.TabIndex = 169;
			this.label9.Text = "Number of Food Types";
			// 
			// lNumDETs
			// 
			this.lNumDETs.AutoSize = true;
			this.lNumDETs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lNumDETs.Location = new System.Drawing.Point(213, 363);
			this.lNumDETs.Name = "lNumDETs";
			this.lNumDETs.Size = new System.Drawing.Size(84, 17);
			this.lNumDETs.TabIndex = 172;
			this.lNumDETs.Text = "num of sites";
			this.lNumDETs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(32, 345);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(250, 17);
			this.label11.TabIndex = 171;
			this.label11.Text = "Number of Data Entry Templates:";
			// 
			// lNumReports
			// 
			this.lNumReports.AutoSize = true;
			this.lNumReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lNumReports.Location = new System.Drawing.Point(213, 319);
			this.lNumReports.Name = "lNumReports";
			this.lNumReports.Size = new System.Drawing.Size(84, 17);
			this.lNumReports.TabIndex = 174;
			this.lNumReports.Text = "num of sites";
			this.lNumReports.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(32, 320);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(150, 17);
			this.label13.TabIndex = 173;
			this.label13.Text = "Number of Reports:";
			// 
			// lFoodWasteClassesUsed
			// 
			this.lFoodWasteClassesUsed.AutoSize = true;
			this.lFoodWasteClassesUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFoodWasteClassesUsed.Location = new System.Drawing.Point(265, 384);
			this.lFoodWasteClassesUsed.Name = "lFoodWasteClassesUsed";
			this.lFoodWasteClassesUsed.Size = new System.Drawing.Size(32, 17);
			this.lFoodWasteClassesUsed.TabIndex = 176;
			this.lFoodWasteClassesUsed.Text = "Yes";
			this.lFoodWasteClassesUsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(32, 384);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(194, 17);
			this.label15.TabIndex = 175;
			this.label15.Text = "Food Waste Types Used?";
			// 
			// lNonFoodWasteClassesUsed
			// 
			this.lNonFoodWasteClassesUsed.AutoSize = true;
			this.lNonFoodWasteClassesUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lNonFoodWasteClassesUsed.Location = new System.Drawing.Point(267, 414);
			this.lNonFoodWasteClassesUsed.Name = "lNonFoodWasteClassesUsed";
			this.lNonFoodWasteClassesUsed.Size = new System.Drawing.Size(26, 17);
			this.lNonFoodWasteClassesUsed.TabIndex = 178;
			this.lNonFoodWasteClassesUsed.Text = "No";
			this.lNonFoodWasteClassesUsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(32, 414);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(229, 17);
			this.label16.TabIndex = 177;
			this.label16.Text = "Non-Food Waste Types Used?";
			// 
			// lNonFoodWasteClassesAllowed
			// 
			this.lNonFoodWasteClassesAllowed.AutoSize = true;
			this.lNonFoodWasteClassesAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lNonFoodWasteClassesAllowed.Location = new System.Drawing.Point(602, 414);
			this.lNonFoodWasteClassesAllowed.Name = "lNonFoodWasteClassesAllowed";
			this.lNonFoodWasteClassesAllowed.Size = new System.Drawing.Size(26, 17);
			this.lNonFoodWasteClassesAllowed.TabIndex = 194;
			this.lNonFoodWasteClassesAllowed.Text = "No";
			this.lNonFoodWasteClassesAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(357, 414);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(247, 17);
			this.label6.TabIndex = 193;
			this.label6.Text = "Non-Food Waste Types Allowed?";
			// 
			// lFoodWasteClassesAllowed
			// 
			this.lFoodWasteClassesAllowed.AutoSize = true;
			this.lFoodWasteClassesAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFoodWasteClassesAllowed.Location = new System.Drawing.Point(596, 384);
			this.lFoodWasteClassesAllowed.Name = "lFoodWasteClassesAllowed";
			this.lFoodWasteClassesAllowed.Size = new System.Drawing.Size(32, 17);
			this.lFoodWasteClassesAllowed.TabIndex = 192;
			this.lFoodWasteClassesAllowed.Text = "Yes";
			this.lFoodWasteClassesAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(357, 384);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(212, 17);
			this.label10.TabIndex = 191;
			this.label10.Text = "Food Waste Types Allowed?";
			// 
			// lMaxReportsAllowed
			// 
			this.lMaxReportsAllowed.AutoSize = true;
			this.lMaxReportsAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lMaxReportsAllowed.Location = new System.Drawing.Point(538, 319);
			this.lMaxReportsAllowed.Name = "lMaxReportsAllowed";
			this.lMaxReportsAllowed.Size = new System.Drawing.Size(84, 17);
			this.lMaxReportsAllowed.TabIndex = 190;
			this.lMaxReportsAllowed.Text = "num of sites";
			this.lMaxReportsAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(357, 320);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(150, 17);
			this.label14.TabIndex = 189;
			this.label14.Text = "Number of Reports:";
			// 
			// lMaxDETsAllowed
			// 
			this.lMaxDETsAllowed.AutoSize = true;
			this.lMaxDETsAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lMaxDETsAllowed.Location = new System.Drawing.Point(538, 363);
			this.lMaxDETsAllowed.Name = "lMaxDETsAllowed";
			this.lMaxDETsAllowed.Size = new System.Drawing.Size(84, 17);
			this.lMaxDETsAllowed.TabIndex = 188;
			this.lMaxDETsAllowed.Text = "num of sites";
			this.lMaxDETsAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.Location = new System.Drawing.Point(357, 345);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(250, 17);
			this.label18.TabIndex = 187;
			this.label18.Text = "Number of Data Entry Templates:";
			// 
			// lMaxFoodTypesAllowed
			// 
			this.lMaxFoodTypesAllowed.AutoSize = true;
			this.lMaxFoodTypesAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lMaxFoodTypesAllowed.Location = new System.Drawing.Point(538, 245);
			this.lMaxFoodTypesAllowed.Name = "lMaxFoodTypesAllowed";
			this.lMaxFoodTypesAllowed.Size = new System.Drawing.Size(84, 17);
			this.lMaxFoodTypesAllowed.TabIndex = 186;
			this.lMaxFoodTypesAllowed.Text = "num of sites";
			this.lMaxFoodTypesAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.Location = new System.Drawing.Point(357, 245);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(173, 17);
			this.label20.TabIndex = 185;
			this.label20.Text = "Number of Food Types";
			// 
			// lMaxLossTypesAllowed
			// 
			this.lMaxLossTypesAllowed.AutoSize = true;
			this.lMaxLossTypesAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lMaxLossTypesAllowed.Location = new System.Drawing.Point(538, 270);
			this.lMaxLossTypesAllowed.Name = "lMaxLossTypesAllowed";
			this.lMaxLossTypesAllowed.Size = new System.Drawing.Size(84, 17);
			this.lMaxLossTypesAllowed.TabIndex = 184;
			this.lMaxLossTypesAllowed.Text = "num of sites";
			this.lMaxLossTypesAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.Location = new System.Drawing.Point(357, 270);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(176, 17);
			this.label22.TabIndex = 183;
			this.label22.Text = "Number of Loss Types:";
			// 
			// lMaxUserTypesAllowed
			// 
			this.lMaxUserTypesAllowed.AutoSize = true;
			this.lMaxUserTypesAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lMaxUserTypesAllowed.Location = new System.Drawing.Point(538, 295);
			this.lMaxUserTypesAllowed.Name = "lMaxUserTypesAllowed";
			this.lMaxUserTypesAllowed.Size = new System.Drawing.Size(84, 17);
			this.lMaxUserTypesAllowed.TabIndex = 182;
			this.lMaxUserTypesAllowed.Text = "num of sites";
			this.lMaxUserTypesAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.Location = new System.Drawing.Point(357, 295);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(176, 17);
			this.label24.TabIndex = 181;
			this.label24.Text = "Number of User Types:";
			// 
			// lMaxSitesAllowed
			// 
			this.lMaxSitesAllowed.AutoSize = true;
			this.lMaxSitesAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lMaxSitesAllowed.Location = new System.Drawing.Point(538, 220);
			this.lMaxSitesAllowed.Name = "lMaxSitesAllowed";
			this.lMaxSitesAllowed.Size = new System.Drawing.Size(84, 17);
			this.lMaxSitesAllowed.TabIndex = 180;
			this.lMaxSitesAllowed.Text = "num of sites";
			this.lMaxSitesAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label26.Location = new System.Drawing.Point(357, 220);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(129, 17);
			this.label26.TabIndex = 179;
			this.label26.Text = "Number of Sites:";
			// 
			// lBrowseDB
			// 
			this.lBrowseDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lBrowseDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lBrowseDB.Location = new System.Drawing.Point(21, 468);
			this.lBrowseDB.Name = "lBrowseDB";
			this.lBrowseDB.Size = new System.Drawing.Size(154, 29);
			this.lBrowseDB.TabIndex = 195;
			this.lBrowseDB.Text = "Browse for Database";
			this.lBrowseDB.Click += new System.EventHandler(this.lBrowseDB_Click);
			// 
			// UCDatabaseInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lBrowseDB);
			this.Controls.Add(this.lNonFoodWasteClassesAllowed);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lFoodWasteClassesAllowed);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.lMaxReportsAllowed);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.lMaxDETsAllowed);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.lMaxFoodTypesAllowed);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.lMaxLossTypesAllowed);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.lMaxUserTypesAllowed);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.lMaxSitesAllowed);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.lNonFoodWasteClassesUsed);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.lFoodWasteClassesUsed);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.lNumReports);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.lNumDETs);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.lNumFoodTypes);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.lNumLossTypes);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lNumUserTypes);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lNumSites);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lDBVersion);
			this.Controls.Add(this.ldbv);
			this.Controls.Add(this.lFileSize);
			this.Controls.Add(this.lFullpath);
			this.Controls.Add(this.ultraLabel2);
			this.Controls.Add(this.bDone);
			this.Controls.Add(this.lRateWeeklyPart);
			this.Controls.Add(this.lMTTitle);
			this.Controls.Add(this.pTaskHdr);
			this.Name = "UCDatabaseInfo";
			this.Size = new System.Drawing.Size(727, 512);
			this.pTaskHdr.ResumeLayout(false);
			this.pTaskHdr.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl lTaskTitle;
		private System.Windows.Forms.Label lMTTitle;
		private Infragistics.Win.Misc.UltraLabel lRateWeeklyPart;
		private Infragistics.Win.Misc.UltraButton bDone;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private System.Windows.Forms.Label lFullpath;
		private System.Windows.Forms.Label lFileSize;
		private System.Windows.Forms.Panel pTaskHdr;
		private System.Windows.Forms.Label ldbv;
		private System.Windows.Forms.Label lDBVersion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lNumSites;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lNumUserTypes;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lNumLossTypes;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lNumFoodTypes;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lNumDETs;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lNumReports;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lFoodWasteClassesUsed;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label lNonFoodWasteClassesUsed;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lNonFoodWasteClassesAllowed;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lFoodWasteClassesAllowed;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lMaxReportsAllowed;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lMaxDETsAllowed;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lMaxFoodTypesAllowed;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label lMaxLossTypesAllowed;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label lMaxUserTypesAllowed;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label lMaxSitesAllowed;
		private System.Windows.Forms.Label label26;
		private Infragistics.Win.Misc.UltraButton lBrowseDB;
	}
}
