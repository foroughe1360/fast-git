using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Report
{
    public partial class HardwareInformationReport
    {
        public string EquipmentName { get; set; }
        public string EquipmentModel { get; set; }
        public string PropertyNumber { get; set; }
        public string EmployemeName { get; set; }
        public string PostGroupName { get; set; }
        public string UnitSCenterName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string UnitDepartmentSection { get; set; }
        public string NetworkIP { get; set; }
        public string NetworkID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Descriptions { get; set; }
        public string DeliveryDateStr { get; set; }
        public HardwareInformationReport()
        {

        }
        public HardwareInformationReport(string equipmentname, string equipmentmodel, string propertynumber, string employemename, string postgroupname
            , string unitscentername, string departmentname, string sectionname, string networkip, string networkid, DateTime deliverydate, string descriptions)
        {
            EquipmentName = equipmentname;
            EquipmentModel = equipmentmodel;
            PropertyNumber = propertynumber;
            EmployemeName = employemename;

            PostGroupName = postgroupname;
            UnitSCenterName = unitscentername;
            DepartmentName = departmentname;
            SectionName = sectionname;
            UnitDepartmentSection = postgroupname + '-' + unitscentername + '-' + departmentname + '-' + sectionname;

            NetworkIP = networkip;
            NetworkID = networkid;
            DeliveryDate = deliverydate;
            Descriptions = descriptions;
        }
    }
}
