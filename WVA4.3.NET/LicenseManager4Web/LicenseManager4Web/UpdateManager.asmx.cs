using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LicenseManager4Web.Entities.Written;
using LicenseManager4Web.Services;
using Version = LicenseManager4Web.Entities.Written.Version;

namespace LicenseManager4Web
{
    /// <summary>
    /// Update manager webservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UpdateManager : System.Web.Services.WebService
    {
        #region Updates

        [WebMethod]
        public List<UpdateType> GetUpdateTypes()
        {
            return Enum.GetValues(typeof(UpdateType)).Cast<UpdateType>().ToList();
        }

        [WebMethod]
        public Update SaveUpdate(Update u)
        {
            return UpdateService.SaveUpdate(u);
        }

        [WebMethod]
        public Update GetUpdateById(Guid id)
        {
            return UpdateService.GetUpdateById(id);
        }

        [WebMethod]
        public List<Update> GetAllUpdates()
        {
            return UpdateService.GetAllUpdates();
        }

        [WebMethod]
        public List<Update> GetUpdatesBySeriesId(Guid id)
        {
            return UpdateService.GetUpdatesBySeriesId(id);
        }

        [WebMethod]
        public void CompleteUpdate(Guid applicationid, Guid updateId)
        {
            UpdateService.CompleteUpdate(applicationid, updateId);
        }

        [WebMethod]
        public List<Guid> CheckForUpdates(string version, Guid applicationId)
        {
            return UpdateService.CheckForUpdates(version, applicationId);
        }

        [WebMethod]
        public Update GetUpdate(Guid id)
        {
            return new Update();
        }

        [WebMethod]
        public UpdateSeries GetUpdateSeries(Guid id)
        {
            return new UpdateSeries();
        }
        
        [WebMethod]
        public void DeleteUpdateById(Guid id)
        {
            UpdateService.DeleteUpdateById(id);
        }

        #endregion

        #region Update Series
        
        [WebMethod]
        public bool InstallUpdatesInSeriesByIds(List<Guid> ids)
        {
            var installs = new List<Update>();
            foreach(var g in ids)
            {
                installs.AddRange(UpdateService.GetAllInstallUpdatesInSeriesById(g));
                installs.AddRange(UpdateService.GetAllHotfixUpdatesInSeriesById(g));
            }

            return installs.Count > 0 ? true : false;
        }

        [WebMethod]
        public bool HotfixUpdatesInSeriesByIds(List<Guid> ids)
        {
            var hotfixes = new List<Update>();
            foreach(var g in ids)
            {
                hotfixes.AddRange(UpdateService.GetAllHotfixUpdatesInSeriesById(g));
            }

            return hotfixes.Count > 0 ? true : false;
        }

        [WebMethod]
        public List<Update> GetAllMessageUpdatesInSeriesById(Guid id)
        {
            return UpdateService.GetAllMessageUpdatesInSeriesById(id);
        }

        [WebMethod]
        public List<Update> GetAllHotfixUpdatesInSeriesById(Guid id)
        {
            return UpdateService.GetAllHotfixUpdatesInSeriesById(id);
        }

        [WebMethod]
        public List<UpdateSeries> GetAllUpdateSeries()
        {
            return UpdateService.GetAllUpdateSeries();
        }

        [WebMethod]
        public UpdateSeries GetUpdateSeriesById(Guid id)
        {
            return UpdateService.GetUpdateSeriesById(id);
        }

        [WebMethod]
        public UpdateSeries SaveUpdateSeriesWithUpdateIds(UpdateSeries us, List<Guid> updateIds)
        {
            try
            {
                return UpdateService.SaveUpdateSeries(us);
            }
            catch(Exception)
            {
                return null;
            }
        }

        [WebMethod]
        public void DeleteUpdateSeriesById(Guid id)
        {
            try
            {
                UpdateService.DeleteUpdateSeriesById(id);
            }
            catch(Exception) { }
        }

        [WebMethod]
        public UpdateSeries SaveUpdateSeries(UpdateSeries us)
        {
            try
            {
                us.Updates = UpdateService.GetUpdatesBySeriesId(us.Id);
                return UpdateService.SaveUpdateSeries(us);
            }
            catch(Exception)
            {
                return null;
            }
        }

        #endregion
        
        #region Versions
        
        [WebMethod]
        public List<Version> GetAllVersionsForUpdateSeries(Guid id)
        {
            return UpdateService.GetAllVersionsForUpdateSeries(id);
        }

        [WebMethod]
        public List<Version> GetAllVersions()
        {
            return UpdateService.GetAllVersions();
        }

        [WebMethod]
        public int SaveVersion(Version v)
        {
            try
            {
                UpdateService.SaveVersion(v);
                return 1;
            }
            catch(Exception)
            {
                return -1;
            }
        }

        [WebMethod]
        public void DeleteVersionById(Guid id)
        {
            try
            {
                UpdateService.DeleteVersionById(id);
            }
            catch (Exception) { }
        }

        #endregion

        #region file upload & download

        [WebMethod]
        public long StartDownload(Guid fileId)
        {
            UpdateFile f = UpdateService.GetUpdateFileById(fileId);
            return f.File.Length;
        }

        [WebMethod]
        public byte[] Download(Guid fileId, int read)
        {
            var f = UpdateService.GetUpdateFileById(fileId);
            const int bufferSize = 10420;
            var bytesToRead = (f.File.Length - read) < bufferSize ? (f.File.Length - read) : bufferSize;
            var bytes = new byte[bytesToRead];
            Buffer.BlockCopy(f.File, read, bytes, 0, bytesToRead);

            return bytes;
        }

        [WebMethod]
        public Guid StartUpload(Guid updateId, string fileName, string installPath)
        {
            return UpdateService.CreateUpdateFile(updateId, fileName, installPath);
        }

        [WebMethod]
        public string AppendUpload(Guid fileId, byte[] bytes)
        {
            try
            {
                UpdateService.SaveUpdateFile(fileId, bytes);
                return "Success";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public bool FinishUpload(Guid fileId)
        {
            try
            {
                UpdateService.FinishUpdateFile(fileId);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        
        [WebMethod]
        public void DeleteAllUploadsByUpdateId(Guid updateId)
        {
            try
            {
                UpdateService.CancelUploads(updateId);
            }
            catch { }
        }

        [WebMethod]
        public void CancelAllUploadsByUpdateId(Guid updateId)
        {
            try
            {
                UpdateService.CancelUploads(updateId);
            }
            catch { }
        }

        [WebMethod]
        public void DeleteUpload(Guid fileId)
        {
            UpdateService.DeleteUpdateFile(fileId);
        }

        [WebMethod]
        public void CancelUpload(Guid fileId)
        {
            UpdateService.DeleteUpdateFile(fileId);
        }

        [WebMethod]
        public UpdateFile GetUpdateFileById(Guid id)
        {
            return UpdateService.GetUpdateFileById(id);
        }

        [WebMethod]
        public List<UpdateFile> GetFilesForUpdate(Guid id)
        {
            return UpdateService.GetFilesForUpdate(id);
        }

        #endregion
    }
}
