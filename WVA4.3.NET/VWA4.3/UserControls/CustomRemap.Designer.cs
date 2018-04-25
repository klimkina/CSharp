namespace UserControls
{
    partial class CustomRemap
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
			Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton1 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
			Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton2 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
			Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton3 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
			this.ucTreeView1 = new UserControls.UCTreeView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ultraOriginalType = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ultraTextEditor2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraOriginalType)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// ucTreeView1
			// 
			this.ucTreeView1.EnableCheckboxes = false;
			this.ucTreeView1.ID = "";
			this.ucTreeView1.Location = new System.Drawing.Point(99, -2);
			this.ucTreeView1.Name = "ucTreeView1";
			this.ucTreeView1.ShowAllNames = false;
			this.ucTreeView1.ShowBEONumber = true;
			this.ucTreeView1.ShowDisabled = false;
			this.ucTreeView1.ShowPrice = false;
			this.ucTreeView1.Size = new System.Drawing.Size(286, 148);
			this.ucTreeView1.TabIndex = 0;
			this.ucTreeView1.TypeCatalogID = "0";
			this.ucTreeView1.TypeName = "";
			this.ucTreeView1.Visible = false;
			this.ucTreeView1.TreeViewIDChanged += new UserControls.UCTreeView.TreeViewIDChangedEventHandler(this.ucTreeView1_TreeViewIDChanged);
			this.ucTreeView1.Load += new System.EventHandler(this.ucTreeView1_Load);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnDelete);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Controls.Add(this.btnNew);
			this.panel2.Controls.Add(this.btnOk);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 89);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(285, 50);
			this.panel2.TabIndex = 5;
			// 
			// btnDelete
			// 
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnDelete.Location = new System.Drawing.Point(66, 3);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(69, 21);
			this.btnDelete.TabIndex = 100;
			this.btnDelete.Text = "Delete Last";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.CausesValidation = false;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(221, 26);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(60, 23);
			this.btnCancel.TabIndex = 103;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnNew
			// 
			this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnNew.Location = new System.Drawing.Point(3, 3);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(62, 21);
			this.btnNew.TabIndex = 101;
			this.btnNew.Text = "Add New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(171, 26);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(48, 23);
			this.btnOk.TabIndex = 102;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Remap FoodType:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ultraOriginalType);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.ucTreeView1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(285, 24);
			this.panel1.TabIndex = 1;
			this.panel1.Validating += new System.ComponentModel.CancelEventHandler(this.panel1_Validating);
			// 
			// ultraOriginalType
			// 
			this.ultraOriginalType.AcceptsReturn = true;
			dropDownEditorButton1.Control = this.ucTreeView1;
			dropDownEditorButton1.PreferredDropDownSize = new System.Drawing.Size(0, 0);
			this.ultraOriginalType.ButtonsRight.Add(dropDownEditorButton1);
			this.ultraOriginalType.Location = new System.Drawing.Point(99, 2);
			this.ultraOriginalType.Name = "ultraOriginalType";
			this.ultraOriginalType.Size = new System.Drawing.Size(185, 21);
			this.ultraOriginalType.TabIndex = 2;
			this.ultraOriginalType.BeforeEditorButtonDropDown += new Infragistics.Win.UltraWinEditors.BeforeEditorButtonDropDownEventHandler(this.SetTreeViewID);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ultraTextEditor2);
			this.groupBox1.Controls.Add(this.numericUpDown2);
			this.groupBox1.Controls.Add(this.ultraTextEditor1);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(285, 65);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "To Following items:";
			this.groupBox1.Validating += new System.ComponentModel.CancelEventHandler(this.groupBox1_Validating);
			// 
			// ultraTextEditor2
			// 
			dropDownEditorButton2.Control = this.ucTreeView1;
			dropDownEditorButton2.PreferredDropDownSize = new System.Drawing.Size(0, 0);
			this.ultraTextEditor2.ButtonsRight.Add(dropDownEditorButton2);
			this.ultraTextEditor2.Location = new System.Drawing.Point(99, 40);
			this.ultraTextEditor2.Name = "ultraTextEditor2";
			this.ultraTextEditor2.Size = new System.Drawing.Size(185, 21);
			this.ultraTextEditor2.TabIndex = 8;
			this.ultraTextEditor2.BeforeEditorButtonDropDown += new Infragistics.Win.UltraWinEditors.BeforeEditorButtonDropDownEventHandler(this.SetTreeViewID);
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.DecimalPlaces = 2;
			this.numericUpDown2.Location = new System.Drawing.Point(6, 40);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(92, 20);
			this.numericUpDown2.TabIndex = 7;
			this.numericUpDown2.Enter += new System.EventHandler(this.SetMaxPercent);
			this.numericUpDown2.Leave += new System.EventHandler(this.CalcTotalPercent);
			// 
			// ultraTextEditor1
			// 
			dropDownEditorButton3.Control = this.ucTreeView1;
			dropDownEditorButton3.PreferredDropDownSize = new System.Drawing.Size(0, 0);
			this.ultraTextEditor1.ButtonsRight.Add(dropDownEditorButton3);
			this.ultraTextEditor1.Location = new System.Drawing.Point(99, 15);
			this.ultraTextEditor1.Name = "ultraTextEditor1";
			this.ultraTextEditor1.Size = new System.Drawing.Size(185, 21);
			this.ultraTextEditor1.TabIndex = 5;
			this.ultraTextEditor1.BeforeEditorButtonDropDown += new Infragistics.Win.UltraWinEditors.BeforeEditorButtonDropDownEventHandler(this.SetTreeViewID);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Location = new System.Drawing.Point(5, 16);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(92, 20);
			this.numericUpDown1.TabIndex = 4;
			this.numericUpDown1.Enter += new System.EventHandler(this.SetMaxPercent);
			this.numericUpDown1.Leave += new System.EventHandler(this.CalcTotalPercent);
			// 
			// CustomRemap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(285, 139);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomRemap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CustomRemap";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraOriginalType)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        private UCTreeView ucTreeView1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraOriginalType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
    }
}