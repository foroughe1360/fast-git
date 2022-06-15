namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlacementTabJobCopyRow : DbMigration
    {
        public override void Up()
        {//https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
            var sp = @"CREATE  procedure  PlacementTabJobCopyRow ( @CurrentPlacementTabJobTrainingId Int)
                    as 
                    Begin
                    declare @NewPlacementTabJobTrainingId int 
                            insert into PlacementTabJobTrainings
				                          (GUID, TimeCreated, TimeLastModified, EmployemeId, Hidden, PlacementTabJobTrainingDateId, SectionId, PreviousJobs, PostGroupId, DateStartPostGroupName, CorporateResponsibility)
                            SELECT            NEWID(), GETDATE(),GETDATE(), EmployemeId, Hidden, PlacementTabJobTrainingDateId, SectionId, PreviousJobs, PostGroupId, DateStartPostGroupName, CorporateResponsibility
                            FROM          PlacementTabJobTrainings
                            WHERE        (PlacementTabJobTrainingId = @CurrentPlacementTabJobTrainingId)
                            set  @NewPlacementTabJobTrainingId= SCOPE_IDENTITY()

                            insert into DetailPlacementTabJobTrainings
			                              (GUID, TimeCreated, TimeLastModified, PlacementTabJobTrainingId, Title, FinalComment, NumberOfHours, OJTLevelId, Hidden)
                            SELECT            NEWID(), GETDATE(),GETDATE(), @NewPlacementTabJobTrainingId, Title, FinalComment, NumberOfHours, OJTLevelId, Hidden
                            FROM          DetailPlacementTabJobTrainings
                            where PlacementTabJobTrainingId =@CurrentPlacementTabJobTrainingId

                            return
                            end";

            Sql(sp);
        }

        public override void Down()
        {
        }
    }
}
