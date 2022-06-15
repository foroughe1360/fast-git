using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity
{
    public class TableInterfaceValueEntity: TableInterfaceValue
    {
        public string TableName { get; set; }
        public string TableNameFarsi { get; set; }
        public TableInterfaceValueEntity()
        {

        }
        public TableInterfaceValueEntity(int tableInterfaceId, string tablevalue, int tableinterfacevaluecode) :base(tableInterfaceId,  tablevalue, tableinterfacevaluecode)
        {

        }

        public enum Form : int
        {
            //TableInerfaceId=35

            AccessMenuUser = 35001,
            AccessUser = 35002,
            LogError = 35003,
            Login = 35004,
            Menu = 35005,
            NameOfSignatory = 35006,
            OperationLog = 35007,
            PostGroup = 35008,
            SideSignatory = 35009,
            SignatureResponsibility = 35010,
            User = 35011,
            AbsenceCount = 35012,
            Assessor = 35013,
            CodingTrainingPage = 35014,
            Department = 35015,
            DetailTypeRate = 35016,
            DeviceCollection = 35017,
            EducationEmployeme = 35018,
            EmployeeTrainingPassed = 35019,
            Employeme = 35020,
            EmployemeJob = 35021,
            FileRepository = 35022,
            HoursCertification = 35023,
            JobGroup = 35024,
            ListResponsibilitiePower = 35025,
            MasterRateIt = 35026,
            NumberSucceed = 35027,
            OJTLevel = 35028,
            Point = 35029,
            RatingEvaluation = 35030,
            Section = 35031,
            TableInterface = 35032,
            TableInterfaceValue = 35033,
            Tariff = 35034,
            Teacher = 35035,
            TeacherLevel = 35036,
            TeacherLevelDate = 35037,
            TestsCollection = 35038,
            TrainingCourse = 35039,
            TypeOfEvaluation = 35040,
            TypesRate = 35041,
            Home = 35042,
            CompetencyOperateTheMachine = 35043,
            CompetencyTesting = 35044,
            EmployeeEvaluation = 35045,
            HistoryQualificationOfStaff = 35046,
            ListEmployeeEvaluation = 35047,
            ListQualificationOfStaff = 35048,
            AssessmentOfTrainingService = 35049,
            AssessmentOfTrainingServiceInformation = 35050,
            Attendance = 35051,
            AttendanceDate = 35052,
            CourseObjectivesEffectivenessTraining = 35053,
            CourseRegistration = 35054,
            CriterionAssessmentOfTrainingService = 35055,
            DesignTrainingCourse = 35056,
            DesignTrainingCourseDate = 35057,
            DetailOfferTrainingForJob = 35058,
            DetailPlacementTabJobTraining = 35059,
            DetailHistoryTrainingUploadPage = 35060,
            EffectivenessTraining = 35061,
            EvaluationTrainingProgram = 35062,
            FinancialCommitment = 35063,
            HistoryTrainingUploadPage = 35064,
            Inventoryjob = 35065,
            ListAbilityRequiredJob = 35066,
            ListCommunityOrganization = 35067,
            ListEffectivenessOfCourse = 35068,
            ListHealthCondition = 35069,
            ListLearningAssistTool = 35070,
            ListOfCorporateJob = 35071,
            ListOfCorporateJobDate = 35072,
            ListPhysicalCondition = 35073,
            ListStyleCourse = 35074,
            ListTrainingCourse = 35075,
            ListTrainingRequired = 35076,
            ListTypeTestScore = 35077,
            NoteAbsence = 35078,
            OfferTrainingForJob = 35079,
            OfferTrainingForJobDate = 35080,
            PlacementTabJobTraining = 35081,
            PlacementTabJobTrainingDate = 35082,
            TablesRelatedAssessmentOfTrainingService = 35083,
            TableTypeOfTraining = 35084,
            TestScore = 35085,
            TrainingCalendar = 35086,
            TrainingCalendarDate = 35087,
            TrainingPageFile = 35088,
            Supervisor = 35089,
            //970203
            OfferTrainingForEmployeeDate = 35090,
            OfferTrainingForEmployeme = 35091,
            DetailOfferTrainingForEmployeme = 35092,
            ListTrainingCoursesWithAttendances=35093,
            EmployemeSignatury = 35094,
            SetDateForReport=35095,
            ReportOfEmployeme = 35096,
            HardwareEquipment=35097,
            HardwareInformation=35098,
            HardwareForEmployeme = 35099,
        }

        public enum OperationType:int
        {
            //TableInerfaceId=36
            CreatePost = 36001,
            EditPost = 36002,
            DeletePost = 36003,
            Get = 36004,
            Index = 36005,
            CreateGet = 36006,
            EditGet = 36007,
            PrintGet= 36008,
            StiReport= 36009,
            ViewerEvent= 36010,
            LoginUser = 36011,
        }
    }
}
