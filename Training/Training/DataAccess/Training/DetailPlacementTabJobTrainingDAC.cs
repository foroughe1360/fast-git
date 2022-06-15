using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Report;

namespace DataAccess
{
    //Repository:
    //بین دو لایه می باشد DACو Bussiness
    public class DetailPlacementTabJobTrainingDAC : IDetailPlacementTabJobTrainingRepository
    {
        public int Add(DetailPlacementTabJobTraining Current)
        {
            TrainingContext db = new TrainingContext();
            db.DetailPlacementTabJobTrainings.Add(Current);
            db.SaveChanges();
            return Current.DetailPlacementTabJobTrainingId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var detailplacementtabjobtraining = new DetailPlacementTabJobTraining() { DetailPlacementTabJobTrainingId = ID, Hidden = true };
                db.DetailPlacementTabJobTrainings.Attach(detailplacementtabjobtraining);
                db.Entry(detailplacementtabjobtraining).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(DetailPlacementTabJobTraining Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.DetailPlacementTabJobTrainings.Attach(Current);
                db.Entry(Current).Property(x => x.DetailPlacementTabJobTrainingId).IsModified = true;
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.PlacementTabJobTrainingId).IsModified = true;
                db.Entry(Current).Property(x => x.Title).IsModified = true;
                db.Entry(Current).Property(x => x.FinalComment).IsModified = true;
                db.Entry(Current).Property(x => x.NumberOfHours).IsModified = true;
                db.Entry(Current).Property(x => x.OJTLevelId).IsModified = true;

                //db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public DetailPlacementTabJobTraining Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.DetailPlacementTabJobTrainings.SingleOrDefault(x => x.DetailPlacementTabJobTrainingId == ID);
        }

        public IQueryable<DetailPlacementTabJobTraining> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.DetailPlacementTabJobTrainings select item;
        }

        public IQueryable<DetailPlacementTabJobTrainingEntity> GetAllDetailPlacementTabJobTraining(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                 (
                 from detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings.Where(a => a.Hidden == false && a.PlacementTabJobTrainingId == ID)
                     //join placementtabjobtrainings in db.PlacementTabJobTrainings on detailplacementtabjobtrainings.PlacementTabJobTrainingId equals placementtabjobtrainings.PlacementTabJobTrainingId
                 join placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.Hidden == false) on detailplacementtabjobtrainings.PlacementTabJobTrainingId equals placementtabjobtrainings.PlacementTabJobTrainingId
                 join ojtlevelIds in db.OJTLevels on detailplacementtabjobtrainings.OJTLevelId equals ojtlevelIds.OJTLevelId

                 select new DetailPlacementTabJobTrainingEntity
                 {
                     DetailPlacementTabJobTrainingId = detailplacementtabjobtrainings.DetailPlacementTabJobTrainingId,
                     OJTLevelId = detailplacementtabjobtrainings.OJTLevelId,
                     OJTLevelName = ojtlevelIds.LevelNumber,
                     OJTLevelDescription = ojtlevelIds.Description,
                     PlacementTabJobTrainingId = placementtabjobtrainings.PlacementTabJobTrainingId,
                     Title = detailplacementtabjobtrainings.Title,
                     NumberOfHours = detailplacementtabjobtrainings.NumberOfHours,
                     FinalComment = detailplacementtabjobtrainings.FinalComment,
                     TimeCreated = detailplacementtabjobtrainings.TimeCreated
                 }
                );
            //970230
            return _query.OrderBy(a => a.TimeCreated);
        }

        public IQueryable<PlacementTabJobTrainingReport> GetAllDetailPlacementTabJobTrainingReport(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query =
                 (
                 from detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings.Where(a => a.Hidden == false && a.PlacementTabJobTrainingId == ID)
                 join placementtabjobtrainings in db.PlacementTabJobTrainings on detailplacementtabjobtrainings.PlacementTabJobTrainingId equals placementtabjobtrainings.PlacementTabJobTrainingId
                 join ojtlevelIds in db.OJTLevels on detailplacementtabjobtrainings.OJTLevelId equals ojtlevelIds.OJTLevelId

                 select new PlacementTabJobTrainingReport
                 {
                     OJTLevelName = detailplacementtabjobtrainings.Title,
                     NumberOfHours = detailplacementtabjobtrainings.NumberOfHours,
                     FinalComment = detailplacementtabjobtrainings.FinalComment,
                     OJTLevel1 = (detailplacementtabjobtrainings.OJTLevelId == 1 ? true : false),
                     OJTLevel2 = (detailplacementtabjobtrainings.OJTLevelId == 2 ? true : false),
                     OJTLevel3 = (detailplacementtabjobtrainings.OJTLevelId == 3 ? true : false),
                     OJTLevel4 = (detailplacementtabjobtrainings.OJTLevelId == 4 ? true : false),
                     OJTLevel5 = (detailplacementtabjobtrainings.OJTLevelId == 5 ? true : false),
                 });
            return _query;
        }

        public IQueryable<DetailPlacementTabJobTrainingEntity> GetAllDetailPlacementTabJobTraining(int sourceid, int destinationid)
        {
            TrainingContext db = new TrainingContext();

            var lisplacementtabjobtrainingsdestination = db.PlacementTabJobTrainings.Where(a => a.PlacementTabJobTrainingDateId == destinationid && a.Hidden == false);

            var listdetailplacementtabjobtrainingssource = (
                            //970230
                            //from detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings
                            from detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings.Where(a => a.Hidden == false)
                                //join placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.PlacementTabJobTrainingDateId == sourceid)
                            join placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.PlacementTabJobTrainingDateId == sourceid && a.Hidden == false)
                            on detailplacementtabjobtrainings.PlacementTabJobTrainingId equals placementtabjobtrainings.PlacementTabJobTrainingId
                            select new
                            {
                                DetailPlacementTabJobTrainingId = detailplacementtabjobtrainings.DetailPlacementTabJobTrainingId,
                                PlacementTabJobTrainingId = placementtabjobtrainings.PlacementTabJobTrainingId,
                                Title = detailplacementtabjobtrainings.Title,
                                FinalComment = detailplacementtabjobtrainings.FinalComment,
                                NumberOfHours = detailplacementtabjobtrainings.NumberOfHours,
                                OJTLevelId = detailplacementtabjobtrainings.OJTLevelId,
                                EmployemeId = placementtabjobtrainings.EmployemeId
                            });

            var listdetailplacementtabjobtrainingsdestination =
                        from lptjtd in lisplacementtabjobtrainingsdestination
                        join ldptjts in listdetailplacementtabjobtrainingssource on lptjtd.EmployemeId equals ldptjts.EmployemeId
                        select new DetailPlacementTabJobTrainingEntity
                        {
                            PlacementTabJobTrainingId = lptjtd.PlacementTabJobTrainingId,
                            Title = ldptjts.Title,
                            FinalComment = ldptjts.FinalComment,
                            NumberOfHours = ldptjts.NumberOfHours,
                            OJTLevelId = ldptjts.OJTLevelId
                        };

            var list =
                        (from ldptjtd in listdetailplacementtabjobtrainingsdestination
                             //join detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings
                         join detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings.Where(a => a.Hidden == false)
                         on ldptjtd.PlacementTabJobTrainingId equals detailplacementtabjobtrainings.PlacementTabJobTrainingId
                         into Temp
                         from temp in Temp.DefaultIfEmpty()
                         select new DetailPlacementTabJobTrainingEntity
                         {
                             PlacementTabJobTrainingId = (temp.PlacementTabJobTrainingId == null ? ldptjtd.PlacementTabJobTrainingId : 0),
                             Title = (temp.PlacementTabJobTrainingId == null ? ldptjtd.Title : ""),
                             FinalComment = (temp.PlacementTabJobTrainingId == null ? ldptjtd.FinalComment : ""),
                             NumberOfHours = (temp.PlacementTabJobTrainingId == null ? ldptjtd.NumberOfHours : 0),
                             OJTLevelId = (temp.PlacementTabJobTrainingId == null ? ldptjtd.OJTLevelId : 0)
                         });
            return list.Where(a => a.PlacementTabJobTrainingId != 0);
        }

        public IQueryable<EmployeeTrainingPassedReport> GetDetailPlacementTabJobTrainingemployeme(int employemeid)
        {
            TrainingContext db = new TrainingContext();

            #region Report Bar Asase Akharin Tarihk Sabt shode
            //var maxplacementtabjobtrainingdate = (
            //    from PlacementTabJobTrainingDates in db.PlacementTabJobTrainingDates
            //    orderby PlacementTabJobTrainingDates.PTJTDate descending
            //    select new
            //    {
            //        PlacementTabJobTrainingDateId = PlacementTabJobTrainingDates.PlacementTabJobTrainingDateId,
            //        PTJTDate = PlacementTabJobTrainingDates.PTJTDate
            //    }).Take(1).Single();

            //var list = (
            //    from placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.PlacementTabJobTrainingDateId == maxplacementtabjobtrainingdate.PlacementTabJobTrainingDateId && a.EmployemeId == employemeid)
            //    join detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings on placementtabjobtrainings.PlacementTabJobTrainingId equals detailplacementtabjobtrainings.PlacementTabJobTrainingId
            //    select new EmployeeTrainingPassedReport
            //    {
            //        TrainingCourseName = detailplacementtabjobtrainings.Title,
            //        SD = false,
            //        OJT = true,
            //        C = false,
            //        trainingvenueName = "مرکز پژوهش متالورژی رازی",
            //        Duration = detailplacementtabjobtrainings.NumberOfHours,
            //        DateCourseDateTime = maxplacementtabjobtrainingdate.PTJTDate,
            //        CertificateStateYse = false,
            //        CertificateStateNo = true
            //    });
            #endregion

            var list = (
                from placementtabjobtrainingdates in db.PlacementTabJobTrainingDates.Where(a => a.Hidden == false)
                join placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.EmployemeId == employemeid && a.Hidden == false)
                on placementtabjobtrainingdates.PlacementTabJobTrainingDateId equals placementtabjobtrainings.PlacementTabJobTrainingDateId
                join detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings.Where(a => a.Hidden == false) on placementtabjobtrainings.PlacementTabJobTrainingId equals detailplacementtabjobtrainings.PlacementTabJobTrainingId
                select new EmployeeTrainingPassedReport
                {
                    TrainingCourseName = detailplacementtabjobtrainings.Title,
                    SD = false,
                    OJT = true,
                    C = false,
                    TrainingvenueName = "مرکز پژوهش متالورژی رازی",
                    Duration = detailplacementtabjobtrainings.NumberOfHours,
                    DateCourseDateTime = placementtabjobtrainingdates.PTJTDate,
                    CertificateStateYse = false,
                    CertificateStateNo = true
                });
            //970807
            //return list;
            return list.OrderBy(a => a.DateCourseDateTime);

        }
      
    }
}
