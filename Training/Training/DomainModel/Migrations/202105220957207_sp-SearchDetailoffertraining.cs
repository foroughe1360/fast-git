namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class spSearchDetailoffertraining : DbMigration
    {
        public override void Up()
        {
            var sp = @"Create Procedure DetailoffertrainingforemployemeSearch (@NeedTraining nvarchar(50) , @OfferTrainingForEmployeeDateId int)
                as
                --declare  @NeedTraining nvarchar(30) = 'ÂÒãæ'
                SET @NeedTraining = '%'+@NeedTraining +'%'
                select 
                    detailoffertrainingforemployeme.NeedTraining as NeedTraining ,
                    tableInterfacevalues.TableValue as PriorityName,
                    tabletypeoftrainingsoffer.Sd as SD,
                    tabletypeoftrainingsoffer.Ojt as OJT,
                    tabletypeoftrainingsoffer.C as C,
                    tabletypeoftrainingsset.Sd as SDSet ,
                    tabletypeoftrainingsset.Ojt as OJTSet,
                    tabletypeoftrainingsset.C as CSet,
                    sections.Name as SectionName ,
                    TableInterfaceValuesPostType.TableValue as PostTypeName ,
                    tableinterfacevaluesCollection.TableValue as CollectionName, 
                    tableinterfacevaluesCollection.TableValue + ' -- ' + TableInterfaceValuesPostType.TableValue as PostGroupName, 
                    tableinterfacevaluesunitcenter.TableValue as UnitSCenterName,
                    departments.Name as DepartmentName ,
                    employemes.FirstName + ' ' + employemes.LastName as EmployemeName
                from 
	                DetailOfferTrainingForEmployemes as detailoffertrainingforemployeme
	                inner join  OfferTrainingForEmployemes as offertrainingforemployemes on detailoffertrainingforemployeme.OfferTrainingForEmployemesId = offertrainingforemployemes.OfferTrainingForEmployemeId
	                inner join  Sections as sections on offertrainingforemployemes.SectionId = sections.SectionId
	                inner join  Departments as departments on sections.DepartmentId = departments.DepartmentId
	                inner join  TableInterfaceValues as tableinterfacevaluesunitcenter on departments.UnitSCenterId =  tableinterfacevaluesunitcenter.TableInterfaceValueId
	                inner join  PostGroups as postgroups on OfferTrainingForEmployemes.PostGroupId = postgroups.PostGroupId
	                inner join  Employemes on Employemes.EmployemeId = OfferTrainingForEmployemes.EmployemeId
	                inner join  TableInterfaceValues as tableinterfacevaluesCollection on postgroups.CollectionId = tableinterfacevaluesCollection.TableInterfaceValueId
	                inner join  TableInterfaceValues as TableInterfaceValuesPostType on postgroups.PostTypeId = TableInterfaceValuesPostType.TableInterfaceValueId
	                inner join TableInterfaceValues as tableInterfacevalues on detailoffertrainingforemployeme.PriorityId = tableInterfacevalues.TableInterfaceValueId
	                inner join TableTypeOfTrainings as tabletypeoftrainingsoffer on detailoffertrainingforemployeme.TableTypeOfTrainingOfferId = tabletypeoftrainingsoffer.TableTypeOfTrainingId
	                inner join TableTypeOfTrainings as tabletypeoftrainingsset on  detailoffertrainingforemployeme.TableTypeOfTrainingSetId = tabletypeoftrainingsset.TableTypeOfTrainingId
                Where detailoffertrainingforemployeme.Hidden = 0 
	                and OfferTrainingForEmployemes.OfferTrainingForEmployeeDateId = @OfferTrainingForEmployeeDateId
	                and Employemes.Hidden = 0 
	                and detailoffertrainingforemployeme.NeedTraining like @NeedTraining
	                --and  Employemes.EmployemeId = 67
                    --and  detailoffertrainingforemployeme.OfferTrainingForEmployemesId =  604
	                order by detailoffertrainingforemployeme.NeedTraining desc
                    ";
            Sql(sp);
        }

        public override void Down()
        {
        }
    }
}
