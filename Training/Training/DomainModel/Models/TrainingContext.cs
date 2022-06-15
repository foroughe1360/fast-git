using DomainModel.Models.AccessAndLog;
using DomainModel.Models.AccessAndLog.Mapping;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Configuration;
using System.Reflection.Emit;

namespace DomainModel.Models
{
    //کلاس DbContext در حقیقت یک Container برای Entity های ما هست که وظیفه شناسایی و تعریف Mapping ها را به صورت خودکار انجام می دهد
    //دی بی 
    public partial class TrainingContext : DbContext
    {
        static TrainingContext()
        {
            Database.SetInitializer<TrainingContext>(null);
        }
        public TrainingContext() : base("Name=TrainingDB")
        {
            //Database.SetInitializer<TrainingContext>(new CreateDatabaseIfNotExists<TrainingContext>());
        }

        //Entity ها به جداول بانک اطلاعاتی Map شوند
        #region AccessAndLog
        public DbSet<AccessMenuUser> AccessMenuUsers { get; set; }
        public DbSet<AccessUser> AccessUsers { get; set; }
        public DbSet<LogError> LogErrors { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<OperationLog> OperationLogs { get; set; }
        public DbSet<PostGroup> PostGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SignatureResponsibility> SignatureResponsibilities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SideSignatory> SideSignatories { get; set; }
        public DbSet<NameOfSignatory> NameOfSignatories { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<EmployemeSignatury> EmployemeSignaturies { get; set; }

        #endregion

        #region BasicInformation
        public DbSet<Assessor> Assessors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DetailTypeRate> DetailTypeRates { get; set; }
        public DbSet<DeviceCollection> DeviceCollections { get; set; }
        public DbSet<EducationEmployeme> EducationEmployemes { get; set; }
        public DbSet<EmployeeTrainingPassed> EmployeeTrainingPasseds { get; set; }
        public DbSet<Employeme> Employemes { get; set; }
        public DbSet<EmployemeJob> EmployemeJobs { get; set; }
        public DbSet<JobGroup> JobGroups { get; set; }
        public DbSet<MasterRateIt> MasterRateIts { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<TableInterface> TableInterfaces { get; set; }
        public DbSet<TableInterfaceValue> TableInterfaceValues { get; set; }
        public DbSet<TableTypeOfTraining> TableTypeOfTrainings { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherLevelDate> TeacherLevelDates { get; set; }
        public DbSet<TeacherLevel> TeacherLevels { get; set; }
        public DbSet<TestsCollection> TestsCollections { get; set; }
        public DbSet<TrainingCourse> TrainingCourses { get; set; }
        public DbSet<TypeOfEvaluation> TypeOfEvaluations { get; set; }
        public DbSet<TypesRate> TypesRates { get; set; }
        public DbSet<HoursCertification> HoursCertifications { get; set; }
        public DbSet<NumberSucceed> NumberSucceeds { get; set; }
        public DbSet<AbsenceCount> AbsenceCounts { get; set; }
        public DbSet<OJTLevel> OJTLevels { get; set; }
        public DbSet<FileRepository> FileRepositories { get; set; }
        public DbSet<RatingEvaluation> RatingEvaluations { get; set; }
        public DbSet<ListResponsibilitiePower> ListResponsibilitiePowers { get; set; }
        public DbSet<CodingTrainingPage> CodingTrainingPages { get; set; }

        public DbSet<SetDateForReport> SetDateForReports { get; set; }
        #endregion

        #region Promotion
        public DbSet<CompetencyOperateTheMachine> CompetencyOperateTheMachines { get; set; }
        public DbSet<CompetencyTesting> CompetencyTestings { get; set; }
        public DbSet<EmployeeEvaluation> EmployeeEvaluations { get; set; }
        public DbSet<HistoryQualificationOfStaff> HistoryQualificationOfStaffs { get; set; }
        public DbSet<ListEmployeeEvaluation> ListEmployeeEvaluations { get; set; }
        public DbSet<ListQualificationOfStaff> ListQualificationOfStaffs { get; set; }
        #endregion

        #region Training
        public DbSet<AssessmentOfTrainingService> AssessmentOfTrainingServices { get; set; }
        public DbSet<AssessmentOfTrainingServiceInformation> AssessmentOfTrainingServiceInformations { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<CourseObjectivesEffectivenessTraining> CourseObjectivesEffectivenessTrainings { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DbSet<CriterionAssessmentOfTrainingService> CriterionAssessmentOfTrainingServices { get; set; }
        public DbSet<DesignTrainingCourse> DesignTrainingCourses { get; set; }
        public DbSet<DetailOfferTrainingForJob> DetailOfferTrainingForJobs { get; set; }
        public DbSet<EffectivenessTraining> EffectivenessTrainings { get; set; }
        public DbSet<EvaluationTrainingProgram> EvaluationTrainingPrograms { get; set; }
        public DbSet<FinancialCommitment> FinancialCommitments { get; set; }
        public DbSet<Inventoryjob> Inventoryjobs { get; set; }
        public DbSet<ListAbilityRequiredJob> ListAbilityRequiredJobs { get; set; }
        public DbSet<ListCommunityOrganization> ListCommunityOrganizations { get; set; }
        public DbSet<ListEffectivenessOfCourse> ListEffectivenessOfCourses { get; set; }
        public DbSet<ListHealthCondition> ListHealthConditions { get; set; }
        public DbSet<ListLearningAssistTool> ListLearningAssistTools { get; set; }
        public DbSet<ListPhysicalCondition> ListPhysicalConditions { get; set; }
        public DbSet<ListStyleCourse> ListStyleCourses { get; set; }
        public DbSet<ListTrainingRequired> ListTrainingRequireds { get; set; }
        public DbSet<NoteAbsence> NoteAbsences { get; set; }
        public DbSet<OfferTrainingForJob> OfferTrainingForJobs { get; set; }
        public DbSet<TablesRelatedAssessmentOfTrainingService> TablesRelatedAssessmentOfTrainingServices { get; set; }
        public DbSet<TestScore> TestScores { get; set; }
        public DbSet<TrainingCalendar> TrainingCalendars { get; set; }
        public DbSet<ListOfCorporateJob> ListOfCorporateJobs { get; set; }
        public DbSet<AttendanceDate> AttendanceDates { get; set; }
        public DbSet<PlacementTabJobTraining> PlacementTabJobTrainings { get; set; }
        public DbSet<DetailPlacementTabJobTraining> DetailPlacementTabJobTrainings { get; set; }
        public DbSet<ListTypeTestScore> ListTypeTestScores { get; set; }
        public DbSet<OfferTrainingForJobDate> OfferTrainingForJobDates { get; set; }
        public DbSet<TrainingCalendarDate> TrainingCalendarDates { get; set; }
        public DbSet<ListOfCorporateJobDate> ListOfCorporateJobDates { get; set; }
        public DbSet<PlacementTabJobTrainingDate> PlacementTabJobTrainingDates { get; set; }
        public DbSet<DesignTrainingCourseDate> DesignTrainingCourseDates { get; set; }
        public DbSet<HistoryTrainingUploadPage> HistoryTrainingUploadPages { get; set; }
        public DbSet<DetialHistoryTrainingUploadPage> DetialHistoryTrainingUploadPages { get; set; }
        public DbSet<TrainingPageFile> TrainingPageFiles { get; set; }
        public DbSet<DetailOfferTrainingForEmployeme> DetailOfferTrainingForEmployeme { get; set; }
        public DbSet<OfferTrainingForEmployeeDate> OfferTrainingForEmployeeDate { get; set; }
        public DbSet<OfferTrainingForEmployeme> OfferTrainingForEmployemes { get; set; }

        #endregion

        #region IT    
        public DbSet<HardwareName> HardwareNames { get; set; }
        public DbSet<HardwareEquipment> HardwareEquipments { get; set; }
        public DbSet<HardwareInformation> HardwareInformations { get; set; }
        #endregion

        //عملیات Mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            #region AccessAndLog
            modelBuilder.Configurations.Add(new AccessMenuUserMap());
            modelBuilder.Configurations.Add(new AccessUserMap());
            modelBuilder.Configurations.Add(new LogErrorMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new OperationLogMap());
            modelBuilder.Configurations.Add(new PostGroupMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SignatureResponsibilityMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new SideSignatoryMap());
            modelBuilder.Configurations.Add(new NameOfSignatoryMap());
            modelBuilder.Configurations.Add(new SupervisorMap());
            modelBuilder.Configurations.Add(new EmployemeSignaturyMap());
            #endregion

            #region BasicInformation
            modelBuilder.Configurations.Add(new AssessorMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new DetailTypeRateMap());
            modelBuilder.Configurations.Add(new DeviceCollectionMap());
            modelBuilder.Configurations.Add(new EducationEmployemeMap());
            modelBuilder.Configurations.Add(new EmployeeTrainingPassedMap());
            modelBuilder.Configurations.Add(new EmployemeJobMap());
            modelBuilder.Configurations.Add(new EmployemeMap());
            modelBuilder.Configurations.Add(new JobGroupMap());
            modelBuilder.Configurations.Add(new MasterRateItMap());
            modelBuilder.Configurations.Add(new PointMap());
            modelBuilder.Configurations.Add(new SectionMap());
            modelBuilder.Configurations.Add(new TableInterfaceValueMap());
            modelBuilder.Configurations.Add(new TableInterfaceMap());
            modelBuilder.Configurations.Add(new TableTypeOfTrainingMap());
            modelBuilder.Configurations.Add(new TariffMap());
            modelBuilder.Configurations.Add(new TeacherLevelDateMap());
            modelBuilder.Configurations.Add(new TeacherLevelMap());
            modelBuilder.Configurations.Add(new TeacherMap());
            modelBuilder.Configurations.Add(new TestsCollectionMap());
            modelBuilder.Configurations.Add(new TrainingCourseMap());
            modelBuilder.Configurations.Add(new TypeOfEvaluationMap());
            modelBuilder.Configurations.Add(new TypesRateMap());
            modelBuilder.Configurations.Add(new HoursCertificationMap());
            modelBuilder.Configurations.Add(new NumberSucceedMap());
            modelBuilder.Configurations.Add(new AbsenceCountMap());
            modelBuilder.Configurations.Add(new OJTLevelMap());
            modelBuilder.Configurations.Add(new FileRepositoryMap());
            modelBuilder.Configurations.Add(new RatingEvaluationMap());
            modelBuilder.Configurations.Add(new ListResponsibilitiePowerMap());
            modelBuilder.Configurations.Add(new CodingTrainingPageMap());
            modelBuilder.Configurations.Add(new SetDateForReportMap());

            #endregion 

            #region Promotion
            modelBuilder.Configurations.Add(new CompetencyOperateTheMachineMap());
            modelBuilder.Configurations.Add(new CompetencyTestingMap());
            modelBuilder.Configurations.Add(new EmployeeEvaluationMap());
            modelBuilder.Configurations.Add(new HistoryQualificationOfStaffMap());
            modelBuilder.Configurations.Add(new ListEmployeeEvaluationMap());
            modelBuilder.Configurations.Add(new ListQualificationOfStaffMap());
            #endregion

            #region  Training
            modelBuilder.Configurations.Add(new AssessmentOfTrainingServiceInformationMap());
            modelBuilder.Configurations.Add(new AssessmentOfTrainingServiceMap());
            modelBuilder.Configurations.Add(new AttendanceMap());
            modelBuilder.Configurations.Add(new CourseObjectivesEffectivenessTrainingMap());
            modelBuilder.Configurations.Add(new CourseRegistrationMap());
            modelBuilder.Configurations.Add(new CriterionAssessmentOfTrainingServiceMap());
            modelBuilder.Configurations.Add(new DesignTrainingCourseMap());
            modelBuilder.Configurations.Add(new DetailOfferTrainingForJobsMa());
            modelBuilder.Configurations.Add(new EffectivenessTrainingMap());
            modelBuilder.Configurations.Add(new EvaluationTrainingProgramMap());
            modelBuilder.Configurations.Add(new FinancialCommitmentMap());
            modelBuilder.Configurations.Add(new InventoryjobMap());
            modelBuilder.Configurations.Add(new ListAbilityRequiredJobMap());
            modelBuilder.Configurations.Add(new ListCommunityOrganizationMap());
            modelBuilder.Configurations.Add(new ListEffectivenessOfCourseMap());
            modelBuilder.Configurations.Add(new ListHealthConditionMap());
            modelBuilder.Configurations.Add(new ListLearningAssistToolMap());
            modelBuilder.Configurations.Add(new ListPhysicalConditionMap());
            modelBuilder.Configurations.Add(new ListStyleCourseMap());
            modelBuilder.Configurations.Add(new ListTrainingRequiredMap());
            modelBuilder.Configurations.Add(new OfferTrainingForJobMap());
            modelBuilder.Configurations.Add(new TablesRelatedAssessmentOfTrainingServiceMap());
            modelBuilder.Configurations.Add(new TestScoreMap());
            modelBuilder.Configurations.Add(new TrainingCalendarMap());
            modelBuilder.Configurations.Add(new ListOfCorporateJobMap());
            modelBuilder.Configurations.Add(new AttendanceDateMap());
            modelBuilder.Configurations.Add(new PlacementTabJobTrainingMap());
            modelBuilder.Configurations.Add(new DetailPlacementTabJobTrainingMap());
            modelBuilder.Configurations.Add(new ListTypeTestScoresMap());
            modelBuilder.Configurations.Add(new OfferTrainingForJobDateMap());
            modelBuilder.Configurations.Add(new TrainingCalendarDateMap());
            modelBuilder.Configurations.Add(new ListOfCorporateJobDateMap());
            modelBuilder.Configurations.Add(new PlacementTabJobTrainingDateMap());
            modelBuilder.Configurations.Add(new DesignTrainingCourseDateMap());
            modelBuilder.Configurations.Add(new HistoryTrainingUploadPageMap());
            modelBuilder.Configurations.Add(new DetialHistoryTrainingUploadPageMap());
            modelBuilder.Configurations.Add(new TrainingPageFileMap());

            modelBuilder.Configurations.Add(new DetailOfferTrainingForEmployemeMap());
            modelBuilder.Configurations.Add(new OfferTrainingForEmployeeDateMap());
            modelBuilder.Configurations.Add(new OfferTrainingForEmployemeMap());

            #endregion

            #region IT
            modelBuilder.Configurations.Add(new HardwareNameMap());
            modelBuilder.Configurations.Add(new HardwareEquipmentMap());
            modelBuilder.Configurations.Add(new HardwareInformationMap());
            #endregion
        }
    }
}
