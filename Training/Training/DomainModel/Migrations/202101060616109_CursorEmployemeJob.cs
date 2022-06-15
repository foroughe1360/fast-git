namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursorEmployemeJob : DbMigration
    {
        public override void Up()
        {
            var sp = @"CREATE FUNCTION [dbo].[GetEmployemeJobsName] (@EmployemeId int )
            RETURNS Nvarchar(max)
            AS
            BEGIN
	            DECLARE  @EmployemeJob  AS nvarchar(max) ,@EmployemeJobNames AS nvarchar(max) 
	
	            DECLARE cursorEmployemeJob CURSOR FOR
	            SELECT 
			            tableinterfacevaluesPostType.TableValue +'-'+ tableinterfacevaluesUnitSCenter.TableValue+'-'+  departments.Name+'-'+  sections.Name as EmployemeJobName
	            from	Employemes
			            inner join 
			            EmployemeJobs 
		            on  
			            employemejobs.EmployemeId = Employemes.EmployemeId
			            inner join 
			            PostGroups 
		            on 
			            employemejobs.PostGroupId = PostGroups.PostGroupId
			            inner join 
			            TableInterfaceValues as tableinterfacevaluesPostType 
		            on 
			            PostGroups.PostTypeId = tableinterfacevaluesPostType.TableInterfaceValueId
			            inner join 
			            Sections 
		            on 
			            employemejobs.SectionId = sections.SectionId
			            inner join 
			            Departments 
		            on 
			            sections.DepartmentId = departments.DepartmentId
			            inner join 
			            TableInterfaceValues as tableinterfacevaluesUnitSCenter 
		            on 
			            departments.UnitSCenterId = tableinterfacevaluesUnitSCenter.TableInterfaceValueId
	            where EmployemeJobs.EmployemeId = @EmployemeId
	
	            SET @EmployemeJob = ''	
	            OPEN cursorEmployemeJob
	            FETCH NEXT FROM cursorEmployemeJob INTO  @EmployemeJobNames;
	
	            SELECT @EmployemeJob = @EmployemeJobNames
	            FETCH NEXT FROM cursorEmployemeJob INTO @EmployemeJobNames

	            WHILE @@FETCH_STATUS = 0
	            BEGIN
	              Select  @EmployemeJob = @EmployemeJob + ' , ' + @EmployemeJobNames 
	              FETCH NEXT FROM cursorEmployemeJob INTO  @EmployemeJobNames
	            END
	            CLOSE cursorEmployemeJob
	            DEALLOCATE cursorEmployemeJob
	            return @EmployemeJob
            END
            ";

            Sql(sp);
        }

        public override void Down()
        {
        }
    }
}
