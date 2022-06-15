using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Models;
using InterfaceEntity;

namespace DataAccess
{
    public class EmployemeSignaturyDAC : IEmployemeSignaturyRepository
    {
        public int Add(EmployemeSignatury Current)
        {
            TrainingContext db = new TrainingContext();
            db.EmployemeSignaturies.Add(Current);
            db.SaveChanges();
            return Current.EmployemeSignaturyId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var employemesignatury = new EmployemeSignatury() { EmployemeSignaturyId = ID, Hidden = true };
                db.EmployemeSignaturies.Attach(employemesignatury);
                db.Entry(employemesignatury).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(EmployemeSignatury Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.EmployemeSignaturies.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.SideSignatoryId).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
                db.Entry(Current).Property(x => x.EmployemeSignaturyDate).IsModified = true;
                db.Entry(Current).Property(x => x.State).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public EmployemeSignatury Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.EmployemeSignaturies.SingleOrDefault(x => x.EmployemeSignaturyId == ID);
        }

        public IQueryable<EmployemeSignatury> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.EmployemeSignaturies select item;
        }

        public IQueryable<EmployemeSignaturyEntity> GetAllEmployemeSignatury(int sidesignatoryid)
        {
            TrainingContext db = new TrainingContext();
            return
                from employemesignaturies in db.EmployemeSignaturies.Where(a => a.SideSignatoryId == sidesignatoryid && a.Hidden == false)
                join sidesignatories in db.SideSignatories on employemesignaturies.SideSignatoryId equals sidesignatories.SideSignatoryId
                join employemes in db.Employemes on employemesignaturies.EmployemeId equals employemes.EmployemeId
                select new EmployemeSignaturyEntity
                {
                    EmployemeSignaturyId = employemesignaturies.EmployemeSignaturyId,
                    SideSignatoryId = employemesignaturies.SideSignatoryId,
                    EmployemeId = employemesignaturies.EmployemeId,
                    EmployemeSignaturyDate = employemesignaturies.EmployemeSignaturyDate,
                    StateStr = (employemesignaturies.State == true ? "فعال" : "غیرفعال")
                    , Specifications = employemes.FirstName + " " + employemes.LastName
                };
        }

        public IQueryable<EmployemeSignaturyEntity> GetListEmployemeSignatury()
        {
            TrainingContext db = new TrainingContext();

            EmployemeSignatury _EmployemeSignatury = new EmployemeSignatury();
            var qqq = from s in db.EmployemeSignaturies.Where(a => a.Hidden == false)
                      group s by s.SideSignatoryId into g
                      select new { SideSignatoryId = g.Key };

            return
                (from list in qqq
                 join employemesignaturies in db.EmployemeSignaturies.Where(a => a.State) on list.SideSignatoryId equals employemesignaturies.SideSignatoryId
                 join sidesignatories in db.SideSignatories on employemesignaturies.SideSignatoryId equals sidesignatories.SideSignatoryId
                 join signatureresponsibilities in db.SignatureResponsibilities on employemesignaturies.EmployemeId equals signatureresponsibilities.EmployemeId
                 join employemes in db.Employemes on employemesignaturies.EmployemeId equals employemes.EmployemeId
                 select new EmployemeSignaturyEntity
                 {
                     EmployemeSignaturyId = employemesignaturies.EmployemeSignaturyId,
                     SideSignatoryId = employemesignaturies.SideSignatoryId,
                     EmployemeSignaturyDate = employemesignaturies.EmployemeSignaturyDate,
                     State = employemesignaturies.State,
                     Specifications = employemes.FirstName + " " + employemes.LastName,
                     SideSignatoryCode = sidesignatories.SideSignatoryCode,
                     EmployemeId = employemes.EmployemeId,
                     Signature = signatureresponsibilities.Signature
                 });
        }

        public List<EmployemeSignaturyEntity> GetEmployemeMangerSignatury(int EmployemeId)
        {
            TrainingContext db = new TrainingContext();
            //var query = from customer in clist
            //            from order in olist
            //                .Where(o => o.CustomerID == customer.CustomerID &&
            //                            o.OrderDate == olist
            //                                .Where(o => o.CustomerID == customer.CustomerID)
            //                                .Select(o => o.OrderDate).Max())
            //            select new
            //            {
            //                customer.CustomerID,
            //                customer.Name,
            //                customer.Address,
            //                Product = order != null ? order.Product : string.Empty
            //            };
            /*
                        var MangerSignatury = (

                              from placementtabjobtrainingdates in db.PlacementTabJobTrainingDates.Where(a => a.Hidden == false)
                              from placementtabjobtrainings in db.PlacementTabJobTrainings
                             .Where(p => p.PlacementTabJobTrainingDateId == placementtabjobtrainingdates.PlacementTabJobTrainingDateId
                             && p.EmployemeId == EmployemeId
                             && placementtabjobtrainingdates.PTJTDate == db.PlacementTabJobTrainingDates
                             .Where(pt => pt.PlacementTabJobTrainingDateId == placementtabjobtrainingdates.PlacementTabJobTrainingDateId)
                             .Select(pt => pt.PTJTDate).Max()
                             //&& placementtabjobtrainingdates.PTJTDate == db.PlacementTabJobTrainingDates.Max(pt => pt.PTJTDate)
                                )

                              join supervisors in db.Supervisors on placementtabjobtrainings.CorporateResponsibility equals supervisors.SupervisorId
                              join employemes in db.Employemes on supervisors.EmployemeId equals employemes.EmployemeId
                              join signatureresponsibilities in db.SignatureResponsibilities on supervisors.EmployemeId equals signatureresponsibilities.EmployemeId
                              select new EmployemeSignaturyEntity
                              {
                                  Specifications = employemes.FirstName + " " + employemes.LastName,
                                  EmployemeId = employemes.EmployemeId,
                                  Signature = signatureresponsibilities.Signature,
                              });
                              */

            var MangerSignatury = db.Database.SqlQuery<EmployemeSignaturyEntity>(
            "GetSignature @EmployemeId",
            new System.Data.SqlClient.SqlParameter("EmployemeId", EmployemeId)
            ).ToList();

            return MangerSignatury;
        }




    }
}


