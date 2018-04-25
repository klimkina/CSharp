namespace VWA4Common
{
	partial class ProgressDialog
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressDialog));
			this.lblStatus = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lLeadIn = new System.Windows.Forms.Label();
			this.lDetailDescription = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(70, 41);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(56, 13);
			this.lblStatus.TabIndex = 37;
			this.lblStatus.Text = "lblStatus";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(11, 64);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(397, 20);
			this.progressBar1.TabIndex = 38;
			this.progressBar1.Value = 20;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// lLeadIn
			// 
			this.lLeadIn.AutoSize = true;
			this.lLeadIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lLeadIn.Location = new System.Drawing.Point(69, 14);
			this.lLeadIn.Name = "lLeadIn";
			this.lLeadIn.Size = new System.Drawing.Size(76, 17);
			this.lLeadIn.TabIndex = 39;
			this.lLeadIn.Text = "lLeadIn...";
			// 
			// lDetailDescription
			// 
			this.lDetailDescription.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lDetailDescription.AutoSize = true;
			this.lDetailDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lDetailDescription.Location = new System.Drawing.Point(155, 95);
			this.lDetailDescription.Name = "lDetailDescription";
			this.lDetailDescription.Size = new System.Drawing.Size(107, 13);
			this.lDetailDescription.TabIndex = 40;
			this.lDetailDescription.Text = "lDetailDescription";
			this.lDetailDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::VWA4Common.Properties.Resources.gears1;
			this.pictureBox1.Location = new System.Drawing.Point(11, 10);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(50, 44);
			this.pictureBox1.TabIndex = 41;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(11, 10);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(50, 44);
			this.pictureBox2.TabIndex = 42;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(166, 113);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 43;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ProgressDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(242)))), ((int)(((byte)(235)))));
			this.ClientSize = new System.Drawing.Size(421, 142);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lDetailDescription);
			this.Controls.Add(this.lLeadIn);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.pictureBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgressDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ValuWaste Advantage 4";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProgressDialog_KeyPress);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lLeadIn;
		private System.Windows.Forms.Label lDetailDescription;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
	}
}