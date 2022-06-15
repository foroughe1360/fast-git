namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spGetTestScoreChang : DbMigration
    {
        public override void Up()
        {
            var sp = @"ALTER Procedure [dbo].[GetTestScore_Select]( @DesignTrainingCourseId int )
                as 
                begin
                with cte 
                AS (
                select 
                listtypetestscores.ListTypeTestScoreId,DesignTrainingCourses.ExamDates,
                listtypetestscores.DesignTrainingCourseId,trainingcourses.CourseName as DesignTrainingCourseName,listtypetestscores.VarietyOfTestId,
                tableinterfacevalues.TableValue as VarietyOfTestName,  listtypetestscores.PurposeTest
                ,TestScores.Score 
                ,CourseRegistrations.EmployemeId ,
                 employemes.FirstName + ' ' + employemes.LastName as EmployemeName,TrainingCourses.TrainingCourseId
                from   ListTypeTestScores
                inner join TableInterfaceValues on ListTypeTestScores.VarietyOfTestId = tableinterfacevalues.TableInterfaceValueId
                inner join DesignTrainingCourses on ListTypeTestScores.DesignTrainingCourseId = designtrainingcourses.DesignTrainingCourseId
                inner join TrainingCourses on DesignTrainingCourses.TrainingCourseId = trainingcourses.TrainingCourseId
                left join  TestScores on ListTypeTestScores.ListTypeTestScoreId = TestScores.ListTypeTestScoresId
                inner join CourseRegistrations on TestScores.CourseRegistrationId = courseregistrations.CourseRegistrationId
                inner join Employemes on courseregistrations.EmployemeId = employemes.EmployemeId
                where ListTypeTestScores.Hidden = 0 and  ListTypeTestScores.DesignTrainingCourseId = @DesignTrainingCourseId 
                and CourseRegistrations.EmployemeStateID !=183
                --and Employemes.EmployemeId =1107
                )
                Select  attendancedates.GUID, AttendanceDates.AttendanceDateId,
                     attendancedates.AttendanceAbsenceDate as AttendanceAbsenceDate,employemes.EmployemeId,
                                      employemes.FirstName + ' ' + employemes.LastName as EmployemeName,
                                      attendances.TypeAttendanceId as TypeAttendance,
                                      courseregistrations.CourseRegistrationId as  CourseRegistrationId,
                                      designtrainingcourses.DesignTrainingCourseId as DesignTrainingCourseId,
					                 TrainingCourses.TrainingCourseId, TrainingCourses.CourseName 
					                 ,isnull((select cte.Score from cte where cte.VarietyOfTestId	= 187 and cte.EmployemeId = Employemes.EmployemeId),0)PreTestScore
					                 ,isnull((select cte.Score from cte where cte.VarietyOfTestId	= 383 and cte.EmployemeId = Employemes.EmployemeId),0)PracticalTestScore
					                 ,isnull((select cte.Score  from cte where cte.VarietyOfTestId	= 103 and cte.EmployemeId = Employemes.EmployemeId), 0) TestScore
					                 ,isnull((select cte.Score from cte where cte.VarietyOfTestId	= 385 and cte.EmployemeId = Employemes.EmployemeId),0)FinalTestScore
                from  AttendanceDates
                inner join Attendances on AttendanceDates.AttendanceDateId = attendances.AttendanceDateId
                inner join CourseRegistrations on attendances.CourseRegistrationId = courseregistrations.CourseRegistrationId
                inner join DesignTrainingCourses on courseregistrations.DesignTrainingCourseId = designtrainingcourses.DesignTrainingCourseId
                inner join Employemes on courseregistrations.EmployemeId = employemes.EmployemeId
                inner join TrainingCourses on DesignTrainingCourses.TrainingCourseId = trainingcourses.TrainingCourseId

                Where AttendanceDates.DesignTrainingCourseId = @DesignTrainingCourseId and AttendanceDates.Hidden = 0
                and CourseRegistrations.EmployemeStateID !=183
                --and Employemes.EmployemeId =  1107

                end";

            Sql(sp);
        }

        public override void Down()
        {
        }
    }
}
