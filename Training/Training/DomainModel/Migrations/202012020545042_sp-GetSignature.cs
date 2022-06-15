namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spGetSignature : DbMigration
    {
        public override void Up()
        {
            //https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
            var sp = @"CREATE  procedure  GetSignature ( @EmployemeId int)
                    as 
                    Begin
                        SELECT     
                            PlacementTabJobTrainings.EmployemeId, 
                            Supervisors.SupervisorId ,Supervisors.EmployemeId ,Employemes.FirstName ,Employemes.LastName ,
                            SignatureResponsibilities.Signature,SignatureResponsibilityId
                        FROM            
                            PlacementTabJobTrainingDates 
                        INNER JOIN
                            PlacementTabJobTrainings 
                        ON 
                            PlacementTabJobTrainings.PlacementTabJobTrainingDateId = PlacementTabJobTrainingDates.PlacementTabJobTrainingDateId 
                        INNER JOIN
                            Supervisors 
                        ON 
                            Supervisors.SupervisorId = PlacementTabJobTrainings.CorporateResponsibility
                        INNER JOIN
                            Employemes 
                        ON 
                            Supervisors.EmployemeId = Employemes.EmployemeId
                        INNER JOIN
                            SignatureResponsibilities 
                        ON 
                            SignatureResponsibilities.EmployemeId = Employemes.EmployemeId
                        WHERE  
                            (PlacementTabJobTrainingDates.PTJTDate =
                            (SELECT        MAX(PTJTDate) AS Expr1
                            FROM            PlacementTabJobTrainingDates
                            WHERE        (Hidden = 0))) AND (PlacementTabJobTrainings.EmployemeId = @EmployemeId)
                    end";

            Sql(sp);
        }
        
        public override void Down()
        {
        }
    }
}
