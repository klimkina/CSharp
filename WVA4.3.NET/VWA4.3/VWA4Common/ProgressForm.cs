using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VWA4Common
{
    /// <summary>
    /// Allows a progress indicator to pop up, blocking the user from
    /// doing anything (except possibly canceling the operation).
    /// To use you MUST MUST MUST call SetupAndShow, then call Finish in
    /// a finally block. You may call ShowProgress any number of times
    /// in between. If you allow cancellation, then you must trap errors,
    /// as a cancellation will throw an exception.
    /// </summary>
    public partial class ProgressForm : Form, IMessageFilter
    {
        const int WM_PAINT = 0x000F, WM_NCACTIVATE = 0x086;

        private Form caller;
        private DateTime showTime; //time when form should show, UTC
        private Cursor priorCursor = Cursors.Default;
        private bool allowCancel; //controls whether a manual close should cause an exception
        private bool pleaseAbort; //set when user presses cancel

        public ProgressForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Setup the form.
        /// </summary>
        /// <param name="menubartext">text to display on the menu bar</param>
        /// <param name="msg1">the message describing the work being done</param>
        /// <param name="delayedDisplay">if true, the form is only shown if
        /// the operation takes longer than a half-second</param>
        public void SetupAndShow(Form caller, string menubartext, string msg1, 
            bool delayedDisplay, bool allowCancel)
        {
            if (caller == null)
            {
                if (Application.OpenForms.Count == 0) return;
                caller = Application.OpenForms[0];
            }
            this.allowCancel = allowCancel; 
            eCancel.Visible = allowCancel;
            this.Text = menubartext;
            lMessage.Text = msg1;
            this.caller = caller;
            //eBar.Value = 0;
            if (delayedDisplay)
                showTime = DateTime.UtcNow.AddSeconds(0.5);
            else
            {
                showTime = DateTime.MinValue;
                ShowProgress(0, null);
            }
            priorCursor = caller.Cursor;
            caller.Cursor = Cursors.WaitCursor;
            Application.AddMessageFilter(this);
            RepositionControls();
        }

        /// <summary>
        /// Update progress bar and labels. If enough time has passed,
        /// make form visible. Call DoEvents, and if form is canceled,
        /// throw Exception.
        /// </summary>
        /// <param name="percent">a number between 0 and 1</param>
        /// <param name="displayValue"></param>
        public void ShowProgress(double percent, string displayValue)
        {
            //if (percent > 0)
            //{
            //    try { eBar.Value = (int)(percent * 100.0); }
            //    catch { }
            //}
            //if (displayValue != null)
            //    label2.Text = displayValue;

            //show/paint form
            if (!Visible && showTime < DateTime.UtcNow)
            {
                Show();
                Cursor = Cursors.WaitCursor;
                if (eCancel.Visible) eCancel.Focus(); 
            }
         
            //allow some events to occur during the work, but only those
            //that deal with the cancel button
            Application.DoEvents();
            if (pleaseAbort)
            {
                Application.RemoveMessageFilter(this);
                Hide();
                throw new Exception("Operation Cancelled");
            }
            RepositionControls();
        }

        //returns true if a message should be filtered out
        public bool PreFilterMessage(ref Message m)
        {
            bool isgoodtype = m.Msg == WM_PAINT;
            bool allowed = isgoodtype ||
                (Visible && (m.HWnd == this.Handle || m.HWnd == eCancel.Handle));
            return !allowed;
        }

        private void eCancel_Click(object sender, EventArgs e)
        {
            pleaseAbort = true;
        }

        /// <summary>
        /// Finish form - hides, unless there are errors, in which case it
        /// shows it as a dialog and waits for OK pressed
        /// </summary>
        public void Finish()
        {
            Application.DoEvents(); //this clears the event queue of unwanted clicks
            Hide();
            Application.RemoveMessageFilter(this);
            caller.Cursor = priorCursor;
            Dispose();
        }

        private void eCancel_Click_1(object sender, EventArgs e)
        {
			Finish();
        }

        /// <summary>
        /// Reposition controls on resizing of form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressForm_Resize(object sender, EventArgs e)
        {
            RepositionControls();
        }

        private void RepositionControls()
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                // Center the message text
                lMessage.Left = (this.Width - this.lMessage.Width) / 2;
                lMessage.Top = 15;
                // Center the Cancel button
                eCancel.Left = (this.Width - this.eCancel.Width) / 2;
                eCancel.Top = (lMessage.Top + lMessage.Height + 20);
            }
        }

    }
}
