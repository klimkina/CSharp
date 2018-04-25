namespace LMan4.Updates
{
    partial class ManageUpdatesNew
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
            this.grdUpdateSeries = new System.Windows.Forms.DataGridView();
            this.lblUpdateSeries = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdateSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUpdateSeries
            // 
            this.grdUpdateSeries.AllowUserToAddRows = false;
            this.grdUpdateSeries.AllowUserToDeleteRows = false;
            this.grdUpdateSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUpdateSeries.Location = new System.Drawing.Point(0, 47);
            this.grdUpdateSeries.Name = "grdUpdateSeries";
            this.grdUpdateSeries.ReadOnly = true;
            this.grdUpdateSeries.Size = new System.Drawing.Size(804, 417);
            this.grdUpdateSeries.TabIndex = 0;
            // 
            // lblUpdateSeries
            // 
            this.lblUpdateSeries.AutoSize = true;
            this.lblUpdateSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateSeries.Location = new System.Drawing.Point(13, 13);
            this.lblUpdateSeries.Name = "lblUpdateSeries";
            this.lblUpdateSeries.Size = new System.Drawing.Size(141, 24);
            this.lblUpdateSeries.TabIndex = 1;
            this.lblUpdateSeries.Text = "Update Series";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(717, 18);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // ManageUpdatesNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 464);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblUpdateSeries);
            this.Controls.Add(this.grdUpdateSeries);
            this.Name = "ManageUpdatesNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ManageUpdatesNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdateSeries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdUpdateSeries;
        private System.Windows.Forms.Label lblUpdateSeries;
        private System.Windows.Forms.Button btnNew;
    }
}