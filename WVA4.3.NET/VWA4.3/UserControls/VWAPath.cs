using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace UserControls
{
    public class VWAPath
    {
        private const string PATH_IMAGES = "Images";
        private const string IMAGE_BACKGROUND = "Value Waste Logo.bmp";
        private const string IMAGE_LEANPATH = "leanpath_clr_small.jpg";
        private const string IMAGE_CUSTOMER_LOGO = "bulk.gif";
        private const string PATH_ViewWaste = @"Config";

        private static string WVAImagesPath = GetDirectory(PATH_IMAGES);
        private static string WVAViewWasteConfigPath = GetDirectory(PATH_ViewWaste);

        // DB Data
       

        internal static string ImagesPath
        {
            get { return VWAPath.WVAImagesPath; }
        }
        internal static string CustomerLogo
        {
            get { return VWA4Common.GlobalSettings.LogoUpperLeft; } // VWAPath.WVAImagesPath + "\\" + IMAGE_CUSTOMER_LOGO; }
        }
        internal static string AccessDBPath
        {
            get { return VWA4Common.AppContext.WasteConnectionString; }
        }

        internal static bool DirectoriesFound
        {
            get { return (VWA4Common.AppContext.WasteConnectionString != string.Empty); }
        }

        private static string GetDirectory(string directory)
        {
			DirectoryInfo di = new DirectoryInfo(VWA4Common.GlobalSettings.VirtualAppDir).Parent;

            while (di != null)
            {
                foreach (DirectoryInfo subDir in di.GetDirectories(directory))
                {
                    if (subDir.Name == directory)
                        return subDir.FullName;
                }

                di = di.Parent;
            }

            return string.Empty;
        }

        public static string ViewWasteConfigPath
        {
            get { return WVAViewWasteConfigPath; }
        }

        private static string ViewWasteDBPath
        {
            get { return VWA4Common.AppContext.DBPathName; }
        }
        public static string ViewWasteDBName
        {
            get { return VWA4Common.AppContext.DBPathName; }
        }
        public static string ViewWasteImagesPath
        {
            get { return VWAPath.ImagesPath; }
        }
        public static string ViewWasteBackgroundImage
        {
            get { return VWAPath.ImagesPath + "\\" + VWAPath.IMAGE_BACKGROUND; }
        }
        public static string ViewWasteLeanPathImage
        {
            get { return VWA4Common.GlobalSettings.LogoLowerRight; } //VWAPath.ImagesPath + "\\" + VWAPath.IMAGE_LEANPATH; }
        }
    }
}
