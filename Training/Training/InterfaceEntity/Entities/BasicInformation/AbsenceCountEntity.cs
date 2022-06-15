using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class AbsenceCountEntity: AbsenceCount
    {
        public string AbsenceCountDateStr { get; set; }
        public AbsenceCountEntity()
        {

        }

        public AbsenceCountEntity(int maxabsencecount, DateTime absencecountdate) :base(maxabsencecount, absencecountdate)
        {

        }
    }
}
