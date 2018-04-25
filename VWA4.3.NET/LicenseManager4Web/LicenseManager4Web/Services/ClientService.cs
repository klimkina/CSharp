using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LicenseManager4Web.DataContext;
using LicenseManager4Web.Entities.Written;

namespace LicenseManager4Web.Services
{
    public static class ClientService
    {
        static ClientService()
        {
            Mapper.CreateMap<LicenseManager4Web.Entities.Client, LicenseManager4Web.Entities.Written.Client>();            
        }

        public static int CreateClient(string ClientName)
        {
            return ClientService.CreateClient(ClientName, string.Empty);
        }

        public static int CreateClient(string ClientName, string SalesForceId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                Entities.Client c = new Entities.Client();
                c.ClientName = ClientName;
                c.SalesForceId = SalesForceId;

                dc.Clients.InsertOnSubmit(c);
                dc.SubmitChanges();

                return c.ID;
            }
        }

        public static void SaveClient(int clientId, string clientName)
        {
            ClientService.SaveClient(clientId, clientName, string.Empty);
        }

        public static void SaveClient(int clientId, string clientName, string salesForceId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                Entities.Client c = dc.Clients.SingleOrDefault(x => x.ID == clientId);
                c.ClientName = clientName;
                c.SalesForceId = salesForceId;

                dc.SubmitChanges();
            }
        }

        public static List<Client> GetAllClients()
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return (from client in dc.Clients select MapClient(client)).ToList();
            }
        }

        public static Client MapClient(LicenseManager4Web.Entities.Client dboClient)
        {
            var clientobj = new Client();
            Mapper.Map(dboClient, clientobj);

            clientobj.NumberOfSites = dboClient.Sites.Count;

            return clientobj;
        }

        public static bool ClientHasActiveLicenses(int clientId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                if (dc.Licenses.Where(x => x.ClientID == clientId).Select(x => x.ID).Count() > 0)
                    return true;
                return false;
            }
        }

        public static Client GetClientById(int clientId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                return MapClient(dc.Clients.SingleOrDefault(x => x.ID == clientId));
            }
        }
        
        public static Client GetClient(int clientId)
        {
            using (var dc = new LicenseManagerClassesDataContext())
            {
                Client c = (from client in dc.Clients where client.ID == clientId select MapClient(client)).FirstOrDefault();

                if (c == null)
                    c = new Client();

                return c;
            }
        }
    }
}