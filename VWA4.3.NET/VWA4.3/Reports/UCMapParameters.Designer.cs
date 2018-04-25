namespace Reports
{
    partial class UCMapParameters
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
            this.lblParamName = new System.Windows.Forms.Label();
            this.cbSettings = new System.Windows.Forms.ComboBox();
            this.cbGlobalVars = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cbPrevReports = new System.Windows.Forms.ComboBox();
            this.cbOutputParams = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtPicker = new UserControls.SmartDateTimePicker();
            this.SuspendLayout();
            // 
            // lblParamName
            // 
            this.lblParamName.AutoSize = true;
            this.lblParamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblParamName.Location = new System.Drawing.Point(3, 8);
            this.lblParamName.Name = "lblParamName";
            this.lblParamName.Size = new System.Drawing.Size(100, 13);
            this.lblParamName.TabIndex = 0;
            this.lblParamName.Text = "Parameter Name";
            // 
            // cbSettings
            // 
            this.cbSettings.FormattingEnabled = true;
            this.cbSettings.Items.AddRange(new object[] {
            "Settings",
            "Global Parameters",
            "Output Parameters"});
            this.cbSettings.Location = new System.Drawing.Point(147, 5);
            this.cbSettings.Name = "cbSettings";
            this.cbSettings.Size = new System.Drawing.Size(121, 21);
            this.cbSettings.TabIndex = 1;
            // 
            // cbGlobalVars
            // 
            this.cbGlobalVars.FormattingEnabled = true;
            this.cbGlobalVars.Items.AddRange(new object[] {
            "List of Global Vars"});
            this.cbGlobalVars.Location = new System.Drawing.Point(273, 5);
            this.cbGlobalVars.Name = "cbGlobalVars";
            this.cbGlobalVars.Size = new System.Drawing.Size(121, 21);
            this.cbGlobalVars.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(106, 8);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "From:";
            // 
            // cbPrevReports
            // 
            this.cbPrevReports.FormattingEnabled = true;
            this.cbPrevReports.Items.AddRange(new object[] {
            "List of prev reports"});
            this.cbPrevReports.Location = new System.Drawing.Point(404, 33);
            this.cbPrevReports.Name = "cbPrevReports";
            this.cbPrevReports.Size = new System.Drawing.Size(121, 21);
            this.cbPrevReports.TabIndex = 5;
            // 
            // cbOutputParams
            // 
            this.cbOutputParams.FormattingEnabled = true;
            this.cbOutputParams.Items.AddRange(new object[] {
            "List of Output Parameters"});
            this.cbOutputParams.Location = new System.Drawing.Point(531, 33);
            this.cbOutputParams.Name = "cbOutputParams";
            this.cbOutputParams.Size = new System.Drawing.Size(121, 21);
            this.cbOutputParams.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(543, 90);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(620, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dtPicker
            // 
            this.dtPicker.Location = new System.Drawing.Point(404, 5);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(291, 20);
            this.dtPicker.TabIndex = 3;
            this.dtPicker.Value = new System.DateTime(2008, 11, 24, 12, 44, 16, 0);
            // 
            // UCMapParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbOutputParams);
            this.Controls.Add(this.cbPrevReports);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtPicker);
            this.Controls.Add(this.cbGlobalVars);
            this.Controls.Add(this.cbSettings);
            this.Controls.Add(this.lblParamName);
            this.Name = "UCMapParameters";
            this.Size = new System.Drawing.Size(701, 116);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParamName;
        private System.Windows.Forms.ComboBox cbSettings;
        private System.Windows.Forms.ComboBox cbGlobalVars;
        private UserControls.SmartDateTimePicker dtPicker;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ComboBox cbPrevReports;
        private System.Windows.Forms.ComboBox cbOutputParams;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
