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
    public class PointDAC : IPointRepository
    {
        public int Add(Point Current)
        {
            TrainingContext db = new TrainingContext();
            db.Points.Add(Current);
            db.SaveChanges();
            return Current.PointId;
        }

        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var point = new Point() { PointId = ID, Hidden = true };
                db.Points.Attach(point);
                db.Entry(point).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public bool Edit(Point Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Points.Attach(Current);
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.PointName).IsModified = true;
                db.Entry(Current).Property(x => x.NumPoint).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }

        public Point Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Points.SingleOrDefault(x => x.PointId == ID);
        }

        public IQueryable<Point> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Points.Where(a => a.Hidden==false) select item;
        }
    }
}
