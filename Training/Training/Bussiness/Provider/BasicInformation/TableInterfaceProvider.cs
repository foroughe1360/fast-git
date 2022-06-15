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
    public class TableInterfaceProvider : ITableInterfaceProvider
    {
        private TableInterfaceDAC _TableInterfaceDAC;
        public TableInterfaceProvider()
        {
            _TableInterfaceDAC = new TableInterfaceDAC();
        }

        public int Add(TableInterfaceEntity Current)
        {
            //بعد از بررسی شرایط ها به سمت لایه دیتا ارسال می شود

            TableInterface _TableInterface = new TableInterface(Current.TableName,Current.TableNameFarsi);
            return _TableInterfaceDAC.Add(_TableInterface);
        }

        public bool Delete(int ID)
        {
            return _TableInterfaceDAC.Delete(ID);
        }

        public bool Edit(TableInterfaceEntity Current)
        {
            TableInterface _TableInterface = new TableInterface();
            _TableInterface.TableInterfaceId = Current.TableInterfaceId;
            _TableInterface.TimeLastModified = DateTime.Now;
            _TableInterface.TableName = Current.TableName;
            _TableInterface.TableNameFarsi = Current.TableNameFarsi;
            return _TableInterfaceDAC.Edit(_TableInterface);
        }

        public TableInterfaceEntity Get(int ID)
        {
            TableInterfaceEntity _TableInterfaceEntity = new TableInterfaceEntity();
            var q = _TableInterfaceDAC.Get(ID);
            _TableInterfaceEntity.TableInterfaceId = q.TableInterfaceId;
            _TableInterfaceEntity.GUID = q.GUID;
            _TableInterfaceEntity.TimeCreated = q.TimeCreated;
            _TableInterfaceEntity.TimeLastModified = q.TimeLastModified;
            _TableInterfaceEntity.TableName = q.TableName;
            _TableInterfaceEntity.TableNameFarsi = q.TableNameFarsi;
            _TableInterfaceEntity.Hidden = q.Hidden;
            return _TableInterfaceEntity;

            //  return (TableInterfaceEntity)_TableInterfaceDAC.Get(ID);
        }

        public IQueryable<TableInterfaceEntity> GetAll()
        {

            var query = _TableInterfaceDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 select new TableInterfaceEntity()
                 {
                     TableInterfaceId = q.TableInterfaceId,
                     TableName = q.TableName,
                     TableNameFarsi=q.TableNameFarsi

                 });
            return _query;
        }
    }
}
