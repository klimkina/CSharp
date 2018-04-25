namespace UserControls
{
	partial class UCManageEachFormats
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
			Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			this.pTaskHdr = new System.Windows.Forms.Panel();
			this.lTaskTitle = new DevExpress.XtraEditors.LabelControl();
			this.bDone = new Infragistics.Win.Misc.UltraButton();
			this.txtEachName = new System.Windows.Forms.TextBox();
			this.lEachName = new System.Windows.Forms.Label();
			this.lUnitsWtLeadin = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.ceWtMultiplier = new DevExpress.XtraEditors.CalcEdit();
			this.lFoodEach_TypeName = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.cbWtUnits = new System.Windows.Forms.ComboBox();
			this.lEachQuantityleadin = new Infragistics.Win.Misc.UltraLabel();
			this.ceEachQuantity = new DevExpress.XtraEditors.CalcEdit();
			this.lFoodEach_TypeID = new Infragistics.Win.Misc.UltraLabel();
			this.bNew = new System.Windows.Forms.Button();
			this.bOpen = new System.Windows.Forms.Button();
			this.bSave = new System.Windows.Forms.Button();
			this.bSelectFoodType = new System.Windows.Forms.Button();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pTaskHdr.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ceWtMultiplier.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ceEachQuantity.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pTaskHdr
			// 
			this.pTaskHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(174)))), ((int)(((byte)(65)))));
			this.pTaskHdr.Controls.Add(this.lTaskTitle);
			this.pTaskHdr.Dock = System.Windows.Forms.DockStyle.Top;
			this.pTaskHdr.Location = new System.Drawing.Point(0, 0);
			this.pTaskHdr.Name = "pTaskHdr";
			this.pTaskHdr.Size = new System.Drawing.Size(669, 45);
			this.pTaskHdr.TabIndex = 255;
			// 
			// lTaskTitle
			// 
			this.lTaskTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lTaskTitle.Appearance.ForeColor = System.Drawing.Color.White;
			this.lTaskTitle.Appearance.Options.UseFont = true;
			this.lTaskTitle.Appearance.Options.UseForeColor = true;
			this.lTaskTitle.Location = new System.Drawing.Point(3, 4);
			this.lTaskTitle.Name = "lTaskTitle";
			this.lTaskTitle.Size = new System.Drawing.Size(321, 35);
			this.lTaskTitle.TabIndex = 56;
			this.lTaskTitle.Text = "Manage Each Formats";
			// 
			// bDone
			// 
			this.bDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bDone.Location = new System.Drawing.Point(548, 409);
			this.bDone.Name = "bDone";
			this.bDone.Size = new System.Drawing.Size(105, 29);
			this.bDone.TabIndex = 256;
			this.bDone.Text = "Done";
			this.bDone.Click += new System.EventHandler(this.bDone_Click);
			// 
			// txtEachName
			// 
			this.txtEachName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEachName.Location = new System.Drawing.Point(164, 82);
			this.txtEachName.Name = "txtEachName";
			this.txtEachName.Size = new System.Drawing.Size(176, 21);
			this.txtEachName.TabIndex = 257;
			this.txtEachName.Text = "txtEachName";
			this.txtEachName.TextChanged += new System.EventHandler(this.txtEachName_TextChanged);
			// 
			// lEachName
			// 
			this.lEachName.AutoSize = true;
			this.lEachName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lEachName.Location = new System.Drawing.Point(14, 85);
			this.lEachName.Name = "lEachName";
			this.lEachName.Size = new System.Drawing.Size(144, 16);
			this.lEachName.TabIndex = 258;
			this.lEachName.Text = "Each Format Name:";
			// 
			// lUnitsWtLeadin
			// 
			appearance56.FontData.BoldAsString = "True";
			appearance56.TextHAlignAsString = "Left";
			appearance56.TextVAlignAsString = "Middle";
			this.lUnitsWtLeadin.Appearance = appearance56;
			this.lUnitsWtLeadin.AutoSize = true;
			this.lUnitsWtLeadin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lUnitsWtLeadin.Location = new System.Drawing.Point(63, 174);
			this.lUnitsWtLeadin.Name = "lUnitsWtLeadin";
			this.lUnitsWtLeadin.Size = new System.Drawing.Size(90, 17);
			this.lUnitsWtLeadin.TabIndex = 213;
			this.lUnitsWtLeadin.Text = "Weight Units:";
			// 
			// ultraLabel5
			// 
			appearance1.FontData.BoldAsString = "True";
			appearance1.TextHAlignAsString = "Left";
			appearance1.TextVAlignAsString = "Middle";
			this.ultraLabel5.Appearance = appearance1;
			this.ultraLabel5.AutoSize = true;
			this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ultraLabel5.Location = new System.Drawing.Point(38, 213);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.Size = new System.Drawing.Size(115, 17);
			this.ultraLabel5.TabIndex = 262;
			this.ultraLabel5.Text = "Weight Multiplier:";
			// 
			// ceWtMultiplier
			// 
			this.ceWtMultiplier.Location = new System.Drawing.Point(164, 211);
			this.ceWtMultiplier.Name = "ceWtMultiplier";
			this.ceWtMultiplier.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ceWtMultiplier.Properties.Appearance.Options.UseFont = true;
			this.ceWtMultiplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ceWtMultiplier.Size = new System.Drawing.Size(140, 21);
			this.ceWtMultiplier.TabIndex = 260;
			this.ceWtMultiplier.TextChanged += new System.EventHandler(this.txtEachName_TextChanged);
			// 
			// lFoodEach_TypeName
			// 
			appearance2.FontData.BoldAsString = "True";
			appearance2.TextHAlignAsString = "Left";
			appearance2.TextVAlignAsString = "Middle";
			this.lFoodEach_TypeName.Appearance = appearance2;
			this.lFoodEach_TypeName.AutoSize = true;
			this.lFoodEach_TypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFoodEach_TypeName.Location = new System.Drawing.Point(164, 117);
			this.lFoodEach_TypeName.Name = "lFoodEach_TypeName";
			this.lFoodEach_TypeName.Size = new System.Drawing.Size(150, 17);
			this.lFoodEach_TypeName.TabIndex = 214;
			this.lFoodEach_TypeName.Text = "lFoodEach_TypeName";
			// 
			// ultraLabel4
			// 
			appearance6.FontData.BoldAsString = "True";
			appearance6.TextHAlignAsString = "Left";
			appearance6.TextVAlignAsString = "Middle";
			this.ultraLabel4.Appearance = appearance6;
			this.ultraLabel4.AutoSize = true;
			this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ultraLabel4.Location = new System.Drawing.Point(76, 117);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.Size = new System.Drawing.Size(77, 17);
			this.ultraLabel4.TabIndex = 213;
			this.ultraLabel4.Text = "Food Type:";
			// 
			// cbWtUnits
			// 
			this.cbWtUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbWtUnits.FormattingEnabled = true;
			this.cbWtUnits.Location = new System.Drawing.Point(164, 171);
			this.cbWtUnits.Name = "cbWtUnits";
			this.cbWtUnits.Size = new System.Drawing.Size(140, 23);
			this.cbWtUnits.TabIndex = 214;
			this.cbWtUnits.TextChanged += new System.EventHandler(this.txtEachName_TextChanged);
			// 
			// lEachQuantityleadin
			// 
			appearance30.FontData.BoldAsString = "True";
			appearance30.TextHAlignAsString = "Left";
			appearance30.TextVAlignAsString = "Middle";
			this.lEachQuantityleadin.Appearance = appearance30;
			this.lEachQuantityleadin.AutoSize = true;
			this.lEachQuantityleadin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lEachQuantityleadin.Location = new System.Drawing.Point(54, 249);
			this.lEachQuantityleadin.Name = "lEachQuantityleadin";
			this.lEachQuantityleadin.Size = new System.Drawing.Size(99, 17);
			this.lEachQuantityleadin.TabIndex = 264;
			this.lEachQuantityleadin.Text = "Each Quantity:";
			// 
			// ceEachQuantity
			// 
			this.ceEachQuantity.Location = new System.Drawing.Point(164, 247);
			this.ceEachQuantity.Name = "ceEachQuantity";
			this.ceEachQuantity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ceEachQuantity.Properties.Appearance.Options.UseFont = true;
			this.ceEachQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ceEachQuantity.Size = new System.Drawing.Size(140, 21);
			this.ceEachQuantity.TabIndex = 263;
			this.ceEachQuantity.TextChanged += new System.EventHandler(this.txtEachName_TextChanged);
			// 
			// lFoodEach_TypeID
			// 
			appearance5.FontData.BoldAsString = "True";
			appearance5.TextHAlignAsString = "Left";
			appearance5.TextVAlignAsString = "Middle";
			this.lFoodEach_TypeID.Appearance = appearance5;
			this.lFoodEach_TypeID.AutoSize = true;
			this.lFoodEach_TypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lFoodEach_TypeID.Location = new System.Drawing.Point(164, 141);
			this.lFoodEach_TypeID.Name = "lFoodEach_TypeID";
			this.lFoodEach_TypeID.Size = new System.Drawing.Size(127, 17);
			this.lFoodEach_TypeID.TabIndex = 215;
			this.lFoodEach_TypeID.Text = "lFoodEach_TypeID";
			this.lFoodEach_TypeID.TextChanged += new System.EventHandler(this.txtEachName_TextChanged);
			// 
			// bNew
			// 
			this.bNew.Location = new System.Drawing.Point(38, 322);
			this.bNew.Name = "bNew";
			this.bNew.Size = new System.Drawing.Size(109, 23);
			this.bNew.TabIndex = 265;
			this.bNew.Text = "New Each Format";
			this.bNew.UseVisualStyleBackColor = true;
			this.bNew.Click += new System.EventHandler(this.bNew_Click);
			// 
			// bOpen
			// 
			this.bOpen.Location = new System.Drawing.Point(164, 322);
			this.bOpen.Name = "bOpen";
			this.bOpen.Size = new System.Drawing.Size(109, 23);
			this.bOpen.TabIndex = 266;
			this.bOpen.Text = "Open Each Format";
			this.bOpen.UseVisualStyleBackColor = true;
			this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
			// 
			// bSave
			// 
			this.bSave.Location = new System.Drawing.Point(368, 322);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(109, 23);
			this.bSave.TabIndex = 267;
			this.bSave.Text = "Save Each Format";
			this.bSave.UseVisualStyleBackColor = true;
			this.bSave.Click += new System.EventHandler(this.bSave_Click);
			// 
			// bSelectFoodType
			// 
			this.bSelectFoodType.Location = new System.Drawing.Point(38, 138);
			this.bSelectFoodType.Name = "bSelectFoodType";
			this.bSelectFoodType.Size = new System.Drawing.Size(109, 23);
			this.bSelectFoodType.TabIndex = 268;
			this.bSelectFoodType.Text = "Select Food Type";
			this.bSelectFoodType.UseVisualStyleBackColor = true;
			this.bSelectFoodType.Click += new System.EventHandler(this.ChooseFood_Click);
			// 
			// txtDescription
			// 
			this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDescription.Location = new System.Drawing.Point(368, 114);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(205, 80);
			this.txtDescription.TabIndex = 269;
			this.txtDescription.Text = "txtDescription";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(365, 85);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 16);
			this.label1.TabIndex = 270;
			this.label1.Text = "Description:";
			// 
			// UCManageEachFormats
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.bSelectFoodType);
			this.Controls.Add(this.bSave);
			this.Controls.Add(this.bOpen);
			this.Controls.Add(this.bNew);
			this.Controls.Add(this.cbWtUnits);
			this.Controls.Add(this.lUnitsWtLeadin);
			this.Controls.Add(this.lFoodEach_TypeID);
			this.Controls.Add(this.lEachQuantityleadin);
			this.Controls.Add(this.lFoodEach_TypeName);
			this.Controls.Add(this.ceEachQuantity);
			this.Controls.Add(this.ultraLabel4);
			this.Controls.Add(this.ultraLabel5);
			this.Controls.Add(this.ceWtMultiplier);
			this.Controls.Add(this.lEachName);
			this.Controls.Add(this.txtEachName);
			this.Controls.Add(this.bDone);
			this.Controls.Add(this.pTaskHdr);
			this.Name = "UCManageEachFormats";
			this.Size = new System.Drawing.Size(669, 451);
			this.pTaskHdr.ResumeLayout(false);
			this.pTaskHdr.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ceWtMultiplier.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ceEachQuantity.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pTaskHdr;
		private DevExpress.XtraEditors.LabelControl lTaskTitle;
		private Infragistics.Win.Misc.UltraButton bDone;
		private System.Windows.Forms.TextBox txtEachName;
		private System.Windows.Forms.Label lEachName;
		private Infragistics.Win.Misc.UltraLabel lUnitsWtLeadin;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private DevExpress.XtraEditors.CalcEdit ceWtMultiplier;
		private Infragistics.Win.Misc.UltraLabel lFoodEach_TypeName;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private System.Windows.Forms.ComboBox cbWtUnits;
		private Infragistics.Win.Misc.UltraLabel lEachQuantityleadin;
		private DevExpress.XtraEditors.CalcEdit ceEachQuantity;
		private Infragistics.Win.Misc.UltraLabel lFoodEach_TypeID;
		private System.Windows.Forms.Button bNew;
		private System.Windows.Forms.Button bOpen;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.Button bSelectFoodType;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label1;
	}
}
