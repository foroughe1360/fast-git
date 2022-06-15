using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SetDateForReportDAC : ISetDateForReportRepository
    {
        public int Add(SetDateForReport Current)
        {
            TrainingContext db = new TrainingContext();
            db.SetDateForReports.Add(Current);
            db.SaveChanges();
            return Current.SetDateForReportId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var setdateforreport = new SetDateForReport() { SetDateForReportId = ID, Hidden = true };
                db.SetDateForReports.Attach(setdateforreport);
                db.Entry(setdateforreport).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(SetDateForReport Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.SetDateForReports.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.DateOfApprover).IsModified = true;
                db.Entry(Current).Property(x => x.DateOfProducer).IsModified = true;
                db.Entry(Current).Property(x => x.DateOfRegistrar).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
                db.Entry(Current).Property(x => x.PublicCode).IsModified = true;
                db.Entry(Current).Property(x => x.ReportNameId).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public SetDateForReport Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.SetDateForReports.SingleOrDefault(x => x.SetDateForReportId == ID);
        }

        public IQueryable<SetDateForReport> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.SetDateForReports select item;
        }

        public IQueryable<SetDateForReportEntity> GetAll(int ID , int ReportNameId)
        {
            TrainingContext db = new TrainingContext();
            return
                (from setdateforreports in db.SetDateForReports.Where(a => a.Hidden == false && a.PublicCode == ID && a.ReportNameId == ReportNameId)
                 join tableinterfacevalues in db.TableInterfaceValues on setdateforreports.ReportNameId equals tableinterfacevalues.TableInterfaceValueId
                 select new SetDateForReportEntity
                 {
                     SetDateForReportId = setdateforreports.SetDateForReportId,
                     ReportNameId = setdateforreports.ReportNameId,
                     EmployemeId = setdateforreports.EmployemeId,
                     PublicCode = setdateforreports.PublicCode,
                     ReportNameTitle = tableinterfacevalues.TableValue,
                     DateOfProducer = setdateforreports.DateOfProducer,
                     DateOfApprover = setdateforreports.DateOfApprover,
                     DateOfRegistrar = setdateforreports.DateOfRegistrar,
                 });
        }

        public IQueryable<SetDateForReportEntity> GetAllSetDateForReport(int ID ,int ReportNameId)
        {
            TrainingContext db = new TrainingContext();
            return
                (from setdateforreports in db.SetDateForReports.Where(a => a.Hidden == false && a.PublicCode == ID && a.ReportNameId == ReportNameId)
                 join tableinterfacevalues in db.TableInterfaceValues on setdateforreports.ReportNameId equals tableinterfacevalues.TableInterfaceValueId
                 select new SetDateForReportEntity
                 {
                     SetDateForReportId = setdateforreports.SetDateForReportId,
                     ReportNameId = setdateforreports.ReportNameId,
                     EmployemeId = setdateforreports.EmployemeId,
                     PublicCode = setdateforreports.PublicCode,
                     ReportNameTitle = tableinterfacevalues.TableValue,
                     DateOfProducer = setdateforreports.DateOfProducer,
                     DateOfApprover = setdateforreports.DateOfApprover,
                     DateOfRegistrar = setdateforreports.DateOfRegistrar,
                 });
        }

    }
}
