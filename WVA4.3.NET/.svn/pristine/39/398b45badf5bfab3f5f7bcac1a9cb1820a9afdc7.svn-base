using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using VWA4Common.Security;

namespace VWA4Common
{
    public class SecurityManager
    {
        private const string _LicenseFileName = "vw4license.txt";
        public string LicenseName = "";
        private LicenseUtility currentLicense = LicenseUtility.GetLicenseUtility();

        private static bool _IsLogged = false;

        /// <summary>
        /// if administrator or db manager is currently logged on
        /// </summary>
        public static bool IsLogged
        {
            get { return SecurityManager._IsLogged; }
            set { SecurityManager._IsLogged = value; }
        }
        private static bool _IsSuper = false;
        /// <summary>
        /// if administrator is logged on/off
        /// </summary>
        public static bool IsSuper
        {
            get { return SecurityManager._IsSuper; }
            set { SecurityManager._IsSuper = value; }
        }
        public string GetDBManagerPermission(string name)//returns DB Manager property without password prompt
        {
            string perm = currentLicense.GetValue(name);
            if (perm == "")
            {
                LoadLicense();

                perm = currentLicense.GetValue(name);
            }
            return perm;
        }

        public bool CheckLicense()
        {
            string cpu = VWACommon.GetCPUID();
            if (!LicenseManager.IsInited())
                LoadLicense();
            //if (LicenseCipher.IsActivated())
            //{
            string license_cpu = currentLicense.GetValue("CPU ID");
            if (!license_cpu.Equals(cpu) || license_cpu.Trim().Equals(""))
            {
                if (MessageBox.Show("This License was already activated for another CPU.\n Do you want to load another licence?",
                    "Wrong CPU", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    return InstallNewLicense();
                return false;
            }
            return true;
            //}

            frmEnterActivationCode frm = new frmEnterActivationCode();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string code = LicenseManager.GenerateActivationCode(cpu, currentLicense.GetValue("License Serial Number"), currentLicense.GetValue("Expiration Date"));
                if (code.Equals(frm.ActivationCode))
                {
                    currentLicense.SetValue("Is Activated", true.ToString());
                    currentLicense.SetValue("Activation Code", code);
                    currentLicense.SetValue("CPU ID", cpu);
                    currentLicense.SaveLicense(LicenseName);
                    return true;
                }
            }

            return false;
        }

        public bool InstallNewLicense()
        {
            OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            string fileName = FindLicenseFile();
            dlg.InitialDirectory = new FileInfo(fileName).DirectoryName;
            dlg.FileName = fileName;
            dlg.Filter = "License (" + _LicenseFileName + ")|" + _LicenseFileName +
                        "|All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] tmp = File.ReadAllLines(dlg.FileName);
                    File.WriteAllLines(LicenseName, tmp);
                    //File.Copy(dlg.FileName, LicenseName, true); // save unmodifyed file
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't install new license: " + ex.Message);
                }

                if (LoadLicense())
                {
                    //todo: check activations here
                    currentLicense.SetValue("CPU ID", VWACommon.GetCPUID());
                    //LicenseCipher.SetValue("CPU ID", VWACommon.GetCPUID());
                    currentLicense.SaveLicense(LicenseName);
                    return true;
                }

            }
            return false;

        }
        private static bool _ShowMessage = true;
        public void SetPermission(string name, string perm_val)
        {
            currentLicense.SetValue(name, perm_val);
        }
        // Helper function -- search permissions for the property
        // Returns false if property not found
        public string GetPermission(string name)
        {
            return string.Empty;
            //if (name == "Allowed Waste Classes") return "-1";
            //if (VWA4Common.GlobalSettings.TestModeFileExists)
            //{
            //    if (name == "Expiration Date")
            //        return VWA4Common.GlobalSettings.ExpirationDate.ToLongDateString();
            //    if (name == "Manager Password")
            //        return VWA4Common.GlobalSettings.ManagerPassword;
            //    if (name == "Administrator Password")
            //        return VWA4Common.GlobalSettings.AdministratorPassword;
            //    if (name == "Default User Level")
            //        return VWA4Common.GlobalSettings.DefaultUserLevel;
            //}

            //string perm_val = "";
            //string exp = "";
            //if (!currentLicense.IsInited())
            //    LoadLicense();
            //if (name != "Expiration Date")
            //{
            //    exp = GetPermission("Expiration Date");
            //    DateTime expDate = DateTime.Now;
            //    if (DateTime.TryParse(exp, out expDate))
            //    {
            //        if (expDate < DateTime.Now && _ShowMessage)
            //        {
            //            VWA4Common.NiceErrorDialog ned = new VWA4Common.NiceErrorDialog(
            //                "Expired License",
            //                "The current installed license has expired." + Environment.NewLine
            //                + "If you have a new license, Click Install below." + Environment.NewLine
            //                + "Otherwise, contact LeanPath Support: " + Environment.NewLine
            //                + "support@leanpath.com or (877)620-6512 ext.2",
            //                "Install License",
            //                "Quit");
            //            if (ned.ShowDialog() == DialogResult.OK)
            //            {
            //                InstallNewLicense();
            //                exp = GetPermission("Expiration Date");
            //            }
            //            //MessageBox.Show("Your license has expired. Please update your license");
            //            _ShowMessage = false;
            //        }
            //    }
            //}
            //string perm = currentLicense.GetValue(name);
            //if (perm == "" && !LoadLicense())
            //    return "";
            //perm = currentLicense.GetValue(name);
            ////if (perm == "")
            ////    perm = currentLicense.GetDefaultValue(name);

            //if (name != "Expiration Date" && DateTime.Parse(exp) < DateTime.Now && perm.ToLower() == "true")
            //    perm = "false";

            //perm_val = perm.Trim();
            ////string super = LicenseCipher.GetSuperValue(name);
            //bool isSuper = Regex.IsMatch(super, "Super");
            //bool isManager = Regex.IsMatch(super, "Manager");
            //if ((perm.ToLower() != "false") && ((isManager || isSuper) && (!_IsLogged) || isSuper && !_IsSuper))
            //{
            //    string pinManager = "";
            //    string pinSuper = "";
            //    pinManager = GetPermission("Manager Password");
            //    pinSuper = GetPermission("Administrator Password");
            //    frmLogin frm = new frmLogin(isSuper, pinManager, pinSuper);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        _IsLogged = true;
            //        _IsSuper = frm.IsSuper;
            //        if (frm.NewPIN != "")
            //            SaveNewPIN(frm.IsSuper, frm.NewPIN);
            //    }
            //    else
            //    {
            //        perm_val = false.ToString();
            //    }
            //}
            //return perm_val;
        }


        // The single instance allowed
        private static SecurityManager theSecurityManagerInstance = null;


        // Private constructor preventing creating an instance
        private SecurityManager()
        {
            LicenseName = VWA4Common.GlobalSettings.VirtualAppDir + "\\" + _LicenseFileName;

            string res = "";
            res = GetPermission("Default User Level");
            _IsLogged = res != "User";
            _IsSuper = res == "Super";
        }

        // The only way to get the object's instance
        public static SecurityManager GetSecurityManager()
        {
            if (theSecurityManagerInstance == null)
            {
                theSecurityManagerInstance = new SecurityManager();
            }
            return theSecurityManagerInstance;
        }
        //private static bool _IsWarningShown = false;
        private bool LoadLicense()
        {
            bool res = false;
            try
            {
                string path = LicenseName;
                if (!File.Exists(path))
                {
                    VWA4Common.NiceErrorDialog ned = new VWA4Common.NiceErrorDialog(
                        "License File Not Found",
                        "If you have a new license, Click Install below." + Environment.NewLine
                        + "Otherwise, contact LeanPath Support: " + Environment.NewLine
                        + "support@leanpath.com or (877)620-6512 ext.2",
                        "Install License",
                        "Quit");
                    if (ned.ShowDialog() == DialogResult.OK)
                    {
                        OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
                        dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                        dlg.Filter = "License (" + _LicenseFileName + ")|" + _LicenseFileName;

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(dlg.FileName, LicenseName); // save unmodifyed file
                        }
                        else
                            System.Environment.Exit(-1);//exit application
                    }
                    else
                        System.Environment.Exit(-1);//exit application
                }
				string errmsg;
				res = LicenseManager.LoadLicense(path, out errmsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying file: " + ex.Message);
            }
            return res;
        }

        public bool SaveNewPIN(bool isSuper, string newPIN)
        {
            LicenseManager.SetValue(isSuper ? "Administrator Password" : "Manager Password", newPIN);
            SaveNewSettings();

            return true;
        }
        private void SaveNewSettings()
        {
            LicenseManager.SaveLicense(LicenseName);
        }

        private ArrayList SearchDir(string drive)
        {
            ArrayList fileNames = new ArrayList();
            System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(drive);
            if (driveInfo.IsReady)
                fileNames.AddRange(DirSearch(drive, _LicenseFileName, 2));

            return fileNames;
        }

        private ArrayList DirSearch(string dir, string pattern, int level)
        {
            ArrayList res = new ArrayList();
            try
            {
                foreach (string f in Directory.GetFiles(dir, pattern))
                {
                    res.Add(f);
                    return res;
                }
                if (level > 0)
                    foreach (string d in Directory.GetDirectories(dir))
                    {
                        res.AddRange(DirSearch(d, pattern, level - 1));
                    }
            }
            catch (System.UnauthorizedAccessException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for license file. " + Environment.NewLine + ex.Message);
            }
            return res;
        }

        private string FindLicenseFile()
        {
            try
            {

                string[] drives = Directory.GetLogicalDrives();
                //search for VW import files - ENTIRE disk!
                foreach (string drive in drives)
                {
                    ArrayList fileNames = SearchDir(drive);
                    if (fileNames != null && fileNames.Count > 0)
                        return fileNames[0].ToString();// new FileInfo(fileNames[0].ToString()).DirectoryName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for license file. " + Environment.NewLine + ex.Message, "License Searching Error");
            }
            return Application.StartupPath;
        }
    }
}
