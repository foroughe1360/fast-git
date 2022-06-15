namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbsenceCounts",
                c => new
                    {
                        AbsenceCountId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        MaxAbsenceCount = c.Int(nullable: false),
                        AbsenceCountDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AbsenceCountId);
            
            CreateTable(
                "dbo.AccessMenuUsers",
                c => new
                    {
                        AccessMenuUserId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        AccessTypeId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccessMenuUserId);
            
            CreateTable(
                "dbo.AccessUsers",
                c => new
                    {
                        AccessUserId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        AccessId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccessUserId);
            
            CreateTable(
                "dbo.AssessmentOfTrainingServiceInformations",
                c => new
                    {
                        AssessmentOfTrainingServiceInformationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AssessmentOfTrainingServiceInformationId);
            
            CreateTable(
                "dbo.AssessmentOfTrainingServices",
                c => new
                    {
                        AssessmentOfTrainingServiceId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        InstitutionName = c.String(maxLength: 50),
                        ManagingDirector = c.String(maxLength: 50),
                        TypeOfCompanyId = c.Int(nullable: false),
                        ScopeOfTheActivities = c.String(maxLength: 50),
                        EconomicCode = c.Int(nullable: false),
                        TeacherName = c.String(maxLength: 50),
                        EducationId = c.Int(nullable: false),
                        Adress = c.String(),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AssessmentOfTrainingServiceId);
            
            CreateTable(
                "dbo.Assessors",
                c => new
                    {
                        AssessorId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AssessorId);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        CourseRegistrationId = c.Int(nullable: false),
                        AttendanceDate = c.DateTime(nullable: false),
                        IsAttendance = c.Boolean(nullable: false),
                        HourDelayFrom = c.DateTime(nullable: false),
                        HourDelayTo = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId);
            
            CreateTable(
                "dbo.CompetencyOperateTheMachines",
                c => new
                    {
                        CompetencyOperateTheMachineId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        ListQualificationOfStaffId = c.Int(nullable: false),
                        LaboratoryDevicesId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompetencyOperateTheMachineId);
            
            CreateTable(
                "dbo.CompetencyTestings",
                c => new
                    {
                        CompetencyTestingId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        ListQualificationOfStaffId = c.Int(nullable: false),
                        LaboratoryTestsId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompetencyTestingId);
            
            CreateTable(
                "dbo.CourseObjectivesEffectivenessTrainings",
                c => new
                    {
                        CourseObjectivesEffectivenessTrainingId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        EffectivenessTrainingId = c.Int(nullable: false),
                        CourseObjectiveId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseObjectivesEffectivenessTrainingId);
            
            CreateTable(
                "dbo.CourseRegistrations",
                c => new
                    {
                        CourseRegistrationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        DesignTrainingCourseId = c.Int(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseRegistrationId);
            
            CreateTable(
                "dbo.CriterionAssessmentOfTrainingServices",
                c => new
                    {
                        CriterionAssessmentOfTrainingServiceId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        AssessmentOfTrainingServiceId = c.Int(nullable: false),
                        TypeOfEvaluationId = c.Int(nullable: false),
                        Earnpoints = c.Int(nullable: false),
                        Description = c.String(),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CriterionAssessmentOfTrainingServiceId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        UnitSCenterId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.DesignTrainingCourses",
                c => new
                    {
                        DesignTrainingCourseId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        TrainingCourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        TookHold = c.DateTime(nullable: false),
                        TrainingVenueId = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        NumberOfParticipants = c.Int(nullable: false),
                        CostCourses = c.Long(nullable: false),
                        CourseObjectives = c.String(maxLength: 50),
                        CourseContent = c.String(maxLength: 50),
                        OtherNotes = c.String(maxLength: 50),
                        ExamDates = c.DateTime(nullable: false),
                        PurposeTest = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DesignTrainingCourseId);
            
            CreateTable(
                "dbo.DetailOfferTrainingForJobs",
                c => new
                    {
                        DetailOfferTrainingForJobId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        OfferTrainingForJobsId = c.Int(nullable: false),
                        NeedTraining = c.String(),
                        PriorityId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                        TableTypeOfTrainingOfferId = c.Int(nullable: false),
                        TableTypeOfTrainingSetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetailOfferTrainingForJobId);
            
            CreateTable(
                "dbo.DetailTypeRates",
                c => new
                    {
                        DetailTypeRateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        TypesRateId = c.Int(nullable: false),
                        Parent = c.Int(nullable: false),
                        DetailTypeName = c.String(maxLength: 50),
                        NumDetailType = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DetailTypeRateId);
            
            CreateTable(
                "dbo.DeviceCollections",
                c => new
                    {
                        DeviceCollectionId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        CollectionsId = c.Int(nullable: false),
                        JobDeviceCollection = c.String(maxLength: 50),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceCollectionId);
            
            CreateTable(
                "dbo.EducationEmployemes",
                c => new
                    {
                        EducationEmployemeId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        EducationId = c.Int(nullable: false),
                        FieldOfStudy = c.String(maxLength: 50),
                        AcademicOrientation = c.String(maxLength: 50),
                        DateOfGraduation = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EducationEmployemeId);
            
            CreateTable(
                "dbo.EffectivenessTrainings",
                c => new
                    {
                        EffectivenessTrainingId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        EmployemesId = c.Int(nullable: false),
                        SupervisorId = c.Int(nullable: false),
                        EffectivenessOfCoursesId = c.Int(nullable: false),
                        Correctiveaction = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EffectivenessTrainingId);
            
            CreateTable(
                "dbo.EmployeeEvaluations",
                c => new
                    {
                        EmployeeEvaluationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        ListEmployeeEvaluationId = c.Int(nullable: false),
                        TheoreticalKnowledge = c.Int(nullable: false),
                        TheoreticalKnowledgeDetail = c.String(),
                        Experience = c.Int(nullable: false),
                        ExperienceDetail = c.String(),
                        Skill = c.Int(nullable: false),
                        SkillDetail = c.String(),
                        WorkPerformance = c.Int(nullable: false),
                        WorkPerformanceDetail = c.String(),
                        Accountability = c.Int(nullable: false),
                        AccountabilityDetail = c.String(),
                        IndividualBehavior = c.Int(nullable: false),
                        IndividualBehaviorDetail = c.String(),
                        UpgradeConfirmation = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeEvaluationId);
            
            CreateTable(
                "dbo.EmployeeTrainingPasseds",
                c => new
                    {
                        EmployeeTrainingPassedId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Employemeid = c.Int(nullable: false),
                        TrainingCourseId = c.Int(nullable: false),
                        TableTypeOfTrainingId = c.Int(nullable: false),
                        TrainingVenueId = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        DateCourse = c.DateTime(nullable: false),
                        CertificateState = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeTrainingPassedId);
            
            CreateTable(
                "dbo.EmployemeJobs",
                c => new
                    {
                        EmployemeJobId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        PostGroupId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployemeJobId);
            
            CreateTable(
                "dbo.Employemes",
                c => new
                    {
                        EmployemeJobId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        FatherName = c.String(maxLength: 50),
                        PlaceOfBirth = c.String(maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        FieldOfStudy = c.String(maxLength: 50),
                        IDNumber = c.Int(nullable: false),
                        DateOfEmployement = c.DateTime(nullable: false),
                        PersonnelCode = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployemeJobId);
            
            CreateTable(
                "dbo.EvaluationTrainingPrograms",
                c => new
                    {
                        EvaluationTrainingProgramId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        DesignTrainingCourseId = c.Int(nullable: false),
                        ContentQuestionsId = c.Int(nullable: false),
                        ScoreEducationIdForContentQuestionsId = c.Int(nullable: false),
                        DirectorEducationQuestionId = c.Int(nullable: false),
                        ScoreEducationIdForDirectorEducationQuestionId = c.Int(nullable: false),
                        EmployemesId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluationTrainingProgramId);
            
            CreateTable(
                "dbo.FinancialCommitments",
                c => new
                    {
                        FinancialCommitmentId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        TrainingCourseId = c.Int(nullable: false),
                        TrainingVenueId = c.Int(nullable: false),
                        AmountPierced = c.Long(nullable: false),
                        TimeEmployment = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FinancialCommitmentId);
            
            CreateTable(
                "dbo.HistoryQualificationOfStaffs",
                c => new
                    {
                        HistoryQualificationOfStaffId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        ListQualificationOfStaffId = c.Int(nullable: false),
                        SignatureResponsibilityId = c.Int(nullable: false),
                        StageNameId = c.Int(nullable: false),
                        Description = c.String(maxLength: 50),
                        WorkFlowState = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryQualificationOfStaffId);
            
            CreateTable(
                "dbo.HoursCertifications",
                c => new
                    {
                        HoursCertificationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        TimePeriod = c.Int(nullable: false),
                        HoursCertificationDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HoursCertificationId);
            
            CreateTable(
                "dbo.Inventoryjobs",
                c => new
                    {
                        InventoryjobId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        UnitSCenterId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        PostGroupId = c.Int(nullable: false),
                        NumberEmployees = c.Int(nullable: false),
                        AsJobs2 = c.String(),
                        AsJobs3 = c.String(),
                        EducationId = c.Int(nullable: false),
                        FieldOfStudy = c.String(),
                        AcademicOrientation = c.String(),
                        Experience = c.String(),
                        Responsibilities = c.String(),
                        PercentPhysicalActivity = c.Int(nullable: false),
                        PercentMentalActivity = c.Int(nullable: false),
                        TheoreticalKnowledge = c.String(),
                        Qualified = c.String(),
                        OtherTraining = c.String(),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryjobId);
            
            CreateTable(
                "dbo.JobGroups",
                c => new
                    {
                        JobGroupId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        JobGroupName = c.String(maxLength: 50),
                        PonitJobGroup = c.Int(nullable: false),
                        GroupNumber = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JobGroupId);
            
            CreateTable(
                "dbo.ListAbilityRequiredJobs",
                c => new
                    {
                        DetailOfferTrainingForJobId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        InventoryjobsId = c.Int(nullable: false),
                        AbilityRequiredJobId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DetailOfferTrainingForJobId);
            
            CreateTable(
                "dbo.ListCommunityOrganizations",
                c => new
                    {
                        ListCommunityOrganizationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        InventoryjobsId = c.Int(nullable: false),
                        CommunityOrganizationsId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListCommunityOrganizationId);
            
            CreateTable(
                "dbo.ListEffectivenessOfCourses",
                c => new
                    {
                        ListEffectivenessOfCourseId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        DesignTrainingCourseId = c.Int(nullable: false),
                        EffectivenessOfCoursesId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListEffectivenessOfCourseId);
            
            CreateTable(
                "dbo.ListEmployeeEvaluations",
                c => new
                    {
                        ListEmployeeEvaluationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        EmployemesId = c.Int(nullable: false),
                        AssessorsId = c.Int(nullable: false),
                        AssessorTypeId = c.Int(nullable: false),
                        EmployeeEvaluationState = c.Int(nullable: false),
                        EmployeeEvaluationState1 = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListEmployeeEvaluationId);
            
            CreateTable(
                "dbo.ListHealthConditions",
                c => new
                    {
                        ListHealthConditionId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        InventoryjobsId = c.Int(nullable: false),
                        HealthConditionsId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListHealthConditionId);
            
            CreateTable(
                "dbo.ListLearningAssistTools",
                c => new
                    {
                        ListLearningAssistToolId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        DesignTrainingCourseId = c.Int(nullable: false),
                        LearningAssistToolId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListLearningAssistToolId);
            
            CreateTable(
                "dbo.ListPhysicalConditions",
                c => new
                    {
                        ListPhysicalConditionId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        InventoryjobsId = c.Int(nullable: false),
                        PhysicalConditionsId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListPhysicalConditionId);
            
            CreateTable(
                "dbo.ListQualificationOfStaffs",
                c => new
                    {
                        ListQualificationOfStaffId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        EmployemesId = c.Int(nullable: false),
                        CollectionId = c.Int(nullable: false),
                        TrainingManagerApprovalDate = c.DateTime(nullable: false),
                        TrainingManagerApproval = c.Int(nullable: false),
                        CompetencyTestingDatetime = c.DateTime(nullable: false),
                        CompetencyTesting = c.Int(nullable: false),
                        CompetencyOperateTheMachineDatetime = c.DateTime(nullable: false),
                        CompetencyOperateTheMachine = c.Int(nullable: false),
                        CompetencyTestingType = c.Int(nullable: false),
                        CompetencyOperateTheMachineType = c.Int(nullable: false),
                        CompilingReports = c.Boolean(nullable: false),
                        AnalysisAndInterpretationOfResults = c.Boolean(nullable: false),
                        InitialVerificationReport = c.Boolean(nullable: false),
                        TheFinalVerificationReport = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListQualificationOfStaffId);
            
            CreateTable(
                "dbo.ListStyleCourses",
                c => new
                    {
                        ListStyleCourseId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        DesignTrainingCourseId = c.Int(nullable: false),
                        StyleCoursesId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListStyleCourseId);
            
            CreateTable(
                "dbo.ListTrainingRequireds",
                c => new
                    {
                        ListTrainingRequiredId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        InventoryjobsId = c.Int(nullable: false),
                        TrainingRequiredId = c.Int(nullable: false),
                        Description = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                        TableTypeOfTrainingFaceId = c.Int(nullable: false),
                        TableTypeOfTrainingTimeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListTrainingRequiredId);
            
            CreateTable(
                "dbo.LogErrors",
                c => new
                    {
                        LogErrorId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        FormId = c.Int(nullable: false),
                        ErrorMessage = c.String(maxLength: 50),
                        AccessTypeId = c.Int(nullable: false),
                        Description = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LogErrorId);
            
            CreateTable(
                "dbo.MasterRateIts",
                c => new
                    {
                        MasterRateItId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        TypesRateItId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        MinRating = c.Double(nullable: false),
                        MaxRating = c.Double(nullable: false),
                        Parent = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MasterRateItId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 50),
                        Parent = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.NoteAbsences",
                c => new
                    {
                        NoteAbsenceId = c.Int(nullable: false, identity: true),
                        GUID = c.String(),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        AttendanceId = c.Int(nullable: false),
                        WrittenNoticeId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NoteAbsenceId);
            
            CreateTable(
                "dbo.NumberSucceeds",
                c => new
                    {
                        NumberSucceedId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        NumberSucceedDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NumberSucceedId);
            
            CreateTable(
                "dbo.OfferTrainingForJobs",
                c => new
                    {
                        OfferTrainingForJobId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        SectionId = c.Int(nullable: false),
                        PostGroupId = c.Int(nullable: false),
                        DateNeeds = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OfferTrainingForJobId);
            
            CreateTable(
                "dbo.OperationLogs",
                c => new
                    {
                        OperationLogId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        TableId = c.Int(nullable: false),
                        Description = c.String(maxLength: 50),
                        AccessTypeId = c.Int(nullable: false),
                        FormId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        HostName = c.String(maxLength: 50),
                        UserSystem = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OperationLogId);
            
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        PointId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        DetailTypeRateId = c.Int(nullable: false),
                        PointName = c.String(maxLength: 50),
                        NumPoint = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PointId);
            
            CreateTable(
                "dbo.PostGroups",
                c => new
                    {
                        TypeOfEvaluationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        CollectionId = c.Int(nullable: false),
                        PostTypeId = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TypeOfEvaluationId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SectionId);
            
            CreateTable(
                "dbo.TableInterfaces",
                c => new
                    {
                        TableInterfaceId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        TableName = c.String(maxLength: 50),
                        TableNameFarsi = c.String(),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TableInterfaceId);
            
            CreateTable(
                "dbo.TableInterfaceValues",
                c => new
                    {
                        TableInterfaceValueId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        TableInterfaceId = c.Int(nullable: false),
                        TableValue = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TableInterfaceValueId);
            
            CreateTable(
                "dbo.TablesRelatedAssessmentOfTrainingServices",
                c => new
                    {
                        TablesRelatedAssessmentOfTrainingServiceId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        AssessmentOfTrainingServiceInformationId = c.Int(nullable: false),
                        AssessmentOfTrainingServiceId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TablesRelatedAssessmentOfTrainingServiceId);
            
            CreateTable(
                "dbo.TableTypeOfTrainings",
                c => new
                    {
                        TableTypeOfTrainingId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        TableId = c.Int(nullable: false),
                        UsedTableId = c.Int(nullable: false),
                        C = c.Boolean(nullable: false),
                        Sd = c.Boolean(nullable: false),
                        Ojt = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TableTypeOfTrainingId);
            
            CreateTable(
                "dbo.Tariffs",
                c => new
                    {
                        TariffId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Cost = c.Long(nullable: false),
                        CourseTypeId = c.Int(nullable: false),
                        TariffDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TariffId);
            
            CreateTable(
                "dbo.TeacherLevels",
                c => new
                    {
                        TeacherLevelId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        TrainingCourseId = c.Int(nullable: false),
                        EffectivenessOfPreviousPeriod = c.Int(nullable: false),
                        Rhetorical = c.Int(nullable: false),
                        EducationId = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        CoursePlan = c.Int(nullable: false),
                        HistoryOfCooperation = c.Int(nullable: false),
                        Degree = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherLevelId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 50),
                        Family = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        EducationId = c.Int(nullable: false),
                        DateOfEmployement = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.TestsCollections",
                c => new
                    {
                        TestsCollectionId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        CollectionId = c.Int(nullable: false),
                        TestsCollectionName = c.String(maxLength: 50),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TestsCollectionId);
            
            CreateTable(
                "dbo.TestScores",
                c => new
                    {
                        TestScoreId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        CourseRegistrationId = c.Int(nullable: false),
                        VarietyOfTestId = c.Int(nullable: false),
                        Score = c.Double(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TestScoreId);
            
            CreateTable(
                "dbo.TrainingCourses",
                c => new
                    {
                        TrainingCourseId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        CourseName = c.String(maxLength: 50),
                        CourseTypeId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingCourseId);
            
            CreateTable(
                "dbo.TypeOfEvaluations",
                c => new
                    {
                        TypeOfEvaluationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Title = c.String(maxLength: 50),
                        MaxScore = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TypeOfEvaluationId);
            
            CreateTable(
                "dbo.TypesRates",
                c => new
                    {
                        TypesRateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        RateName = c.String(maxLength: 50),
                        NumberRate = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TypesRateId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 50),
                        Family = c.String(maxLength: 50),
                        State = c.Boolean(nullable: false),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.TypesRates");
            DropTable("dbo.TypeOfEvaluations");
            DropTable("dbo.TrainingCourses");
            DropTable("dbo.TestScores");
            DropTable("dbo.TestsCollections");
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherLevels");
            DropTable("dbo.Tariffs");
            DropTable("dbo.TableTypeOfTrainings");
            DropTable("dbo.TablesRelatedAssessmentOfTrainingServices");
            DropTable("dbo.TableInterfaceValues");
            DropTable("dbo.TableInterfaces");
            DropTable("dbo.Sections");
            DropTable("dbo.PostGroups");
            DropTable("dbo.Points");
            DropTable("dbo.OperationLogs");
            DropTable("dbo.OfferTrainingForJobs");
            DropTable("dbo.NumberSucceeds");
            DropTable("dbo.NoteAbsences");
            DropTable("dbo.Menus");
            DropTable("dbo.MasterRateIts");
            DropTable("dbo.LogErrors");
            DropTable("dbo.ListTrainingRequireds");
            DropTable("dbo.ListStyleCourses");
            DropTable("dbo.ListQualificationOfStaffs");
            DropTable("dbo.ListPhysicalConditions");
            DropTable("dbo.ListLearningAssistTools");
            DropTable("dbo.ListHealthConditions");
            DropTable("dbo.ListEmployeeEvaluations");
            DropTable("dbo.ListEffectivenessOfCourses");
            DropTable("dbo.ListCommunityOrganizations");
            DropTable("dbo.ListAbilityRequiredJobs");
            DropTable("dbo.JobGroups");
            DropTable("dbo.Inventoryjobs");
            DropTable("dbo.HoursCertifications");
            DropTable("dbo.HistoryQualificationOfStaffs");
            DropTable("dbo.FinancialCommitments");
            DropTable("dbo.EvaluationTrainingPrograms");
            DropTable("dbo.Employemes");
            DropTable("dbo.EmployemeJobs");
            DropTable("dbo.EmployeeTrainingPasseds");
            DropTable("dbo.EmployeeEvaluations");
            DropTable("dbo.EffectivenessTrainings");
            DropTable("dbo.EducationEmployemes");
            DropTable("dbo.DeviceCollections");
            DropTable("dbo.DetailTypeRates");
            DropTable("dbo.DetailOfferTrainingForJobs");
            DropTable("dbo.DesignTrainingCourses");
            DropTable("dbo.Departments");
            DropTable("dbo.CriterionAssessmentOfTrainingServices");
            DropTable("dbo.CourseRegistrations");
            DropTable("dbo.CourseObjectivesEffectivenessTrainings");
            DropTable("dbo.CompetencyTestings");
            DropTable("dbo.CompetencyOperateTheMachines");
            DropTable("dbo.Attendances");
            DropTable("dbo.Assessors");
            DropTable("dbo.AssessmentOfTrainingServices");
            DropTable("dbo.AssessmentOfTrainingServiceInformations");
            DropTable("dbo.AccessUsers");
            DropTable("dbo.AccessMenuUsers");
            DropTable("dbo.AbsenceCounts");
        }
    }
}
