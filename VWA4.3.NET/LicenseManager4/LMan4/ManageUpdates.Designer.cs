namespace LMan4
{
    partial class frmManageUpdates
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
            this.grpUpdateSeries = new System.Windows.Forms.GroupBox();
            this.lstUpdateSeries = new System.Windows.Forms.ListBox();
            this.grpUpdates = new System.Windows.Forms.GroupBox();
            this.lstUpdates = new System.Windows.Forms.ListBox();
            this.grpEditUpdateSeries = new System.Windows.Forms.GroupBox();
            this.pnlEditUpdateSeries = new System.Windows.Forms.Panel();
            this.btnNewSeries = new System.Windows.Forms.Button();
            this.lstSeriesVersions = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveUpdateSeries = new System.Windows.Forms.Button();
            this.lblSeriesDateModified = new System.Windows.Forms.Label();
            this.lblDateModified = new System.Windows.Forms.Label();
            this.lblSeriesDateCreated = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.txtSeriesDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtSeriesName = new System.Windows.Forms.TextBox();
            this.lblSeriesName = new System.Windows.Forms.Label();
            this.grpEditUpdate = new System.Windows.Forms.GroupBox();
            this.pnlEditUpdate = new System.Windows.Forms.Panel();
            this.btnNewUpdate = new System.Windows.Forms.Button();
            this.btnDeleteUpdate = new System.Windows.Forms.Button();
            this.btnUpdateSave = new System.Windows.Forms.Button();
            this.updateType = new System.Windows.Forms.TabControl();
            this.tabInfoMessage = new System.Windows.Forms.TabPage();
            this.txtInfoMessage = new System.Windows.Forms.RichTextBox();
            this.lblInfoMessage = new System.Windows.Forms.Label();
            this.tabHotFix = new System.Windows.Forms.TabPage();
            this.grdFiles = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHotFixBrowse = new System.Windows.Forms.Button();
            this.lblUpdateFileName = new System.Windows.Forms.Label();
            this.tabUpgrade = new System.Windows.Forms.TabPage();
            this.btnUpdateBrowse = new System.Windows.Forms.Button();
            this.txtUpdatePackageFilePath = new System.Windows.Forms.TextBox();
            this.lblUpdatePackage = new System.Windows.Forms.Label();
            this.lblUpdateDateModified = new System.Windows.Forms.Label();
            this.txtUpdateDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUpdateDescription = new System.Windows.Forms.Label();
            this.lblUpdateDateCreated = new System.Windows.Forms.Label();
            this.txtUpdateName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUpdateName = new System.Windows.Forms.Label();
            this.grpVersions = new System.Windows.Forms.GroupBox();
            this.lstVersions = new System.Windows.Forms.ListBox();
            this.btnAddVersion = new System.Windows.Forms.Button();
            this.txtNewVersionName = new System.Windows.Forms.TextBox();
            this.lblNewVersion = new System.Windows.Forms.Label();
            this.grpUpdateSeries.SuspendLayout();
            this.grpUpdates.SuspendLayout();
            this.grpEditUpdateSeries.SuspendLayout();
            this.pnlEditUpdateSeries.SuspendLayout();
            this.grpEditUpdate.SuspendLayout();
            this.pnlEditUpdate.SuspendLayout();
            this.updateType.SuspendLayout();
            this.tabInfoMessage.SuspendLayout();
            this.tabHotFix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFiles)).BeginInit();
            this.tabUpgrade.SuspendLayout();
            this.grpVersions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUpdateSeries
            // 
            this.grpUpdateSeries.Controls.Add(this.lstUpdateSeries);
            this.grpUpdateSeries.Location = new System.Drawing.Point(599, 4);
            this.grpUpdateSeries.Name = "grpUpdateSeries";
            this.grpUpdateSeries.Size = new System.Drawing.Size(264, 171);
            this.grpUpdateSeries.TabIndex = 0;
            this.grpUpdateSeries.TabStop = false;
            this.grpUpdateSeries.Text = "Update Series";
            // 
            // lstUpdateSeries
            // 
            this.lstUpdateSeries.FormattingEnabled = true;
            this.lstUpdateSeries.Location = new System.Drawing.Point(7, 20);
            this.lstUpdateSeries.Name = "lstUpdateSeries";
            this.lstUpdateSeries.Size = new System.Drawing.Size(251, 147);
            this.lstUpdateSeries.TabIndex = 0;
            this.lstUpdateSeries.SelectedIndexChanged += new System.EventHandler(this.lstUpdateSeries_SelectedIndexChanged);
            // 
            // grpUpdates
            // 
            this.grpUpdates.Controls.Add(this.lstUpdates);
            this.grpUpdates.Location = new System.Drawing.Point(599, 181);
            this.grpUpdates.Name = "grpUpdates";
            this.grpUpdates.Size = new System.Drawing.Size(264, 206);
            this.grpUpdates.TabIndex = 1;
            this.grpUpdates.TabStop = false;
            this.grpUpdates.Text = "Updates";
            // 
            // lstUpdates
            // 
            this.lstUpdates.FormattingEnabled = true;
            this.lstUpdates.Location = new System.Drawing.Point(7, 20);
            this.lstUpdates.Name = "lstUpdates";
            this.lstUpdates.Size = new System.Drawing.Size(251, 173);
            this.lstUpdates.TabIndex = 0;
            this.lstUpdates.SelectedIndexChanged += new System.EventHandler(this.lstUpdate_SelectedIndexChanged);
            // 
            // grpEditUpdateSeries
            // 
            this.grpEditUpdateSeries.Controls.Add(this.pnlEditUpdateSeries);
            this.grpEditUpdateSeries.Location = new System.Drawing.Point(13, 4);
            this.grpEditUpdateSeries.Name = "grpEditUpdateSeries";
            this.grpEditUpdateSeries.Size = new System.Drawing.Size(580, 198);
            this.grpEditUpdateSeries.TabIndex = 2;
            this.grpEditUpdateSeries.TabStop = false;
            this.grpEditUpdateSeries.Text = "Create/Edit Update Series";
            // 
            // pnlEditUpdateSeries
            // 
            this.pnlEditUpdateSeries.Controls.Add(this.btnNewSeries);
            this.pnlEditUpdateSeries.Controls.Add(this.lstSeriesVersions);
            this.pnlEditUpdateSeries.Controls.Add(this.label1);
            this.pnlEditUpdateSeries.Controls.Add(this.btnDelete);
            this.pnlEditUpdateSeries.Controls.Add(this.btnSaveUpdateSeries);
            this.pnlEditUpdateSeries.Controls.Add(this.lblSeriesDateModified);
            this.pnlEditUpdateSeries.Controls.Add(this.lblDateModified);
            this.pnlEditUpdateSeries.Controls.Add(this.lblSeriesDateCreated);
            this.pnlEditUpdateSeries.Controls.Add(this.lblDateCreated);
            this.pnlEditUpdateSeries.Controls.Add(this.txtSeriesDescription);
            this.pnlEditUpdateSeries.Controls.Add(this.lblDescription);
            this.pnlEditUpdateSeries.Controls.Add(this.txtSeriesName);
            this.pnlEditUpdateSeries.Controls.Add(this.lblSeriesName);
            this.pnlEditUpdateSeries.Location = new System.Drawing.Point(7, 20);
            this.pnlEditUpdateSeries.Name = "pnlEditUpdateSeries";
            this.pnlEditUpdateSeries.Size = new System.Drawing.Size(567, 171);
            this.pnlEditUpdateSeries.TabIndex = 0;
            // 
            // btnNewSeries
            // 
            this.btnNewSeries.Location = new System.Drawing.Point(391, 142);
            this.btnNewSeries.Name = "btnNewSeries";
            this.btnNewSeries.Size = new System.Drawing.Size(52, 23);
            this.btnNewSeries.TabIndex = 12;
            this.btnNewSeries.Text = "New";
            this.btnNewSeries.UseVisualStyleBackColor = true;
            this.btnNewSeries.Click += new System.EventHandler(this.btnNewSeries_Click);
            // 
            // lstSeriesVersions
            // 
            this.lstSeriesVersions.FormattingEnabled = true;
            this.lstSeriesVersions.Location = new System.Drawing.Point(94, 101);
            this.lstSeriesVersions.Name = "lstSeriesVersions";
            this.lstSeriesVersions.Size = new System.Drawing.Size(280, 64);
            this.lstSeriesVersions.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Versions:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(507, 142);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(52, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSaveUpdateSeries
            // 
            this.btnSaveUpdateSeries.Location = new System.Drawing.Point(449, 142);
            this.btnSaveUpdateSeries.Name = "btnSaveUpdateSeries";
            this.btnSaveUpdateSeries.Size = new System.Drawing.Size(52, 23);
            this.btnSaveUpdateSeries.TabIndex = 8;
            this.btnSaveUpdateSeries.Text = "Save";
            this.btnSaveUpdateSeries.UseVisualStyleBackColor = true;
            this.btnSaveUpdateSeries.Click += new System.EventHandler(this.btnSaveUpdateSeries_Click);
            // 
            // lblSeriesDateModified
            // 
            this.lblSeriesDateModified.AutoSize = true;
            this.lblSeriesDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesDateModified.Location = new System.Drawing.Point(485, 36);
            this.lblSeriesDateModified.Name = "lblSeriesDateModified";
            this.lblSeriesDateModified.Size = new System.Drawing.Size(79, 15);
            this.lblSeriesDateModified.TabIndex = 7;
            this.lblSeriesDateModified.Text = "01/14/2011";
            // 
            // lblDateModified
            // 
            this.lblDateModified.AutoSize = true;
            this.lblDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateModified.Location = new System.Drawing.Point(390, 36);
            this.lblDateModified.Name = "lblDateModified";
            this.lblDateModified.Size = new System.Drawing.Size(101, 15);
            this.lblDateModified.TabIndex = 6;
            this.lblDateModified.Text = "Date Modified:";
            // 
            // lblSeriesDateCreated
            // 
            this.lblSeriesDateCreated.AutoSize = true;
            this.lblSeriesDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesDateCreated.Location = new System.Drawing.Point(485, 5);
            this.lblSeriesDateCreated.Name = "lblSeriesDateCreated";
            this.lblSeriesDateCreated.Size = new System.Drawing.Size(79, 15);
            this.lblSeriesDateCreated.TabIndex = 5;
            this.lblSeriesDateCreated.Text = "01/14/2011";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCreated.Location = new System.Drawing.Point(390, 4);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(95, 15);
            this.lblDateCreated.TabIndex = 4;
            this.lblDateCreated.Text = "Date Created:";
            // 
            // txtSeriesDescription
            // 
            this.txtSeriesDescription.Location = new System.Drawing.Point(94, 36);
            this.txtSeriesDescription.Multiline = true;
            this.txtSeriesDescription.Name = "txtSeriesDescription";
            this.txtSeriesDescription.Size = new System.Drawing.Size(281, 54);
            this.txtSeriesDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(4, 36);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(84, 15);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtSeriesName
            // 
            this.txtSeriesName.Location = new System.Drawing.Point(94, 4);
            this.txtSeriesName.Name = "txtSeriesName";
            this.txtSeriesName.Size = new System.Drawing.Size(281, 20);
            this.txtSeriesName.TabIndex = 1;
            // 
            // lblSeriesName
            // 
            this.lblSeriesName.AutoSize = true;
            this.lblSeriesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesName.Location = new System.Drawing.Point(39, 4);
            this.lblSeriesName.Name = "lblSeriesName";
            this.lblSeriesName.Size = new System.Drawing.Size(49, 15);
            this.lblSeriesName.TabIndex = 0;
            this.lblSeriesName.Text = "Name:";
            // 
            // grpEditUpdate
            // 
            this.grpEditUpdate.Controls.Add(this.pnlEditUpdate);
            this.grpEditUpdate.Location = new System.Drawing.Point(13, 201);
            this.grpEditUpdate.Name = "grpEditUpdate";
            this.grpEditUpdate.Size = new System.Drawing.Size(580, 383);
            this.grpEditUpdate.TabIndex = 3;
            this.grpEditUpdate.TabStop = false;
            this.grpEditUpdate.Text = "Created/Edit Update";
            // 
            // pnlEditUpdate
            // 
            this.pnlEditUpdate.Controls.Add(this.btnNewUpdate);
            this.pnlEditUpdate.Controls.Add(this.btnDeleteUpdate);
            this.pnlEditUpdate.Controls.Add(this.btnUpdateSave);
            this.pnlEditUpdate.Controls.Add(this.updateType);
            this.pnlEditUpdate.Controls.Add(this.lblUpdateDateModified);
            this.pnlEditUpdate.Controls.Add(this.txtUpdateDescription);
            this.pnlEditUpdate.Controls.Add(this.label2);
            this.pnlEditUpdate.Controls.Add(this.lblUpdateDescription);
            this.pnlEditUpdate.Controls.Add(this.lblUpdateDateCreated);
            this.pnlEditUpdate.Controls.Add(this.txtUpdateName);
            this.pnlEditUpdate.Controls.Add(this.label4);
            this.pnlEditUpdate.Controls.Add(this.lblUpdateName);
            this.pnlEditUpdate.Location = new System.Drawing.Point(7, 20);
            this.pnlEditUpdate.Name = "pnlEditUpdate";
            this.pnlEditUpdate.Size = new System.Drawing.Size(567, 357);
            this.pnlEditUpdate.TabIndex = 0;
            // 
            // btnNewUpdate
            // 
            this.btnNewUpdate.Location = new System.Drawing.Point(391, 324);
            this.btnNewUpdate.Name = "btnNewUpdate";
            this.btnNewUpdate.Size = new System.Drawing.Size(52, 23);
            this.btnNewUpdate.TabIndex = 13;
            this.btnNewUpdate.Text = "New";
            this.btnNewUpdate.UseVisualStyleBackColor = true;
            this.btnNewUpdate.Click += new System.EventHandler(this.btnNewUpdate_Click);
            // 
            // btnDeleteUpdate
            // 
            this.btnDeleteUpdate.Location = new System.Drawing.Point(507, 324);
            this.btnDeleteUpdate.Name = "btnDeleteUpdate";
            this.btnDeleteUpdate.Size = new System.Drawing.Size(52, 23);
            this.btnDeleteUpdate.TabIndex = 20;
            this.btnDeleteUpdate.Text = "Delete";
            this.btnDeleteUpdate.UseVisualStyleBackColor = true;
            this.btnDeleteUpdate.Click += new System.EventHandler(this.btnDeleteUpdate_Click);
            // 
            // btnUpdateSave
            // 
            this.btnUpdateSave.Location = new System.Drawing.Point(449, 324);
            this.btnUpdateSave.Name = "btnUpdateSave";
            this.btnUpdateSave.Size = new System.Drawing.Size(52, 23);
            this.btnUpdateSave.TabIndex = 19;
            this.btnUpdateSave.Text = "Save";
            this.btnUpdateSave.UseVisualStyleBackColor = true;
            this.btnUpdateSave.Click += new System.EventHandler(this.btnUpdateSave_Click);
            // 
            // updateType
            // 
            this.updateType.Controls.Add(this.tabInfoMessage);
            this.updateType.Controls.Add(this.tabHotFix);
            this.updateType.Controls.Add(this.tabUpgrade);
            this.updateType.Location = new System.Drawing.Point(7, 101);
            this.updateType.Name = "updateType";
            this.updateType.SelectedIndex = 0;
            this.updateType.Size = new System.Drawing.Size(556, 217);
            this.updateType.TabIndex = 18;
            // 
            // tabInfoMessage
            // 
            this.tabInfoMessage.Controls.Add(this.txtInfoMessage);
            this.tabInfoMessage.Controls.Add(this.lblInfoMessage);
            this.tabInfoMessage.Location = new System.Drawing.Point(4, 22);
            this.tabInfoMessage.Name = "tabInfoMessage";
            this.tabInfoMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfoMessage.Size = new System.Drawing.Size(548, 191);
            this.tabInfoMessage.TabIndex = 0;
            this.tabInfoMessage.Text = "Info Message";
            this.tabInfoMessage.UseVisualStyleBackColor = true;
            // 
            // txtInfoMessage
            // 
            this.txtInfoMessage.Location = new System.Drawing.Point(7, 22);
            this.txtInfoMessage.Name = "txtInfoMessage";
            this.txtInfoMessage.Size = new System.Drawing.Size(535, 134);
            this.txtInfoMessage.TabIndex = 22;
            this.txtInfoMessage.Text = "";
            // 
            // lblInfoMessage
            // 
            this.lblInfoMessage.AutoSize = true;
            this.lblInfoMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoMessage.Location = new System.Drawing.Point(3, 3);
            this.lblInfoMessage.Name = "lblInfoMessage";
            this.lblInfoMessage.Size = new System.Drawing.Size(97, 15);
            this.lblInfoMessage.TabIndex = 21;
            this.lblInfoMessage.Text = "Info Message:";
            // 
            // tabHotFix
            // 
            this.tabHotFix.Controls.Add(this.grdFiles);
            this.tabHotFix.Controls.Add(this.label3);
            this.tabHotFix.Controls.Add(this.btnHotFixBrowse);
            this.tabHotFix.Controls.Add(this.lblUpdateFileName);
            this.tabHotFix.Location = new System.Drawing.Point(4, 22);
            this.tabHotFix.Name = "tabHotFix";
            this.tabHotFix.Padding = new System.Windows.Forms.Padding(3);
            this.tabHotFix.Size = new System.Drawing.Size(548, 191);
            this.tabHotFix.TabIndex = 1;
            this.tabHotFix.Text = "Hot Fix";
            this.tabHotFix.UseVisualStyleBackColor = true;
            // 
            // grdFiles
            // 
            this.grdFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFiles.Location = new System.Drawing.Point(7, 35);
            this.grdFiles.Name = "grdFiles";
            this.grdFiles.Size = new System.Drawing.Size(535, 150);
            this.grdFiles.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(283, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Install Path:";
            // 
            // btnHotFixBrowse
            // 
            this.btnHotFixBrowse.Location = new System.Drawing.Point(83, 6);
            this.btnHotFixBrowse.Name = "btnHotFixBrowse";
            this.btnHotFixBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnHotFixBrowse.TabIndex = 23;
            this.btnHotFixBrowse.Text = "Browse";
            this.btnHotFixBrowse.UseVisualStyleBackColor = true;
            this.btnHotFixBrowse.Click += new System.EventHandler(this.btnHotFixBrowse_Click);
            // 
            // lblUpdateFileName
            // 
            this.lblUpdateFileName.AutoSize = true;
            this.lblUpdateFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateFileName.Location = new System.Drawing.Point(3, 9);
            this.lblUpdateFileName.Name = "lblUpdateFileName";
            this.lblUpdateFileName.Size = new System.Drawing.Size(79, 15);
            this.lblUpdateFileName.TabIndex = 21;
            this.lblUpdateFileName.Text = "Select File:";
            // 
            // tabUpgrade
            // 
            this.tabUpgrade.Controls.Add(this.btnUpdateBrowse);
            this.tabUpgrade.Controls.Add(this.txtUpdatePackageFilePath);
            this.tabUpgrade.Controls.Add(this.lblUpdatePackage);
            this.tabUpgrade.Location = new System.Drawing.Point(4, 22);
            this.tabUpgrade.Name = "tabUpgrade";
            this.tabUpgrade.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpgrade.Size = new System.Drawing.Size(548, 191);
            this.tabUpgrade.TabIndex = 2;
            this.tabUpgrade.Text = "Upgrade";
            this.tabUpgrade.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBrowse
            // 
            this.btnUpdateBrowse.Location = new System.Drawing.Point(369, 21);
            this.btnUpdateBrowse.Name = "btnUpdateBrowse";
            this.btnUpdateBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateBrowse.TabIndex = 25;
            this.btnUpdateBrowse.Text = "Browse";
            this.btnUpdateBrowse.UseVisualStyleBackColor = true;
            // 
            // txtUpdatePackageFilePath
            // 
            this.txtUpdatePackageFilePath.Location = new System.Drawing.Point(13, 21);
            this.txtUpdatePackageFilePath.Name = "txtUpdatePackageFilePath";
            this.txtUpdatePackageFilePath.Size = new System.Drawing.Size(350, 20);
            this.txtUpdatePackageFilePath.TabIndex = 24;
            // 
            // lblUpdatePackage
            // 
            this.lblUpdatePackage.AutoSize = true;
            this.lblUpdatePackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatePackage.Location = new System.Drawing.Point(3, 3);
            this.lblUpdatePackage.Name = "lblUpdatePackage";
            this.lblUpdatePackage.Size = new System.Drawing.Size(160, 15);
            this.lblUpdatePackage.TabIndex = 23;
            this.lblUpdatePackage.Text = "Select Update Package:";
            // 
            // lblUpdateDateModified
            // 
            this.lblUpdateDateModified.AutoSize = true;
            this.lblUpdateDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateDateModified.Location = new System.Drawing.Point(485, 41);
            this.lblUpdateDateModified.Name = "lblUpdateDateModified";
            this.lblUpdateDateModified.Size = new System.Drawing.Size(79, 15);
            this.lblUpdateDateModified.TabIndex = 13;
            this.lblUpdateDateModified.Text = "01/14/2011";
            // 
            // txtUpdateDescription
            // 
            this.txtUpdateDescription.Location = new System.Drawing.Point(94, 41);
            this.txtUpdateDescription.Multiline = true;
            this.txtUpdateDescription.Name = "txtUpdateDescription";
            this.txtUpdateDescription.Size = new System.Drawing.Size(281, 54);
            this.txtUpdateDescription.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(390, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Date Modified:";
            // 
            // lblUpdateDescription
            // 
            this.lblUpdateDescription.AutoSize = true;
            this.lblUpdateDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateDescription.Location = new System.Drawing.Point(4, 41);
            this.lblUpdateDescription.Name = "lblUpdateDescription";
            this.lblUpdateDescription.Size = new System.Drawing.Size(84, 15);
            this.lblUpdateDescription.TabIndex = 6;
            this.lblUpdateDescription.Text = "Description:";
            // 
            // lblUpdateDateCreated
            // 
            this.lblUpdateDateCreated.AutoSize = true;
            this.lblUpdateDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateDateCreated.Location = new System.Drawing.Point(485, 10);
            this.lblUpdateDateCreated.Name = "lblUpdateDateCreated";
            this.lblUpdateDateCreated.Size = new System.Drawing.Size(79, 15);
            this.lblUpdateDateCreated.TabIndex = 11;
            this.lblUpdateDateCreated.Text = "01/14/2011";
            // 
            // txtUpdateName
            // 
            this.txtUpdateName.Location = new System.Drawing.Point(94, 9);
            this.txtUpdateName.Name = "txtUpdateName";
            this.txtUpdateName.Size = new System.Drawing.Size(281, 20);
            this.txtUpdateName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(390, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date Created:";
            // 
            // lblUpdateName
            // 
            this.lblUpdateName.AutoSize = true;
            this.lblUpdateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateName.Location = new System.Drawing.Point(39, 9);
            this.lblUpdateName.Name = "lblUpdateName";
            this.lblUpdateName.Size = new System.Drawing.Size(49, 15);
            this.lblUpdateName.TabIndex = 4;
            this.lblUpdateName.Text = "Name:";
            // 
            // grpVersions
            // 
            this.grpVersions.Controls.Add(this.lstVersions);
            this.grpVersions.Controls.Add(this.btnAddVersion);
            this.grpVersions.Controls.Add(this.txtNewVersionName);
            this.grpVersions.Controls.Add(this.lblNewVersion);
            this.grpVersions.Location = new System.Drawing.Point(600, 393);
            this.grpVersions.Name = "grpVersions";
            this.grpVersions.Size = new System.Drawing.Size(263, 185);
            this.grpVersions.TabIndex = 4;
            this.grpVersions.TabStop = false;
            this.grpVersions.Text = "Versions";
            // 
            // lstVersions
            // 
            this.lstVersions.FormattingEnabled = true;
            this.lstVersions.Location = new System.Drawing.Point(9, 20);
            this.lstVersions.Name = "lstVersions";
            this.lstVersions.Size = new System.Drawing.Size(248, 121);
            this.lstVersions.TabIndex = 26;
            // 
            // btnAddVersion
            // 
            this.btnAddVersion.Location = new System.Drawing.Point(209, 159);
            this.btnAddVersion.Name = "btnAddVersion";
            this.btnAddVersion.Size = new System.Drawing.Size(48, 23);
            this.btnAddVersion.TabIndex = 25;
            this.btnAddVersion.Text = "Add";
            this.btnAddVersion.UseVisualStyleBackColor = true;
            this.btnAddVersion.Click += new System.EventHandler(this.btnAddVersion_Click);
            // 
            // txtNewVersionName
            // 
            this.txtNewVersionName.Location = new System.Drawing.Point(9, 161);
            this.txtNewVersionName.Name = "txtNewVersionName";
            this.txtNewVersionName.Size = new System.Drawing.Size(194, 20);
            this.txtNewVersionName.TabIndex = 24;
            // 
            // lblNewVersion
            // 
            this.lblNewVersion.AutoSize = true;
            this.lblNewVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewVersion.Location = new System.Drawing.Point(6, 142);
            this.lblNewVersion.Name = "lblNewVersion";
            this.lblNewVersion.Size = new System.Drawing.Size(87, 15);
            this.lblNewVersion.TabIndex = 23;
            this.lblNewVersion.Text = "Add Version:";
            // 
            // frmManageUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 590);
            this.Controls.Add(this.grpVersions);
            this.Controls.Add(this.grpEditUpdate);
            this.Controls.Add(this.grpEditUpdateSeries);
            this.Controls.Add(this.grpUpdates);
            this.Controls.Add(this.grpUpdateSeries);
            this.Name = "frmManageUpdates";
            this.Text = "Manage Updates";
            this.Load += new System.EventHandler(this.frmManageUpdates_Load);
            this.grpUpdateSeries.ResumeLayout(false);
            this.grpUpdates.ResumeLayout(false);
            this.grpEditUpdateSeries.ResumeLayout(false);
            this.pnlEditUpdateSeries.ResumeLayout(false);
            this.pnlEditUpdateSeries.PerformLayout();
            this.grpEditUpdate.ResumeLayout(false);
            this.pnlEditUpdate.ResumeLayout(false);
            this.pnlEditUpdate.PerformLayout();
            this.updateType.ResumeLayout(false);
            this.tabInfoMessage.ResumeLayout(false);
            this.tabInfoMessage.PerformLayout();
            this.tabHotFix.ResumeLayout(false);
            this.tabHotFix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFiles)).EndInit();
            this.tabUpgrade.ResumeLayout(false);
            this.tabUpgrade.PerformLayout();
            this.grpVersions.ResumeLayout(false);
            this.grpVersions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUpdateSeries;
        private System.Windows.Forms.GroupBox grpUpdates;
        private System.Windows.Forms.GroupBox grpEditUpdateSeries;
        private System.Windows.Forms.Panel pnlEditUpdateSeries;
        private System.Windows.Forms.Label lblSeriesName;
        private System.Windows.Forms.Label lblSeriesDateModified;
        private System.Windows.Forms.Label lblDateModified;
        private System.Windows.Forms.Label lblSeriesDateCreated;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.TextBox txtSeriesDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtSeriesName;
        private System.Windows.Forms.GroupBox grpEditUpdate;
        private System.Windows.Forms.Panel pnlEditUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSaveUpdateSeries;
        private System.Windows.Forms.Label lblUpdateDateModified;
        private System.Windows.Forms.TextBox txtUpdateDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUpdateDescription;
        private System.Windows.Forms.Label lblUpdateDateCreated;
        private System.Windows.Forms.TextBox txtUpdateName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUpdateName;
        private System.Windows.Forms.Button btnDeleteUpdate;
        private System.Windows.Forms.Button btnUpdateSave;
        private System.Windows.Forms.TabControl updateType;
        private System.Windows.Forms.TabPage tabInfoMessage;
        private System.Windows.Forms.RichTextBox txtInfoMessage;
        private System.Windows.Forms.Label lblInfoMessage;
        private System.Windows.Forms.TabPage tabHotFix;
        private System.Windows.Forms.Button btnHotFixBrowse;
        private System.Windows.Forms.Label lblUpdateFileName;
        private System.Windows.Forms.TabPage tabUpgrade;
        private System.Windows.Forms.Button btnUpdateBrowse;
        private System.Windows.Forms.TextBox txtUpdatePackageFilePath;
        private System.Windows.Forms.Label lblUpdatePackage;
        private System.Windows.Forms.GroupBox grpVersions;
        private System.Windows.Forms.Button btnAddVersion;
        private System.Windows.Forms.TextBox txtNewVersionName;
        private System.Windows.Forms.Label lblNewVersion;
        private System.Windows.Forms.ListBox lstUpdateSeries;
        private System.Windows.Forms.ListBox lstUpdates;
        private System.Windows.Forms.ListBox lstVersions;
        private System.Windows.Forms.CheckedListBox lstSeriesVersions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewSeries;
        private System.Windows.Forms.Button btnNewUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdFiles;

    }
}