namespace LMan4.Updates
{
    partial class EditUpdateSeries
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
            this.lblUpdateSeries = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblUpdates = new System.Windows.Forms.Label();
            this.grdUpdates = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblDateModified = new System.Windows.Forms.Label();
            this.lblDateCreatedValue = new System.Windows.Forms.Label();
            this.lblDateModifiedValue = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstVersions = new System.Windows.Forms.ListBox();
            this.btnAddVersion = new System.Windows.Forms.Button();
            this.btnDeleteVersion = new System.Windows.Forms.Button();
            this.lblVersions = new System.Windows.Forms.Label();
            this.btnManageVersions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdates)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUpdateSeries
            // 
            this.lblUpdateSeries.AutoSize = true;
            this.lblUpdateSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateSeries.Location = new System.Drawing.Point(13, 13);
            this.lblUpdateSeries.Name = "lblUpdateSeries";
            this.lblUpdateSeries.Size = new System.Drawing.Size(183, 24);
            this.lblUpdateSeries.TabIndex = 2;
            this.lblUpdateSeries.Text = "Edit Update Series";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(52, 52);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 16);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(111, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(368, 20);
            this.txtName.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(14, 82);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(91, 16);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(111, 81);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(368, 82);
            this.txtDescription.TabIndex = 6;
            // 
            // lblUpdates
            // 
            this.lblUpdates.AutoSize = true;
            this.lblUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdates.Location = new System.Drawing.Point(13, 236);
            this.lblUpdates.Name = "lblUpdates";
            this.lblUpdates.Size = new System.Drawing.Size(86, 24);
            this.lblUpdates.TabIndex = 7;
            this.lblUpdates.Text = "Updates";
            // 
            // grdUpdates
            // 
            this.grdUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUpdates.Location = new System.Drawing.Point(0, 263);
            this.grdUpdates.Name = "grdUpdates";
            this.grdUpdates.Size = new System.Drawing.Size(804, 201);
            this.grdUpdates.TabIndex = 8;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnNew.Location = new System.Drawing.Point(691, 234);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(101, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "Add Update";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCreated.Location = new System.Drawing.Point(14, 176);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(100, 16);
            this.lblDateCreated.TabIndex = 10;
            this.lblDateCreated.Text = "DateCreated:";
            // 
            // lblDateModified
            // 
            this.lblDateModified.AutoSize = true;
            this.lblDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateModified.Location = new System.Drawing.Point(9, 196);
            this.lblDateModified.Name = "lblDateModified";
            this.lblDateModified.Size = new System.Drawing.Size(105, 16);
            this.lblDateModified.TabIndex = 11;
            this.lblDateModified.Text = "DateModified:";
            // 
            // lblDateCreatedValue
            // 
            this.lblDateCreatedValue.AutoSize = true;
            this.lblDateCreatedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCreatedValue.Location = new System.Drawing.Point(120, 177);
            this.lblDateCreatedValue.Name = "lblDateCreatedValue";
            this.lblDateCreatedValue.Size = new System.Drawing.Size(0, 15);
            this.lblDateCreatedValue.TabIndex = 12;
            // 
            // lblDateModifiedValue
            // 
            this.lblDateModifiedValue.AutoSize = true;
            this.lblDateModifiedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateModifiedValue.Location = new System.Drawing.Point(120, 197);
            this.lblDateModifiedValue.Name = "lblDateModifiedValue";
            this.lblDateModifiedValue.Size = new System.Drawing.Size(0, 15);
            this.lblDateModifiedValue.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(610, 234);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstVersions
            // 
            this.lstVersions.FormattingEnabled = true;
            this.lstVersions.Location = new System.Drawing.Point(530, 78);
            this.lstVersions.Name = "lstVersions";
            this.lstVersions.Size = new System.Drawing.Size(262, 82);
            this.lstVersions.TabIndex = 15;
            // 
            // btnAddVersion
            // 
            this.btnAddVersion.Location = new System.Drawing.Point(610, 169);
            this.btnAddVersion.Name = "btnAddVersion";
            this.btnAddVersion.Size = new System.Drawing.Size(75, 23);
            this.btnAddVersion.TabIndex = 16;
            this.btnAddVersion.Text = "Add Version";
            this.btnAddVersion.UseVisualStyleBackColor = true;
            this.btnAddVersion.Click += new System.EventHandler(this.btnAddVersion_Click);
            // 
            // btnDeleteVersion
            // 
            this.btnDeleteVersion.Location = new System.Drawing.Point(691, 169);
            this.btnDeleteVersion.Name = "btnDeleteVersion";
            this.btnDeleteVersion.Size = new System.Drawing.Size(101, 23);
            this.btnDeleteVersion.TabIndex = 17;
            this.btnDeleteVersion.Text = "Delete Version";
            this.btnDeleteVersion.UseVisualStyleBackColor = true;
            this.btnDeleteVersion.Click += new System.EventHandler(this.btnDeleteVersion_Click);
            // 
            // lblVersions
            // 
            this.lblVersions.AutoSize = true;
            this.lblVersions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersions.Location = new System.Drawing.Point(527, 56);
            this.lblVersions.Name = "lblVersions";
            this.lblVersions.Size = new System.Drawing.Size(73, 16);
            this.lblVersions.TabIndex = 18;
            this.lblVersions.Text = "Versions:";
            // 
            // btnManageVersions
            // 
            this.btnManageVersions.Location = new System.Drawing.Point(691, 53);
            this.btnManageVersions.Name = "btnManageVersions";
            this.btnManageVersions.Size = new System.Drawing.Size(101, 23);
            this.btnManageVersions.TabIndex = 19;
            this.btnManageVersions.Text = "Manage Versions";
            this.btnManageVersions.UseVisualStyleBackColor = true;
            this.btnManageVersions.Click += new System.EventHandler(this.btnManageVersions_Click);
            // 
            // EditUpdateSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 464);
            this.Controls.Add(this.btnManageVersions);
            this.Controls.Add(this.lblVersions);
            this.Controls.Add(this.btnDeleteVersion);
            this.Controls.Add(this.btnAddVersion);
            this.Controls.Add(this.lstVersions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDateModifiedValue);
            this.Controls.Add(this.lblDateCreatedValue);
            this.Controls.Add(this.lblDateModified);
            this.Controls.Add(this.lblDateCreated);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grdUpdates);
            this.Controls.Add(this.lblUpdates);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUpdateSeries);
            this.Name = "EditUpdateSeries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Update Series";
            this.Load += new System.EventHandler(this.EditUpdateSeries_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpdateSeries;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblUpdates;
        private System.Windows.Forms.DataGridView grdUpdates;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblDateModified;
        private System.Windows.Forms.Label lblDateCreatedValue;
        private System.Windows.Forms.Label lblDateModifiedValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lstVersions;
        private System.Windows.Forms.Button btnAddVersion;
        private System.Windows.Forms.Button btnDeleteVersion;
        private System.Windows.Forms.Label lblVersions;
        private System.Windows.Forms.Button btnManageVersions;
    }
}