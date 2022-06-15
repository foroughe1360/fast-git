namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class spTrainingCoursesWithAttendancesSearch : DbMigration
    {
        public override void Up()
        {
            //https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
            var sp = @"CREATE  procedure  ListTrainingCoursesWithAttendancesSearch ( @FromDate nvarchar(50) ,@LastDate nvarchar(50))
                    as 
                    Begin
                    with cte 
                    AS (
                    select 
                    listtypetestscores.ListTypeTestScoreId,DesignTrainingCourses.ExamDates,
                    listtypetestscores.DesignTrainingCourseId,trainingcourses.CourseName as DesignTrainingCourseName,listtypetestscores.VarietyOfTestId,
                    tableinterfacevalues.TableValue as VarietyOfTestName,  listtypetestscores.PurposeTest,
                    TestScores.Score ,CourseRegistrations.EmployemeId ,
                    employemes.FirstName + ' ' + employemes.LastName as EmployemeName,TrainingCourses.TrainingCourseId
                    from   ListTypeTestScores
                    inner join TableInterfaceValues on ListTypeTestScores.VarietyOfTestId = tableinterfacevalues.TableInterfaceValueId
                    inner join DesignTrainingCourses on ListTypeTestScores.DesignTrainingCourseId = designtrainingcourses.DesignTrainingCourseId
                    inner join TrainingCourses on DesignTrainingCourses.TrainingCourseId = trainingcourses.TrainingCourseId
                    left join  TestScores on ListTypeTestScores.ListTypeTestScoreId = TestScores.ListTypeTestScoresId
                    inner join CourseRegistrations on TestScores.CourseRegistrationId = courseregistrations.CourseRegistrationId
                    inner join Employemes on courseregistrations.EmployemeId = employemes.EmployemeId
                    where ListTypeTestScores.Hidden = 0 and  ListTypeTestScores.DesignTrainingCourseId = 98 
                    and CourseRegistrations.EmployemeStateID !=183
                    )
                    Select  DesignTrainingCourses.DesignTrainingCourseId,Employemes.EmployemeId, Count( attendances.TypeAttendanceId) CountTypeAttendanceId, 
		                    employemes.FirstName + ' ' + employemes.LastName as EmployemeName,TrainingCourses.CourseName 
		                    ,(select cte.Score from cte where cte.VarietyOfTestId	= 187 and cte.EmployemeId = Employemes.EmployemeId)PreTestScore
		                    ,(select cte.Score from cte where cte.VarietyOfTestId	= 103 and cte.EmployemeId = Employemes.EmployemeId)MidtermScore
		                    ,(select cte.Score from cte where cte.VarietyOfTestId	= 385 and cte.EmployemeId = Employemes.EmployemeId)FinalTestScore
                    from  AttendanceDates
                    inner join Attendances on AttendanceDates.AttendanceDateId = attendances.AttendanceDateId
                    inner join CourseRegistrations on attendances.CourseRegistrationId = courseregistrations.CourseRegistrationId
                    inner join DesignTrainingCourses on courseregistrations.DesignTrainingCourseId = designtrainingcourses.DesignTrainingCourseId
                    inner join Employemes on courseregistrations.EmployemeId = employemes.EmployemeId
                    inner join TrainingCourses on DesignTrainingCourses.TrainingCourseId = trainingcourses.TrainingCourseId

                    Where AttendanceDates.Hidden = 0
                    and CourseRegistrations.EmployemeStateID !=183 and Attendances.TypeAttendanceId = 184
                    and DesignTrainingCourses.ExamDates between @FromDate and @LastDate
                    group by  employemes.FirstName , employemes.LastName ,Employemes.EmployemeId,courseregistrations.CourseRegistrationId,
                              designtrainingcourses.DesignTrainingCourseId ,TrainingCourses.TrainingCourseId, TrainingCourses.CourseName 
                    return
                    end";

            Sql(sp);

        }

        public override void Down()
        {
        }
    }
}
