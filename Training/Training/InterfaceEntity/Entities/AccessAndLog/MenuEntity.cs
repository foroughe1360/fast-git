using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class MenuEntity: Menu
    {
        public string ParentName { get; set; }
        public MenuEntity()
        {

        }

        public MenuEntity(string name, int parent, bool status)
        {
            Name = name;
            Parent = parent;
            Status = status;
        }


        public class SeededMenus
        {
            public int Seed { get; set; }
            public IList<MenuEntity> Menus { get; set; }
        }
    }
}
