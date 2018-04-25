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
	public partial class ProgressDialog : Form
	{
		private VWA4Common.CommonEvents commonEvents = null;
		
		public ProgressDialog()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			commonEvents = VWA4Common.CommonEvents.GetEvents();
			this.Opacity = .00;
			this.lDetailDescription.Text = "";
			this.lblStatus.Text = "";
			this.lLeadIn.Text = "";
			this.Text = VWA4Common.GlobalSettings.ProductName;
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
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
		
		//// Animation interval
		//private const int Animation_Interval = 600;
		//static int Animation_Countdown;

		// Status string
		static string ms_sStatus;
		static int ms_iLevel;
		static string ms_sLeadin;
		static string ms_sDetailDescr;
		static bool ms_bHideProgressNow;
		static int ms_left;
		static int ms_top;

		// Threading
		static ProgressDialog ms_frmProgress = null;
		static Thread ms_oThread = null;

		// A static method to create the thread and 
		// launch the ShowProgressDialog.
		static public void ShowProgressDialog()
		{
			// Make sure it's only launched once.
			if (ms_frmProgress != null)
				return;
			ms_oThread = new Thread(new ThreadStart(ProgressDialog.ShowForm));
			ms_oThread.IsBackground = true;
			ms_oThread.ApartmentState = ApartmentState.STA;
			ms_oThread.Start();
		}

		static public void ShowProgressDialog(string sleadin, string sstatus, string sdetail)
		{
			ShowProgressDialog();
			SetLeadin(sleadin);
			SetStatus(sstatus, 0);
			SetDetailedDescr(sdetail);
			ms_left = 0;
			ms_top = 0;
		}
		
		static public void ShowProgressDialog(string sleadin, string sstatus, string sdetail, int left, int top)
		{
			ShowProgressDialog();

			SetLeadin(sleadin);
			SetStatus(sstatus, 0);
			SetDetailedDescr(sdetail);
			ms_left = left;
			ms_top = top;
		}

		// A property returning the Progress Dialog instance
		static public ProgressDialog fProgressDialog
		{
			get
			{
				return ms_frmProgress;
			}
		}

		// A private entry point for the thread.
		static private void ShowForm()
		{
			ms_frmProgress = new ProgressDialog();
			Application.Run(ms_frmProgress);

		}

        private delegate void CloseProgressFormHandler();
        //closes progress form in the same thread
        static public void CloseProgressForm()
        {
            if (ms_frmProgress != null && ms_frmProgress.InvokeRequired)
                ms_frmProgress.Invoke(new CloseProgressFormHandler(CloseProgressForm), new object[] { });
            else
            {
                if (ms_frmProgress != null && ms_frmProgress.IsDisposed == false)
                {
                    // Make it start going away.
                    ms_frmProgress.m_dblOpacityIncrement = -ms_frmProgress.m_dblOpacityDecrement;
                }
                if (ms_frmProgress != null)
                    ms_frmProgress.Close();
                ms_oThread = null;	// we don't need these any more.
                ms_frmProgress = null;
            }
        }
		// A static method to close the ProgressDialog
		static public void CloseForm()
		{
            if (ms_frmProgress != null && ms_frmProgress.IsDisposed == false)
			{
				// Make it start going away.
				ms_frmProgress.m_dblOpacityIncrement = -ms_frmProgress.m_dblOpacityDecrement;
			}
            ms_frmProgress.Close();
			ms_oThread = null;	// we don't need these any more.
			ms_frmProgress = null;
		}

		// A static method to set the status and progress level
		static public void SetStatus(string newStatus, int newlevel)
		{
			ms_sStatus = newStatus;
			ms_iLevel = newlevel;
		}
		
		// A static method to set the progress level
		static public void SetStatus(int newlevel)
		{
			ms_iLevel = newlevel;
		}

		static public void SetLeadin(string sLeadin)
		{
			ms_sLeadin = sLeadin;
		}
		
		static public void SetDetailedDescr(string sdetaileddescr)
		{
			ms_sDetailDescr = sdetaileddescr;
		}

		static public void SetHideProgressNow(bool hidenow)
		{
			ms_bHideProgressNow = hidenow;
		}

		///
		///********* Event Handlers ************
		///

		// Tick Event handler for the Timer control.  Handle fade in and fade out.  Also
		// handle the smoothed progress bar.
		private void timer1_Tick(object sender, System.EventArgs e)
		{
            if (_CancelPressed)
            {
                this.Close();
            }
            else
            {
                SetlblStatusText(ms_sStatus);
                SetProgressBarLevel(ms_iLevel);
                SetlLeadinText(ms_sLeadin);
                SetlDetailedDescrText(ms_sDetailDescr);
                //DecrementAnimationCountdown(TIMER_INTERVAL);
                Point location = new Point(ms_left, ms_top);
                if ((ms_top != 0) && (ms_left != 0))
                { // reset location
                    SetLocationParams(location);
                }
                if (ms_bHideProgressNow)
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
		
		private delegate void SetlLeadinTextDelegate(string labeltext);
		private void SetlLeadinText(string labeltext)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new SetlLeadinTextDelegate(SetlLeadinText), new object[] { labeltext });
				return;
			}
			lLeadIn.Text = labeltext;
		}
		
		private delegate void SetlDetailedDescrTextDelegate(string labeltext);
		private void SetlDetailedDescrText(string labeltext)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new SetlDetailedDescrTextDelegate(SetlDetailedDescrText), new object[] { labeltext });
				return;
			}
			lDetailDescription.Text = labeltext;
		}

		private delegate void SetProgressBarDelegate(int level);
		private void SetProgressBarLevel(int level)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new SetProgressBarDelegate(SetProgressBarLevel), new object[] { level });
				return;
			}
			if (level < 0) level = 0;
			if (level > 100) level = level % 100;
			progressBar1.Value = level;
		}

		//private delegate void DecrementAnimationCountdownDelegate(int decrementvalue);
		//private void DecrementAnimationCountdown(int decrementvalue)
		//{
		//    if (this.InvokeRequired)
		//    {
		//        this.BeginInvoke(new DecrementAnimationCountdownDelegate(DecrementAnimationCountdown), new object[] { decrementvalue });
		//        return;
		//    }
		//    Animation_Countdown -= decrementvalue;
		//    if (Animation_Countdown < 0)
		//    { // Switch images
		//        SetPictureBoxIndex(0);
		//    }
		//}


		//private delegate void SetPictureBoxIndexDelegate(int index);
		//private void SetPictureBoxIndex(int index)
		//{
		//    if (this.InvokeRequired)
		//    {
		//        this.BeginInvoke(new SetPictureBoxIndexDelegate(SetPictureBoxIndex), new object[] { index });
		//        return;
		//    }
		//    switch (index)
		//    {
		//        case 0: // switch from current
		//            {
		//                if (pictureBox1.Visible)
		//                {
		//                    pictureBox2.Show();
		//                    pictureBox1.Hide();
		//                }
		//                else
		//                {
		//                    pictureBox1.Show();
		//                    pictureBox2.Hide();
		//                }
		//                break;
		//            }
		//        case 1:
		//            {
		//                pictureBox1.Show();
		//                pictureBox2.Hide();
		//                break;
		//            }
		//        case 2:
		//            {
		//                pictureBox2.Show();
		//                pictureBox1.Hide();
		//                break;
		//            }
		//        default:
		//            return;
		//    }
		//    pictureBox1.Update();
		//    pictureBox2.Update();
		//    Animation_Countdown = Animation_Interval;
		//}
		
		private delegate void SetLocationParamsDelegate(Point location);
		private void SetLocationParams(Point location )
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new SetLocationParamsDelegate(SetLocationParams), new object[] { location });
				return;
			}
			if (fProgressDialog != null)
			{
				fProgressDialog.Left = location.X-10;
				fProgressDialog.Top = location.Y-10;
			}
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

        private static bool _CancelPressed = false;

        public static bool CancelPressed
        {
            get { return _CancelPressed; }
            set { _CancelPressed = value; }
        }
        private void ProgressDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)

                _CancelPressed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
			commonEvents.CancelProgress = true;
			VWA4Common.GlobalSettings.PrintViewReportsProgressCancelled = true;
			_CancelPressed = true;
        }

	}
}
