using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Search.Trianing;

namespace DataAccess.Training
{
    public class OfferTrainingForEmployemeDAC : IOfferTrainingForEmployemeRepository
    {
        public int Add(OfferTrainingForEmployeme Current)
        {
            TrainingContext db = new TrainingContext();
            db.OfferTrainingForEmployemes.Add(Current);
            db.SaveChanges();
            return Current.OfferTrainingForEmployemeId;
        }
        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var offertrainingforemployeme = new OfferTrainingForEmployeme() { OfferTrainingForEmployemeId  = ID, Hidden = true };
                db.OfferTrainingForEmployemes.Attach(offertrainingforemployeme);
                db.Entry(offertrainingforemployeme).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(OfferTrainingForEmployeme Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.OfferTrainingForEmployemes.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.SectionId).IsModified = true;
                db.Entry(Current).Property(x => x.PostGroupId).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
                db.Entry(Current).Property(x => x.DateNeeds).IsModified = true;

                //db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Success = false;
            }
            return Success;
        }
        public OfferTrainingForEmployeme Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.OfferTrainingForEmployemes.SingleOrDefault(x => x.OfferTrainingForEmployemeId == ID);
        }
        public IQueryable<OfferTrainingForEmployeme> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.OfferTrainingForEmployemes select item;
        }

        //public IQueryable<OfferTrainingForEmployemeEntity> GetAll(DetailoffertrainingforemployemeSearch detailoffertrainingforemployemesearch)
        //{
        //    //TrainingContext db = new TrainingContext();
        //    //var query = db.Database.SqlQuery<OfferTrainingForEmployemeEntity>(
        //    //"DetailoffertrainingforemployemeSearch @NeedTraining, @OfferTrainingForEmployeeDateId",
        //    //new System.Data.SqlClient.SqlParameter("NeedTraining", detailoffertrainingforemployemesearch.NeedTraining),
        //    //new System.Data.SqlClient.SqlParameter("OfferTrainingForEmployeeDateId", detailoffertrainingforemployemesearch.OfferTrainingForEmployeeDateId)
        //    //).AsQueryable();
        //    //return query;
        //}
        public IQueryable<OfferTrainingForEmployemeEntity> GetAll(DetailoffertrainingforemployemeSearch detailoffertrainingforemployemesearch)
        { 
            TrainingContext db = new TrainingContext();
            var _query = (
                          from offertrainingforemployeme in db.OfferTrainingForEmployemes.Where(a => a.Hidden == false && a.OfferTrainingForEmployeeDateId == detailoffertrainingforemployemesearch.OfferTrainingForEmployeeDateId)
                          join detailoffertrainingforemployeme in db.DetailOfferTrainingForEmployeme on offertrainingforemployeme.OfferTrainingForEmployemeId equals detailoffertrainingforemployeme.OfferTrainingForEmployemesId
                          join sections in db.Sections on offertrainingforemployeme.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforemployeme.PostGroupId equals postgroups.PostGroupId
                          join employemes in db.Employemes.Where(a => a.Hidden == false) on offertrainingforemployeme.EmployemeId equals employemes.EmployemeId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId

                          select new OfferTrainingForEmployemeEntity
                          {
                              OfferTrainingForEmployeeDateId = offertrainingforemployeme.OfferTrainingForEmployeeDateId,
                              DateNeeds = offertrainingforemployeme.DateNeeds,
                              OfferTrainingForEmployemeId = offertrainingforemployeme.OfferTrainingForEmployemeId,
                              SectionId = offertrainingforemployeme.SectionId,
                              SectionName = sections.Name,
                              PostGroupId = offertrainingforemployeme.PostGroupId,
                              PostTypeId = postgroups.PostTypeId,
                              CollectionId = postgroups.CollectionId,
                              PostTypeName = TableInterfaceValuesPostType.TableValue,
                              CollectionName = tableinterfacevaluesCollection.TableValue,
                              PostGroupName = tableinterfacevaluesCollection.TableValue + " -- " + TableInterfaceValuesPostType.TableValue,
                              UnitSCenterId = tableinterfacevaluesunitcenter.TableInterfaceValueId,
                              UnitSCenterName = tableinterfacevaluesunitcenter.TableValue,
                              DepartmentId = departments.DepartmentId,
                              DepartmentName = departments.Name,
                              EmployemeId = employemes.EmployemeId,
                              EmployemeName = employemes.FirstName + " " + employemes.LastName,
                              NeedTraining = detailoffertrainingforemployeme.NeedTraining,
                          });
            if (detailoffertrainingforemployemesearch.NeedTraining.Trim() != "")
                _query = _query.Where(p => p.NeedTraining.Contains(detailoffertrainingforemployemesearch.NeedTraining));
            return _query;
        }

        public OfferTrainingForEmployemeEntity GetOfferTrainingForEmployeme(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query = (from offertrainingforemployeme in db.OfferTrainingForEmployemes.Where(a => a.Hidden == false && a.OfferTrainingForEmployemeId == ID)
                          join sections in db.Sections on offertrainingforemployeme.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforemployeme.PostGroupId equals postgroups.PostGroupId
                          join employemes in db.Employemes.Where(a => a.Hidden == false) on offertrainingforemployeme.EmployemeId equals employemes.EmployemeId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId

                          select new OfferTrainingForEmployemeEntity
                          {
                              OfferTrainingForEmployeeDateId = offertrainingforemployeme.OfferTrainingForEmployeeDateId,
                              DateNeeds = offertrainingforemployeme.DateNeeds,
                              OfferTrainingForEmployemeId = offertrainingforemployeme.OfferTrainingForEmployemeId,
                              SectionId = offertrainingforemployeme.SectionId,
                              SectionName = sections.Name,
                              PostGroupId = offertrainingforemployeme.PostGroupId,
                              PostTypeId = postgroups.PostTypeId,
                              CollectionId = postgroups.CollectionId,
                              PostTypeName = TableInterfaceValuesPostType.TableValue,
                              CollectionName = tableinterfacevaluesCollection.TableValue,
                              PostGroupName = tableinterfacevaluesCollection.TableValue + " -- " + TableInterfaceValuesPostType.TableValue,
                              UnitSCenterId = tableinterfacevaluesunitcenter.TableInterfaceValueId,
                              UnitSCenterName = tableinterfacevaluesunitcenter.TableValue,
                              DepartmentId = departments.DepartmentId,
                              DepartmentName = departments.Name,
                              EmployemeId = employemes.EmployemeId,
                              EmployemeName = employemes.FirstName + " " + employemes.LastName,

                          });
            return _query.SingleOrDefault();
        }
        public PostReportEmployeme GetPostReport(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query = (from offertrainingforemployemes in db.OfferTrainingForEmployemes.Where(a => a.Hidden == false && a.OfferTrainingForEmployemeId == ID)
                          join sections in db.Sections on offertrainingforemployemes.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforemployemes.PostGroupId equals postgroups.PostGroupId
                          join employemes in db.Employemes.Where(a => a.Hidden == false) on offertrainingforemployemes.EmployemeId equals employemes.EmployemeId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId
                          select new PostReportEmployeme
                          {
                              UnitDepartmentSection = tableinterfacevaluesunitcenter.TableValue + " , " + departments.Name + " , " + sections.Name,
                              DateNeed = offertrainingforemployemes.DateNeeds,
                              Post = tableinterfacevaluesCollection.TableValue + " -- " + TableInterfaceValuesPostType.TableValue,
                              EmployemeName = employemes.FirstName + " " + employemes.LastName,
                              EmployemeId = employemes.EmployemeId ,

                          });
            return _query.SingleOrDefault();
        }

        public PostReportEmployeme GetPostReports(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query = (from offertrainingforemployemes in db.OfferTrainingForEmployemes.Where(a => a.Hidden == false && a.OfferTrainingForEmployemeId == ID)
                          join sections in db.Sections on offertrainingforemployemes.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforemployemes.PostGroupId equals postgroups.PostGroupId
                          join employemes in db.Employemes.Where(a => a.Hidden == false) on offertrainingforemployemes.EmployemeId equals employemes.EmployemeId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId
                          select new PostReportEmployeme
                          {
                              UnitDepartmentSection = tableinterfacevaluesunitcenter.TableValue + " , " + departments.Name + " , " + sections.Name,
                              DateNeed = offertrainingforemployemes.DateNeeds,
                              Post = tableinterfacevaluesCollection.TableValue + " -- " + TableInterfaceValuesPostType.TableValue,
                              EmployemeName = employemes.FirstName + " " + employemes.LastName,

                          });
            return _query.SingleOrDefault();
        }
        public IQueryable<OfferTrainingForEmployemeEntity> GetAllOfferTrainingForEmployeme()
        {
            TrainingContext db = new TrainingContext();
            var _query = (from offertrainingforemployemes in db.OfferTrainingForEmployemes.Where(a => a.Hidden == false)
                          join sections in db.Sections on offertrainingforemployemes.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join employemes in db.Employemes.Where(a => a.Hidden == false) on sections.DepartmentId equals employemes.EmployemeId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforemployemes.PostGroupId equals postgroups.PostGroupId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId

                          select new OfferTrainingForEmployemeEntity
                          {
                              OfferTrainingForEmployeeDateId = offertrainingforemployemes.OfferTrainingForEmployeeDateId,
                              DateNeeds = offertrainingforemployemes.DateNeeds,
                              OfferTrainingForEmployemeId = offertrainingforemployemes.OfferTrainingForEmployemeId,
                              SectionId = offertrainingforemployemes.SectionId,
                              SectionName = sections.Name,
                              PostGroupId = offertrainingforemployemes.PostGroupId,
                              PostTypeId = postgroups.PostTypeId,
                              EmployemeId = offertrainingforemployemes.EmployemeId,
                              EmployemeName = employemes.LastName,
                              CollectionId = postgroups.CollectionId,
                              PostTypeName = TableInterfaceValuesPostType.TableValue,
                              CollectionName = tableinterfacevaluesCollection.TableValue,
                              PostGroupName = tableinterfacevaluesCollection.TableValue + " -- " + TableInterfaceValuesPostType.TableValue,
                              UnitSCenterId = tableinterfacevaluesunitcenter.TableInterfaceValueId,
                              UnitSCenterName = tableinterfacevaluesunitcenter.TableValue,
                              DepartmentId = departments.DepartmentId,
                              DepartmentName = departments.Name

                          });
            return _query;
        }
        public IQueryable<OfferTrainingForEmployemeEntity> GetAllOfferTrainingForEmployeme(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query = (from offertrainingforemployemes in db.OfferTrainingForEmployemes.Where(a => a.Hidden == false && a.OfferTrainingForEmployeeDateId == ID)
                          join sections in db.Sections on offertrainingforemployemes.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforemployemes.PostGroupId equals postgroups.PostGroupId
                          join employemes in db.Employemes.Where(a => a.Hidden == false) on offertrainingforemployemes.EmployemeId equals employemes.EmployemeId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId

                          select new OfferTrainingForEmployemeEntity
                          {
                              OfferTrainingForEmployeeDateId = offertrainingforemployemes.OfferTrainingForEmployeeDateId,
                              DateNeeds = offertrainingforemployemes.DateNeeds,
                              OfferTrainingForEmployemeId = offertrainingforemployemes.OfferTrainingForEmployemeId,
                              SectionId = offertrainingforemployemes.SectionId,
                              SectionName = sections.Name,
                              PostGroupId = offertrainingforemployemes.PostGroupId,
                              PostTypeId = postgroups.PostTypeId,
                              CollectionId = postgroups.CollectionId,
                              PostTypeName = TableInterfaceValuesPostType.TableValue,
                              CollectionName = tableinterfacevaluesCollection.TableValue,
                              PostGroupName = tableinterfacevaluesCollection.TableValue + " -- " + TableInterfaceValuesPostType.TableValue,
                              UnitSCenterId = tableinterfacevaluesunitcenter.TableInterfaceValueId,
                              UnitSCenterName = tableinterfacevaluesunitcenter.TableValue,
                              DepartmentId = departments.DepartmentId,
                              DepartmentName = departments.Name,
                              EmployemeId = employemes.EmployemeId,
                              EmployemeName= employemes.FirstName + " " + employemes.LastName,
                          });
            return _query.OrderBy(a=>a.DepartmentName);
        }

    }
}
