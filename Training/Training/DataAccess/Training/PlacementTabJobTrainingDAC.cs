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
    public class PlacementTabJobTrainingDAC : IPlacementTabJobTrainingRepository
    {
        public int Add(PlacementTabJobTraining Current)
        {
            TrainingContext db1 = new TrainingContext();
            db1.PlacementTabJobTrainings.Add(Current);
            db1.SaveChanges();
            return Current.PlacementTabJobTrainingId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var placementtabJobtraining = new PlacementTabJobTraining() { PlacementTabJobTrainingId = ID, Hidden = true };
                db.PlacementTabJobTrainings.Attach(placementtabJobtraining);
                db.Entry(placementtabJobtraining).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(PlacementTabJobTraining Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.PlacementTabJobTrainings.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
                db.Entry(Current).Property(x => x.SectionId).IsModified = true;
                db.Entry(Current).Property(x => x.PostGroupId).IsModified = true;
                db.Entry(Current).Property(x => x.DateStartPostGroupName).IsModified = true;
                db.Entry(Current).Property(x => x.PreviousJobs).IsModified = true;
                db.Entry(Current).Property(x => x.CorporateResponsibility).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public PlacementTabJobTraining Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.PlacementTabJobTrainings.SingleOrDefault(x => x.PlacementTabJobTrainingId == ID);
        }

        public PlacementTabJobTrainingEntity GetPlacementTabJobTraining(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (
                from placementtabjobtrainings in db.PlacementTabJobTrainings.Where(x => x.PlacementTabJobTrainingId == ID)
                join sections in db.Sections on placementtabjobtrainings.SectionId equals sections.SectionId
                join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                join TableInterfaceValuesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals TableInterfaceValuesUnitSCenter.TableInterfaceValueId
                join PostGroups in db.PostGroups on placementtabjobtrainings.PostGroupId equals PostGroups.PostGroupId
                join tableinterfacevaluesPostType in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevaluesPostType.TableInterfaceValueId
                select new PlacementTabJobTrainingEntity
                {
                    PlacementTabJobTrainingId = placementtabjobtrainings.PlacementTabJobTrainingId,
                    PlacementTabJobTrainingDateId = placementtabjobtrainings.PlacementTabJobTrainingDateId,
                    EmployemeId = placementtabjobtrainings.EmployemeId,
                    UnitSCenterId = TableInterfaceValuesUnitSCenter.TableInterfaceValueId,
                    UnitSCenterName = TableInterfaceValuesUnitSCenter.TableValue,
                    DepartmentId = departments.DepartmentId,
                    DepartmentName = departments.Name,
                    PostGroupId = placementtabjobtrainings.PostGroupId,
                    CurrentPostGroupName = tableinterfacevaluesPostType.TableValue,
                    SectionId = placementtabjobtrainings.SectionId,
                    SectionName = sections.Name,
                    DateStartPostGroupName = placementtabjobtrainings.DateStartPostGroupName,
                    PreviousJobs = placementtabjobtrainings.PreviousJobs,
                    CorporateResponsibility = placementtabjobtrainings.CorporateResponsibility
                }).SingleOrDefault();
        }

        public IQueryable<PlacementTabJobTraining> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.PlacementTabJobTrainings select item;
        }

        public IQueryable<PlacementTabJobTrainingEntity> GetAllPlacementTabJobTraining(int ID)
        {
            TrainingContext db = new TrainingContext();
            var placementtabjobtrainingList =

                (from placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.Hidden == false && a.PlacementTabJobTrainingDateId == ID)
                 join employemes in db.Employemes on placementtabjobtrainings.EmployemeId equals employemes.EmployemeId
                 join postgroups in db.PostGroups on placementtabjobtrainings.PostGroupId equals postgroups.PostGroupId
                 join sections in db.Sections on placementtabjobtrainings.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 join tableinterfacevaluesPostGroup in db.TableInterfaceValues on postgroups.PostTypeId equals tableinterfacevaluesPostGroup.TableInterfaceValueId

                 orderby departments.Name
                 select new
                 {
                     PlacementTabJobTrainingId = placementtabjobtrainings.PlacementTabJobTrainingId,
                     PlacementTabJobTrainingDateId = placementtabjobtrainings.PlacementTabJobTrainingDateId,
                     EmployemeId = placementtabjobtrainings.EmployemeId,
                     EmployemeName = employemes.FirstName + " " + employemes.LastName,
                     UnitDepartmentSection = tableinterfacevaluesUnitSCenter.TableValue + " - " + departments.Name + " - " + sections.Name,
                     CurrentPostGroupName = tableinterfacevaluesPostGroup.TableValue,
                     DateOfEmployement = employemes.DateOfEmployement,
                     DateStartPostGroupName = placementtabjobtrainings.DateStartPostGroupName,
                     UnitSCenterId = tableinterfacevaluesUnitSCenter.TableInterfaceId,
                     DepartmentId = departments.DepartmentId,
                     PreviousJobs = placementtabjobtrainings.PreviousJobs,
                     CorporateResponsibility = placementtabjobtrainings.CorporateResponsibility,
                 });
            //return placementtabjobtrainingList;

            //1400 06 13
            var detailplacementtabjobtrainingList =
                  from detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings.Where(a => a.Hidden == false)
                  join placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.Hidden == false && a.PlacementTabJobTrainingDateId == ID)
                  on detailplacementtabjobtrainings.PlacementTabJobTrainingId equals placementtabjobtrainings.PlacementTabJobTrainingId
                  join ojtlevelIds in db.OJTLevels on detailplacementtabjobtrainings.OJTLevelId equals ojtlevelIds.OJTLevelId
                  group detailplacementtabjobtrainings by detailplacementtabjobtrainings.PlacementTabJobTrainingId into detailplacementtabjobtrainingsGroup
                  select new
                  {
                      PlacementTabJobTrainingId = detailplacementtabjobtrainingsGroup.Key,
                      NumberOfHours = detailplacementtabjobtrainingsGroup.Sum(x => x.NumberOfHours)
                  };

            var _query =
               from p in placementtabjobtrainingList
               join d in detailplacementtabjobtrainingList on p.PlacementTabJobTrainingId equals d.PlacementTabJobTrainingId
               into Temp
               from temp in Temp.DefaultIfEmpty()
               select new PlacementTabJobTrainingEntity
               {
                   PlacementTabJobTrainingId = p.PlacementTabJobTrainingId,
                   PlacementTabJobTrainingDateId = p.PlacementTabJobTrainingDateId,
                   EmployemeId = p.EmployemeId,
                   EmployemeName = p.EmployemeName,
                   UnitDepartmentSection = p.UnitDepartmentSection,
                   CurrentPostGroupName = p.CurrentPostGroupName,
                   DateOfEmployement = p.DateOfEmployement,
                   DateStartPostGroupName = p.DateStartPostGroupName,
                   UnitSCenterId = p.UnitSCenterId,
                   DepartmentId = p.DepartmentId,
                   PreviousJobs = p.PreviousJobs,
                   CorporateResponsibility = p.CorporateResponsibility,
                   SumNumberOfHours = (temp.NumberOfHours == 0 ? 0 : temp.NumberOfHours),
               };

            return _query;
        }

        public IQueryable<PlacementTabJobTrainingEntity> GetAllPlacementTabJobTraining(int sourceid, int destinationid)
        {
            TrainingContext db = new TrainingContext();
            var listplacementtabjobtrainingssource = db.PlacementTabJobTrainings.Where(a => a.PlacementTabJobTrainingDateId == sourceid && a.Hidden == false);

            var listplacementtabjobtrainingsdestination = db.PlacementTabJobTrainings.Where(a => a.PlacementTabJobTrainingDateId == destinationid && a.Hidden == false);

            var list = (from lptjts in listplacementtabjobtrainingssource
                        join lptjtd in listplacementtabjobtrainingsdestination on lptjts.EmployemeId equals lptjtd.EmployemeId
                        into Temp
                        from temp in Temp.DefaultIfEmpty()
                        select new PlacementTabJobTrainingEntity
                        {
                            PlacementTabJobTrainingDateId = (temp == null ? destinationid : 0),
                            EmployemeId = (temp == null ? lptjts.EmployemeId : 0),
                            SectionId = (temp == null ? lptjts.SectionId : 0),
                            PostGroupId = (temp == null ? lptjts.PostGroupId : 0),
                            DateStartPostGroupName = (temp == null ? lptjts.DateStartPostGroupName : DateTime.Now),
                            PreviousJobs = (temp == null ? lptjts.PreviousJobs : ""),
                        });
            return list.Where(a => a.EmployemeId != 0);
        }

        public bool CopyDataPlacementTabJob(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();

                var query = db.Database.SqlQuery<PlacementTabJobTrainingEntity>(
                "PlacementTabJobCopyRow @CurrentPlacementTabJobTrainingId",
                new System.Data.SqlClient.SqlParameter("CurrentPlacementTabJobTrainingId", ID)
                ).ToList();
                return true;
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public IQueryable<PlacementTabJobTrainingEntity> GetAll(PlacementTabJobTrainingSearch placementtabjobtrainingsearch, int ID)
        {
            TrainingContext db = new TrainingContext();
            var placementtabjobtrainingList =

                (from placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.Hidden == false && a.PlacementTabJobTrainingDateId == ID)
                 join employemes in db.Employemes on placementtabjobtrainings.EmployemeId equals employemes.EmployemeId
                 join postgroups in db.PostGroups on placementtabjobtrainings.PostGroupId equals postgroups.PostGroupId
                 join sections in db.Sections on placementtabjobtrainings.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 join tableinterfacevaluesPostGroup in db.TableInterfaceValues on postgroups.PostTypeId equals tableinterfacevaluesPostGroup.TableInterfaceValueId

                 orderby departments.Name
                 select new
                 {
                     PlacementTabJobTrainingId = placementtabjobtrainings.PlacementTabJobTrainingId,
                     PlacementTabJobTrainingDateId = placementtabjobtrainings.PlacementTabJobTrainingDateId,
                     EmployemeId = placementtabjobtrainings.EmployemeId,
                     EmployemeName = employemes.FirstName + " " + employemes.LastName,
                     UnitDepartmentSection = tableinterfacevaluesUnitSCenter.TableValue + " - " + departments.Name + " - " + sections.Name,
                     CurrentPostGroupName = tableinterfacevaluesPostGroup.TableValue,
                     DateOfEmployement = employemes.DateOfEmployement,
                     DateStartPostGroupName = placementtabjobtrainings.DateStartPostGroupName,
                     UnitSCenterId = departments.UnitSCenterId, //tableinterfacevaluesUnitSCenter.TableInterfaceValueId,
                     departmentId = departments.DepartmentId,
                     PreviousJobs = placementtabjobtrainings.PreviousJobs,
                     CorporateResponsibility = placementtabjobtrainings.CorporateResponsibility,
                 });
            //return placementtabjobtrainingList;

            //1400 06 13
            var detailplacementtabjobtrainingList =
                  from detailplacementtabjobtrainings in db.DetailPlacementTabJobTrainings.Where(a => a.Hidden == false)
                  join placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.Hidden == false && a.PlacementTabJobTrainingDateId == ID)
                  on detailplacementtabjobtrainings.PlacementTabJobTrainingId equals placementtabjobtrainings.PlacementTabJobTrainingId
                  join ojtlevelIds in db.OJTLevels on detailplacementtabjobtrainings.OJTLevelId equals ojtlevelIds.OJTLevelId
                  group detailplacementtabjobtrainings by detailplacementtabjobtrainings.PlacementTabJobTrainingId into detailplacementtabjobtrainingsGroup
                  select new
                  {
                      PlacementTabJobTrainingId = detailplacementtabjobtrainingsGroup.Key,
                      NumberOfHours = detailplacementtabjobtrainingsGroup.Sum(x => x.NumberOfHours)
                  };

            var list =
               from p in placementtabjobtrainingList
               join d in detailplacementtabjobtrainingList on p.PlacementTabJobTrainingId equals d.PlacementTabJobTrainingId
               into Temp
               from temp in Temp.DefaultIfEmpty()
               select new PlacementTabJobTrainingEntity
               {
                   PlacementTabJobTrainingId = p.PlacementTabJobTrainingId,
                   PlacementTabJobTrainingDateId = p.PlacementTabJobTrainingDateId,
                   EmployemeId = p.EmployemeId,
                   EmployemeName = p.EmployemeName,
                   UnitDepartmentSection = p.UnitDepartmentSection,
                   CurrentPostGroupName = p.CurrentPostGroupName,
                   DateOfEmployement = p.DateOfEmployement,
                   DateStartPostGroupName = p.DateStartPostGroupName,
                   UnitSCenterId = p.UnitSCenterId,
                   DepartmentId = p.departmentId,
                   PreviousJobs = p.PreviousJobs,
                   CorporateResponsibility = p.CorporateResponsibility,
                   SumNumberOfHours = (temp.NumberOfHours == 0 ? 0 : temp.NumberOfHours),
               };

            if (placementtabjobtrainingsearch.EmployemeName.Trim() != "")
                list = list.Where(p => p.EmployemeName.Contains(placementtabjobtrainingsearch.EmployemeName));

            if (placementtabjobtrainingsearch.UnitSCenterId != 0)
                list = list.Where(p => p.UnitSCenterId == placementtabjobtrainingsearch.UnitSCenterId);

            if (placementtabjobtrainingsearch.DepartmentId != 0)
                list = list.Where(p => p.DepartmentId == placementtabjobtrainingsearch.DepartmentId);

            return list.OrderBy(a => a.DateOfEmployement);
        }



    }
}
