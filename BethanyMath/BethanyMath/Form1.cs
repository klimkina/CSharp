using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.OleDb;
using System.Threading;
using System.Security;
using mshtml;

namespace BethanyMath
{
    public partial class frmSendEmails : Form
    {
        private const Boolean TestMode = false;
        private string BethanyMathClubList = @"BethanyMathClub2015.xlsx";//@"C:\Users\Public\Documents\BethanyMathClub\EmailList.xlsx";

        private IHTMLDocument2 doc;

        public frmSendEmails()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetWhere()
        {
            string where = "";// "Attended = 'Yes'";
            if (!(chk2.Checked && chk3.Checked && chk4.Checked && chk5.Checked))
                if (chk2.Checked)
                    where = "Grade = '2' OR Grade = '1'";
            if (chk3.Checked)
                if(where == "")
                    where = "Grade = '3'";
                else
                    where = where + " OR Grade = '3'";
            if (chk4.Checked)
                if (where == "")
                    where = "Grade = '4'";
                else
                    where = where + " OR Grade = '4'";
            if (chk5.Checked)
                if (where == "")
                    where = "Grade = '5'";
                else
                    where = where + " OR Grade = '5'";

            if (chkPaid.Checked)
            {
                if (where == "")
                    where = "[Paid] IS NOT NULL";
                else
                    where = "(" + where + ")" + " AND [Paid] IS NOT NULL";
            }
            else if (chkNotPaid.Checked)
            {
                if (where == "")
                    where = "[Paid] IS NULL";
                else
                    where = "(" + where + ")" + " AND [Paid] IS NULL";
            }

            if (where != "")
                where = " WHERE (" + where + ")";

            return where;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            OleDbConnection mConnection = null;
            OleDbDataAdapter dbAdapter = null;
            try
            {
                string where = GetWhere();
               

                string source = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + BethanyMathClubList + 
                    ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
                string command = "SELECT * FROM [Sheet1$]" + where;// +" AND Address IS NULL";
                OleDbCommand mCommand = new OleDbCommand(); 
                mConnection = new OleDbConnection(source);
                mConnection.Open();
                mCommand.Connection = mConnection; 
                mCommand.CommandText = command;
                dbAdapter = new OleDbDataAdapter();

                dbAdapter.SelectCommand = mCommand;

                dbAdapter.Fill(ds); 

                if (ds != null)
                {

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.Subject = txtSubject.Text;
                    mail.IsBodyHtml = true;
                    
                    mail.From = new MailAddress("bethanymathleague@gmail.com");
                    mail.Attachments.Clear();

                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("klimkina@gmail.com", "******");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;


                    // add all the file attachments if we have any
                    if (lbAttachments.Items != null && lbAttachments.Items.Count > 0)
                        foreach (object strAttachments in lbAttachments.Items)
                            mail.Attachments.Add(new System.Net.Mail.Attachment(strAttachments.ToString()));


                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["Email"].ToString() != "")
                        {
                            mail.To.Clear();
                            mail.CC.Clear();
                            mail.Bcc.Clear();
                            //mail.Attachments.Clear();

                            string emails = Regex.Replace(ds.Tables[0].Rows[i]["Email"].ToString(), "(\\r?\\n)+", ",");
                            emails = Regex.Replace(emails, "\\s+,", "");
                            emails = Regex.Replace(emails, ",$", "");

                            if (TestMode)
                            {
                                mail.To.Add("sharmelka77@mail.ru");
                                mail.Subject = txtSubject.Text + emails;
                            }
                            else
                            {
                                mail.To.Add(emails);
                                mail.CC.Add("bethanymathleague@gmail.com");
                            }

                            string body = txtBody.Text;
                            int grade = 3;
                            string mathfaxgrade = ds.Tables[0].Rows[i]["Grade"].ToString().Trim();
                            switch (mathfaxgrade)
                            {
                                case "1": grade = 3;
                                    mathfaxgrade = "1st";
                                    break;
                                case "2": grade = 3;
                                    mathfaxgrade = "2nd";
                                    break;
                                case "3": grade = 3;
                                    mathfaxgrade = "3rd";
                                    break;
                                case "4": grade = 4;
                                    mathfaxgrade = "4th";
                                    break;
                                case "5": grade = 5;
                                    mathfaxgrade = "5th";
                                    break;
                                default: grade = 3;
                                    mathfaxgrade = "3rd";
                                    break;
                            }
                            double percent = 0;
                            Double.TryParse(ds.Tables[0].Rows[i]["Math Fax IV"].ToString(), out percent);                            
                            percent = percent * 4;

                            string display = ds.Tables[0].Rows[i]["Student Name"].ToString();
                            string add = "";

                            string score = ds.Tables[0].Rows[i]["Math Fax IV"].ToString();
                            string mathleague = ds.Tables[0].Rows[i]["Math League"].ToString();
                            string total = ds.Tables[0].Rows[i]["Total"].ToString();
                            string place = ds.Tables[0].Rows[i]["Math Fax Place"].ToString();
                            string mathleagueplace = ds.Tables[0].Rows[i]["Math League Place"].ToString();
                            
                            if (score.Equals(""))
                                score = "Not Attended";
                            else
                                score = score + "/25";
                            if (place != "")
                                place = "Congradulations! " + ds.Tables[0].Rows[i]["Student Name"] + " scored " + place + " among " + mathfaxgrade + " graders in the Math Fax competition!";
                            else
                                place = "We are pleased to announce " + ds.Tables[0].Rows[i]["Student Name"] + "  score in the Math Fax competition.";
                            if (mathleagueplace != "")
                                mathleagueplace = "Congradulations! " + ds.Tables[0].Rows[i]["Student Name"] + " scored " + mathleague + " and got " + mathleagueplace + " among " + mathfaxgrade + " graders in the Math League competition!";
                            else if (mathleague != "" && mathleague != "0")
                                mathleagueplace = "We are pleased to announce " + ds.Tables[0].Rows[i]["Student Name"] + "  scored <b>" + mathleague + " </b> in the Math League competition.";
                            //total = total + "/100";
                            //mail.Attachments.Clear();
                            if (ds.Tables[0].Rows[i]["Score Release"].ToString() != "Yes")
                            {
                                display = "Student #" + ds.Tables[0].Rows[i]["Number"].ToString();
                                //add = "If you want to see your kid's name there, please, sign Score Release form and send us a scan.";
                                //mail.Attachments.Add(new System.Net.Mail.Attachment(@"C:\Users\Public\Documents\BethanyMathClub\ScoreReleaseForm.pdf"));
                            }


                            body = Regex.Replace(body, @"\<Parent\>", ds.Tables[0].Rows[i]["Parent Name"].ToString(), RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\<Student\>", ds.Tables[0].Rows[i]["Student Name"].ToString(), RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\<Display\>", display, RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\<Score\>", score, RegexOptions.IgnoreCase);
                            //body = Regex.Replace(body, @"\<Total\>", total, RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\<mathleague\>", mathleagueplace, RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\<Place\>", place, RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\<Grade\>", ds.Tables[0].Rows[i]["Grade"].ToString(), RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\<CompGrade\>", grade.ToString(), RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\<Percent\>", percent.ToString(), RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\<add\>", add, RegexOptions.IgnoreCase);
                            body = Regex.Replace(body, @"\n", "<p>", RegexOptions.IgnoreCase);

                            mail.Body = "<html><body>" + body +
                                "<p><p><br><br>Best Regards,&nbsp;<br>" +
                                "Madhavi&nbsp;</b><br>" +
                                "<b><a href=\"bethanymathclub.weebly.com\" " +
                                "target=\"_blank\"><span style='color:blue'>Bethany Math Club</span></a></b></p>" +
                                "</body></html>";

                            //string fname = @"C:\Temp\" + ds.Tables[0].Rows[i]["Student Name"].ToString() + ".pdf";
                            //if (System.IO.File.Exists(fname))
                            //    mail.Attachments.Add(new System.Net.Mail.Attachment(fname));
                            SmtpServer.Send(mail);
                            System.Threading.Thread.Sleep(1000);//wait before next message
                            
                        }
                    }
                    MessageBox.Show("Mails Send");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            { // Clean up.
                if(mConnection != null)
                {
                    mConnection.Close();
                    mConnection.Dispose();
                }
                if (dbAdapter != null)
                    dbAdapter.Dispose();
                if(ds != null)
                    ds.Dispose();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgAttachFile = new OpenFileDialog();
            dlgAttachFile.Title = "Attach File";
            dlgAttachFile.InitialDirectory = @"C:\Users\Public\Documents\BethanyMathClub";
            dlgAttachFile.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            dlgAttachFile.FilterIndex = 2;
            dlgAttachFile.RestoreDirectory = true;
            dlgAttachFile.Multiselect = true;

            if (dlgAttachFile.ShowDialog() == DialogResult.OK)
            {
                // Add the files
                foreach (String file in dlgAttachFile.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        lbAttachments.Items.Add(file);
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot add file: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }

                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            while (lbAttachments.SelectedItems.Count > 0)
            {

                lbAttachments.Items.Remove(lbAttachments.SelectedItems[0]);

            }
            
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (HTMLEditor.Visible == false)
                {
                    HTMLEditor.Document.ExecCommand("Bold", false, null);
                    //HTMLEditor.Document.ExecCommand("Underline", false, null);
                    //HTMLEditor.Document.ExecCommand("Italics", false, null);
                    //HTMLEditor.Document.ExecCommand("StrikeThrough", false, null);
                    //HTMLEditor.Document.ExecCommand("FontName", false, "Times New Roman");
                    //HTMLEditor.Document.ExecCommand("FontName", false, "Arial");
                    //HTMLEditor.Document.ExecCommand("FontName", false, "etc.");
                    //HTMLEditor.Document.ExecCommand("FontSize", false, "1");
                    //HTMLEditor.Document.ExecCommand("FontSize", false, "2");
                    //HTMLEditor.Document.ExecCommand("FontSize", false, "3");
                    //HTMLEditor.Document.ExecCommand("InsertUnorderedList", false, null);
                    //HTMLEditor.Document.ExecCommand("InsertOrderedList", false, null);
                    //HTMLEditor.Document.ExecCommand("Cut", false, null);
                    //HTMLEditor.Document.ExecCommand("Copy", false, null);
                    //HTMLEditor.Document.ExecCommand("Paste", false, null);
                    //HTMLEditor.Document.ExecCommand("CreateLink", true, null);


                    //HERE IS THE WAY TO INSERT YOUR OWN TEXT INTO THE HTML EDITOR:


                    String TEXT = txtBody.Text;

                    IHTMLTxtRange range =
                        doc.selection.createRange() as IHTMLTxtRange;
                    range.pasteHTML(TEXT);
                    range.collapse(false);
                    range.select();

                    toolStrip1.Visible = true;
                    HTMLEditor.Visible = true;
                }
                else
                {
                    txtBody.Text = HTMLEditor.DocumentText;
                    toolStrip1.Visible = false;
                    HTMLEditor.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void frmSendEmails_Load(object sender, EventArgs e)
        {
            HTMLEditor.DocumentText = "<html><body></body></html>"; //This will get our HTML editor ready, inserting common HTML blocks into the document
	        //Make the web 'browser' an editable HTML field
	 
	        doc =
	        HTMLEditor.Document.DomDocument as IHTMLDocument2;
	        doc.designMode = "On";
	        //What we just did was make our web browser editable!
        }

        private void toolStripBtnBold_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("Bold", false, null);
        }

        private void toolStripBtnItalic_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("Italics", false, null);
        }

        private void toolStripBtnSize_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("FontSize", false, 1);
        }

        private void toolStripBtnLink_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("CreateLink", false, null);
        }
    }
}
