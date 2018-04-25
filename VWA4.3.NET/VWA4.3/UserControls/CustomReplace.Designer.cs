namespace UserControls
{
    partial class CustomReplace
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.ultraMaskedEdit1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.ultraComboEditor1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.smartDateTimePicker1 = new UserControls.SmartDateTimePicker();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ultraMaskedEdit1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.ultraComboEditor1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(296, 21);
			this.panel1.TabIndex = 2;
			// 
			// ultraMaskedEdit1
			// 
			this.ultraMaskedEdit1.Location = new System.Drawing.Point(176, 1);
			this.ultraMaskedEdit1.Name = "ultraMaskedEdit1";
			this.ultraMaskedEdit1.Size = new System.Drawing.Size(117, 20);
			this.ultraMaskedEdit1.TabIndex = 5;
			this.ultraMaskedEdit1.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Change selected values to: ";
			// 
			// ultraComboEditor1
			// 
			this.ultraComboEditor1.Location = new System.Drawing.Point(169, 1);
			this.ultraComboEditor1.Name = "ultraComboEditor1";
			this.ultraComboEditor1.Size = new System.Drawing.Size(127, 21);
			this.ultraComboEditor1.TabIndex = 9;
			this.ultraComboEditor1.Text = "ultraComboEditor1";
			this.ultraComboEditor1.Visible = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 43);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(296, 28);
			this.panel2.TabIndex = 3;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(217, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(142, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// smartDateTimePicker1
			// 
			this.smartDateTimePicker1.Location = new System.Drawing.Point(4, 24);
			this.smartDateTimePicker1.Name = "smartDateTimePicker1";
			this.smartDateTimePicker1.Size = new System.Drawing.Size(291, 20);
			this.smartDateTimePicker1.TabIndex = 8;
			this.smartDateTimePicker1.Value = new System.DateTime(2008, 8, 6, 13, 30, 10, 0);
			this.smartDateTimePicker1.Visible = false;
			// 
			// CustomReplace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 71);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.smartDateTimePicker1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomReplace";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CustomReplace";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit ultraMaskedEdit1;
        private SmartDateTimePicker smartDateTimePicker1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ultraComboEditor1;
    }
}