using System;
using System.Collections.Generic;
using System.Text;
using VWA4Common.Security;

namespace VWA4Common.Security
{
    public static class LicenseCipher
    {
        private static string ValidChars = "TAZ2WSX3" + "QGB6YHN7" + "EDC4RFL5" + "UJM8K9VP";

        public static bool LoadLicense(string fileName)
        {
            return LicenseUtility.GetLicenseUtility().LoadLicense(fileName);
        }

        public static void SaveLicense(string fileName)
        {
            LicenseUtility.GetLicenseUtility().SaveLicense(fileName);
        }

        public static bool IsInited()
        {
            return LicenseUtility.GetLicenseUtility().IsInited();
        }

        public static bool IsActivated()
        {
            throw new NotImplementedException();
        }

        public static string GetValue(string name)
        {
            return LicenseUtility.GetLicenseUtility().GetValue(name);
        }

        public static void SetValue(string name, string value)
        {
            LicenseUtility.GetLicenseUtility().SetValue(name, value);
        }

        public static string GenerateActivationCode(string cpuID, string licenseID, string expDate)
        {
            DateTime dt = DateTime.Parse(expDate);
            string strDate = dt.ToString("MMddyyyy");
            strDate = strDate.Substring(0, 4) + strDate.Substring(6, 2);
            string code = cpuID.Substring(0, 2) + cpuID.Substring(cpuID.Length - 3, 2) + strDate;

            UTF8Encoding textConverter = new UTF8Encoding();
            byte[] passBytes = textConverter.GetBytes(code);

            string res = toBase32String(passBytes);

            return res;
        }

        public static string GetExpirationDate(string cpuID, string licenseID, string activationCode)
        {
            byte[] passBytes = fromBase32String(activationCode);
            UTF8Encoding textConverter = new UTF8Encoding();
            string code = textConverter.GetString(passBytes);
            string res = "";
            if (code.Substring(0, 2) == cpuID.Substring(0, 2) && code.Substring(2, 2) == cpuID.Substring(cpuID.Length - 3, 2))
            {
                res = code.Substring(4, 2) + "/" + code.Substring(6, 2) + "/20" + code.Substring(8, 2);
                DateTime dt = DateTime.Parse(res);
                res = dt.ToString("MM/dd/yyyy");
            }
            return res;
        }

        private static string toBase32String(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();         // holds the base32 chars
            byte index;
            int hi = 5;
            int currentByte = 0;

            while (currentByte < bytes.Length)
            {
                // do we need to use the next byte?
                if (hi > 8)
                {
                    // get the last piece from the current byte, shift it to the right
                    // and increment the byte counter
                    index = (byte)(bytes[currentByte++] >> (hi - 5));
                    if (currentByte != bytes.Length)
                    {
                        // if we are not at the end, get the first piece from
                        // the next byte, clear it and shift it to the left
                        index = (byte)(((byte)(bytes[currentByte] << (16 - hi)) >> 3) | index);
                    }

                    hi -= 3;
                }
                else if (hi == 8)
                {
                    index = (byte)(bytes[currentByte++] >> 3);
                    hi -= 3;
                }
                else
                {

                    // simply get the stuff from the current byte
                    index = (byte)((byte)(bytes[currentByte] << (8 - hi)) >> 3);
                    hi += 5;
                }

                sb.Append(ValidChars[index]);
            }

            return sb.ToString();
        }

        private static byte[] fromBase32String(string str)
        {
            int numBytes = str.Length * 5 / 8;
            byte[] bytes = new Byte[numBytes];

            // all UPPERCASE chars
            str = str.ToUpper();

            int bit_buffer;
            int currentCharIndex;
            int bits_in_buffer;

            if (str.Length < 3)
            {
                bytes[0] = (byte)(ValidChars.IndexOf(str[0]) | ValidChars.IndexOf(str[1]) << 5);
                return bytes;
            }

            bit_buffer = (ValidChars.IndexOf(str[0]) | ValidChars.IndexOf(str[1]) << 5);
            bits_in_buffer = 10;
            currentCharIndex = 2;
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)bit_buffer;
                bit_buffer >>= 8;
                bits_in_buffer -= 8;
                while (bits_in_buffer < 8 && currentCharIndex < str.Length)
                {
                    bit_buffer |= ValidChars.IndexOf(str[currentCharIndex++]) << bits_in_buffer;
                    bits_in_buffer += 5;
                }
            }

            return bytes;
        }

    }
}
