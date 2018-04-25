namespace BethanyMath
{
    partial class frmSendEmails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendEmails));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAttachments = new System.Windows.Forms.ListBox();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk5 = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkPaid = new System.Windows.Forms.CheckBox();
            this.chkNotPaid = new System.Windows.Forms.CheckBox();
            this.HTMLEditor = new System.Windows.Forms.WebBrowser();
            this.btnPreview = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnBold = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnItalic = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnLink = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Attachments:";
            // 
            // lbAttachments
            // 
            this.lbAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAttachments.FormattingEnabled = true;
            this.lbAttachments.Location = new System.Drawing.Point(100, 213);
            this.lbAttachments.Name = "lbAttachments";
            this.lbAttachments.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbAttachments.Size = new System.Drawing.Size(390, 95);
            this.lbAttachments.TabIndex = 2;
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(16, 107);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(474, 96);
            this.txtBody.TabIndex = 3;
            this.txtBody.Text = "";
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(16, 46);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(47, 17);
            this.chk2.TabIndex = 4;
            this.chk2.Text = "2nd ";
            this.chk2.UseVisualStyleBackColor = true;
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Location = new System.Drawing.Point(103, 46);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(41, 17);
            this.chk3.TabIndex = 5;
            this.chk3.Text = "3rd";
            this.chk3.UseVisualStyleBackColor = true;
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.Location = new System.Drawing.Point(190, 46);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(41, 17);
            this.chk4.TabIndex = 6;
            this.chk4.Text = "4th";
            this.chk4.UseVisualStyleBackColor = true;
            // 
            // chk5
            // 
            this.chk5.AutoSize = true;
            this.chk5.Location = new System.Drawing.Point(277, 46);
            this.chk5.Name = "chk5";
            this.chk5.Size = new System.Drawing.Size(41, 17);
            this.chk5.TabIndex = 7;
            this.chk5.Text = "5th";
            this.chk5.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSend.Location = new System.Drawing.Point(323, 321);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(416, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(70, 27);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(420, 20);
            this.txtSubject.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Body:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(15, 243);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(15, 272);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkPaid
            // 
            this.chkPaid.AutoSize = true;
            this.chkPaid.Location = new System.Drawing.Point(15, 70);
            this.chkPaid.Name = "chkPaid";
            this.chkPaid.Size = new System.Drawing.Size(47, 17);
            this.chkPaid.TabIndex = 14;
            this.chkPaid.Text = "Paid";
            this.chkPaid.UseVisualStyleBackColor = true;
            // 
            // chkNotPaid
            // 
            this.chkNotPaid.AutoSize = true;
            this.chkNotPaid.Location = new System.Drawing.Point(100, 70);
            this.chkNotPaid.Name = "chkNotPaid";
            this.chkNotPaid.Size = new System.Drawing.Size(67, 17);
            this.chkNotPaid.TabIndex = 15;
            this.chkNotPaid.Text = "Not Paid";
            this.chkNotPaid.UseVisualStyleBackColor = true;
            // 
            // HTMLEditor
            // 
            this.HTMLEditor.AllowNavigation = false;
            this.HTMLEditor.AllowWebBrowserDrop = false;
            this.HTMLEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HTMLEditor.IsWebBrowserContextMenuEnabled = false;
            this.HTMLEditor.Location = new System.Drawing.Point(16, 107);
            this.HTMLEditor.MinimumSize = new System.Drawing.Size(20, 20);
            this.HTMLEditor.Name = "HTMLEditor";
            this.HTMLEditor.ScriptErrorsSuppressed = true;
            this.HTMLEditor.Size = new System.Drawing.Size(474, 96);
            this.HTMLEditor.TabIndex = 16;
            this.HTMLEditor.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(391, 81);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(99, 23);
            this.btnPreview.TabIndex = 17;
            this.btnPreview.Text = "HTML Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnBold,
            this.toolStripBtnItalic,
            this.toolStripBtnSize,
            this.toolStripBtnLink});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(502, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // toolStripBtnBold
            // 
            this.toolStripBtnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnBold.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnBold.Image")));
            this.toolStripBtnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBold.Name = "toolStripBtnBold";
            this.toolStripBtnBold.Size = new System.Drawing.Size(35, 22);
            this.toolStripBtnBold.Text = "Bold";
            // 
            // toolStripBtnItalic
            // 
            this.toolStripBtnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnItalic.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnItalic.Image")));
            this.toolStripBtnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnItalic.Name = "toolStripBtnItalic";
            this.toolStripBtnItalic.Size = new System.Drawing.Size(36, 22);
            this.toolStripBtnItalic.Text = "Italic";
            this.toolStripBtnItalic.Click += new System.EventHandler(this.toolStripBtnItalic_Click);
            // 
            // toolStripBtnSize
            // 
            this.toolStripBtnSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnSize.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSize.Image")));
            this.toolStripBtnSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSize.Name = "toolStripBtnSize";
            this.toolStripBtnSize.Size = new System.Drawing.Size(31, 22);
            this.toolStripBtnSize.Text = "Size";
            this.toolStripBtnSize.Click += new System.EventHandler(this.toolStripBtnSize_Click);
            // 
            // toolStripBtnLink
            // 
            this.toolStripBtnLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnLink.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnLink.Image")));
            this.toolStripBtnLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnLink.Name = "toolStripBtnLink";
            this.toolStripBtnLink.Size = new System.Drawing.Size(33, 22);
            this.toolStripBtnLink.Text = "Link";
            this.toolStripBtnLink.Click += new System.EventHandler(this.toolStripBtnLink_Click);
            // 
            // frmSendEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 347);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.HTMLEditor);
            this.Controls.Add(this.chkNotPaid);
            this.Controls.Add(this.chkPaid);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.chk5);
            this.Controls.Add(this.chk4);
            this.Controls.Add(this.chk3);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lbAttachments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSendEmails";
            this.Text = "Send Emails";
            this.Load += new System.EventHandler(this.frmSendEmails_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbAttachments;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.CheckBox chk4;
        private System.Windows.Forms.CheckBox chk5;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkPaid;
        private System.Windows.Forms.CheckBox chkNotPaid;
        private System.Windows.Forms.WebBrowser HTMLEditor;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnBold;
        private System.Windows.Forms.ToolStripButton toolStripBtnItalic;
        private System.Windows.Forms.ToolStripButton toolStripBtnSize;
        private System.Windows.Forms.ToolStripButton toolStripBtnLink;
    }
}

