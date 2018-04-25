using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LicenseManager4Web.DataContext;
using LicenseManager4Web.Entities.Written;
using AutoMapper;

namespace LicenseManager4Web.Services
{
    public static class LicenseService
    {
        static LicenseService()
        {
            Mapper.CreateMap<LicenseFeaturesParams, LicenseManager4Web.Entities.LicenseFeature>();
            Mapper.CreateMap<LicenseManager4Web.Entities.LicenseFeature, LicenseFeaturesParams>().ForMember(dest => dest.LicenseType, opt => opt.Ignore());
            
            Mapper.CreateMap<LicenseManager4Web.Entities.License, LicenseManager4Web.Entities.Written.License>(); 
        }

        public static int CreateLicense(LicenseFeaturesParams p)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                //create site if it doesn't exist
                if (p.ClientID == -1)
                {
                    p.ClientID = ClientService.CreateClient(p.ClientName);
                }

                //create site if it doesn't exist
                if (p.SiteID == -1)
                {
                    p.SiteID = SiteService.CreateSite(p.ClientID, p.SiteName);
                }

                //create new or save license
                LicenseManager4Web.Entities.License l = new LicenseManager4Web.Entities.License();

                l.LicenseType = (int)p.LicenseType;
                l.Product = p.Product;
                l.LicenseID = p.LicenseKey;
                l.ClientID = p.ClientID;
                l.SiteID = p.SiteID;
                l.GeneratedTime = p.GeneratedDate;
                l.GeneratedBy = p.GeneratedBy;

                //insert new license
                dc.Licenses.InsertOnSubmit(l);
                dc.SubmitChanges();
                
                //create new features list and map params to it
                LicenseManager4Web.Entities.LicenseFeature f = new LicenseManager4Web.Entities.LicenseFeature();
                Mapper.Map(p, f);

                //insert new license features
                f.LicenseID = l.ID;
                dc.LicenseFeatures.InsertOnSubmit(f);
                dc.SubmitChanges();
               
                return l.ID;
            }
        }

        public static void SaveLicense(LicenseFeaturesParams p)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                //save client
                ClientService.SaveClient(p.ClientID, p.ClientName);
                
                //save site
                SiteService.SaveSite(p.SiteID, p.ClientID, p.SiteName);

                //save license
                LicenseManager4Web.Entities.License l = dc.Licenses.SingleOrDefault(x => x.ID == p.LicenseID);
                l.LicenseType = (int)p.LicenseType;
                l.Product = p.Product;
                l.LicenseID = p.LicenseKey;
                l.GeneratedTime = p.GeneratedDate;
                l.GeneratedBy = p.GeneratedBy;

                //save license features
                LicenseManager4Web.Entities.LicenseFeature f = dc.LicenseFeatures.SingleOrDefault(x => x.LicenseID == p.LicenseID);
                Mapper.Map(p, f);

                dc.SubmitChanges();
            }
        }

        public static LicenseFeaturesParams GetLicenseFeatureParams(int licenseId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                LicenseManager4Web.Entities.LicenseFeature f = dc.LicenseFeatures.SingleOrDefault(x => x.LicenseID == licenseId);
                LicenseFeaturesParams p = new LicenseFeaturesParams();

                Mapper.Map(f, p);

                p.ClientID = f.License.ClientID;
                p.SiteID = f.License.SiteID;
                p.ClientName = f.License.Client.ClientName;
                p.SiteName = f.License.Site.SiteName;
                p.GeneratedBy = f.License.GeneratedBy;
                p.GeneratedDate = f.License.GeneratedTime;
                p.Product = f.License.Product;
                p.LicenseType = (LicenseType)Enum.ToObject(typeof(LicenseType), f.License.LicenseType);

                return p;
            }
        }

        public static List<License> GetAllLicenses()
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from l in dc.Licenses select MapLicense(l)).ToList();
            }
        }

        public static License GetLicenseById(int id)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from l in dc.Licenses where l.ID == id select MapLicense(l)).FirstOrDefault();
            }
        }

        public static List<License> GetLicensesByClientId(int clientId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from l in dc.Licenses where l.ClientID == clientId select MapLicense(l)).ToList();
            }
        }

        public static List<License> GetLicensesByClientIdAndSiteId(int clientId, int siteId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from l in dc.Licenses where l.ClientID == clientId && l.SiteID == siteId select MapLicense(l)).ToList();
            }
        }

        public static License MapLicense(LicenseManager4Web.Entities.License dbo)
        {
            License obj = new License();
            Mapper.Map(dbo, obj);

            return obj;
        }
    }
}