using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;

namespace Bussiness
{
    public class ListTrainingRequiredProvider : IListTrainingRequiredProvider
    {
        private ListTrainingRequiredDAC _ListTrainingRequiredDAC;
        public ListTrainingRequiredProvider()
        {
            _ListTrainingRequiredDAC = new ListTrainingRequiredDAC();
        }
        public int Add(ListTrainingRequiredEntity Current)
        {
            ListTrainingRequired _ListTrainingRequired = new ListTrainingRequired(Current.InventoryjobsId, Current.Description, Current.TableTypeOfTrainingFaceId,Current.TitleTraining, Current.SDTime,Current.OJTTime,Current.CTime);
            return _ListTrainingRequiredDAC.Add(_ListTrainingRequired);
        }

        public bool Delete(int ID)
        {
            return _ListTrainingRequiredDAC.Delete(ID);
        }

        public bool Edit(ListTrainingRequiredEntity Current)
        {

            ListTrainingRequired _ListTrainingRequired = new ListTrainingRequired();
            _ListTrainingRequired.ListTrainingRequiredId = Current.ListTrainingRequiredId;
            _ListTrainingRequired.TimeLastModified = DateTime.Now;
            _ListTrainingRequired.Description = Current.Description;
            _ListTrainingRequired.InventoryjobsId = Current.InventoryjobsId;
            _ListTrainingRequired.TableTypeOfTrainingFaceId = Current.TableTypeOfTrainingFaceId;
            _ListTrainingRequired.TitleTraining = Current.TitleTraining;
            _ListTrainingRequired.SDTime = Current.SDTime;
            _ListTrainingRequired.OJTTime = Current.OJTTime;
            _ListTrainingRequired.CTime = Current.CTime;

            return _ListTrainingRequiredDAC.Edit(_ListTrainingRequired);
        }

        public ListTrainingRequiredEntity Get(int ID)
        {
            ListTrainingRequiredEntity _ListTrainingRequiredEntity = new ListTrainingRequiredEntity();
            var q = _ListTrainingRequiredDAC.Get(ID);
            _ListTrainingRequiredEntity.Description = q.Description;
            _ListTrainingRequiredEntity.InventoryjobsId = q.InventoryjobsId;
            _ListTrainingRequiredEntity.ListTrainingRequiredId = q.ListTrainingRequiredId;    
            _ListTrainingRequiredEntity.TableTypeOfTrainingFaceId = q.TableTypeOfTrainingFaceId;
            _ListTrainingRequiredEntity.TitleTraining = q.TitleTraining;
            _ListTrainingRequiredEntity.SDTime = q.SDTime;
            _ListTrainingRequiredEntity.OJTTime = q.OJTTime;
            _ListTrainingRequiredEntity.CTime = q.CTime;
            return _ListTrainingRequiredEntity;
        }

        public IQueryable<ListTrainingRequiredEntity> GetAll()
        {
           return (IQueryable<ListTrainingRequiredEntity>)_ListTrainingRequiredDAC.GetAll();
        }

        public IQueryable<ListTrainingRequiredEntity> GetAll(int ID)
        {
            return _ListTrainingRequiredDAC.GetAll(ID);
        }
    }
}
