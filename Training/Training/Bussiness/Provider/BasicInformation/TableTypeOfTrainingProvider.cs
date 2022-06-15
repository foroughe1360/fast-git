using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class TableTypeOfTrainingProvider : ITableTypeOfTrainingProvider
    {
        private TableTypeOfTrainingDAC _TableTypeOfTrainingDAC;
        public TableTypeOfTrainingProvider()
        {
            _TableTypeOfTrainingDAC = new TableTypeOfTrainingDAC();
        }
        public int Add(TableTypeOfTrainingEntity Current)
        {
            TableTypeOfTraining _TableTypeOfTraining = new TableTypeOfTraining(Current.TableId,Current.UsedTableId,Current.C,Current.Sd,Current.Ojt);
            return _TableTypeOfTrainingDAC.Add(_TableTypeOfTraining);
        }

        public bool Delete(int ID)
        {
            return _TableTypeOfTrainingDAC.Delete(ID);
        }

        public bool Edit(TableTypeOfTrainingEntity Current)
        {
            TableTypeOfTraining _TableTypeOfTraining = new TableTypeOfTraining();
            _TableTypeOfTraining.TableTypeOfTrainingId = Current.TableTypeOfTrainingId;
            _TableTypeOfTraining.TimeLastModified= DateTime.Now;
            _TableTypeOfTraining.TableId = Current.TableId;
            _TableTypeOfTraining.UsedTableId = Current.UsedTableId;
            _TableTypeOfTraining.C = Current.C;
            _TableTypeOfTraining.Sd = Current.Sd;
            _TableTypeOfTraining.Ojt = Current.Ojt;
            return _TableTypeOfTrainingDAC.Edit(_TableTypeOfTraining);
        }

        public TableTypeOfTrainingEntity Get(int ID)
        {
            TableTypeOfTrainingEntity _TableTypeOfTrainingEntity = new TableTypeOfTrainingEntity();
            var q = _TableTypeOfTrainingDAC.Get(ID);
            _TableTypeOfTrainingEntity.C = q.C;
            _TableTypeOfTrainingEntity.Ojt = q.Ojt;
            _TableTypeOfTrainingEntity.Sd = q.Sd;
            _TableTypeOfTrainingEntity.TableId = q.TableId;
            _TableTypeOfTrainingEntity.TableTypeOfTrainingId = q.TableTypeOfTrainingId;
            _TableTypeOfTrainingEntity.UsedTableId = q.UsedTableId;
            return _TableTypeOfTrainingEntity; 
        }

        public IQueryable<TableTypeOfTrainingEntity> GetAll()
        {
            var query = _TableTypeOfTrainingDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new TableTypeOfTrainingEntity()
                 {
                     C = q.C,
                     Ojt = q.Ojt,
                     Sd = q.Sd,
                     TableId = q.TableId,
                     TableTypeOfTrainingId = q.TableTypeOfTrainingId,
                     UsedTableId = q.UsedTableId

                 });
            return _query;
        }
    }
}
