namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryjobCopyRow : DbMigration
    {
        public override void Up()
        {//https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
            var sp = @"CREATE  procedure  InventoryjobCopyRow ( @CurrentInventoryjobId Int)
                    as 
                    Begin
                    declare @NewInventoryjobId int 
                            insert into Inventoryjobs
				                            (GUID, TimeCreated, TimeLastModified, SectionId, NumberEmployees, AsJobs2, AsJobs3, Experience, PercentPhysicalActivity, PercentMentalActivity, 
				                            TheoreticalKnowledge, Qualified, OtherTraining, Hidden, PostGroupName, Education, ListResponsibilitiePowerId, OtherAbilityRequiredJob, 
				                            ListCommunityOrganizationComment)
                            SELECT        
				                            NEWID(), GETDATE(),GETDATE(), SectionId, NumberEmployees, AsJobs2, AsJobs3, Experience, PercentPhysicalActivity, PercentMentalActivity, 
                                            TheoreticalKnowledge, Qualified, OtherTraining, Hidden, PostGroupName, Education, ListResponsibilitiePowerId, OtherAbilityRequiredJob, 
                                            ListCommunityOrganizationComment
                            FROM            Inventoryjobs
                            WHERE        (InventoryjobId = @CurrentInventoryjobId)
                            set  @NewInventoryjobId= SCOPE_IDENTITY()

                            insert into ListCommunityOrganizations
			                              (GUID, TimeCreated, TimeLastModified, InventoryjobsId, CommunityOrganizationsId, Hidden, CommunicationOrganizationId)
                            SELECT        NEWID(), GETDATE(),GETDATE(), @NewInventoryjobId, CommunityOrganizationsId, Hidden, CommunicationOrganizationId
                            FROM          ListCommunityOrganizations
                            where InventoryjobsId =@CurrentInventoryjobId

                            insert into ListPhysicalConditions
			                              (GUID, TimeCreated, TimeLastModified, InventoryjobsId, PhysicalConditionsId, Hidden)
                            SELECT		  NEWID(), GETDATE(),GETDATE(), @NewInventoryjobId, PhysicalConditionsId, Hidden
                            FROM          ListPhysicalConditions
                            WHERE         (InventoryjobsId = @CurrentInventoryjobId)

                            insert into ListHealthConditions
			                            (GUID, TimeCreated, TimeLastModified, InventoryjobsId, HealthConditionsId, Hidden, Description)
                            SELECT       NEWID(), GETDATE(),GETDATE(), @NewInventoryjobId, HealthConditionsId, Hidden, Description
                            FROM         ListHealthConditions
                            WHERE        (InventoryjobsId = @CurrentInventoryjobId)

                            insert into ListAbilityRequiredJobs
			                            (GUID, TimeCreated, TimeLastModified, InventoryjobsId, AbilityRequiredJobId, Hidden)
                            SELECT      NEWID(), GETDATE(),GETDATE(), @NewInventoryjobId, AbilityRequiredJobId, Hidden
                            FROM        ListAbilityRequiredJobs
                            WHERE       (InventoryjobsId = @CurrentInventoryjobId)

                            insert into ListTrainingRequireds
			                            (GUID, TimeCreated, TimeLastModified, InventoryjobsId, Description, Hidden, TableTypeOfTrainingFaceId, TitleTraining, SDTime, OJTTime, CTime)
                            SELECT      NEWID(), GETDATE(),GETDATE(), @NewInventoryjobId, Description, Hidden, TableTypeOfTrainingFaceId, TitleTraining, SDTime, OJTTime, CTime
                            FROM        ListTrainingRequireds
                            WHERE       (InventoryjobsId = @CurrentInventoryjobId)
                            return
                            end";

            Sql(sp);
        }
        
        public override void Down()
        {
        }
    }
}
