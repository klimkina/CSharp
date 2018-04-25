using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reports
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
			ucReportViewer1.InitReportViewerRunTime();
        }
        public frmReportViewer(bool isProgress)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
			ucReportViewer1.InitReportViewerRunTime();
		}
        public frmReportViewer(string name)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            if (name != null && name != "")
            {
                ucReportViewer1.SetReportType(name);
                this.Text = name + " Report Viewer";
            }
            ucReportViewer1.HideTopPanel();
			ucReportViewer1.InitReportViewerRunTime();
		}
       
		
		public void SetTitle(string name)
        {
            if (name != null && name != "")
                this.Text = "Report Viewer for " + name;
           
        }
        public void AddLoadParameters(int id)
        {
            AddLoadParameters(id, false);
        }
        public void AddLoadParameters(int id, bool isCorrectWeekly)
        {
            ucReportViewer1.AddLoadParameters(id, isCorrectWeekly);
        }

        public void AddPrint(int id)
        {
            AddPrint(id, false);
        }
        public void AddPrint(int id, bool isCorrectWeekly)
        {
            ucReportViewer1.AddPrint(id, isCorrectWeekly);
        }

        public void AddPDF(int id)
        {
            AddPDF(id, false);
        }
        public void AddPDF(int id, bool isCorrectWeekly)
        {
            ucReportViewer1.AddPDF(id, isCorrectWeekly);
        }

        public void View(int id)
        {
            View(id, false);
        }
        public void View(int id, bool isCorrectWeekly)
        {
            ucReportViewer1.View(id, isCorrectWeekly);
        }
        public void View()
        {
            ucReportViewer1.View();
        }
        public void Print(int id)
        {
            ucReportViewer1.Print(id);
        }
        public void Print()
        {
            ucReportViewer1.Print();
        }
        public void ShowPDF(string fileName)
        {
            ucReportViewer1.ShowPDF(fileName);
        }
        public void ShowPDF(int id, string fileName)
        {
            ucReportViewer1.ShowPDF(id, fileName);
        }

        public void Test()
        {
            ucReportViewer1.Test();
        }

        private void ucReportViewer1_TitleChanged(object sender, VWA4Common.VWACommon.TitleEventArgs e)
        {
            this.Text = e.ReportType + " Report Viewer" + (e.Title == "" ? "" : " for " + e.Title);
        }

        private void frmReportViewer_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ucReportViewer1.DisposeReports();
        }

        public void PrintSWATNote(int id)
        {
            ucReportViewer1.PrintSWATNote(id);
        }
    }
}
