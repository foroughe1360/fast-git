using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.Trianing;

namespace DataAccess
{
    public class FinancialCommitmentDAC : IFinancialCommitmentRepository
    {
        public int Add(FinancialCommitment Current)
        {
            TrainingContext db = new TrainingContext();
            db.FinancialCommitments.Add(Current);
            db.SaveChanges();
            return Current.FinancialCommitmentId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var financialCommitment = new FinancialCommitment() { FinancialCommitmentId = ID, Hidden = true };
                db.FinancialCommitments.Attach(financialCommitment);
                db.Entry(financialCommitment).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(FinancialCommitment Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.FinancialCommitments.Attach(Current);

                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingCourseId).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingVenueId).IsModified = true;
                db.Entry(Current).Property(x => x.AmountPierced).IsModified = true;
                db.Entry(Current).Property(x => x.TimeEmployment).IsModified = true;
                db.Entry(Current).Property(x => x.FromDate).IsModified = true;
                db.Entry(Current).Property(x => x.ToDate).IsModified = true;
                db.Entry(Current).Property(x => x.FinancialYear).IsModified = true;

                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public FinancialCommitment Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.FinancialCommitments.SingleOrDefault(x => x.FinancialCommitmentId == ID);
        }

        public FinancialCommitmentEntity GetFinancialCommitment(int ID)
        {

            //TrainingContext db = new TrainingContext();
            //return
            //    (from financialcommitment in db.FinancialCommitments.Where(x => x.FinancialCommitmentId == ID)
            //     join employemes in db.Employemes on financialcommitment.EmployemeId equals employemes.EmployemeId
            //     join trainingcourse in db.TrainingCourses on financialcommitment.TrainingCourseId equals trainingcourse.TrainingCourseId
            //     join tableinterfacevalues in db.TableInterfaceValues on financialcommitment.TrainingVenueId equals tableinterfacevalues.TableInterfaceValueId
            //     select new FinancialCommitmentEntity
            //     {
            //         AmountPierced = financialcommitment.AmountPierced,
            //         EmployemeId = financialcommitment.EmployemeId,
            //         EmployemesName = employemes.FirstName + " " + employemes.LastName,
            //         FinancialCommitmentId = financialcommitment.FinancialCommitmentId,
            //         TimeEmployment = financialcommitment.TimeEmployment,
            //         TrainingCourseId = financialcommitment.TrainingCourseId,
            //         TrainingCourseName = trainingcourse.CourseName,
            //         TrainingVenueId = financialcommitment.TrainingVenueId,
            //         TrainingVenueName = tableinterfacevalues.TableValue,
            //         FromDate = financialcommitment.FromDate,
            //         ToDate = financialcommitment.ToDate
            //     }).SingleOrDefault();


            TrainingContext db = new TrainingContext();
             var ListFinancialCommitment =
            (from financialcommitment in db.FinancialCommitments.Where(x => x.FinancialCommitmentId == ID)
             join employemes in db.Employemes on financialcommitment.EmployemeId equals employemes.EmployemeId
             join trainingcourse in db.TrainingCourses on financialcommitment.TrainingCourseId equals trainingcourse.TrainingCourseId
             join tableinterfacevalues in db.TableInterfaceValues on financialcommitment.TrainingVenueId equals tableinterfacevalues.TableInterfaceValueId

             select new 
             {
                 NationalCode = employemes.NationalCode,
                 AmountPierced = financialcommitment.AmountPierced,
                 EmployemeId = financialcommitment.EmployemeId,
                 EmployemesName = employemes.FirstName + " " + employemes.LastName,
                 FinancialCommitmentId = financialcommitment.FinancialCommitmentId,
                 TimeEmployment = financialcommitment.TimeEmployment,
                 TrainingCourseId = financialcommitment.TrainingCourseId,
                 TrainingCourseName = trainingcourse.CourseName,
                 TrainingVenueId = financialcommitment.TrainingVenueId,
                 TrainingVenueName = tableinterfacevalues.TableValue,
                 FromDate = financialcommitment.FromDate,
                 ToDate = financialcommitment.ToDate,
                 CheckFinancialCommitment = DateTime.Compare(financialcommitment.ToDate, DateTime.Now) > 0 ? true : false,
                 FinancialYear = financialcommitment.FinancialYear,
             });

            var _query =
                (from listfinancialcommitment in ListFinancialCommitment
                 select new FinancialCommitmentEntity
                 {
                     NationalCode = listfinancialcommitment.NationalCode,
                     AmountPierced = listfinancialcommitment.AmountPierced,
                     EmployemeId = listfinancialcommitment.EmployemeId,
                     EmployemesName = listfinancialcommitment.EmployemesName,
                     FinancialCommitmentId = listfinancialcommitment.FinancialCommitmentId,
                     TimeEmployment = listfinancialcommitment.TimeEmployment,
                     TrainingCourseId = listfinancialcommitment.TrainingCourseId,
                     TrainingCourseName = listfinancialcommitment.TrainingCourseName,
                     TrainingVenueId = listfinancialcommitment.TrainingVenueId,
                     TrainingVenueName = listfinancialcommitment.TrainingVenueName,
                     FromDate = listfinancialcommitment.FromDate,
                     ToDate = listfinancialcommitment.ToDate,
                     CheckFinancialCommitment = listfinancialcommitment.CheckFinancialCommitment,
                     FinancialYear = listfinancialcommitment.FinancialYear,
                 });

            return _query.SingleOrDefault();
        }

        public IQueryable<FinancialCommitment> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.FinancialCommitments select item;
        }

        public IQueryable<FinancialCommitmentEntity> GetAllFinancialCommitment()//int trainingcourseid)
        {
            TrainingContext db = new TrainingContext();
            var ListFinancialCommitment =
                (from financialcommitment in db.FinancialCommitments.Where(a => a.Hidden == false)// && a.TrainingCourseId == trainingcourseid)
                 join employemes in db.Employemes on financialcommitment.EmployemeId equals employemes.EmployemeId
                 join trainingcourse in db.TrainingCourses on financialcommitment.TrainingCourseId equals trainingcourse.TrainingCourseId
                 join tableinterfacevalues in db.TableInterfaceValues on financialcommitment.TrainingVenueId equals tableinterfacevalues.TableInterfaceValueId
                 select new FinancialCommitmentEntity
                 {
                     AmountPierced = financialcommitment.AmountPierced,
                     EmployemeId = financialcommitment.EmployemeId,
                     EmployemesName = employemes.FirstName + " " + employemes.LastName,
                     FinancialCommitmentId = financialcommitment.FinancialCommitmentId,
                     TimeEmployment = financialcommitment.TimeEmployment,
                     TrainingCourseId = financialcommitment.TrainingCourseId,
                     TrainingCourseName = trainingcourse.CourseName,
                     TrainingVenueId = financialcommitment.TrainingVenueId,
                     TrainingVenueName = tableinterfacevalues.TableValue,
                     FromDate = financialcommitment.FromDate,
                     ToDate = financialcommitment.ToDate,
                     CheckFinancialCommitment = DateTime.Compare(financialcommitment.ToDate, DateTime.Now) > 0 ? true : false,
                     FinancialYear = financialcommitment.FinancialYear,
                     //TookHold = (designtrainingcourses.TookHold == null ? new DateTime(1753, 1, 1, 12, 0, 0) : designtrainingcourses.TookHold),
                     //TookHoldStr = (designtrainingcourses.TookHold == null ? " " : designtrainingcourses.TookHold.ToString()),
                 });

            //var _query =
            //     (from listfinancialcommitment in ListFinancialCommitment
            //          //join designtrainingcourses in db.DesignTrainingCourses on listfinancialcommitment.TrainingCourseId equals designtrainingcourses.TrainingCourseId
            //          //into Temp
            //          //from temp in Temp.DefaultIfEmpty()
            //      select new FinancialCommitmentEntity
            //      {
            //          AmountPierced = listfinancialcommitment.AmountPierced,
            //          EmployemeId = listfinancialcommitment.EmployemeId,
            //          EmployemesName = listfinancialcommitment.EmployemesName,
            //          FinancialCommitmentId = listfinancialcommitment.FinancialCommitmentId,
            //          TimeEmployment = listfinancialcommitment.TimeEmployment,
            //          TrainingCourseId = listfinancialcommitment.TrainingCourseId,
            //          TrainingCourseName = listfinancialcommitment.TrainingCourseName,
            //          TrainingVenueId = listfinancialcommitment.TrainingVenueId,
            //          TrainingVenueName = listfinancialcommitment.TrainingVenueName,
            //          //TookHold = (temp.TookHold == null ? new DateTime(1753, 1, 1, 12, 0, 0) : temp.TookHold),
            //          //TookHoldStr = (temp.TookHold == null ? " " : temp.TookHold.ToString()),
            //          FromDate = listfinancialcommitment.FromDate,
            //          ToDate = listfinancialcommitment.ToDate,
            //          CheckFinancialCommitment = listfinancialcommitment.CheckFinancialCommitment,
            //          FinancialYear = listfinancialcommitment.FinancialYear,
            //      });

            return ListFinancialCommitment;
        }

        public IQueryable<FinancialCommitmentEntity> GetAll(FinancialCommitmentSearch financialcommitmentsearch)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                (from financialcommitment in db.FinancialCommitments.Where(a => a.Hidden == false)
                 join employemes in db.Employemes on financialcommitment.EmployemeId equals employemes.EmployemeId
                 join employemejobs in db.EmployemeJobs.Where(a => a.Hidden == false && a.ActivePostGroupName == true) on employemes.EmployemeId equals employemejobs.EmployemeId
                 join trainingcourse in db.TrainingCourses on financialcommitment.TrainingCourseId equals trainingcourse.TrainingCourseId
                 join tableinterfacevalues in db.TableInterfaceValues on financialcommitment.TrainingVenueId equals tableinterfacevalues.TableInterfaceValueId
                 select new FinancialCommitmentEntity
                 {
                     AmountPierced = financialcommitment.AmountPierced,
                     EmployemeId = financialcommitment.EmployemeId,
                     EmployemesName = employemes.FirstName + " " + employemes.LastName,
                     FinancialCommitmentId = financialcommitment.FinancialCommitmentId,
                     TimeEmployment = financialcommitment.TimeEmployment,
                     TrainingCourseId = financialcommitment.TrainingCourseId,
                     TrainingCourseName = trainingcourse.CourseName,
                     TrainingVenueId = financialcommitment.TrainingVenueId,
                     TrainingVenueName = tableinterfacevalues.TableValue,
                     FromDate = financialcommitment.FromDate,
                     ToDate = financialcommitment.ToDate,
                     //CheckFinancialCommitment = false,
                     State = employemes.State,
                     //990825
                     ActivePostGroupName = employemejobs.ActivePostGroupName,
                     CheckFinancialCommitment = DateTime.Compare(financialcommitment.ToDate, DateTime.Now) > 0 ? true : false,
                     FinancialYear = financialcommitment.FinancialYear,

                 });

            if (financialcommitmentsearch.State != -1)
                _query = _query.Where(p => p.State == financialcommitmentsearch.UserState);
            ////990825
            //if (financialcommitmentsearch.State != -1)
            //    _query = _query.Where(p => p.ActivePostGroupName == financialcommitmentsearch.ActivePostGroupName);

            if (financialcommitmentsearch.EmployemesName.Trim() != "")
                _query = _query.Where(p => p.EmployemesName.Contains(financialcommitmentsearch.EmployemesName));

            bool checkfinancialcommitment = false;
            if (financialcommitmentsearch.CheckFinancialCommitment == 1)
                checkfinancialcommitment = true;

            if (financialcommitmentsearch.CheckFinancialCommitment != -1)
                _query = _query.Where(p => p.CheckFinancialCommitment == checkfinancialcommitment);


            return _query;
        }

    }
}