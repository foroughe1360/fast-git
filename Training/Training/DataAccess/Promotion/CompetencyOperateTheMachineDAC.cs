using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InfraStructre;
using DomainModel.Models;


namespace DataAccess
{
    public class CompetencyOperateTheMachineDAC : ICompetencyOperateTheMachineRepository
    {
        public int Add(CompetencyOperateTheMachine Current)
        {
            TrainingContext db = new TrainingContext();
            db.CompetencyOperateTheMachines.Add(Current);
            db.SaveChanges();
            return Current.CompetencyOperateTheMachineId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var competencyOperateTheMachine = new CompetencyOperateTheMachine() { CompetencyOperateTheMachineId = ID, Hidden = true };
                db.CompetencyOperateTheMachines.Attach(competencyOperateTheMachine);
                db.Entry(competencyOperateTheMachine).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();

                //TrainingContext db = new TrainingContext();
                //var accessmenuUser = db.AccessMenuUsers.SingleOrDefault(x => x.AccessMenuUserId == ID);
                //db.AccessMenuUsers.Remove(accessmenuUser);
                //db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(CompetencyOperateTheMachine Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.CompetencyOperateTheMachines.Attach(Current);
                db.Entry(Current).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }
    
        public CompetencyOperateTheMachine Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.CompetencyOperateTheMachines.SingleOrDefault(x => x.CompetencyOperateTheMachineId == ID);
        }

        public IQueryable<CompetencyOperateTheMachine> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.CompetencyOperateTheMachines select item;
       }
    }
}
