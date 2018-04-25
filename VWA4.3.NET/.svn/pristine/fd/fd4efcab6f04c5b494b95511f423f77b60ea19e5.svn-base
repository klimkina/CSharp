using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace VWA4
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

			if (VWA4Common.GlobalSettings.ProductType == 1)
			{
				this.Text = "About ValuWaste Advantage"; // String.Format("About {0} {0}", AssemblyTitle);
				this.labelProductName.Text = AssemblyProduct;
				this.lVersion.Text = String.Format("Version: {0}", AssemblyVersion);
				//lLicense.Text = "License Expiration: " + DateTime.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Expiration Date")).ToString("dd MMMM yyyy hh:mm tt");
				lLicense.Text = "License Expiration: " + DateTime.Parse(VWA4Common.GlobalSettings.ExpirationDate.ToString("dd MMMM yyyy hh:mm tt"));
				//lSiteName.Text = "Site Name: " + VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Site ID");
				//lSiteName.Text = "Site ID: " + VWA4Common.GlobalSettings.sit;
				label7.Text 
					= "LeanPath and ValuWaste are registered trademarks of LeanPath, Inc.  All Rights Reserved.";
				//this.labelCopyright.Text = AssemblyCopyright;
				//this.lCompany.Text = AssemblyCompany;
				//this.textBoxDescription.Text = AssemblyDescription;
				this.Icon = VWA4Common.GlobalSettings.ProductIcon;
			}
			else
			{
				this.Text = "About WasteLOGGER"; // String.Format("About {0} {0}", AssemblyTitle);
				this.labelProductName.Text = "LeanPath WasteLOGGER";
				this.lVersion.Text = "Version: 1.0";
				lLicense.Text = "License Expiration: " 
					//+ DateTime.Parse(VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Expiration Date")).ToString("dd MMMM yyyy hh:mm tt");
					+ VWA4Common.GlobalSettings.ExpirationDate.ToString("dd MMMM yyyy hh:mm tt");
				//lSiteName.Text = "Site Name: " + VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Site ID");
				//lSiteName.Text = "Site ID: " + VWA4Common.GlobalSettings.ClientSite_ID;
				//lLevel.Text = "Your Product: " + VWA4Common.SecurityManager.GetSecurityManager().GetPermission("Product");
				lLevel.Text = "Your Product: " + VWA4Common.GlobalSettings.ProductName;
				label7.Text = "LeanPath is a registered trademark of LeanPath, Inc.  All Rights Reserved.";
				this.Icon = VWA4Common.GlobalSettings.ProductIcon;
			}

			/// Show/hide stuff based on licensing
			/// 
			lSupportSite.Visible = VWA4Common.GlobalSettings.ShowSupportWebsite;
			lSupportSite.Text = "Support Site  -      " +
				VWA4Common.GlobalSettings.SupportWebsite;
			///
			lSupportEmailleadin.Visible = VWA4Common.GlobalSettings.ShowSupportEmailAddress;
			lSupportEmail.Visible = VWA4Common.GlobalSettings.ShowSupportEmailAddress;
			lSupportEmail.Text = VWA4Common.GlobalSettings.SupportEmailAddress;
			///
			lSupportPhoneleadin.Visible = VWA4Common.GlobalSettings.ShowSupportPhoneNumber;
			lSupportPhone.Visible = VWA4Common.GlobalSettings.ShowSupportPhoneNumber;
			lSupportPhone.Text = VWA4Common.GlobalSettings.SupportPhoneNumber;
		}

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void lCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.leanpath.com");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://client.leanpath.com");
		}
    }
}
