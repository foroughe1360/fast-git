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
    public class MenuProvider : IMenuProvider
    {
        private MenuDAC _MenuDAC;

        public MenuProvider()
        {
            _MenuDAC = new MenuDAC();
        }

        public int Add(MenuEntity Current)
        {
            Menu _Menu = new Menu(Current.Name, Current.Parent, Current.Status);
            return _MenuDAC.Add(_Menu);
        }

        public bool Delete(int ID)
        {
            return _MenuDAC.Delete(ID);
        }

        public bool Edit(MenuEntity Current)
        {
            Menu _Menu = new Menu();
            _Menu.MenuId = Current.MenuId;
            _Menu.TimeLastModified = DateTime.Now;
            _Menu.Name = Current.Name;
            _Menu.Parent = Current.Parent;
            _Menu.Status = Current.Status;
            return _MenuDAC.Edit(_Menu);
        }

        public MenuEntity Get(int ID)
        {
            MenuEntity _MenuEntity = new MenuEntity();
            var q = _MenuDAC.Get(ID);
            _MenuEntity.MenuId = q.MenuId;
            _MenuEntity.Name = q.Name;
            _MenuEntity.Parent = q.Parent;
            _MenuEntity.Status = q.Status;
            return _MenuEntity;
        }

        public IQueryable<MenuEntity> GetAll()
        {
            var query = _MenuDAC.GetAll();
            var _query =
                (from q in query.Where(a => a.Hidden == false)
                 join m in query.Where(a => a.Hidden == false) on q.Parent equals m.MenuId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new MenuEntity()
                 {
                     MenuId = q.MenuId,
                     Name = q.Name,
                     Parent = q.Parent,
                     Status = q.Status,
                     ParentName = temp.Name
                 });
            return _query;
        }
    }
}
