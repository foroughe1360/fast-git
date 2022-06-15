namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spGetReportOfEmployemeChang : DbMigration
    {
        public override void Up()
        {
            var sp = @"ALTER PROCEDURE [dbo].[GetReportOfEmployeme]
                 as 
                   Begin
        SELECT      
	    Employemes.FirstName,
	    Employemes.LastName,
	    Employemes.FatherName,
	    Employemes.IDNumber,
	    Employemes.PlaceOfBirth,
		Employemes.NationalCode,
	    [dbo].UDF_Gregorian_To_Persian(Employemes.BirthDate) BirthDate,
        DateOfEmployement as DateOfEmployement,
	    [dbo].UDF_Gregorian_To_Persian( DateOfEmployement)DateOfEmployementFarsi  ,
	    tableinterfacevalues.TableValue as EducationName,
	    educationemployemes.FieldOfStudy+' - '+educationemployemes.AcademicOrientation as FieldOfStudy,
	    educationemployemes.AcademicOrientation,
		EducationEmployemes.NameOfUniversity,
		tableinterfacevaluesTypeOfUniversity.TableValue as TypeOfUniversityName,
        DateOfEmployement as DateOfEmployement ,
	    [dbo].UDF_Gregorian_To_Persian(educationemployemes.DateOfGraduation)DateOfGraduationFarsi  ,
	    tableinterfacevaluespost.TableValue as PostGroupName,
	    tableinterfacevaluesUnitSCenter.TableValue UnitSCenterName,
	    Departments.Name as DepartmentName,
	    Sections.Name SectionName,
		case Employemes.State when 0 then 'غیرفعال' else ' ' end Hidden
		--,sum( isnull(EmployeeTrainingPasseds.Duration,0))Duration
		
				, 
		isnull(
		(
		select 	sum ( isnull(detailplacementtabjobtrainings.NumberOfHours,0))Duration 
		from placementtabjobtrainings
		inner join  placementtabjobtrainingdates on  placementtabjobtrainings.PlacementTabJobTrainingDateId = placementtabjobtrainingdates.PlacementTabJobTrainingDateId
		inner join  detailplacementtabjobtrainings on  placementtabjobtrainings.PlacementTabJobTrainingId = detailplacementtabjobtrainings.PlacementTabJobTrainingId
		where placementtabjobtrainings.EmployemeId = Employemes.EmployemeId
		and placementtabjobtrainingdates.Hidden = 0  and detailplacementtabjobtrainings.Hidden= 0 and placementtabjobtrainings.Hidden = 0
		) +sum( isnull(EmployeeTrainingPasseds.Duration,0)) ,0)Duration
  FROM        
    Employemes 

        inner join EducationEmployemes on EducationEmployemes.EmployemeId = Employemes.EmployemeId
        inner join EmployemeJobs on Employemes.EmployemeId =  employemejobs.EmployemeId
		
        inner join TableInterfaceValues on EducationEmployemes.EducationId = tableinterfacevalues.TableInterfaceValueId
        inner join PostGroups on employemejobs.PostGroupId = postgroups.PostGroupId
        inner join TableInterfaceValues as tableinterfacevaluespost on postgroups.PostTypeId = tableinterfacevaluespost.TableInterfaceValueId
		left  join TableInterfaceValues as tableinterfacevaluesTypeOfUniversity on EducationEmployemes.TableTypeOfUniversityId = tableinterfacevaluesTypeOfUniversity.TableInterfaceValueId
        inner join Sections on employemejobs.SectionId = Sections.SectionId
        inner join Departments on Sections.DepartmentId = Departments.DepartmentId
        inner join TableInterfaceValues  as tableinterfacevaluesUnitSCenter on Departments.UnitSCenterId = tableinterfacevaluesUnitSCenter.TableInterfaceValueId
		left  join EmployeeTrainingPasseds on  EmployeeTrainingPasseds.Employemeid =  Employemes.EmployemeId
		inner join trainingcourses on employeetrainingpasseds.TrainingCourseId = trainingcourses.TrainingCourseId
		
         where 
            --Employemes.DateOfEmployement  between  '2015/03/21'and '2020/09/21' 
    
	        EmployemeJobs.ActivePostGroupName=1
            and EducationEmployemes.LastEducationalCertificate = 1
            and postgroups.Hidden = 0
            and EducationEmployemes.Hidden = 0
            --and Employemes.Hidden = 0
            and Departments.Hidden = 0
            and Sections.Hidden=0
            --and Employemes.EmployemeId = 13
            and EmployemeJobs.Hidden=0

	        group by 
		        Employemes.EmployemeId,
		        Employemes.FirstName,
	            Employemes.LastName,
	            Employemes.FatherName,
	            Employemes.IDNumber,
	            Employemes.PlaceOfBirth,
	            Employemes.BirthDate,
                DateOfEmployement ,
	            DateOfEmployement  ,
	            tableinterfacevalues.TableValue ,
	            educationemployemes.FieldOfStudy,
		        educationemployemes.AcademicOrientation ,
	            educationemployemes.AcademicOrientation,
		        EducationEmployemes.NameOfUniversity,
		        tableinterfacevaluesTypeOfUniversity.TableValue ,
                DateOfEmployement ,
	            educationemployemes.DateOfGraduation  ,
	            tableinterfacevaluespost.TableValue ,
	            tableinterfacevaluesUnitSCenter.TableValue ,
	            Departments.Name ,
	            Sections.Name ,
		        Employemes.State ,
		        Employemes.NationalCode
            order by 
		        Employemes.EmployemeId
        return
                    end";

            Sql(sp);
        }


        public override void Down()
        {
        }
    }
}
