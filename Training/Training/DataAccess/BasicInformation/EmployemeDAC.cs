using DataAccess.InfraStructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using System.Data.Entity;
using InterfaceEntity.Report;
using InterfaceEntity;
using InterfaceEntity.Search.BasicInformation;
using System.Data.SqlClient;

namespace DataAccess
{
    public class EmployemeDAC : IEmployemeRepository
    {
        public int Add(Employeme Current)
        {
            TrainingContext db = new TrainingContext();
            db.Employemes.Add(Current);
            db.SaveChanges();
            return Current.EmployemeId;
        }
        public bool Delete(int ID)
        {
            bool Result = true;
            try
            {
                TrainingContext db = new TrainingContext();
                var employeme = new Employeme() { EmployemeId = ID, Hidden = true };
                db.Employemes.Attach(employeme);
                db.Entry(employeme).Property(x => x.Hidden).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Result = false;
            }
            return Result;
        }
        public bool Edit(Employeme Current)
        {
            bool Success = true;
            try
            {
                TrainingContext db = new TrainingContext();
                db.Employemes.Attach(Current);
                db.Entry(Current).Property(x => x.EmployemeId).IsModified = true;
                db.Entry(Current).Property(x => x.TimeLastModified).IsModified = true;
                db.Entry(Current).Property(x => x.FirstName).IsModified = true;
                db.Entry(Current).Property(x => x.LastName).IsModified = true;
                db.Entry(Current).Property(x => x.FatherName).IsModified = true;
                db.Entry(Current).Property(x => x.PlaceOfBirth).IsModified = true;
                db.Entry(Current).Property(x => x.BirthDate).IsModified = true;
                db.Entry(Current).Property(x => x.FieldOfStudy).IsModified = true;
                db.Entry(Current).Property(x => x.IDNumber).IsModified = true;
                db.Entry(Current).Property(x => x.DateOfEmployement).IsModified = true;
                db.Entry(Current).Property(x => x.PersonnelCode).IsModified = true;
                db.Entry(Current).Property(x => x.NationalCode).IsModified = true;
                db.Entry(Current).Property(x => x.State).IsModified = true;
                db.SaveChanges();
            }
            catch
            {
                Success = false;
            }
            return Success;
        }
        public Employeme Get(int ID)
        {
            TrainingContext db = new TrainingContext();
            return db.Employemes.SingleOrDefault(x => x.EmployemeId == ID);
        } 

        public EmployemeOJTReport GetPlacementTabJobTraining(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.Hidden == false && a.PlacementTabJobTrainingId == ID)
                 join employemes in db.Employemes.Where(a => a.Hidden == false) on placementtabjobtrainings.EmployemeId equals employemes.EmployemeId
                 join postgroups in db.PostGroups on placementtabjobtrainings.PostGroupId equals postgroups.PostGroupId
                 join sections in db.Sections on placementtabjobtrainings.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevalues2 in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevalues2.TableInterfaceValueId
                 join tableinterfacevaluesActive in db.TableInterfaceValues on postgroups.PostTypeId equals tableinterfacevaluesActive.TableInterfaceValueId
                 join educationemployemes in db.EducationEmployemes.Where(a => a.LastEducationalCertificate == true) on placementtabjobtrainings.EmployemeId equals educationemployemes.EmployemeId
                 join tableinterfacevaluesEducation in db.TableInterfaceValues on educationemployemes.EducationId equals tableinterfacevaluesEducation.TableInterfaceValueId
                 join supervisors in db.Supervisors on placementtabjobtrainings.CorporateResponsibility equals supervisors.SupervisorId
                 join posttype in db.TableInterfaceValues on supervisors.PostTypeId equals posttype.TableInterfaceValueId
                 join supervisoremployeme in db.Employemes on supervisors.EmployemeId equals supervisoremployeme.EmployemeId
                 join departmentsupervisor in db.Departments on supervisors.DepartmentId equals departmentsupervisor.DepartmentId
                 select new EmployemeOJTReport
                 {
                     EmployemeName = employemes.FirstName + " " + employemes.LastName,
                     UnitDepartmentSection = tableinterfacevalues2.TableValue + " " + departments.Name + " " + sections.Name,
                     CurrentPostGroupName = tableinterfacevaluesActive.TableValue,
                     LatestFieldOfStudyName = tableinterfacevaluesEducation.TableValue + " " + educationemployemes.FieldOfStudy + " " + educationemployemes.AcademicOrientation,
                     DateOfEmployement = employemes.DateOfEmployement,
                     DateStartPostGroupName = placementtabjobtrainings.DateStartPostGroupName,
                     Previousjobs = placementtabjobtrainings.PreviousJobs,
                     CorporateResponsibility = posttype.TableValue + " " + departmentsupervisor.Name,
                     supervisor = supervisoremployeme.FirstName + " " + supervisoremployeme.LastName,
                 }).FirstOrDefault();
        }

        public EmployemeOJTReport GetPlacementTabJobTrainings(int ID)
        { 
            TrainingContext db = new TrainingContext();
            var queryplacementtabjobtrainings =
                 (from placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.Hidden == false && a.PlacementTabJobTrainingId == ID)
                  join employemes in db.Employemes.Where(a => a.Hidden == false ) on placementtabjobtrainings.EmployemeId equals employemes.EmployemeId
                  join postgroups in db.PostGroups on placementtabjobtrainings.PostGroupId equals postgroups.PostGroupId
                  join sections in db.Sections on placementtabjobtrainings.SectionId equals sections.SectionId
                  join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                  join tableinterfacevalues2 in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevalues2.TableInterfaceValueId
                  join tableinterfacevaluesActive in db.TableInterfaceValues on postgroups.PostTypeId equals tableinterfacevaluesActive.TableInterfaceValueId
                  join educationemployemes in db.EducationEmployemes.Where(a => a.LastEducationalCertificate == true) on placementtabjobtrainings.EmployemeId equals educationemployemes.EmployemeId
                  join tableinterfacevaluesEducation in db.TableInterfaceValues on educationemployemes.EducationId equals tableinterfacevaluesEducation.TableInterfaceValueId
                  join supervisors in db.Supervisors on placementtabjobtrainings.CorporateResponsibility equals supervisors.SupervisorId
                  join posttype in db.TableInterfaceValues on supervisors.PostTypeId equals posttype.TableInterfaceValueId
                  join supervisoremployeme in db.Employemes on supervisors.EmployemeId equals supervisoremployeme.EmployemeId
                  join departmentsupervisor in db.Departments on supervisors.DepartmentId equals departmentsupervisor.DepartmentId

                  select new
                  {
                      EmployemeName = employemes.FirstName + " " + employemes.LastName,
                      UnitDepartmentSection = tableinterfacevalues2.TableValue + " " + departments.Name + " " + sections.Name,
                      CurrentPostGroupName = tableinterfacevaluesActive.TableValue,
                      LatestFieldOfStudyName = tableinterfacevaluesEducation.TableValue + " " + educationemployemes.FieldOfStudy + " " + educationemployemes.AcademicOrientation,
                      DateOfEmployement = employemes.DateOfEmployement,
                      DateStartPostGroupName = placementtabjobtrainings.DateStartPostGroupName,
                      Previousjobs = placementtabjobtrainings.PreviousJobs,
                      CorporateResponsibility = posttype.TableValue + " " + departmentsupervisor.Name,
                      supervisor = supervisoremployeme.FirstName + " " + supervisoremployeme.LastName,

                      SupervisorsEmployemeId = supervisoremployeme.EmployemeId,
                      EmployemeId = employemes.EmployemeId,
                  });

            var query =
                (from q1 in queryplacementtabjobtrainings
                 join signatureresponsibilities in db.SignatureResponsibilities.Where(a => a.Hidden == false) on q1.SupervisorsEmployemeId equals signatureresponsibilities.EmployemeId
                 into Temp
                 from temp in Temp.DefaultIfEmpty()
                 select new EmployemeOJTReport
                 {
                     EmployemeName = q1.EmployemeName,
                     UnitDepartmentSection = q1.UnitDepartmentSection,
                     CurrentPostGroupName = q1.CurrentPostGroupName,
                     LatestFieldOfStudyName = q1.LatestFieldOfStudyName,
                     DateOfEmployement = q1.DateOfEmployement,
                     DateStartPostGroupName = q1.DateStartPostGroupName,
                     Previousjobs = q1.Previousjobs,
                     CorporateResponsibility = q1.CorporateResponsibility,
                     supervisor = q1.supervisor,

                     SupervisorsEmployemeId = q1.SupervisorsEmployemeId,
                     EmployemeId = q1.EmployemeId,
                     Signature = (temp.Signature == null ? null : temp.Signature),

                 }).FirstOrDefault();

            return query;
        }
        public IQueryable<Employeme> GetAll()
        {
            TrainingContext db = new TrainingContext();
            return from item in db.Employemes.OrderBy(a => a.DateOfEmployement) select item;
        }
        public IQueryable<EmployemeEntity> GetAll(EmployemeSearch employemesearch)
        {
            TrainingContext db = new TrainingContext();
            var list = from employemes in db.Employemes.Where(a => a.Hidden == false)
                       join educationemployemes in db.EducationEmployemes.Where(a => a.Hidden == false) on employemes.EmployemeId equals educationemployemes.EmployemeId
                       join employemejobs in db.EmployemeJobs.Where(a => a.Hidden == false && a.ActivePostGroupName == true) on employemes.EmployemeId equals employemejobs.EmployemeId
                       join sections in db.Sections.Where(a =>  a.Hidden == false) on employemejobs.SectionId equals sections.SectionId
                       join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                       join tableinterfacevalues in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevalues.TableInterfaceValueId
                       select new EmployemeEntity
                       {
                           BirthDate = employemes.BirthDate,
                           DateOfEmployement = employemes.DateOfEmployement,
                           EmployemeId = employemes.EmployemeId,
                           FatherName = employemes.FatherName,
                           FieldOfStudy = educationemployemes.FieldOfStudy,
                           FirstName = employemes.FirstName,
                           IDNumber = employemes.IDNumber,
                           LastName = employemes.LastName,
                           PlaceOfBirth = employemes.PlaceOfBirth,
                           PersonnelCode = employemes.PersonnelCode,
                           State = employemes.State,
                           //990825
                           ActivePostGroupName = employemejobs.ActivePostGroupName,
                           EmployemeName = employemes.FirstName + " " + employemes.LastName,
                           EducationId = educationemployemes.EducationId,
                           UnitSCenterId = tableinterfacevalues.TableInterfaceValueId,
                           departmentId = departments.DepartmentId,
                           NationalCode= employemes.NationalCode,
                       }; 
            if (employemesearch.FirstName.Trim() != "")
                list = list.Where(p => p.FirstName.Contains(employemesearch.FirstName));

            if (employemesearch.LastName.Trim() != "")
                list = list.Where(p => p.LastName.Contains(employemesearch.LastName));

            if (employemesearch.PersonnelCode != 0)
                list = list.Where(p => p.PersonnelCode == employemesearch.PersonnelCode);

            if (employemesearch.EducationId != 0)
                list = list.Where(p => p.EducationId == employemesearch.EducationId);

            if (employemesearch.FieldOfStudy.Trim() != "")
                list = list.Where(p => p.FieldOfStudy.Contains(employemesearch.FieldOfStudy.Trim()));

            if (employemesearch.UnitSCenterId != 0)
                list = list.Where(p => p.UnitSCenterId == employemesearch.UnitSCenterId);

            if (employemesearch.DepartmentId != 0)
                list = list.Where(p => p.departmentId == employemesearch.DepartmentId);

            if (employemesearch.State != -1)
                list = list.Where(p => p.State == employemesearch.UserState);
            //990825
            if (employemesearch.State != -1)
                list = list.Where(p => p.ActivePostGroupName == employemesearch.UserState);

            if (employemesearch.NationalCode != null)
                list = list.Where(p => p.NationalCode.Contains(employemesearch.NationalCode));

            return list.OrderBy(a => a.DateOfEmployement);
        }
        public EmployemeReport GetEmployemeReport(int ID)
        {
            TrainingContext db = new TrainingContext();
            var s =
                (from employemes in db.Employemes.Where(x => x.EmployemeId == ID)
                 join educationemployemes in db.EducationEmployemes.Where(a => a.LastEducationalCertificate == true) on employemes.EmployemeId equals educationemployemes.EmployemeId
                 join employemejobs in db.EmployemeJobs.Where(a => a.ActivePostGroupName == true) on employemes.EmployemeId equals employemejobs.EmployemeId
                 join tableinterfacevalues in db.TableInterfaceValues on educationemployemes.EducationId equals tableinterfacevalues.TableInterfaceValueId
                 join postgroups in db.PostGroups on employemejobs.PostGroupId equals postgroups.PostGroupId
                 join tableinterfacevaluespost in db.TableInterfaceValues on postgroups.PostTypeId equals tableinterfacevaluespost.TableInterfaceValueId
                 join Sections in db.Sections on employemejobs.SectionId equals Sections.SectionId
                 join Departments in db.Departments on Sections.DepartmentId equals Departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on Departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 select new EmployemeReport
                 {
                     FirstName = employemes.FirstName,
                     LastName = employemes.LastName,
                     BirthDateDatetime = employemes.BirthDate,
                     FatherName = employemes.FatherName,
                     PlaceOfBirth = employemes.PlaceOfBirth,
                     IDNumber = employemes.IDNumber,
                     EducationName = tableinterfacevalues.TableValue,
                     FieldOfStudy = educationemployemes.FieldOfStudy + " - " + educationemployemes.AcademicOrientation,
                     AcademicOrientation = educationemployemes.AcademicOrientation,
                     DateOfEmployementDateTime = employemes.DateOfEmployement,
                     PostGroupName = tableinterfacevaluespost.TableValue,
                     UnitSCenterName = tableinterfacevaluesUnitSCenter.TableValue,
                     DepartmentName = Departments.Name,
                     SectionName = Sections.Name,
                     NationalCode=employemes.NationalCode,

                 });

            return s.FirstOrDefault();
        }
        public IQueryable<EmployeeTrainingPassedReport> GetEmployeeTrainingPassedReport(int ID)
        {
            TrainingContext db = new TrainingContext();
            var list =
                (from employeetrainingpasseds in db.EmployeeTrainingPasseds.Where(a => a.Employemeid == ID && a.Hidden == false)
                 join trainingcourses in db.TrainingCourses.Where(a => a.Hidden == false) on employeetrainingpasseds.TrainingCourseId equals trainingcourses.TrainingCourseId
                 join tabletypeoftrainings in db.TableTypeOfTrainings on employeetrainingpasseds.TableTypeOfTrainingId equals tabletypeoftrainings.TableTypeOfTrainingId
                 join tableinterfacevaluestrainingvenue in db.TableInterfaceValues on employeetrainingpasseds.TrainingVenueId equals tableinterfacevaluestrainingvenue.TableInterfaceValueId
                 select new EmployeeTrainingPassedReport
                 {
                     TrainingCourseName = trainingcourses.CourseName,
                     SD = tabletypeoftrainings.Sd,
                     OJT = tabletypeoftrainings.Ojt,
                     C = tabletypeoftrainings.C,
                     TrainingvenueName = tableinterfacevaluestrainingvenue.TableValue,
                     Duration = employeetrainingpasseds.Duration,
                     DateCourseDateTime = employeetrainingpasseds.DateCourse,
                     CertificateStateYse = (employeetrainingpasseds.CertificateState == true ? true : false),
                     CertificateStateNo = (employeetrainingpasseds.CertificateState == false ? true : false)
                 }).OrderBy(a => a.DateCourseDateTime);
            return list;
        }
        public IQueryable<EmployemeOJTReport> GetAllPreviousjobs(int ID)
        {
            TrainingContext db = new TrainingContext();
            return
                (from placementtabjobtrainings in db.PlacementTabJobTrainings.Where(a => a.Hidden == false && a.PlacementTabJobTrainingDateId == ID)
                 join employemes in db.Employemes on placementtabjobtrainings.EmployemeId equals employemes.EmployemeId
                 join employemejobs in db.EmployemeJobs.Where(a => a.ActivePostGroupName == false) on employemes.EmployemeId equals employemejobs.EmployemeId
                 join PostGroups in db.PostGroups on employemejobs.PostGroupId equals PostGroups.PostGroupId
                 join tableinterfacevaluePostType in db.TableInterfaceValues on PostGroups.PostTypeId equals tableinterfacevaluePostType.TableInterfaceValueId
                 join sections in db.Sections on employemejobs.SectionId equals sections.SectionId
                 join departments in db.Departments on sections.DepartmentId equals departments.DepartmentId
                 join tableinterfacevaluesUnitSCenter in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevaluesUnitSCenter.TableInterfaceValueId
                 select new EmployemeOJTReport
                 {
                     Previousjobs = tableinterfacevaluesUnitSCenter.TableValue + " " + departments.Name + " " + sections.Name + " " + tableinterfacevaluePostType.TableValue 
                 });
        }
        public IQueryable<EmployemeEntity> GetAllEmployeme(int ID)
        {
            TrainingContext db = new TrainingContext();
           
            return
                (from employemes in db.Employemes.Where(a => a.Hidden == false)
                 join employemejobs in db.EmployemeJobs.Where(a => a.Hidden == false) on employemes.EmployemeId equals employemejobs.EmployemeId
                 join postgroups in db.PostGroups.Where(a => a.PostGroupId == ID) on employemejobs.PostGroupId equals postgroups.PostGroupId
                 //join tableinterfacevalues in db.TableInterfaceValues on departments.UnitSCenterId equals tableinterfacevalues.TableInterfaceValueId
                 select new EmployemeEntity
                 {
                     PostGroupId = employemejobs.PostGroupId,
                     EmployemeId = employemes.EmployemeId,
                     Name = employemes.FirstName + " " + employemes.LastName,
                 });
        }
        public IQueryable<EmployemeForReport> GetAllForReport()
        {
            TrainingContext db = new TrainingContext();
            string sqlQuery;
            //SqlParameter[] sqlParams;
            //sqlParams = new SqlParameter[]
            //{
            //new SqlParameter { ParameterName = "@DesignTrainingCourseId",  Value =designtrainingcourseid , Direction = System.Data.ParameterDirection.Input},
            //}; 

            sqlQuery = "GetReportOfEmployeme";
            var EmployemeReportList = db.Database.SqlQuery<EmployemeForReport>(sqlQuery).ToList();//.SingleOrDefault();

            return EmployemeReportList.AsQueryable();
        }

        //public IQueryable<EmployemeHardware> GetAll()
        //{
        //    TrainingContext db = new TrainingContext();
        //    return from item in db.Employemes.OrderBy(a => a.DateOfEmployement) select item;
        //}

    }
}