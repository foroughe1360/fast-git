using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TableInterfaceEntity: TableInterface
    {
        public enum TableInterface : int
        {
            AccessType = 1,
            CourseType = 2,
            TypesOfTraining = 3,
            TrainingVenue = 4,
            Education = 5,
            LearningAssistTool = 6,
            StyleCourse = 7,
            UnitSCenter = 8,
            Collection = 9,
            PostType = 10,
            Table = 11,
            ListEffectivenessOfCourses = 12,
            UsedTable = 13,
            Priority = 14,
            TypesRateIt = 15,
            TypeOfCompany = 16,
            WrittenNotice = 17,
            AbilityRequiredJob = 18,
            CommunityOrganizations = 19,
            PhysicalConditions = 20,
            HealthConditions = 21,
            TrainingRequired = 22,
            Participantlevel = 23,
            EmployemeState = 24,
            TypeAttendance = 25,
            VarietyOfTest = 26,
            ContentQuestions = 27,
            ScoreEducationIdForContentQuestions = 28,
            RatingEvaluationCourses = 29,
            CourseObjective = 30,
            FileForm = 31,
            role = 32,
            TypeOfInstitution = 33,
            CommunicationOrganization = 34,
            Form = 35,
            OperationType = 36,
            ReportName = 37,
            TypeOfUniversity = 38,
            HardwareEquipment=39,
            TypeTrainingCalendarDate = 40,
        }
        public TableInterfaceEntity()
        {

        }
        public TableInterfaceEntity(string tableName,string tablenamefarsi) :base(tableName, tablenamefarsi)
        {

        }
    }
}
