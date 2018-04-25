using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VWA4Common
{
    public partial class EnterActivationCode : Form
    {
        private string strActivationCode;

        public string ActivationCode
        {
            get { return strActivationCode; }
            set { strActivationCode = value; }
        }
        public EnterActivationCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            strActivationCode = txtActivationCode1.Text + txtActivationCode2.Text +
                                    txtActivationCode3.Text + txtActivationCode4.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
