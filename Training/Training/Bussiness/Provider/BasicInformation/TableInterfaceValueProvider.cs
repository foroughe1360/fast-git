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
    public class TableInterfaceValueProvider : ITableInterfaceValueProvider
    {
        private TableInterfaceValueDAC _TableInterfaceValueDAC;
        public TableInterfaceValueProvider()
        {
            _TableInterfaceValueDAC = new TableInterfaceValueDAC();
        }

        public int Add(TableInterfaceValueEntity Current)
        {
            TableInterfaceValue _TableInterfaceValue = new TableInterfaceValue(Current.TableInterfaceId,Current.TableValue,Current.TableInterfaceValueCode);
            return _TableInterfaceValueDAC.Add(_TableInterfaceValue);
        }

        public bool Delete(int ID)
        {
            return _TableInterfaceValueDAC.Delete(ID);
        }

        public bool Edit(TableInterfaceValueEntity Current)
        {
            TableInterfaceValue _TableInterfaceValue = new TableInterfaceValue();
            _TableInterfaceValue.TableInterfaceValueId = Current.TableInterfaceValueId;
            _TableInterfaceValue.TableInterfaceId = Current.TableInterfaceId;
            _TableInterfaceValue.TimeLastModified = DateTime.Now;
            _TableInterfaceValue.TableValue = Current.TableValue;
            _TableInterfaceValue.TableInterfaceValueCode = Current.TableInterfaceValueCode;
            return _TableInterfaceValueDAC.Edit(_TableInterfaceValue);
        }

        public TableInterfaceValueEntity Get(int ID)
        {
            TableInterfaceValueEntity _TableInterfaceValueEntity = new TableInterfaceValueEntity();
            var q = _TableInterfaceValueDAC.Get(ID);
            _TableInterfaceValueEntity.TableInterfaceValueId = q.TableInterfaceValueId;
            _TableInterfaceValueEntity.TableInterfaceId = q.TableInterfaceId;
            _TableInterfaceValueEntity.TableInterfaceValueId = q.TableInterfaceValueId;
            _TableInterfaceValueEntity.TableValue = q.TableValue;
            _TableInterfaceValueEntity.TableInterfaceValueCode = q.TableInterfaceValueCode;
            return  _TableInterfaceValueEntity;
        }

        public IQueryable<TableInterfaceValueEntity> GetAll()
        {
            return (IQueryable<TableInterfaceValueEntity>)_TableInterfaceValueDAC.GetAll();
        }

        public IQueryable<TableInterfaceValueEntity> GetAll(int ID)
        {
            return _TableInterfaceValueDAC.GetAllTableInterfaceValue(ID);
        }

        public IQueryable<TableInterfaceValueEntity> GetTableInterfaceValueDPD(int tableinterfacevalueid)
        {
            return _TableInterfaceValueDAC.GetTableInterfaceValueDPD(tableinterfacevalueid);
             //return (IQueryable<TableInterfaceValueEntity>)_TableInterfaceValueDAC.GetAll();
        }

    }

}
