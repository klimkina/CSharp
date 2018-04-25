using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Management;

namespace VWA4Common.Security
{
    public class LicenseUtility
    {
        private string _LicenseFileName = ConfigurationManager.AppSettings["LicenseFileName"];
        private static LicenseUtility _licenseUtility = null;
        private readonly DESEncryption des = new DESEncryption();
        private readonly Dictionary<string, SecurityPermission> permissions = new Dictionary<string, SecurityPermission>();

        public string this[string name]
        {
            get
            {
                try
                {
                    return permissions[name].Value;
                }
                catch (KeyNotFoundException)
                {
                    return string.Empty;
                }
            }
            set
            {
                if (value == string.Empty)
                    value = "N/A";
                try
                {
                    //set permission value
                    SecurityPermission p = permissions[name];
                    p.Value = value;
                }
                catch (KeyNotFoundException)
                {
                    //if doesn't exist create new permission and set value, and default values
                    permissions.Add(name, new SecurityPermission { Name = name, Value = value });
                }
            }
        }

        public static LicenseUtility GetLicenseUtility()
        {
            return _licenseUtility ?? (_licenseUtility = new LicenseUtility());
        }

        private LicenseUtility() { }
        
        /// <summary>
        /// Checks to see if security permission exists
        /// </summary>
        /// <param name="name">Permission key to check.</param>
        /// <returns>boolean</returns>
        public bool Exists(string name)
        {
            return permissions[name] != null;
        }
        
        /// <summary>
        /// Checks to see if license is initiated.
        /// </summary>
        /// <returns></returns>
        public bool IsInited()
        {
            return permissions.Count > 0;
        }

        /// <summary>
        /// Gets a permissions value by permission name.
        /// </summary>
        /// <param name="name">permission name</param>
        /// <returns>returns permission value if exists else returns null.</returns>
        public string GetValue(string name)
        {
            return permissions[name] != null ? permissions[name].Value : null;
        }

        /// <summary>
        /// Sets a permissions value by the name
        /// </summary>
        /// <param name="name">Name of permission</param>
        /// <param name="value">Value to assign</param>
        public void SetValue(string name, string value)
        {
            this[name] = value;
        }

        /// <summary>
        /// Saves current license
        /// </summary>
        /// <param name="filePath">Path to save license to</param>
        public void SaveLicense(string fileName)
        {
            this.GenerateLicense(fileName);
        }

        /// <summary>
        /// Generates encrypted license file, and saves onto hard drive.
        /// </summary>
        /// <param name="fileName">Path to save license file to</param>
        public void GenerateLicense(string fileName)
        {
            string license = string.Empty;

            foreach (SecurityPermission p in permissions.Values)
            {
                license += string.Format("{0}:{1};", des.EncryptToString(p.Name), des.EncryptToString(p.Value));
            }

            File.WriteAllText(fileName, license);
        }

        /// <summary>
        /// Decrypts and loads permissions from license file.
        /// </summary>
        /// <param name="fileName">Path to license file</param>
		public bool LoadLicense(string fileName, out string errmsg)
		{
			try
			{
				if (File.Exists(fileName))
				{
					string[] perms = File.ReadAllText(fileName).Split(';');

					for (int i = 0; i < perms.Length; i++)
					{
						if (perms[i].Split(':').Length == 2)
						{
							string name = des.DecryptString(perms[i].Split(':')[0]);
							string value = des.DecryptString(perms[i].Split(':')[1]);
							this[name] = value;
						}
					}
					errmsg = null;
					return true;
				}
				errmsg = "Specified file doesn't exist.";
				return false;
			}
			catch (Exception ex)
			{
				errmsg = ex.Message;
				return false;
			}
		}
    }
}
