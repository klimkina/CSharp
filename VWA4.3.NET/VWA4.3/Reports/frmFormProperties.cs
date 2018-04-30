﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using VWA4Common.DAO;
using VWA4Common.DataObject;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using Infragistics.Win.UltraWinListView;

namespace Reports
{
    public partial class frmFormProperties : System.Windows.Forms.Form
    {
        public frmFormProperties(VWA4Common.DataObject.Formx f)
        {
            InitializeComponent();
			updateProductUI();
			this.lblNameValue.Text += f.Name;
            this.lblDocumentValue.Text += f.FileName;
            this.lblTypeValue.Text += f.DocumentType;
            this.lblLocationValue.Text += f.SavePath.Length > 0 ? f.SavePath : "Database";
            this.lblTemplateValue.Text += f.DataEntryTemplateId != 0 ? VWA4Common.DB.Retrieve("select DETName from DataEntryTemplates where ID=" + f.DataEntryTemplateId).Rows[0]["DETName"] : "";
            this.lblLastPrintValue.Text += f.LastPrintedDate;
            this.lblDateCreatedValue.Text += f.CreateDate.ToShortDateString();
            this.lblLastModifiedDateValue.Text += f.ModifiedDate.ToShortDateString();            
        }
		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void updateProductUI()
		{
			///***********
			/// Product Type
			///***********
			// Form background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Form header
			pFormHdr.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lFormTitle.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other stuff
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}