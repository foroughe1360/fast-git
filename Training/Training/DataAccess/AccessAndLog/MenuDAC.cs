using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;

namespace DataAccess
{
    public class MenuDAC : IMenuRepository
    {
        public int Add(Menu Current)
        {
            TrainingContext db = new TrainingContext();
            db.Menus.Add(Current);
            db.SaveChanges();
            return Current.MenuId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var menu = new Menu() { MenuId = ID, Hidden = true };
                db.Menus.Attach(menu);
                db.Entry(menu).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(Menu Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Menus.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.Name).IsModified = true;
                db.Entry(Current).Property(x => x.Parent).IsModified = true;
                db.Entry(Current).Property(x => x.Status).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public Menu Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Menus.SingleOrDefault(x => x.MenuId == ID);
        }

        public IQueryable<Menu> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Menus select item;
        }
    }
}
