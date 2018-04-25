namespace UserControls
{
    partial class UCEditEventOrder
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
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.nGuestNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEventNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpanishName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nRatio = new System.Windows.Forms.NumericUpDown();
            this.nRank = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ucTreeView1 = new UserControls.UCTreeView(false, true);
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucSiteChooser1 = new UserControls.UCSiteChooser();
            this.dtEventDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGuestNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRank)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(208, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "%";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.nGuestNumber);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtEventNumber);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtSpanishName);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtReportName);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.nRatio);
            this.panel3.Controls.Add(this.nRank);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.chkEnabled);
            this.panel3.Controls.Add(this.txtDescription);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 234);
            this.panel3.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Report Name:";
            // 
            // nGuestNumber
            // 
            this.nGuestNumber.Location = new System.Drawing.Point(103, 184);
            this.nGuestNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nGuestNumber.Name = "nGuestNumber";
            this.nGuestNumber.Size = new System.Drawing.Size(120, 20);
            this.nGuestNumber.TabIndex = 9;
            this.nGuestNumber.ValueChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // txtEventNumber
            // 
            this.txtEventNumber.Location = new System.Drawing.Point(103, 162);
            this.txtEventNumber.Name = "txtEventNumber";
            this.txtEventNumber.Size = new System.Drawing.Size(120, 20);
            this.txtEventNumber.TabIndex = 8;
            this.txtEventNumber.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description:";
            // 
            // txtSpanishName
            // 
            this.txtSpanishName.Location = new System.Drawing.Point(103, 49);
            this.txtSpanishName.Name = "txtSpanishName";
            this.txtSpanishName.Size = new System.Drawing.Size(120, 20);
            this.txtSpanishName.TabIndex = 4;
            this.txtSpanishName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Event Number:";
            // 
            // txtReportName
            // 
            this.txtReportName.Location = new System.Drawing.Point(103, 26);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(120, 20);
            this.txtReportName.TabIndex = 3;
            this.txtReportName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Number of Guests:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(103, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Spanish Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Rank:";
            // 
            // nRatio
            // 
            this.nRatio.DecimalPlaces = 4;
            this.nRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRatio.Location = new System.Drawing.Point(103, 207);
            this.nRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nRatio.Name = "nRatio";
            this.nRatio.Size = new System.Drawing.Size(101, 20);
            this.nRatio.TabIndex = 10;
            this.nRatio.ValueChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // nRank
            // 
            this.nRank.Location = new System.Drawing.Point(103, 72);
            this.nRank.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nRank.Name = "nRank";
            this.nRank.Size = new System.Drawing.Size(120, 20);
            this.nRank.TabIndex = 5;
            this.nRank.ValueChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Male Ratio:";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(103, 95);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 6;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(103, 118);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(120, 41);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.Text = "";
            this.txtDescription.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Event Date:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 285);
            this.panel2.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ucTreeView1);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(459, 234);
            this.panel5.TabIndex = 28;
            // 
            // ucTreeView1
            // 
            this.ucTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTreeView1.EnableCheckboxes = false;
            this.ucTreeView1.Location = new System.Drawing.Point(231, 0);
            this.ucTreeView1.Name = "ucTreeView1";
            this.ucTreeView1.ShowPrice = false;
            this.ucTreeView1.Size = new System.Drawing.Size(228, 234);
            this.ucTreeView1.TabIndex = 12;
            this.ucTreeView1.TreeViewIDChanged += new UserControls.UCTreeView.TreeViewIDChangedEventHandler(this.ucTreeView1_TreeViewIDChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.ucSiteChooser1);
            this.panel4.Controls.Add(this.dtEventDate);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(459, 28);
            this.panel4.TabIndex = 27;
            // 
            // ucSiteChooser1
            // 
            this.ucSiteChooser1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSiteChooser1.Location = new System.Drawing.Point(367, 3);
            this.ucSiteChooser1.Name = "ucSiteChooser1";
            this.ucSiteChooser1.Size = new System.Drawing.Size(88, 22);
            this.ucSiteChooser1.TabIndex = 1;
            this.ucSiteChooser1.SiteChanged += new UserControls.UCSiteChooser.SiteChangedEventHandler(this.ucSiteChooser1_SiteChanged);
            // 
            // dtEventDate
            // 
            this.dtEventDate.Location = new System.Drawing.Point(74, 3);
            this.dtEventDate.Name = "dtEventDate";
            this.dtEventDate.Size = new System.Drawing.Size(149, 20);
            this.dtEventDate.TabIndex = 16;
            this.dtEventDate.ValueChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 23);
            this.panel1.TabIndex = 26;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Enabled = false;
            this.btnNew.Location = new System.Drawing.Point(3, -1);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "Add New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(379, -1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(298, -1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(337, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Site:";
            // 
            // UCEditEventOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "UCEditEventOrder";
            this.Size = new System.Drawing.Size(459, 285);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nGuestNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRank)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nGuestNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEventNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSpanishName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nRatio;
        private System.Windows.Forms.NumericUpDown nRank;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private UCTreeView ucTreeView1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private UCSiteChooser ucSiteChooser1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker dtEventDate;
        private System.Windows.Forms.Label label11;


    }
}
