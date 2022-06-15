namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployemeTrainingCourse : DbMigration
    {
        public override void Up()
        { 
            //https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
            var sp = @"create procedure EmployemeTrainingCourse (@DesignTrainingCourseDateId int)
                as
                SELECT        CourseRegistrations.CourseRegistrationId, CourseRegistrations.DesignTrainingCourseId, CourseRegistrations.EmployemeId,
                 DesignTrainingCourses.TeacherId, DesignTrainingCourses.TookHold, 
                                         DesignTrainingCourses.TrainingVenueId, DesignTrainingCourses.Duration, DesignTrainingCourses.NumberOfParticipants, 
						                 DesignTrainingCourses.CostCourses, DesignTrainingCourses.CourseObjectives, 
                                         DesignTrainingCourses.CourseContent, DesignTrainingCourses.TypesOfTrainingId,
						                  DesignTrainingCourses.DesignTrainingCourseDateId, 

                                         DesignTrainingCourses.ListLearningAssistToolComment, DesignTrainingCourses.EffectivenessOfCourse, DesignTrainingCourseDates.Description, 
                                         TrainingCourses.TrainingCourseId ,TrainingCourses.CourseName, TrainingCourses.CourseTypeId, Teachers.TeacherId ,
                                         Teachers.Name, Teachers.Family, 
                                         Employemes.EmployemeId, Employemes.FirstName, Employemes.LastName, 
                                         Employemes.FatherName, Employemes.PlaceOfBirth, Employemes.BirthDate, Employemes.FieldOfStudy, 
                                         Employemes.NationalCode, tableinterfacevaluesTrainingVenueName.TableInterfaceValueId, 
						

                                        tableinterfacevaluesTrainingVenueName.TableInterfaceId, 
                                         tableinterfacevaluesTrainingVenueName.TableValue,  tableinterfacevaluesTrainingVenueName.TableInterfaceValueCode, 
                                         DesignTrainingCourses.DesignTrainingCourseId, DesignTrainingCourses.TrainingCourseId, DesignTrainingCourseDates.DesignTrainingCourseDateId 
                FROM            CourseRegistrations INNER JOIN
                                         DesignTrainingCourses ON DesignTrainingCourses.DesignTrainingCourseId = CourseRegistrations.DesignTrainingCourseId INNER JOIN
                                         DesignTrainingCourseDates ON DesignTrainingCourses.DesignTrainingCourseDateId = DesignTrainingCourseDates.DesignTrainingCourseDateId INNER JOIN
                                         TrainingCourses ON TrainingCourses.TrainingCourseId = DesignTrainingCourses.TrainingCourseId INNER JOIN
                                         Teachers ON Teachers.TeacherId = DesignTrainingCourses.TeacherId INNER JOIN
                                         Employemes ON CourseRegistrations.EmployemeId = Employemes.EmployemeId INNER JOIN
                                         TableInterfaceValues AS tableinterfacevaluesTrainingVenueName ON DesignTrainingCourses.TrainingVenueId = tableinterfacevaluesTrainingVenueName.TableInterfaceValueId
                WHERE        (DesignTrainingCourseDates.Hidden = 0) AND (DesignTrainingCourses.Hidden = 0) AND (TrainingCourses.Hidden = 0) AND (DesignTrainingCourses.Hidden = 0) AND (Teachers.Hidden = 0) AND (Employemes.Hidden = 0) AND 
                                         (CourseRegistrations.Hidden = 0)
						                 and DesignTrainingCourseDates.DesignTrainingCourseDateId= @DesignTrainingCourseDateId";
            Sql(sp);
        }

        public override void Down()
        {
        }
    }
}
