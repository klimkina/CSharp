using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;

namespace UserControls
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class CustomColumnChooser : System.Windows.Forms.Form
	{
		public CustomColumnChooser()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}	

		#region Grid

		private UltraGridBase grid = null;

		/// <summary>
		/// Gets or sets the UltraGrid instances whose columns are displayed in the column chooser.
		/// </summary>
		public UltraGridBase Grid
		{
			get
			{
				return this.grid;
			}
			set
			{
				if ( value != this.grid )
				{
					this.grid = value;

					this.ultraGridColumnChooser1.SourceGrid = this.grid;
				}
			}
		}

		#endregion // Grid

		
		#region ColumnChooserControl

		/// <summary>
		/// Returns the column chooser control.
		/// </summary>
		public UltraGridColumnChooser ColumnChooserControl
		{
			get
			{
				return this.ultraGridColumnChooser1;
			}
		}

		#endregion // ColumnChooserControl

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

		
	}
}

