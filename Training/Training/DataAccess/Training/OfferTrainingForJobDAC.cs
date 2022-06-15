using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
   public class OfferTrainingForJobDAC : IOfferTrainingForJobRepository
    {
        public int Add(OfferTrainingForJob Current)
        {
            TrainingContext db = new TrainingContext();
            db.OfferTrainingForJobs.Add(Current);
            db.SaveChanges();
            return Current.OfferTrainingForJobId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var offerTrainingForJob = new OfferTrainingForJob() { OfferTrainingForJobId = ID, Hidden = true };
                db.OfferTrainingForJobs.Attach(offerTrainingForJob);
                db.Entry(offerTrainingForJob).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(OfferTrainingForJob Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.OfferTrainingForJobs .Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.SectionId).IsModified = true;
                db.Entry(Current).Property(x => x.PostGroupId).IsModified = true;
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

        public OfferTrainingForJob Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.OfferTrainingForJobs.SingleOrDefault(x => x.OfferTrainingForJobId == ID);
        }


        public IQueryable<OfferTrainingForJob> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.OfferTrainingForJobs select item;
        }

        public OfferTrainingForJobEntity GetOfferTrainingForJob(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query = (from offertrainingforjob in db.OfferTrainingForJobs.Where(a => a.Hidden == false && a.OfferTrainingForJobId == ID)
                          join sections in db.Sections on offertrainingforjob.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforjob.PostGroupId equals postgroups.PostGroupId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId

                          select new OfferTrainingForJobEntity
                          {
                              OfferTrainingForJobDateId = offertrainingforjob.OfferTrainingForJobDateId,
                              DateNeeds = offertrainingforjob.DateNeeds,
                              OfferTrainingForJobId = offertrainingforjob.OfferTrainingForJobId,
                              SectionId = offertrainingforjob.SectionId,
                              SectionName = sections.Name,
                              PostGroupId = offertrainingforjob.PostGroupId,
                              PostTypeId = postgroups.PostTypeId,
                              CollectionId = postgroups.CollectionId,
                              PostTypeName = TableInterfaceValuesPostType.TableValue,
                              CollectionName = tableinterfacevaluesCollection.TableValue,
                              PostGroupName = tableinterfacevaluesCollection.TableValue + " -- " + TableInterfaceValuesPostType.TableValue,
                              UnitSCenterId = tableinterfacevaluesunitcenter.TableInterfaceValueId,
                              UnitSCenterName = tableinterfacevaluesunitcenter.TableValue,
                              DepartmentId = departments.DepartmentId,
                              DepartmentName = departments.Name

                          });
            return _query.SingleOrDefault();
        }

        public PostReport GetPostReport(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query = (from offertrainingforjob in db.OfferTrainingForJobs.Where(a => a.Hidden == false && a.OfferTrainingForJobId == ID)
                          join sections in db.Sections on offertrainingforjob.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforjob.PostGroupId equals postgroups.PostGroupId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId
                          select new PostReport
                          {
                              UnitDepartmentSection = tableinterfacevaluesunitcenter.TableValue + " , " + departments.Name + " , "
                                                        + sections.Name,
                              DateNeed= offertrainingforjob.DateNeeds,
                              Post = tableinterfacevaluesCollection.TableValue + " -- " + TableInterfaceValuesPostType.TableValue,
                              
                          });
            return _query.SingleOrDefault();
        }

        public IQueryable<OfferTrainingForJobEntity> GetAllOfferTrainingForJob()
        {
            TrainingContext db = new TrainingContext();
            var _query = (from offertrainingforjob in db.OfferTrainingForJobs.Where(a => a.Hidden == false)
                          join sections in db.Sections on offertrainingforjob.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforjob.PostGroupId equals postgroups.PostGroupId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId

                          select new OfferTrainingForJobEntity
                          {
                              OfferTrainingForJobDateId= offertrainingforjob.OfferTrainingForJobDateId,
                              DateNeeds = offertrainingforjob.DateNeeds,
                              OfferTrainingForJobId = offertrainingforjob.OfferTrainingForJobId,
                              SectionId = offertrainingforjob.SectionId,
                              SectionName = sections.Name,
                              PostGroupId = offertrainingforjob.PostGroupId,
                              PostTypeId = postgroups.PostTypeId,
                              CollectionId = postgroups.CollectionId,
                              PostTypeName = TableInterfaceValuesPostType.TableValue,
                              CollectionName = tableinterfacevaluesCollection.TableValue,
                              PostGroupName = tableinterfacevaluesCollection.TableValue + " -- " + TableInterfaceValuesPostType.TableValue,
                              UnitSCenterId= tableinterfacevaluesunitcenter.TableInterfaceValueId,
                              UnitSCenterName= tableinterfacevaluesunitcenter.TableValue,
                              DepartmentId=departments.DepartmentId,
                              DepartmentName=departments.Name

                          });
            return _query;
        }

        public IQueryable<OfferTrainingForJobEntity> GetAllOfferTrainingForJob(int ID)
        {
            TrainingContext db = new TrainingContext();
            var _query = (from offertrainingforjob in db.OfferTrainingForJobs.Where(a => a.Hidden == false && a.OfferTrainingForJobDateId==ID)
                          join sections in db.Sections on offertrainingforjob.SectionId equals sections.SectionId
                          join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                          join tableinterfacevaluesunitcenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesunitcenter.TableInterfaceValueId
                          join postgroups in db.PostGroups on offertrainingforjob.PostGroupId equals postgroups.PostGroupId
                          join tableinterfacevaluesCollection in db.TableInterfaceValues on postgroups.CollectionId equals tableinterfacevaluesCollection.TableInterfaceValueId
                          join TableInterfaceValuesPostType in db.TableInterfaceValues on postgroups.PostTypeId equals TableInterfaceValuesPostType.TableInterfaceValueId

                          select new OfferTrainingForJobEntity
                          {
                              OfferTrainingForJobDateId = offertrainingforjob.OfferTrainingForJobDateId,
                              DateNeeds = offertrainingforjob.DateNeeds,
                              OfferTrainingForJobId = offertrainingforjob.OfferTrainingForJobId,
                              SectionId = offertrainingforjob.SectionId,
                              SectionName = sections.Name,
                              PostGroupId = offertrainingforjob.PostGroupId,
                              PostTypeId = postgroups.PostTypeId,
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
    }
}
