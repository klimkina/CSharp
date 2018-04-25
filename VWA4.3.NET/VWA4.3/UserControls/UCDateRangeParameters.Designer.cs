namespace UserControls
{
    partial class UCDateRangeParameters
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
            this.dateEnd = new UserControls.SmartDateTimePicker();
            this.dateStart = new UserControls.SmartDateTimePicker();
            this.SuspendLayout();
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(4, 26);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(292, 22);
            this.dateEnd.TabIndex = 1;
            this.dateEnd.ValueChanged += new UserControls.SmartDateTimePicker.ValueChangedEventHandler(this.dateEnd_ValueChanged);
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(4, 2);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(292, 22);
            this.dateStart.TabIndex = 0;
            this.dateStart.ValueChanged += new UserControls.SmartDateTimePicker.ValueChangedEventHandler(this.dateStart_ValueChanged);
            // 
            // UCDateRangeParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Name = "UCDateRangeParameters";
            this.Size = new System.Drawing.Size(305, 51);
            this.ResumeLayout(false);

        }

        #endregion

        private SmartDateTimePicker dateStart;
        private SmartDateTimePicker dateEnd;
    }
}
