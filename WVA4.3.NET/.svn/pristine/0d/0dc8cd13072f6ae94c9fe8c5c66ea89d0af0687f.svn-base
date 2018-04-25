using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using LicenseManager4Web.DataContext;
using LicenseManager4Web.Entities;
using AutoMapper;
using LicenseManager4Web.Entities.Written;
using Update = LicenseManager4Web.Entities.Written.Update;
using UpdateSeries = LicenseManager4Web.Entities.Written.UpdateSeries;
using Version = LicenseManager4Web.Entities.Written.Version;
using UpdateFile = LicenseManager4Web.Entities.Written.UpdateFile;

namespace LicenseManager4Web.Services
{
    public static class UpdateService
    {
        static UpdateService()
        {
            Mapper.CreateMap<Update, LicenseManager4Web.Entities.Update>();
            Mapper.CreateMap<LicenseManager4Web.Entities.Update, Update>();
            Mapper.CreateMap<UpdateSeries, LicenseManager4Web.Entities.UpdateSeries>();
            Mapper.CreateMap<LicenseManager4Web.Entities.UpdateSeries, UpdateSeries>();
            Mapper.CreateMap<Version, LicenseManager4Web.Entities.Version>();
            Mapper.CreateMap<LicenseManager4Web.Entities.Version, Version>();
            Mapper.CreateMap<UpdateFile, LicenseManager4Web.Entities.UpdateFile>();
            Mapper.CreateMap<LicenseManager4Web.Entities.UpdateFile, UpdateFile>().ForMember(dest => dest.File, opt => opt.Ignore()); ;
        }

        #region updates

        public static Update MapUpdate(Entities.Update dbo)
        {
            var obj = new Update();
            Mapper.Map(dbo, obj);

            obj.UpdateFileIds = GetFildIdsForUpdate(obj.Id);

            return obj;
        }

        public static UpdateSeries MapUpdateSeries(Entities.UpdateSeries dbo)
        {
            var obj = new UpdateSeries();
            Mapper.Map(dbo, obj);

            obj.Updates = GetUpdatesBySeriesId(obj.Id);
            obj.Versions = GetVersionsBySeriesId(obj.Id).Select(x => x.Id).ToList();

            return obj;
        }

        public static Version MapVersion(Entities.Version dbo)
        {
            var obj = new Version();
            Mapper.Map(dbo, obj);

            return obj;
        }

        public static List<Version> GetAllVersions()
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from v in dc.Versions select MapVersion(v)).ToList();
            }
        }

        public static List<Version> GetAllVersionsForUpdateSeries(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from v in dc.UpdatesVersions where v.UpdateSeriesId == id select MapVersion(v.Version)).ToList();
            }
        }

        public static List<Version> GetVersionsBySeriesId(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from v in dc.Versions
                        join uv in dc.UpdatesVersions on v.Id equals uv.VersionId
                        where uv.UpdateSeriesId == id
                        select MapVersion(v)).ToList();
            }
        }
        public static List<Update> GetAllInstallUpdatesInSeriesById(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return dc.UpdateSeries.Where(x => x.Id == id).SelectMany(x => x.Updates.Where(y => y.UpdateType.Equals(UpdateType.Update))).Select(x => MapUpdate(x)).ToList();
            }
        }

        public static List<Update> GetAllHotfixUpdatesInSeriesById(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return dc.UpdateSeries.Where(x => x.Id == id).SelectMany(x => x.Updates.Where(y => y.UpdateType.Equals(UpdateType.Hotfix))).Select(x => MapUpdate(x)).ToList();
            }
        }

        public static List<Update> GetAllMessageUpdatesInSeriesById(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return dc.UpdateSeries.Where(x => x.Id == id).SelectMany(x => x.Updates.Where(y => y.UpdateType.Equals(UpdateType.Message))).Select(x => MapUpdate(x)).ToList();
            }
        }

        public static List<UpdateSeries> GetAllUpdateSeries()
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from us in dc.UpdateSeries select MapUpdateSeries(us)).ToList();
            }
        }

        public static UpdateSeries GetUpdateSeriesById(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from us in dc.UpdateSeries where us.Id == id select MapUpdateSeries(us)).SingleOrDefault();
            }
        }

        public static Update GetUpdateById(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from u in dc.Updates where u.Id == id select MapUpdate(u)).SingleOrDefault();
            }
        }

        public static List<Update> GetAllUpdates()
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from u in dc.Updates select MapUpdate(u)).ToList();
            }
        }

        public static void CompleteUpdate(Guid applicationid, Guid updateId)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                dc.UpdatesApplications.InsertOnSubmit(new UpdatesApplication() { Id = Guid.NewGuid(), ApplicationId = applicationid, UpdateId = updateId });
                dc.SubmitChanges();
            }
        }

        public static List<Guid> CheckForUpdates(string version, Guid applicationId)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                var completedUpdates = dc.UpdatesApplications.Where(x => x.ApplicationId == applicationId).Select(x => x.UpdateId);
                return (from u in dc.Updates where !completedUpdates.Contains(u.Id) select u.UpdateSeriesId).Distinct().ToList();
            }
        }

        public static List<Update> GetUpdatesBySeriesId(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from u in dc.Updates where u.UpdateSeriesId == id select MapUpdate(u)).ToList();
            }
        }

        public static Update SaveUpdate(Update u)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                if(u.Id.Equals(Guid.Empty))
                {
                    u.Id = Guid.NewGuid();
                    u.DateCreated = DateTime.Now;
                    u.DateModified = DateTime.Now;

                    var dbo = new Entities.Update();
                    Mapper.Map(u, dbo);

                    dc.Updates.InsertOnSubmit(dbo);
                    dc.SubmitChanges();

                    return MapUpdate(dbo);
                }
                else
                {
                    u.DateModified = DateTime.Now;

                    var dbo = dc.Updates.SingleOrDefault(x => x.Id == u.Id);
                    if(dbo != null)
                    {
                        Mapper.Map(u, dbo);
                        dc.SubmitChanges();
                    }

                    return MapUpdate(dbo);
                }
            }
        }

        public static UpdateSeries SaveUpdateSeries(UpdateSeries us)
        {
            var dbo = new Entities.UpdateSeries();

            using(var dc = new UpdateManagerClassesDataContext())
            {
                if(us.Id.Equals(Guid.Empty))
                {
                    us.Id = Guid.NewGuid();
                    us.DateCreated = DateTime.Now;
                    us.DateModified = DateTime.Now;

                    dbo = new Entities.UpdateSeries();
                    Mapper.Map(us, dbo);

                    dc.UpdateSeries.InsertOnSubmit(dbo);
                    dc.SubmitChanges();
                }
                else
                {
                    us.DateModified = DateTime.Now;

                    dbo = dc.UpdateSeries.SingleOrDefault(x => x.Id == us.Id);
                    if(dbo != null)
                    {
                        Mapper.Map(us, dbo);
                        dc.SubmitChanges();
                    }
                }

                dc.UpdatesVersions.DeleteAllOnSubmit(dc.UpdatesVersions.Where(x => x.UpdateSeriesId == us.Id));
                foreach (var g in us.Versions)
                {
                    dc.UpdatesVersions.InsertOnSubmit(new UpdatesVersion { Id = Guid.NewGuid(), UpdateSeriesId = us.Id, VersionId = g });
                }
                dc.SubmitChanges();

                return MapUpdateSeries(dbo);
            }
        }

        public static void SaveVersion(Version v)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                if(v.Id.Equals(Guid.Empty))
                {
                    v.Id = Guid.NewGuid();

                    var dboversion = new Entities.Version();
                    Mapper.Map(v, dboversion);

                    dc.Versions.InsertOnSubmit(dboversion);
                    dc.SubmitChanges();
                }
                else
                {
                    var dboversion = dc.Versions.SingleOrDefault(x => x.Id == v.Id);
                    if(dboversion != null)
                    {
                        Mapper.Map(v, dboversion);
                        dc.SubmitChanges();
                    }
                }
            }
        }

        public static void DeleteVersionById(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                var dbo = dc.Versions.SingleOrDefault(x => x.Id == id);
                if(dbo != null)
                {
                    dc.UpdatesVersions.DeleteAllOnSubmit((from v in dc.UpdatesVersions where v.VersionId == id select v));
                    dc.Versions.DeleteOnSubmit(dbo);
                    dc.SubmitChanges();
                }
            }
        }

        #endregion

        #region files
        
        public static UpdateFile MapUpdateFile(Entities.UpdateFile dbo)
        {
            var obj = new UpdateFile();
            Mapper.Map(dbo, obj);

            obj.File = dbo.File.ToArray();
            
            return obj;
        }

        public static void CancelUploads(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                dc.UpdateFiles.DeleteAllOnSubmit(dc.UpdateFiles.Where(x => x.UpdateId == id));
                dc.SubmitChanges();
            }
        }

        public static List<UpdateFile> GetFilesForUpdate(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from u in dc.UpdateFiles where u.UpdateId == id select MapUpdateFile(u)).ToList();
            }
        }

        public static UpdateFile GetUpdateFileById(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from f in dc.UpdateFiles where f.Id == id select MapUpdateFile(f)).SingleOrDefault();
            }
        }

        public static List<Guid> GetFildIdsForUpdate(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                return (from u in dc.UpdateFiles where u.UpdateId == id select u.Id).ToList();
            }
        }

        public static void DeleteUpdateSeriesById(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                dc.UpdateSeries.DeleteOnSubmit(dc.UpdateSeries.SingleOrDefault(x => x.Id == id));
                dc.SubmitChanges();
            }
        }

        public static void DeleteUpdateById(Guid id)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                dc.UpdateFiles.DeleteAllOnSubmit(dc.UpdateFiles.Where(x => x.UpdateId == id));
                dc.Updates.DeleteAllOnSubmit(dc.Updates.Where(x => x.Id == id));
                dc.SubmitChanges();
            }
        }

        public static void DeleteUpdateFile(Guid fileId)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                var dbo = dc.UpdateFiles.SingleOrDefault(x => x.Id == fileId);
                if(dbo != null)
                {
                    dc.UpdateFiles.DeleteOnSubmit(dbo);
                    dc.SubmitChanges();
                }
            }
        }

        public static Guid CreateUpdateFile(Guid updateId, string fileName, string installPath)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                var dbo = new Entities.UpdateFile
                              {
                                  Id = Guid.NewGuid(),
                                  UpdateId = updateId,
                                  DateCreated = DateTime.Now,
                                  IsComplete = false,
                                  FileName = fileName,
                                  InstallPath = installPath
                              };

                dc.UpdateFiles.InsertOnSubmit(dbo);
                dc.SubmitChanges();

                return dbo.Id;
            }
        }

        public static void SaveUpdateFile(Guid fileId, byte[] b2)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                var dbo = dc.UpdateFiles.SingleOrDefault(x => x.Id == fileId);
                if(dbo != null)
                {
                    if(dbo.File != null)
                    {
                        var b1 = dbo.File.ToArray();
                        var concat = new byte[b1.Length + b2.Length];

                        Buffer.BlockCopy(b1, 0, concat, 0, b1.Length);
                        Buffer.BlockCopy(b2, 0, concat, b1.Length, b2.Length);

                        dbo.File = new Binary(concat);
                    }
                    else
                    {
                        dbo.File = new Binary(b2);
                    }

                    dc.SubmitChanges();
                }
            }
        }

        public static void FinishUpdateFile(Guid fileId)
        {
            using(var dc = new UpdateManagerClassesDataContext())
            {
                var dbo = dc.UpdateFiles.SingleOrDefault(x => x.Id == fileId);
                if(dbo != null)
                {
                    dbo.DateFinished = DateTime.Now;
                    dbo.IsComplete = true;
                    
                    dc.SubmitChanges();
                }
            }
        }

        #endregion
    }
}