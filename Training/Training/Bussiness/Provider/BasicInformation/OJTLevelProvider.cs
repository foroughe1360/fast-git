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
    public class OJTLevelProvider : IOJTLevelProvider
    {
        private OJTLevelDAC _OJTLevelDAC;

        public OJTLevelProvider()
        {
            _OJTLevelDAC = new OJTLevelDAC();
        }

        public int Add(OJTLevelEntity Current)
        {
            OJTLevel _OJTLevel = new OJTLevel(Current.LevelNumber, Current.Description);
            return _OJTLevelDAC.Add(_OJTLevel);
        }

        public bool Delete(int ID)
        {
            return _OJTLevelDAC.Delete(ID);
        }

        public bool Edit(OJTLevelEntity Current)
        {
            OJTLevel _OJTLevel = new OJTLevel();
            _OJTLevel.OJTLevelId = Current.OJTLevelId;
            _OJTLevel.TimeLastModified = DateTime.Now;
            _OJTLevel.LevelNumber = Current.LevelNumber;
            _OJTLevel.Description = Current.Description;

            return _OJTLevelDAC.Edit(_OJTLevel);
        }

        public OJTLevelEntity Get(int ID)
        {
            OJTLevelEntity _OJTLevelEntity = new OJTLevelEntity();
            var q = _OJTLevelDAC.Get(ID);
            if (q != null)
            {
                _OJTLevelEntity.OJTLevelId = q.OJTLevelId;
                _OJTLevelEntity.LevelNumber = q.LevelNumber;
                _OJTLevelEntity.Description = q.Description;
            }
            else
            {
                _OJTLevelEntity = null;
            }
            return _OJTLevelEntity;
        }

        public IQueryable<OJTLevelEntity> GetAll()
        {
            //return (IQueryable<OJTLevelEntity>)_OJTLevelDAC.GetAll();
            return _OJTLevelDAC.GetAllOJTLevel();
        }

    }
}
