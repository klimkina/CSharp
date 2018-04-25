namespace UserControls
{
    partial class UCManageLogSheet
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
            this.grpManageLogSheet = new System.Windows.Forms.GroupBox();
            this.lstSelectedTypes = new DevExpress.XtraTreeList.TreeList();
            this.displayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.typeId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.typeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lstLossTypes = new DevExpress.XtraTreeList.TreeList();
            this.lossName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lossTypeID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lstFoodTypes = new DevExpress.XtraTreeList.TreeList();
            this.foodName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.foodTypeID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lstUnits = new DevExpress.XtraTreeList.TreeList();
            this.containerName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.containerId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ddlTypes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlSite = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnRTF = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.grpManageLogSheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstSelectedTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstLossTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstFoodTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // grpManageLogSheet
            // 
            this.grpManageLogSheet.Controls.Add(this.lstSelectedTypes);
            this.grpManageLogSheet.Controls.Add(this.lstLossTypes);
            this.grpManageLogSheet.Controls.Add(this.lstFoodTypes);
            this.grpManageLogSheet.Controls.Add(this.lstUnits);
            this.grpManageLogSheet.Controls.Add(this.ddlTypes);
            this.grpManageLogSheet.Controls.Add(this.label2);
            this.grpManageLogSheet.Controls.Add(this.ddlSite);
            this.grpManageLogSheet.Controls.Add(this.label1);
            this.grpManageLogSheet.Controls.Add(this.txtHeader);
            this.grpManageLogSheet.Controls.Add(this.lblHeader);
            this.grpManageLogSheet.Controls.Add(this.txtName);
            this.grpManageLogSheet.Controls.Add(this.lblName);
            this.grpManageLogSheet.Location = new System.Drawing.Point(0, 0);
            this.grpManageLogSheet.Name = "grpManageLogSheet";
            this.grpManageLogSheet.Size = new System.Drawing.Size(940, 180);
            this.grpManageLogSheet.TabIndex = 0;
            this.grpManageLogSheet.TabStop = false;
            this.grpManageLogSheet.Text = "Manage Log Sheets";
            // 
            // lstSelectedTypes
            // 
            this.lstSelectedTypes.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.displayName,
            this.typeId,
            this.typeName});
            this.lstSelectedTypes.Location = new System.Drawing.Point(217, 12);
            this.lstSelectedTypes.Name = "lstSelectedTypes";
            this.lstSelectedTypes.OptionsSelection.MultiSelect = true;
            this.lstSelectedTypes.Size = new System.Drawing.Size(176, 163);
            this.lstSelectedTypes.TabIndex = 13;
            // 
            // displayName
            // 
            this.displayName.Caption = "Selected Types";
            this.displayName.FieldName = "displayName";
            this.displayName.Name = "displayName";
            this.displayName.OptionsColumn.AllowEdit = false;
            this.displayName.OptionsColumn.AllowMove = false;
            this.displayName.OptionsColumn.AllowSize = false;
            this.displayName.Visible = true;
            this.displayName.VisibleIndex = 0;
            // 
            // typeId
            // 
            this.typeId.FieldName = "typeId";
            this.typeId.Name = "typeId";
            // 
            // typeName
            // 
            this.typeName.FieldName = "typeName";
            this.typeName.Name = "typeName";
            // 
            // lstLossTypes
            // 
            this.lstLossTypes.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.lossName,
            this.lossTypeID});
            this.lstLossTypes.Location = new System.Drawing.Point(763, 12);
            this.lstLossTypes.Name = "lstLossTypes";
            this.lstLossTypes.OptionsSelection.MultiSelect = true;
            this.lstLossTypes.Size = new System.Drawing.Size(176, 163);
            this.lstLossTypes.TabIndex = 12;
            // 
            // lossName
            // 
            this.lossName.Caption = "Loss Types";
            this.lossName.FieldName = "lossName";
            this.lossName.Name = "lossName";
            this.lossName.OptionsColumn.AllowEdit = false;
            this.lossName.OptionsColumn.AllowMove = false;
            this.lossName.OptionsColumn.AllowSize = false;
            this.lossName.Visible = true;
            this.lossName.VisibleIndex = 0;
            // 
            // lossTypeID
            // 
            this.lossTypeID.FieldName = "lossTypeID";
            this.lossTypeID.Name = "lossTypeID";
            // 
            // lstFoodTypes
            // 
            this.lstFoodTypes.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.foodName,
            this.foodTypeID});
            this.lstFoodTypes.Location = new System.Drawing.Point(581, 12);
            this.lstFoodTypes.Name = "lstFoodTypes";
            this.lstFoodTypes.OptionsSelection.MultiSelect = true;
            this.lstFoodTypes.Size = new System.Drawing.Size(176, 163);
            this.lstFoodTypes.TabIndex = 11;
            // 
            // foodName
            // 
            this.foodName.Caption = "Food Types";
            this.foodName.FieldName = "foodName";
            this.foodName.Name = "foodName";
            this.foodName.OptionsColumn.AllowEdit = false;
            this.foodName.OptionsColumn.AllowMove = false;
            this.foodName.OptionsColumn.AllowSize = false;
            this.foodName.Visible = true;
            this.foodName.VisibleIndex = 0;
            // 
            // foodTypeID
            // 
            this.foodTypeID.FieldName = "foodTypeID";
            this.foodTypeID.Name = "foodTypeID";
            // 
            // lstUnits
            // 
            this.lstUnits.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.containerName,
            this.containerId});
            this.lstUnits.Location = new System.Drawing.Point(399, 12);
            this.lstUnits.Name = "lstUnits";
            this.lstUnits.OptionsSelection.MultiSelect = true;
            this.lstUnits.Size = new System.Drawing.Size(176, 163);
            this.lstUnits.TabIndex = 10;
            // 
            // containerName
            // 
            this.containerName.Caption = "Units";
            this.containerName.FieldName = "containerName";
            this.containerName.Name = "containerName";
            this.containerName.OptionsColumn.AllowEdit = false;
            this.containerName.OptionsColumn.AllowMove = false;
            this.containerName.OptionsColumn.AllowSize = false;
            this.containerName.Visible = true;
            this.containerName.VisibleIndex = 0;
            // 
            // containerId
            // 
            this.containerId.FieldName = "containerId";
            this.containerId.Name = "containerId";
            this.containerId.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            // 
            // ddlTypes
            // 
            this.ddlTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTypes.FormattingEnabled = true;
            this.ddlTypes.Location = new System.Drawing.Point(49, 81);
            this.ddlTypes.Name = "ddlTypes";
            this.ddlTypes.Size = new System.Drawing.Size(150, 21);
            this.ddlTypes.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ddlSite
            // 
            this.ddlSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSite.FormattingEnabled = true;
            this.ddlSite.Location = new System.Drawing.Point(48, 58);
            this.ddlSite.Name = "ddlSite";
            this.ddlSite.Size = new System.Drawing.Size(150, 21);
            this.ddlSite.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Site:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(48, 35);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(150, 20);
            this.txtHeader.TabIndex = 3;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(4, 39);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(44, 13);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Header:";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(48, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(11, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 23);
            this.btnSave.TabIndex = 59;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(49, 190);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(40, 23);
            this.btnLoad.TabIndex = 60;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnViewReport.Location = new System.Drawing.Point(301, 190);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(85, 23);
            this.btnViewReport.TabIndex = 61;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnRTF
            // 
            this.btnRTF.Location = new System.Drawing.Point(479, 190);
            this.btnRTF.Name = "btnRTF";
            this.btnRTF.Size = new System.Drawing.Size(81, 23);
            this.btnRTF.TabIndex = 63;
            this.btnRTF.Text = "Export to RTF";
            this.btnRTF.UseVisualStyleBackColor = true;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(392, 190);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(81, 23);
            this.btnExportPDF.TabIndex = 62;
            this.btnExportPDF.Text = "Export to PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            // 
            // UCManageLogSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRTF);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpManageLogSheet);
            this.Name = "UCManageLogSheet";
            this.Size = new System.Drawing.Size(948, 213);
            this.grpManageLogSheet.ResumeLayout(false);
            this.grpManageLogSheet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstSelectedTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstLossTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstFoodTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstUnits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpManageLogSheet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnRTF;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.ComboBox ddlSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlTypes;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraTreeList.TreeList lstUnits;
        private DevExpress.XtraTreeList.TreeList lstLossTypes;
        private DevExpress.XtraTreeList.TreeList lstFoodTypes;
        private DevExpress.XtraTreeList.Columns.TreeListColumn containerName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn containerId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn foodName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn foodTypeID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn lossName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn lossTypeID;
        private DevExpress.XtraTreeList.TreeList lstSelectedTypes;
        private DevExpress.XtraTreeList.Columns.TreeListColumn displayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn typeId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn typeName;


    }
}
