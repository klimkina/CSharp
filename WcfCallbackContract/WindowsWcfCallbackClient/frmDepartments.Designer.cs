namespace WindowsWcfCallbackClient
{
	partial class frmDepartments
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
			this.btnGetData = new System.Windows.Forms.Button();
			this.dgvDept = new System.Windows.Forms.DataGridView();
			this.btnClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvDept)).BeginInit();
			this.SuspendLayout();
			// 
			// btnGetData
			// 
			this.btnGetData.Location = new System.Drawing.Point(41, 12);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Size = new System.Drawing.Size(244, 23);
			this.btnGetData.TabIndex = 0;
			this.btnGetData.Text = "Get Data";
			this.btnGetData.UseVisualStyleBackColor = true;
			this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
			// 
			// dgvDept
			// 
			this.dgvDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDept.Location = new System.Drawing.Point(41, 47);
			this.dgvDept.Name = "dgvDept";
			this.dgvDept.Size = new System.Drawing.Size(399, 223);
			this.dgvDept.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(341, 11);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(99, 23);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// frmDepartments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 310);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.dgvDept);
			this.Controls.Add(this.btnGetData);
			this.Name = "frmDepartments";
			this.Text = "Departments on Server";
			this.Load += new System.EventHandler(this.frmDepartments_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvDept)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnGetData;
		private System.Windows.Forms.DataGridView dgvDept;
		private System.Windows.Forms.Button btnClose;
	}
}

