using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VWA4Common
{
    /// <summary>
    /// Summary description for password.
    /// </summary>
    public partial class frmLogin : System.Windows.Forms.Form
    {
        private string _PinManager = "";
        private string _PinSuper = "";
        private bool _IsSuper = false;

        public bool IsSuper
        {
            get { return _IsSuper; }
            set { _IsSuper = value; }
        }
        private static int _EntryCount = 0;
        private const int MAX_ENTRY_COUNT = 3;
        private const int MIN_TIME_REENTRY_SEC = 60;
        private static DateTime _LastTry = DateTime.MinValue;

        private string _NewPIN = "";

        public string NewPIN
        {
            get { return _NewPIN; }
            //set { _NewPIN = value; }
        }

        public frmLogin(bool isSuper, string pinManager, string pinSuper)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            cmbUser.SelectedIndex = (isSuper ? 1 : 0);

			lentropyStatus.Text = "Waiting for password entry...";

            _IsSuper = isSuper;
            _PinManager = pinManager.Trim();
            _PinSuper = pinSuper.Trim();

            if (_LastTry != DateTime.MinValue && DateTime.Now.Subtract(_LastTry) > TimeSpan.FromSeconds(MIN_TIME_REENTRY_SEC))
                _EntryCount = 0;

            passField.Enabled = _EntryCount < MAX_ENTRY_COUNT;
        }

        private void passwordDlg_Load(object sender, System.EventArgs e)
        {

        }

        private void bOK_Click(object sender, System.EventArgs e)
        {
            if (passField.TextLength == 0)
            {
                MessageBox.Show(this,
					"Please enter a valid password here.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _IsSuper = (cmbUser.SelectedIndex == 1 ? true : false);
            _LastTry = DateTime.Now;
            if (_IsSuper && passField.Text.Equals(_PinSuper))
            {
                VWA4Common.DBDetector.GetDBDetector().SuperLogin = true;
				VWA4Common.GlobalSettings.UserLevel = 2;
            }
			else if (!_IsSuper && passField.Text.Equals(_PinManager))
			{
				VWA4Common.DBDetector.GetDBDetector().ManagerLogin = true;
				VWA4Common.GlobalSettings.UserLevel = 1;
			}
			else
			{
				_EntryCount++;
				MessageBox.Show(this, "Incorrect password.", "Input Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (_EntryCount >= MAX_ENTRY_COUNT)
					passField.Enabled = false;
				return;
			}

            _EntryCount = 0;
           
			// If we get here, then its ok to dispose of the dialog and set DialogResult to OK
            DialogResult = DialogResult.OK;
            Close();

        }

        public System.String getPass()
        {
            return passField.Text;
        }

        private void passField_TextChanged(object sender, System.EventArgs e)
        {
            checkStatus(passField.TextLength);
        }

        private void checkStatus(int passSize)
        {
            if (passSize == 0)
				lentropyStatus.Text = "Waiting for password entry...";
            else
                lentropyStatus.Text = "";

        }

        private void lblChange_Click(object sender, EventArgs e)
        {
            frmChangePIN frm = new frmChangePIN((cmbUser.SelectedIndex == 1 ? true : false), _PinManager, _PinSuper);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _NewPIN = frm.getPass();
                _IsSuper = frm.IsSuper;
                // If we get here, then its ok to dispose of the dialog and set DialogResult to OK
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }

}
