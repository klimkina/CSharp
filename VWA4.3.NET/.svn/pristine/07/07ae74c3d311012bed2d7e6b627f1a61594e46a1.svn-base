using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LicenseManager4Web.DataContext;
using LicenseManager4Web.Entities;
using AutoMapper;

namespace LicenseManager4Web.Services
{
    public static class ActivationService
    {
        static ActivationService()
        {
            Mapper.CreateMap<ActivationParams, LicenseManager4Web.Entities.Activation>();
            Mapper.CreateMap<LicenseManager4Web.Entities.Activation, ActivationParams>();

            Mapper.CreateMap<LicenseManager4Web.Entities.Activation, LicenseManager4Web.Entities.Written.Activation>();
        }

        public static int CreateActivation(ActivationParams p)
        {
            //get data context (license manager database)
            using (var dc = new LicenseManagerClassesDataContext())
            {
                //create activation data object
                Activation act = new Activation();
                Mapper.Map(p, act);
                
                //add new activation object to new changes
                dc.Activations.InsertOnSubmit(act);

                //submit changes to database
                dc.SubmitChanges();

                if (p.IsActivated)
                {
                    act.License.LicenseFeatures[0].ExtendedExpirationDate = p.ExtendedExpirationDate;
                    act.License.LicenseFeatures[0].ExpirationWarningStartDate = p.ExpirationWarningsBeginDate;
                    dc.SubmitChanges();
                }                

                return act.ID;
            }
        }

        public static LicenseManager4Web.Entities.Written.Activation ActivateLicense(int licenseId, string cpuID)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                //never activated or has matching cpuid
                LicenseManager4Web.Entities.Activation a = (from act in dc.Activations
                                                            join l in dc.Licenses on act.LicenseID equals l.ID
                                                            join lf in dc.LicenseFeatures on act.LicenseID equals lf.LicenseID
                                                            where act.LicenseID == licenseId && act.Enabled == true
                                                            && (act.CPUID == string.Empty && act.IsActivated == false || act.CPUID == cpuID && act.IsActivated == false)
                                                            select act).FirstOrDefault();


                if (DateTime.Compare(a.License.LicenseFeatures[0].ExtendedExpirationDate.Value, DateTime.Now) <= 0)
                    throw new Exception("Activation has expired.");

                a.CPUID = cpuID;
                a.IsActivated = true;

                a.License.LicenseFeatures[0].ExtendedExpirationDate = a.ExpirationDate;
                    
                dc.SubmitChanges();

                return MapActivation(a);
            }
        }

        public static int SaveActivationCode(int activationId, string activationCode)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                Activation adbo = dc.Activations.SingleOrDefault(x => x.ID == activationId);

                adbo.ActivationCode = activationCode;

                dc.SubmitChanges();

                return adbo.ID;
            }
        }

        public static int SaveActivation(ActivationParams p)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                Activation a = dc.Activations.SingleOrDefault(x => x.ID == p.ID);
                Mapper.Map(p, a);

                a.License.LicenseFeatures[0].ExtendedExpirationDate = p.ExtendedExpirationDate;
                a.License.LicenseFeatures[0].ExpirationWarningStartDate = p.ExpirationWarningsBeginDate;

                dc.SubmitChanges();
                
                return a.ID;
            }
        }

        public static List<LicenseManager4Web.Entities.Written.Activation> GetActivationsByLicenseId(int id)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from a in dc.Activations where a.LicenseID == id select MapActivation(a)).ToList();
            }
        }

        public static LicenseManager4Web.Entities.Written.Activation GetActivationById(int id)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from a in dc.Activations where a.ID == id select MapActivation(a)).FirstOrDefault();
            }
        }

        public static List<LicenseManager4Web.Entities.Written.Activation> GetAllActivations()
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from a in dc.Activations select MapActivation(a)).ToList();
            }
        }

        public static bool IsActivated(int licenseId, string cpuId)
        {
            //using (var dc = new LicenseManagerClassesDataContext())
            //{
            //    //select only activation id, if its null no record exists
            //    int activationId = (from activation in dc.Activations
            //                    where activation.LicenseID == licenseId && activation.CPUID == cpuId && activation.IsActivated == true
            //                    select activation.ID).FirstOrDefault();

            //    if (activationId != null)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        public static LicenseManager4Web.Entities.Written.Activation MapActivation(LicenseManager4Web.Entities.Activation dbo)
        {
            LicenseManager4Web.Entities.Written.Activation obj = new LicenseManager4Web.Entities.Written.Activation();
            Mapper.Map(dbo, obj);

            return obj;
        }
    }
}