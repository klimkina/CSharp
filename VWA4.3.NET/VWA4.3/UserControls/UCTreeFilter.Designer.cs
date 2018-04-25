namespace UserControls
{
    partial class UCTreeFilter
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.gpRadio = new System.Windows.Forms.GroupBox();
            this.radioContainer = new System.Windows.Forms.RadioButton();
            this.radioEventOrder = new System.Windows.Forms.RadioButton();
            this.radioDayPart = new System.Windows.Forms.RadioButton();
            this.radioDisposition = new System.Windows.Forms.RadioButton();
            this.radioLoss = new System.Windows.Forms.RadioButton();
            this.radioFood = new System.Windows.Forms.RadioButton();
            this.radioStation = new System.Windows.Forms.RadioButton();
            this.ucTreeView1 = new UserControls.UCTreeView();
            this.ucSiteChooser1 = new UserControls.UCSiteChooser();
            this.groupBox3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.gpRadio.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel6);
            this.groupBox3.Controls.Add(this.panelLeft);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 232);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Additional Filters";
            this.groupBox3.Leave += new System.EventHandler(this.groupBox3_Leave);
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.Controls.Add(this.ucTreeView1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(140, 16);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(348, 213);
            this.panel6.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.AutoSize = true;
            this.panelLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLeft.Controls.Add(this.ucSiteChooser1);
            this.panelLeft.Controls.Add(this.label7);
            this.panelLeft.Controls.Add(this.gpRadio);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(3, 16);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(137, 213);
            this.panelLeft.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Choose Site:";
            // 
            // gpRadio
            // 
            this.gpRadio.Controls.Add(this.radioContainer);
            this.gpRadio.Controls.Add(this.radioEventOrder);
            this.gpRadio.Controls.Add(this.radioDayPart);
            this.gpRadio.Controls.Add(this.radioDisposition);
            this.gpRadio.Controls.Add(this.radioLoss);
            this.gpRadio.Controls.Add(this.radioFood);
            this.gpRadio.Controls.Add(this.radioStation);
            this.gpRadio.Location = new System.Drawing.Point(10, 44);
            this.gpRadio.Name = "gpRadio";
            this.gpRadio.Size = new System.Drawing.Size(124, 166);
            this.gpRadio.TabIndex = 9;
            this.gpRadio.TabStop = false;
            this.gpRadio.Text = "Choose Report Type:";
            // 
            // radioContainer
            // 
            this.radioContainer.AutoSize = true;
            this.radioContainer.Location = new System.Drawing.Point(12, 99);
            this.radioContainer.Name = "radioContainer";
            this.radioContainer.Size = new System.Drawing.Size(97, 17);
            this.radioContainer.TabIndex = 6;
            this.radioContainer.TabStop = true;
            this.radioContainer.Text = "Container Type";
            this.radioContainer.UseVisualStyleBackColor = true;
            this.radioContainer.CheckedChanged += new System.EventHandler(this.radioContainer_CheckedChanged);
            // 
            // radioEventOrder
            // 
            this.radioEventOrder.AutoSize = true;
            this.radioEventOrder.Location = new System.Drawing.Point(12, 139);
            this.radioEventOrder.Name = "radioEventOrder";
            this.radioEventOrder.Size = new System.Drawing.Size(109, 17);
            this.radioEventOrder.TabIndex = 5;
            this.radioEventOrder.TabStop = true;
            this.radioEventOrder.Text = "Event Order Type";
            this.radioEventOrder.UseVisualStyleBackColor = true;
            this.radioEventOrder.CheckedChanged += new System.EventHandler(this.radioEventOrder_CheckedChanged);
            // 
            // radioDayPart
            // 
            this.radioDayPart.AutoSize = true;
            this.radioDayPart.Location = new System.Drawing.Point(12, 119);
            this.radioDayPart.Name = "radioDayPart";
            this.radioDayPart.Size = new System.Drawing.Size(93, 17);
            this.radioDayPart.TabIndex = 4;
            this.radioDayPart.TabStop = true;
            this.radioDayPart.Text = "Day Part Type";
            this.radioDayPart.UseVisualStyleBackColor = true;
            this.radioDayPart.CheckedChanged += new System.EventHandler(this.radioDayPart_CheckedChanged);
            // 
            // radioDisposition
            // 
            this.radioDisposition.AutoSize = true;
            this.radioDisposition.Location = new System.Drawing.Point(12, 79);
            this.radioDisposition.Name = "radioDisposition";
            this.radioDisposition.Size = new System.Drawing.Size(103, 17);
            this.radioDisposition.TabIndex = 3;
            this.radioDisposition.TabStop = true;
            this.radioDisposition.Text = "Disposition Type";
            this.radioDisposition.UseVisualStyleBackColor = true;
            this.radioDisposition.CheckedChanged += new System.EventHandler(this.radioDisposition_CheckedChanged);
            // 
            // radioLoss
            // 
            this.radioLoss.AutoSize = true;
            this.radioLoss.Location = new System.Drawing.Point(12, 59);
            this.radioLoss.Name = "radioLoss";
            this.radioLoss.Size = new System.Drawing.Size(74, 17);
            this.radioLoss.TabIndex = 2;
            this.radioLoss.TabStop = true;
            this.radioLoss.Text = "Loss Type";
            this.radioLoss.UseVisualStyleBackColor = true;
            this.radioLoss.CheckedChanged += new System.EventHandler(this.radioLoss_CheckedChanged);
            // 
            // radioFood
            // 
            this.radioFood.AutoSize = true;
            this.radioFood.Location = new System.Drawing.Point(12, 39);
            this.radioFood.Name = "radioFood";
            this.radioFood.Size = new System.Drawing.Size(76, 17);
            this.radioFood.TabIndex = 1;
            this.radioFood.TabStop = true;
            this.radioFood.Text = "Food Type";
            this.radioFood.UseVisualStyleBackColor = true;
            this.radioFood.CheckedChanged += new System.EventHandler(this.radioFood_CheckedChanged);
            // 
            // radioStation
            // 
            this.radioStation.AutoSize = true;
            this.radioStation.Location = new System.Drawing.Point(12, 19);
            this.radioStation.Name = "radioStation";
            this.radioStation.Size = new System.Drawing.Size(85, 17);
            this.radioStation.TabIndex = 0;
            this.radioStation.TabStop = true;
            this.radioStation.Text = "Station Type";
            this.radioStation.UseVisualStyleBackColor = true;
            this.radioStation.CheckedChanged += new System.EventHandler(this.radioStation_CheckedChanged);
            // 
            // ucTreeView1
            // 
            this.ucTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTreeView1.EnableCheckboxes = false;
            this.ucTreeView1.ID = "";
            this.ucTreeView1.Location = new System.Drawing.Point(0, 0);
            this.ucTreeView1.Name = "ucTreeView1";
            this.ucTreeView1.ShowAllNames = false;
            this.ucTreeView1.ShowPrice = false;
            this.ucTreeView1.Size = new System.Drawing.Size(348, 213);
            this.ucTreeView1.TabIndex = 0;
            this.ucTreeView1.TypeCatalogID = "0";
            this.ucTreeView1.TypeName = "";
            // 
            // ucSiteChooser1
            // 
            this.ucSiteChooser1.Location = new System.Drawing.Point(12, 19);
            this.ucSiteChooser1.Name = "ucSiteChooser1";
            this.ucSiteChooser1.Size = new System.Drawing.Size(116, 21);
            this.ucSiteChooser1.TabIndex = 12;
            this.ucSiteChooser1.SiteChanged += new UserControls.UCSiteChooser.SiteChangedEventHandler(this.ucSiteChooser1_SiteChanged);
            // 
            // UCTreeFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "UCTreeFilter";
            this.Size = new System.Drawing.Size(491, 232);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.gpRadio.ResumeLayout(false);
            this.gpRadio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gpRadio;
        private System.Windows.Forms.RadioButton radioEventOrder;
        private System.Windows.Forms.RadioButton radioDayPart;
        private System.Windows.Forms.RadioButton radioDisposition;
        private System.Windows.Forms.RadioButton radioLoss;
        private System.Windows.Forms.RadioButton radioFood;
        private System.Windows.Forms.RadioButton radioStation;
        private UCTreeView ucTreeView1;
        private UCSiteChooser ucSiteChooser1;
        private System.Windows.Forms.RadioButton radioContainer;
    }
}
