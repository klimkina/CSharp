using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;

namespace VWA4Common
{
	public partial class SplashScreen : Form
	{
		public SplashScreen()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			//this.labelProductName.Text = AssemblyProduct;
			this.lVersion.Text = String.Format("Version: {0}", AssemblyVersion);
			//lLicense.Text = "License Expiration: " + DateTime.Parse(UserControls.SecurityManager.GetSecurityManager()["Expiration Date"]).ToString("dd MMMM yyyy hh:mm tt");
			this.pErrorPanel.Hide();  // start with Error Panel hidden
			this.Opacity = .00;
			timer1.Interval = TIMER_INTERVAL;
			timer1.Start();
		}
		
		///
		/// ************* Static Methods *************** 
		///

		// Fade in and out.
		private double m_dblOpacityIncrement = .07;
		private double m_dblOpacityDecrement = .09;
		private const int TIMER_INTERVAL = 50;
		
		// Status string
		static string ms_sStatus;
		static int ms_iLevel;
		static string ms_sLicense;
        static string ms_sSiteName;
        static string ms_sLevel;
		static bool ms_bHideSplashNow;

		//// Error panel
		//static string erp_errorleadin; 
		//static string erp_errormessage;
		//static string erp_installbtntext;
		//static string erp_quitbtntext;
		//static bool erp_visible;

		//static DialogResult dr_error;

		// Threading
		static SplashScreen ms_frmSplash = null;
		static Thread ms_oThread = null;

		// A static method to create the thread and 
		// launch the SplashScreen.
		static public void ShowSplashScreen()
		{
			// Make sure it's only launched once.
			if (ms_frmSplash != null)
				return;
			ms_oThread = new Thread(new ThreadStart(SplashScreen.ShowForm));
			ms_oThread.IsBackground = true;
			ms_oThread.ApartmentState = ApartmentState.STA;
			ms_oThread.Start();
			//dr_error = DialogResult.None;
		}

		// A property returning the splash screen instance
		static public SplashScreen SplashForm
		{
			get
			{
				return ms_frmSplash;
			}
		}

		// A private entry point for the thread.
		static private void ShowForm()
		{
			ms_frmSplash = new SplashScreen();
			Application.Run(ms_frmSplash);
		}

		// A static method to close the SplashScreen
		static public void CloseForm()
		{
			if (ms_frmSplash != null && ms_frmSplash.IsDisposed == false)
			{
				// Make it start going away.
				ms_frmSplash.m_dblOpacityIncrement = -ms_frmSplash.m_dblOpacityDecrement;
			}
			ms_oThread = null;	// we don't need these any more.
			ms_frmSplash = null;
		}

		// A static method to set the status
		static public void SetStatus(string newStatus, int newlevel)
		{
			ms_sStatus = newStatus;
			LastStatus = newStatus;
			ms_iLevel = newlevel;
		}
		
		private static string _LastStatus = "";
		static public string LastStatus
		{
			get
			{
				return _LastStatus;
			}
			set
			{
				_LastStatus = value;
			}
		}

		static public void SetLicense(string sLicense)
		{
			ms_sLicense = sLicense;
		}
        static public void SetSiteName(string sSiteName)
        {
            ms_sSiteName = "Site Name: " + sSiteName;
        }
        static public void SetLevel(string sLevel)
        {
            ms_sLevel = "Your Level: " + sLevel;
        }

		static public void SetHideSplashNow(bool hidenow)
		{

			ms_bHideSplashNow = hidenow;
		}

		//static public void Setdr_error(DialogResult newvalue)
		//{
		//    dr_error = newvalue;
		//}

		//static public DialogResult Getdr_error()
		//{
		//    return dr_error;
		//}

		//static public void SetErrorPanelText(string errorleadin, string errormessage, string installbtntext,
		//    string quitbtntext)
		//{
		//    erp_errorleadin = errorleadin;
		//    erp_errormessage = errormessage;
		//    erp_installbtntext = installbtntext;
		//    erp_quitbtntext = quitbtntext;
		//}

		//static public void SetErrorPanelHideSplashNow(bool hidenow)
		//{
		//    erp_visible = hidenow;
		//}


		///
		///********* Event Handlers ************
		///

		// Tick Event handler for the Timer control.  Handle fade in and fade out.  Also
		// handle the smoothed progress bar.
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			SetlblStatusText(ms_sStatus);
			SetProgressBar(ms_iLevel);
			SetlblLicenseText(ms_sLicense);
            SetlblSiteNameText(ms_sSiteName);
            SetlblLevelText(ms_sLevel);
			labelProductName.Text = GlobalSettings.ProductName;
			this.Text = labelProductName.Text;
			//SetErrorPanel(erp_errorleadin, erp_errormessage, erp_installbtntext, erp_quitbtntext);
			//SetErrorPanelHideNow(erp_visible);

			if (ms_bHideSplashNow)
			{
				SetHideNow(true);
				return;
			}
			else
			{
				SetHideNow(false);
			}

				if (m_dblOpacityIncrement > 0)
				{
					if (this.Opacity < 1)
						this.Opacity += m_dblOpacityIncrement;
				}
				else
				{
					if (this.Opacity > 0)
						this.Opacity += m_dblOpacityIncrement;
					else
					{
						this.Close();
					}
				}
		}

		/// Handle cross-thread control accesses
		private delegate void SetlblStatusTextDelegate(string labeltext);
		private void SetlblStatusText(string labeltext)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new SetlblStatusTextDelegate(SetlblStatusText), new object[] { labeltext });
				return;
			}
			lblStatus.Text = labeltext;
		}
		
		private delegate void SetlblLicenseTextDelegate(string labeltext);
		private void SetlblLicenseText(string labeltext)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new SetlblLicenseTextDelegate(SetlblLicenseText), new object[] { labeltext });
				return;
			}
			lLicense.Text = labeltext;
		}
        private delegate void SetlblSiteNameTextDelegate(string labeltext);
        private void SetlblSiteNameText(string labeltext)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetlblSiteNameTextDelegate(SetlblSiteNameText), new object[] { labeltext });
                return;
            }
            lSiteName.Text = labeltext;
        }
        private delegate void SetlblLevelTextDelegate(string labeltext);
        private void SetlblLevelText(string labeltext)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetlblLevelTextDelegate(SetlblLevelText), new object[] { labeltext });
                return;
            }
            lLevel.Text = labeltext;
        }
		private delegate void SetProgressBarDelegate(int level);
		private void SetProgressBar(int level)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new SetProgressBarDelegate(SetProgressBar), new object[] { level });
				return;
			}
			if (level < 0) level = 0;
			if (level > 100) level = 100;
			progressBar1.Value = level;
		}
		private delegate void SetHideNowDelegate(bool hidenow);
		private void SetHideNow(bool hidenow)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new SetHideNowDelegate(SetHideNow), new object[] { hidenow });
				return;
			}
			if (hidenow) this.Hide(); else this.Show();
		}

		//private delegate void SetErrorPanelDelegate(string errorleadin, string errormessage, string installbtntext, 
		//    string quitbtntext);
		//private void SetErrorPanel(string errorleadin, string errormessage, string installbtntext, 
		//    string quitbtntext)
		//{
		//    if (this.InvokeRequired)
		//    {
		//        this.BeginInvoke(new SetErrorPanelDelegate(SetErrorPanel), new object[] { errorleadin, 
		//            errormessage, installbtntext, quitbtntext });
		//        return;
		//    }
		//    lErrorLeadin.Text = errorleadin;
		//    lErrorMessage.Text = errormessage;
		//    bInstall.Text = installbtntext;
		//    bQuit.Text = quitbtntext;
		//    this.Show();

		//    //if (hidenow) this.Hide(); else this.Show();
		//}
		//private delegate void SetErrorPanelHideNowDelegate(bool hidenow);
		//private void SetErrorPanelHideNow(bool hidenow)
		//{
		//    if (this.InvokeRequired)
		//    {
		//        this.BeginInvoke(new SetErrorPanelHideNowDelegate(SetErrorPanelHideNow), new object[] { hidenow });
		//        return;
		//    }
		//    if (hidenow) this.Hide(); else this.Show();
		//}


		/// <summary>
		///  Assembly Attribute Accessors
		/// </summary>
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

		//private void bInstall_Click(object sender, EventArgs e)
		//{
		//    Setdr_error(DialogResult.OK);
		//    SetErrorPanelHideNow(true);
		//}

		//private void bQuit_Click(object sender, EventArgs e)
		//{
		//    Setdr_error(DialogResult.Cancel);
		//    SetErrorPanelHideNow(true);
		//}
	}
}
