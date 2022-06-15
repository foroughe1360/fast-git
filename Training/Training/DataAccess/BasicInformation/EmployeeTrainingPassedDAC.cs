using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity;
using InterfaceEntity.Search.Trianing;

namespace DataAccess
{
    public class EmployeeTrainingPassedDAC : IEmployeeTrainingPassedRepository
    {
        public int Add(EmployeeTrainingPassed Current)
        {
            TrainingContext db = new TrainingContext();
            db.EmployeeTrainingPasseds.Add(Current);
            db.SaveChanges();
            return Current.EmployeeTrainingPassedId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var employeetrainingpassed = new EmployeeTrainingPassed() { EmployeeTrainingPassedId = ID, Hidden = true };
                db.EmployeeTrainingPasseds.Attach(employeetrainingpassed);
                db.Entry(employeetrainingpassed).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(EmployeeTrainingPassed Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.EmployeeTrainingPasseds.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingCourseId).IsModified = true;
                db.Entry(Current).Property(x => x.TrainingVenueId).IsModified = true;
                db.Entry(Current).Property(x => x.Duration).IsModified = true;
                db.Entry(Current).Property(x => x.DateCourse).IsModified = true;
                db.Entry(Current).Property(x => x.CertificateState).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public EmployeeTrainingPassed Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.EmployeeTrainingPasseds.SingleOrDefault(x => x.EmployeeTrainingPassedId == ID);
        }

        public IQueryable<EmployeeTrainingPassed> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.EmployeeTrainingPasseds select item;
        }

        public IQueryable<EmployeeTrainingPassedEntity> GetAll(int Id)
        {
            TrainingContext db = new TrainingContext();
            return
                (from employeetrainingpasseds in db.EmployeeTrainingPasseds.Where(a => a.Employemeid == Id && a.Hidden == false)
                 join trainingcourses in db.TrainingCourses on employeetrainingpasseds.TrainingCourseId equals trainingcourses.TrainingCourseId
                 join tabletypeoftrainings in db.TableTypeOfTrainings on employeetrainingpasseds.TableTypeOfTrainingId equals tabletypeoftrainings.TableTypeOfTrainingId
                 join tableinterfacevalues in db.TableInterfaceValues on employeetrainingpasseds.TrainingVenueId equals tableinterfacevalues.TableInterfaceValueId


                 select new EmployeeTrainingPassedEntity
                 {
                     CertificateState = employeetrainingpasseds.CertificateState,
                     DateCourse = employeetrainingpasseds.DateCourse,
                     Duration = employeetrainingpasseds.Duration,
                     EmployeeTrainingPassedId = employeetrainingpasseds.EmployeeTrainingPassedId,
                     Employemeid = employeetrainingpasseds.Employemeid,
                     TableTypeOfTrainingId = employeetrainingpasseds.TableTypeOfTrainingId,
                     TrainingCourseName = trainingcourses.CourseName,
                     TrainingCourseId = employeetrainingpasseds.TrainingCourseId,
                     TrainingVenueId = employeetrainingpasseds.TrainingVenueId,
                     SD = tabletypeoftrainings.Sd,
                     OJT = tabletypeoftrainings.Ojt,
                     C = tabletypeoftrainings.C,
                     TrainingvenueName = tableinterfacevalues.TableValue
                 });
        }

        public IQueryable<EmployeeTrainingPassedEntity> GetListEmployeeTrainingPassedSearch(EmployeeTrainingPassedReportSearch employeetrainingpassedreportsearch)
        {
            TrainingContext db = new TrainingContext();

            List<EmployeeTrainingPassedEntity> ListEmployeeTrainingPassedReport = new List<EmployeeTrainingPassedEntity>();

            var DetailPlacementTabJobTraining = this.GetDetailPlacementTabJobTrainingemployeme(employeetrainingpassedreportsearch.EmployemeId).ToList();
            if (DetailPlacementTabJobTraining.Count > 0)
            {
                foreach (var item in DetailPlacementTabJobTraining)
                {
                    ListEmployeeTrainingPassedReport.Add(item);
                }
            }
            //var list = from employeetrainingpasseds in ListEmployeeTrainingPassedReport.Where(a => a.Hidden == false)
            //           select new EmployeeTrainingPassedEntity
            //           {
            //               CertificateState = employeetrainingpasseds.CertificateState,
            //               DateCourse = employeetrainingpasseds.DateCourse,
            //               Duration = employeetrainingpasseds.Duration,
            //               EmployeeTrainingPassedId = employeetrainingpasseds.EmployeeTrainingPassedId,
            //               Employemeid = employeetrainingpasseds.Employemeid,
            //               TableTypeOfTrainingId = employeetrainingpasseds.TableTypeOfTrainingId,
            //               TrainingCourseName = employeetrainingpasseds.TrainingCourseName,
            //               TrainingCourseId = employeetrainingpasseds.TrainingCourseId,
            //               TrainingVenueId = employeetrainingpasseds.TrainingVenueId,
            //               SD = employeetrainingpasseds.SD,
            //               OJT = employeetrainingpasseds.OJT,
            //               C = employeetrainingpasseds.C,
            //               TrainingvenueName = employeetrainingpasseds.TrainingvenueName
            //           };

            if (employeetrainingpassedreportsearch.TrainingCourseName.Trim() != "")
                ListEmployeeTrainingPassedReport.Where(p => p.TrainingCourseName.Contains(employeetrainingpassedreportsearch.TrainingCourseName));

            return ListEmployeeTrainingPassedReport.AsQueryable();


            //var list = (from employeetrainingpasseds in db.EmployeeTrainingPasseds.Where(a => a.Employemeid == employeetrainingpassedreportsearch.EmployemeId && a.Hidden == false)
            //            join trainingcourses in db.TrainingCourses on employeetrainingpasseds.TrainingCourseId equals trainingcourses.TrainingCourseId
            //            join tabletypeoftrainings in db.TableTypeOfTrainings on employeetrainingpasseds.TableTypeOfTrainingId equals tabletypeoftrainings.TableTypeOfTrainingId
            //            join tableinterfacevalues in db.TableInterfaceValues on employeetrainingpasseds.TrainingVenueId equals tableinterfacevalues.TableInterfaceValueId

            //            select new EmployeeTrainingPassedEntity
            //            {
            //                CertificateState = employeetrainingpasseds.CertificateState,
            //                DateCourse = employeetrainingpasseds.DateCourse,
            //                Duration = employeetrainingpasseds.Duration,
            //                EmployeeTrainingPassedId = employeetrainingpasseds.EmployeeTrainingPassedId,
            //                Employemeid = employeetrainingpasseds.Employemeid,
            //                TableTypeOfTrainingId = employeetrainingpasseds.TableTypeOfTrainingId,
            //                TrainingCourseName = trainingcourses.CourseName,
            //                TrainingCourseId = employeetrainingpasseds.TrainingCourseId,
            //                TrainingVenueId = employeetrainingpasseds.TrainingVenueId,
            //                SD = tabletypeoftrainings.Sd,
            //                OJT = tabletypeoftrainings.Ojt,
            //                C = tabletypeoftrainings.C,
            //                TrainingvenueName = tableinterfacevalues.TableValue
            //            });
            //if (employeetrainingpassedreportsearch.TrainingCourseName.Trim() != "")
            //    list.Where(p => p.TrainingCourseName.Contains(employeetrainingpassedreportsearch.TrainingCourseName));

            //return list;
        }

        public IQueryable<EmployeeTrainingPassedEntity> GetDetailPlacementTabJobTrainingemployeme(int employemeid)
        {
            TrainingContext db = new TrainingContext();


            var list = (
                from placementtabjobtrainingdates in db.PlacementTabJobTrainingDates.Where(a => a.Hidden == false)
                join placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.EmployemeId == employemeid && a.Hidden == false)
                on   placementtabjobtrainingdates.PlacementTabJobTrainingDateId equals placementtabjobtrainings.PlacementTabJobTrainingDateId
                join detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings.Where(a => a.Hidden == false) on placementtabjobtrainings.PlacementTabJobTrainingId equals detailplacementtabjobtrainings.PlacementTabJobTrainingId
                select new EmployeeTrainingPassedEntity
                {
                    TrainingCourseName = detailplacementtabjobtrainings.Title,
                    SD = false,
                    OJT = true,
                    C = false,
                    TrainingvenueName = "مرکز پژوهش متالورژی رازی",
                    Duration = detailplacementtabjobtrainings.NumberOfHours,
                    DateCourse = placementtabjobtrainingdates.PTJTDate,
                    //cou = placementtabjobtrainingdates.PTJTDate,
                    //CertificateStateYse = false,
                    //CertificateStateNo = true
                });
            //970807
            //return list;
            return list.OrderBy(a => a.DateCourse);

        }

        public Double SumDuration(int employemeid)
        {
            TrainingContext db = new TrainingContext();
            var SumDuration = db.EmployeeTrainingPasseds.Where(a => a.Employemeid == employemeid && a.Hidden == false)
                    .Sum(a => a.Duration);

            return SumDuration;
        }

        public IQueryable<EmployeeTrainingPassedEntity> GetAllEmployeeTrainingPassed()
        {
            TrainingContext db = new TrainingContext();
            return
                (from employeetrainingpasseds in db.EmployeeTrainingPasseds.Where(a => a.Hidden == false)
                 join trainingcourses in db.TrainingCourses on employeetrainingpasseds.TrainingCourseId equals trainingcourses.TrainingCourseId
                 join tabletypeoftrainings in db.TableTypeOfTrainings on employeetrainingpasseds.TableTypeOfTrainingId equals tabletypeoftrainings.TableTypeOfTrainingId
                 join tableinterfacevalues in db.TableInterfaceValues on employeetrainingpasseds.TrainingVenueId equals tableinterfacevalues.TableInterfaceValueId


                 select new EmployeeTrainingPassedEntity
                 {
                     CertificateState = employeetrainingpasseds.CertificateState,
                     DateCourse = employeetrainingpasseds.DateCourse,
                     Duration = employeetrainingpasseds.Duration,
                     EmployeeTrainingPassedId = employeetrainingpasseds.EmployeeTrainingPassedId,
                     Employemeid = employeetrainingpasseds.Employemeid,
                     TableTypeOfTrainingId = employeetrainingpasseds.TableTypeOfTrainingId,
                     TrainingCourseName = trainingcourses.CourseName,
                     TrainingCourseId = employeetrainingpasseds.TrainingCourseId,
                     TrainingVenueId = employeetrainingpasseds.TrainingVenueId,
                     SD = tabletypeoftrainings.Sd,
                     OJT = tabletypeoftrainings.Ojt,
                     C = tabletypeoftrainings.C,
                     TrainingvenueName = tableinterfacevalues.TableValue
                 });
        }
    }
}
