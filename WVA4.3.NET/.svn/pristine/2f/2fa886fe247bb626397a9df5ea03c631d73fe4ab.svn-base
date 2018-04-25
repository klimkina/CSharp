using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserControls
{
    public partial class frmPrintProperties : Form
    {
        private PreviewSettings settings;
        public PreviewSettings PreviewSettings
        { 
            get {return settings;}
            set {
                settings = value;
                if (settings.FitToPages > 0)
                {
                    chkFit.Checked = true;
                    nPages.Value = settings.FitToPages;
                }
                chkImage.Checked = settings.IncludeImage;
                chkFilter.Checked = settings.IncludeFilter;
                if (settings.PagesFrom > 0 || settings.PagesTo > 0)
                {
                    radioRange.Checked = true;
                    this.txtFrom.Text = settings.PagesFrom.ToString();
                    this.txtTo.Text = settings.PagesTo.ToString();
                }
                radioAll.Checked = settings.AllPages;
                radioCurrent.Checked = settings.CurrentPage;
                txtTitle.Text = settings.Title;
            }
        }

        public frmPrintProperties(string title)
        {
            InitializeComponent();
            settings = new PreviewSettings(title);
            this.txtTitle.Text = title;
			updateProductUI();
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

        private void chkFit_CheckedChanged(object sender, EventArgs e)
        {
            nPages.Enabled = chkFit.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //set the previewinfo values based on the values selected in
                // the controls on the form

                if (chkFit.Checked)
                    settings.FitToPages = Int32.Parse(nPages.Value.ToString().Trim());
                settings.IncludeImage = chkImage.Checked;
                settings.IncludeFilter = chkFilter.Checked;
                if (radioRange.Checked)
                { 
                    settings.PagesFrom = Int32.Parse(this.txtFrom.Text.Trim());
                    settings.PagesTo = Int32.Parse(this.txtTo.Text.Trim());
                }
                settings.AllPages = radioAll.Checked;
                settings.CurrentPage = radioCurrent.Checked;
                settings.Title = txtTitle.Text;
                this.Close();
            }
            catch{}
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtFrom.Enabled = radioRange.Checked;
            txtTo.Enabled = radioRange.Checked;
        }
    }
    public class PreviewSettings
    {
        private string title;
        private int pages;
        private bool filter;
        private bool image;
        private bool isAll;
        private bool isCurrent;
        private int pagesFrom;
        private int pagesTo;

        public string Title 
        { 
            get { return title; }
            set { title = value; }
        }
        public int FitToPages 
        { 
            get { return pages; }
            set { pages = value; }
        }
        public bool IncludeFilter 
        { 
            get { return filter; }
            set { filter = value; }
        }
        public bool IncludeImage 
        { 
            get { return image; }
            set { image = value; }
        }
        public bool AllPages 
        { 
            get { return isAll; }
            set { isAll = value; }
        }
        public bool CurrentPage 
        { 
            get { return isCurrent; }
            set { isCurrent = value; }
        }
        public int PagesFrom 
        { 
            get { return pagesFrom; }
            set { pagesFrom = value; }
        }
        public int PagesTo 
        { 
            get { return pagesTo; }
            set { pagesTo = value; }
        }

        public PreviewSettings() : this("Waste")
        { 
        }

        public PreviewSettings(string title)
        { 
            this.title = title;
            pages = 0;
            filter = false;
            image = false;
            isAll = true;
            isCurrent = false;
            pagesFrom = 0;
            pagesTo = 0;
        }
    }
}
