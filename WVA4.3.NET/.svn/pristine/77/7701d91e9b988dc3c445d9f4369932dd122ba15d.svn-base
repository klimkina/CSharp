using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.ComponentModel;
using LicenseManager4Web.Services;
using LicenseManager4Web.Entities.Written;
using System.Data.Linq;

namespace LicenseManager4Web
{
    /// <summary>
    /// License Manager Web Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class LicenseManagerWebService : System.Web.Services.WebService
    {
        #region Activations

        [WebMethod]
        public Activation ActivateLicense(int licenseId, string cpuID)
        {
            try
            {
                return ActivationService.ActivateLicense(licenseId, cpuID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [WebMethod]
        public string AddActivation(ActivationParams p)
        {
            try
            {
                return ActivationService.CreateActivation(p).ToString();
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}", ex.Message);
            }            
        }

        [WebMethod]
        public Activation GetActivationById(int activationId)
        {
            try
            {
                return ActivationService.GetActivationById(activationId);
            }
            catch (Exception )
            {
                throw;
            }
        }

        [WebMethod]
        public string SaveActivationCode(int activationId, string activationCode)
        {
            try
            {
                return ActivationService.SaveActivationCode(activationId, activationCode).ToString();
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}{1}{2}", ex.Message, Environment.NewLine, ex.InnerException.ToString());
            }
        }

        [WebMethod]
        public string SaveActivation(ActivationParams p)
        {
            try
            {
                return ActivationService.SaveActivation(p).ToString();
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}{1}{2}", ex.Message, Environment.NewLine, ex.InnerException.ToString());
            }
        }

        [WebMethod]
        public List<Activation> GetActivationsByLicenseId(int id)
        {
            try
            {
                return ActivationService.GetActivationsByLicenseId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public string IsActivated(int licenseId, string cpuId)
        {
            try
            {
                ActivationService.IsActivated(licenseId, cpuId);
                return "true";
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}", ex.Message);
            }
        }

        #endregion

        #region Licenses

        [WebMethod]
        public string CreateLicense(LicenseFeaturesParams p)
        {
            try
            {
                return LicenseService.CreateLicense(p).ToString();
            }
            catch (DuplicateKeyException)
            {
                return string.Format("Error, cannot insert duplicate License Key: {0}", p.LicenseKey);
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}", ex.Message);
            }            
        }

        [WebMethod]
        public string SaveLicense(LicenseFeaturesParams p)
        {
            try
            {
                LicenseService.SaveLicense(p);
                return "Success";
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}{1}{2}", ex.Message, Environment.NewLine, ex.InnerException.ToString());
            }
        }

        [WebMethod]
        public LicenseManager4Web.Entities.Written.License GetLicenseById(int id)
        {
            try
            {
                return LicenseService.GetLicenseById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public LicenseFeaturesParams GetLicenseFeatureParams(int licenseId)
        {
            try
            {
                return LicenseService.GetLicenseFeatureParams(licenseId);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [WebMethod]
        public List<LicenseManager4Web.Entities.Written.License> GetAllLicenses()
        {
            try
            {
                return LicenseService.GetAllLicenses();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<LicenseManager4Web.Entities.Written.License> GetLicensesByClientId(int clientId)
        {
            try
            {
                return LicenseService.GetLicensesByClientId(clientId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public List<LicenseManager4Web.Entities.Written.License> GetLicensesByClientIdAndSiteId(int clientId, int siteId)
        {
            try
            {
                return LicenseService.GetLicensesByClientIdAndSiteId(clientId, siteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Clients

        [WebMethod]
        public void DeleteClient(int clientId)
        {
            throw new NotImplementedException();
        }

        [WebMethod]
        public bool ClientHasActiveLicenses(int clientId)
        {
            try
            {
                return ClientService.ClientHasActiveLicenses(clientId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public int CreateClient(string clientName, string salesForceId)
        {
            try
            {
                return ClientService.CreateClient(clientName, salesForceId);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [WebMethod]
        public string SaveClient(int clientId, string clientName, string salesForceId)
        {
            try
            {
                ClientService.SaveClient(clientId, clientName, salesForceId);
                return "Success";
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}{1}{2}", ex.Message, Environment.NewLine, ex.InnerException.ToString());
            }            
        }

        [WebMethod]
        public Client GetClientById(int clientId)
        {
            try
            {
                return ClientService.GetClientById(clientId);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [WebMethod]
        public List<Client> GetAllClients()
        {
            try
            {
                return ClientService.GetAllClients();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        #endregion

        #region Sites

        [WebMethod]
        public void DeleteSite(int siteId)
        {
            throw new NotImplementedException();
        }

        [WebMethod]
        public bool SiteHasActiveLicenses(int siteId)
        {
            try
            {
                return SiteService.SiteHasActiveLicenses(siteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public int CreateSite(int clientId, string siteName, string salesForceId)
        {
            try
            {
                return SiteService.CreateSite(clientId, siteName, salesForceId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public string SaveSite(int siteId, int clientId, string siteName, string salesForceId)
        {
            try
            {
                SiteService.SaveSite(siteId, clientId, siteName, salesForceId);
                return "Success";
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}{1}{2}", ex.Message, Environment.NewLine, ex.InnerException.ToString());
            }
        }

        [WebMethod]
        public Site GetSiteById(int siteId)
        {
            try
            {
                return SiteService.GetSiteById(siteId);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [WebMethod]
        public List<Site> GetAllSites()
        {
            try
            {
                return SiteService.GetAllSites();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [WebMethod]
        public List<Site> GetAllSitesByClientId(int clientId)
        {
            try
            {
                return SiteService.GetAllSitesByClientId(clientId);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        #endregion
    }
}
