using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web;
using LicenseManager4Web.DataContext;
using LicenseManager4Web.Entities.Written;

namespace LicenseManager4Web.Services
{
    public static class SiteService
    {
        static SiteService()
        {
            Mapper.CreateMap<LicenseManager4Web.Entities.Site, LicenseManager4Web.Entities.Written.Site>();
        }

        public static int CreateSite(int clientId, string siteName)
        {
            return SiteService.CreateSite(clientId, siteName, string.Empty);
        }

        public static int CreateSite(int clientId, string siteName, string salesForceId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                Entities.Site s = new Entities.Site();
                s.SiteName = siteName;
                s.ClientID = clientId;
                s.SalesForceId = salesForceId;

                dc.Sites.InsertOnSubmit(s);
                dc.SubmitChanges();

                return s.ID;
            }
        }

        public static void SaveSite(int siteId, int clientId, string siteName)
        {
            SiteService.SaveSite(siteId, clientId, siteName, string.Empty);
        }

        public static void SaveSite(int siteId, int clientId, string siteName, string salesForceId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                Entities.Site s = dc.Sites.SingleOrDefault(x => x.ID == siteId);
                s.SiteName = siteName;
                s.ClientID = clientId;
                s.SalesForceId = salesForceId;

                dc.SubmitChanges();
            }
        }

        public static List<Site> GetAllSitesByClientId(int clientId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from site in dc.Sites where site.ClientID == clientId select MapSite(site)).ToList();
            }
        }

        public static Site MapSite(LicenseManager4Web.Entities.Site dboSite)
        {
            Site siteobj = new Site();
            Mapper.Map(dboSite, siteobj);

            return siteobj;
        }

        public static bool SiteHasActiveLicenses(int siteId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                if (dc.Licenses.Where(x => x.SiteID == siteId).Select(x => x.ID).Count() > 0)
                    return true;
                return false;
            }
        }

        public static List<Site> GetAllSites()
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from site in dc.Sites select MapSite(site)).ToList();
            }
        }

        public static Site GetSiteById(int siteId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return MapSite(dc.Sites.SingleOrDefault(x => x.ID == siteId));
            }
        }

        public static Site GetSite(int siteId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                Site c = (from site in dc.Sites where site.ID == siteId select MapSite(site)).FirstOrDefault();

                if (c == null)
                    c = new Site();

                return c;
            }
        }
    }
}