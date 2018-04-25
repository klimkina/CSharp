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
    public partial class frmChangePIN : System.Windows.Forms.Form
    {
        private string _OldManagerPIN = "";
        private string _OldSuperPIN = "";
        private bool _IsSuper = false;

        public bool IsSuper
        {
            get { return _IsSuper; }
            set { _IsSuper = value; }
        }
        public frmChangePIN(bool isSuper, string oldManagerPIN, string oldSuperPIN)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            _OldManagerPIN = oldManagerPIN.Trim();
            _OldSuperPIN = oldSuperPIN.Trim();
            _IsSuper = isSuper;
            cmbUser.SelectedIndex = (isSuper ? 1 : 0);
        }

        private void passwordDlg_Load(object sender, System.EventArgs e)
        {

        }

        private void okBtn_Click(object sender, System.EventArgs e)
        {
            if (passField.TextLength == 0)
            {
                MessageBox.Show(this,
                    "Please enter a valid password here.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (confirmField.TextLength == 0)
            {
                MessageBox.Show(this,
                    "Please re-enter the password to confirm it.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!passField.Text.Equals(confirmField.Text))
            {
                // Fields don't match
                MessageBox.Show(this,
                    "The PINs do not match up. Please try again.", "PINs don't match!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _IsSuper = (cmbUser.SelectedIndex == 1 ? true : false);
            
            if (_IsSuper && oldPIN.Text.Equals(_OldSuperPIN))         
                DBDetector.GetDBDetector().SuperLogin = true;
            else if(!_IsSuper && oldPIN.Text.Equals(_OldManagerPIN))
                DBDetector.GetDBDetector().ManagerLogin = true;
            else
            {
                // Fields don't match
                MessageBox.Show(this,
					"The Old password does not match up. Please try again.", "Old password doesn't match!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
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
            checkEffectiveBitSize(passField.TextLength);
        }

        private void checkEffectiveBitSize(int passSize)
        {
            int charSet = 0;
            string passStrength = "";

            charSet = getCharSetUsed(passField.Text);

            double result = Math.Log(Math.Pow(charSet, passSize)) / Math.Log(2);

            if (result <= 32)
            {
                passStrength = "weak;";
            }
            else if (result <= 64)
            {
                passStrength = "mediocre;";
            }
            else if (result <= 128)
            {
                passStrength = "OK;";
            }
            else if (result > 128)
            {
                passStrength = "great;";
            }

			entropyStatus.Text = "Your password is " + passStrength +
                " it is equivalent to a " + Math.Round(result, 0) + "-bit key.";

        }

        private int getCharSetUsed(string pass)
        {
            int ret = 0;

            if (containsNumbers(pass))
            {
                ret += 10;
            }

            if (containsLowerCaseChars(pass))
            {
                ret += 26;
            }

            if (containsUpperCaseChars(pass))
            {
                ret += 26;
            }

            if (containsPunctuation(pass))
            {
                ret += 31;
            }

            return ret;
        }

        private bool containsNumbers(string str)
        {
            Regex pattern = new Regex(@"[\d]");
            return pattern.IsMatch(str);
        }

        private bool containsLowerCaseChars(string str)
        {
            Regex pattern = new Regex("[a-z]");
            return pattern.IsMatch(str);
        }

        private bool containsUpperCaseChars(string str)
        {
            Regex pattern = new Regex("[A-Z]");
            return pattern.IsMatch(str);
        }

        private bool containsPunctuation(string str)
        {
            // regular expression include _ as a valid char for alphanumeric.. 
            // so we need to explicity state that its considered punctuation.
            Regex pattern = new Regex(@"[\W|_]");
            return pattern.IsMatch(str);
        }
    }

}
