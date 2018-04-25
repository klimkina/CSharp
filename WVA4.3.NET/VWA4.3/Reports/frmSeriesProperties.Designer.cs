namespace Reports
{
    partial class frmSeriesProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeriesProperties));
			this.pFormHdr = new System.Windows.Forms.Panel();
			this.lFormTitle = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlFormsInSeries = new System.Windows.Forms.Panel();
			this.lblDateCreated = new System.Windows.Forms.Label();
			this.lblLastModifiedDate = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList();
			this.lblNameValue = new System.Windows.Forms.Label();
			this.lblDateCreatedValue = new System.Windows.Forms.Label();
			this.lblLastModifiedDateValue = new System.Windows.Forms.Label();
			this.pFormHdr.SuspendLayout();
			this.SuspendLayout();
			// 
			// pFormHdr
			// 
			this.pFormHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pFormHdr.Controls.Add(this.lFormTitle);
			this.pFormHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pFormHdr.Location = new System.Drawing.Point(0, 0);
			this.pFormHdr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pFormHdr.Name = "pFormHdr";
			this.pFormHdr.Size = new System.Drawing.Size(458, 41);
			this.pFormHdr.TabIndex = 241;
			// 
			// lFormTitle
			// 
			this.lFormTitle.AutoSize = true;
			this.lFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFormTitle.Location = new System.Drawing.Point(6, 11);
			this.lFormTitle.Name = "lFormTitle";
			this.lFormTitle.Size = new System.Drawing.Size(193, 20);
			this.lFormTitle.TabIndex = 0;
			this.lFormTitle.Text = "Form Series Properties";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(17, 54);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(97, 16);
			this.lblName.TabIndex = 242;
			this.lblName.Text = "Series Name: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(17, 190);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(111, 16);
			this.label2.TabIndex = 243;
			this.label2.Text = "Forms in Series:";
			// 
			// pnlFormsInSeries
			// 
			this.pnlFormsInSeries.Location = new System.Drawing.Point(23, 217);
			this.pnlFormsInSeries.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlFormsInSeries.Name = "pnlFormsInSeries";
			this.pnlFormsInSeries.Size = new System.Drawing.Size(408, 290);
			this.pnlFormsInSeries.TabIndex = 244;
			// 
			// lblDateCreated
			// 
			this.lblDateCreated.AutoSize = true;
			this.lblDateCreated.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDateCreated.Location = new System.Drawing.Point(17, 98);
			this.lblDateCreated.Name = "lblDateCreated";
			this.lblDateCreated.Size = new System.Drawing.Size(99, 16);
			this.lblDateCreated.TabIndex = 245;
			this.lblDateCreated.Text = "Date Created: ";
			// 
			// lblLastModifiedDate
			// 
			this.lblLastModifiedDate.AutoSize = true;
			this.lblLastModifiedDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLastModifiedDate.Location = new System.Drawing.Point(17, 144);
			this.lblLastModifiedDate.Name = "lblLastModifiedDate";
			this.lblLastModifiedDate.Size = new System.Drawing.Size(134, 16);
			this.lblLastModifiedDate.TabIndex = 246;
			this.lblLastModifiedDate.Text = "Last Modified Date: ";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "row_add.png");
			// 
			// lblNameValue
			// 
			this.lblNameValue.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNameValue.Location = new System.Drawing.Point(34, 78);
			this.lblNameValue.Name = "lblNameValue";
			this.lblNameValue.Size = new System.Drawing.Size(408, 18);
			this.lblNameValue.TabIndex = 271;
			// 
			// lblDateCreatedValue
			// 
			this.lblDateCreatedValue.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDateCreatedValue.Location = new System.Drawing.Point(34, 122);
			this.lblDateCreatedValue.Name = "lblDateCreatedValue";
			this.lblDateCreatedValue.Size = new System.Drawing.Size(408, 18);
			this.lblDateCreatedValue.TabIndex = 272;
			// 
			// lblLastModifiedDateValue
			// 
			this.lblLastModifiedDateValue.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLastModifiedDateValue.Location = new System.Drawing.Point(34, 162);
			this.lblLastModifiedDateValue.Name = "lblLastModifiedDateValue";
			this.lblLastModifiedDateValue.Size = new System.Drawing.Size(408, 18);
			this.lblLastModifiedDateValue.TabIndex = 273;
			// 
			// frmSeriesProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(231)))));
			this.ClientSize = new System.Drawing.Size(458, 522);
			this.Controls.Add(this.lblLastModifiedDateValue);
			this.Controls.Add(this.lblDateCreatedValue);
			this.Controls.Add(this.lblNameValue);
			this.Controls.Add(this.lblLastModifiedDate);
			this.Controls.Add(this.lblDateCreated);
			this.Controls.Add(this.pnlFormsInSeries);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.pFormHdr);
			this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "frmSeriesProperties";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmSeriesProperties";
			this.pFormHdr.ResumeLayout(false);
			this.pFormHdr.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pFormHdr;
        private System.Windows.Forms.Label lFormTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlFormsInSeries;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblLastModifiedDate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblNameValue;
        private System.Windows.Forms.Label lblDateCreatedValue;
        private System.Windows.Forms.Label lblLastModifiedDateValue;
    }
}