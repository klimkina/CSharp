namespace VWA4
{
	partial class ShowEULA
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowEULA));
			this.rtDoc = new System.Windows.Forms.RichTextBox();
			this.bOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// rtDoc
			// 
			this.rtDoc.Location = new System.Drawing.Point(12, 12);
			this.rtDoc.Name = "rtDoc";
			this.rtDoc.ReadOnly = true;
			this.rtDoc.Size = new System.Drawing.Size(580, 452);
			this.rtDoc.TabIndex = 0;
			this.rtDoc.Text = "";
			// 
			// bOK
			// 
			this.bOK.Location = new System.Drawing.Point(511, 470);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(81, 29);
			this.bOK.TabIndex = 1;
			this.bOK.Text = "OK";
			this.bOK.UseVisualStyleBackColor = true;
			this.bOK.Click += new System.EventHandler(this.bOK_Click);
			// 
			// ShowEULA
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 508);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.rtDoc);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "ShowEULA";
			this.Text = "End User License Agreement";
			this.Shown += new System.EventHandler(this.ShowEULA_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtDoc;
		private System.Windows.Forms.Button bOK;
	}
}