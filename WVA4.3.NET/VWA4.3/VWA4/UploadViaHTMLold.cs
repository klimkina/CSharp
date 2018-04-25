using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace VWA4Common
{
    public partial class UploadViaHTML : Form
    {
		string URLtoLoad;
		bool Uploader;

        public UploadViaHTML()
        {
            InitializeComponent();
			URLtoLoad = "http://www.leanpath.com/upload/";
			Uploader = true;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}
		public UploadViaHTML(string url)
		{
			InitializeComponent();
			URLtoLoad = url;
			Uploader = false;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}


		void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (Uploader)
			{
				HtmlDocument doc = this.webBrowser1.Document;
				//this.webBrowser1.Focus();
				SendKeys.Send("{TAB}" + "{TAB}" + VWA4Common.GlobalSettings.CurrentSiteName);
				//SendKeys.Send("{TAB}" + VWA4Common.GlobalSettings.PrimaryUserName);
				//SendKeys.Send("{TAB}" + VWA4Common.GlobalSettings.PrimaryUserEmail);
				SendKeys.Send("{TAB}" + VWA4Common.AppContext.DBPathName);
				webBrowser1.Show();
				HtmlElement textBox = doc.GetElementsByTagName("input")["f3"];
				//todo: need to set the attribute to the path name
				//textBox.SetAttribute("value", "c:\\temp\\");
				//textBox.SetAttribute("name", "name");
				//textBox.SetAttribute("text", "text");
				// Check the task complete
				VWA4Common.UtilitiesInstance utils = new VWA4Common.UtilitiesInstance();
                utils.setTaskCheck(DateTime.Parse(VWA4Common.GlobalSettings.StartDateOfSelectedWeek, CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None), true, "uploadwastedata");
			} else
			{
				// Don't send any keys
				HtmlDocument doc = this.webBrowser1.Document;
				webBrowser1.Show();
			}
		}

        private void Form1_Load(object sender, EventArgs e)
        {
			//webBrowser1.Hide();
			//this.webBrowser1.Url = new Uri("http://www.lrssolutions.com/Uploader");
			//string url = "http://www.leanpath.com/upload/";
//                            string url = "http://www.leanpath.com/upload/?" +
//"f1=" + VWA4Common.GlobalSettings.CurrentSiteName +
//                "&f9=" + VWA4Common.GlobalSettings.PrimaryUserName +
//                "&f2=" + VWA4Common.GlobalSettings.PrimaryUserEmail +
//                "&f3=" + VWA4Common.AppContext.DBPathName;
            this.webBrowser1.Navigate(URLtoLoad);
			//this.webBrowser1.Navigate("http://www.lrssolutions.com/Uploader");

            //HtmlDocument doc = this.webBrowser1.Document;
            //HtmlElement textBox = doc.GetElementsByTagName("input")["f1"];
            //textBox.SetAttribute("value", "c:\\temp\\");
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
    }
}
