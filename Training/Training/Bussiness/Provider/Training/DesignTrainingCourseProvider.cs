using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.InfraStructre;
using DataAccess;
using DomainModel.Models;
using InterfaceEntity;
using InterfaceEntity.Report.Training.DesignTrainingCourse;

namespace Bussiness
{
    public class DesignTrainingCourseProvider : IDesignTrainingCourseProvider
    {
        private DesignTrainingCourseDAC _DesignTrainingCourseDAC;
        public DesignTrainingCourseProvider()
        {
            _DesignTrainingCourseDAC = new DesignTrainingCourseDAC();
        }
        public int Add(DesignTrainingCourseEntity Current)
        {
            General _General = new General();
            Current.TookHold = _General.ShamsiToMiladi(Current.TookHoldStr);
            Current.ExamDates = _General.ShamsiToMiladi(Current.ExamDatesStr);
            DesignTrainingCourse _DesignTrainingCourse = new DesignTrainingCourse
                (Current.DesignTrainingCourseDateId, Current.TrainingCourseId, Current.TeacherId, Current.TookHold, Current.TrainingVenueId, Current.Duration, Current.NumberOfParticipants, Current.CostCourses,
                  Current.CourseObjectives, Current.CourseContent, Current.OtherNotes, Current.ExamDates, Current.TypesOfTrainingId, Current.MaximumScore,
                  Current.HoursHolding, Current.MinutesHolding, Current.ListLearningAssistToolComment, Current.EffectivenessOfCourse);
            return _DesignTrainingCourseDAC.Add(_DesignTrainingCourse);
        }
        public bool Delete(int ID)
        {
            return _DesignTrainingCourseDAC.Delete(ID);
        }
        public bool Edit(DesignTrainingCourseEntity Current)
        {
            General _General = new General();
            DesignTrainingCourse _DesignTrainingCourse = new DesignTrainingCourse();

            _DesignTrainingCourse.DesignTrainingCourseId = Current.DesignTrainingCourseId;
            _DesignTrainingCourse.TimeLastModified = DateTime.Now;
            _DesignTrainingCourse.CostCourses = Current.CostCourses;
            _DesignTrainingCourse.CourseContent = Current.CourseContent;
            _DesignTrainingCourse.CourseObjectives = Current.CourseObjectives;
            _DesignTrainingCourse.Duration = Current.Duration;
            _DesignTrainingCourse.NumberOfParticipants = Current.NumberOfParticipants;
            _DesignTrainingCourse.OtherNotes = Current.OtherNotes;
            _DesignTrainingCourse.TeacherId = Current.TeacherId;
            _DesignTrainingCourse.TookHold = _General.ShamsiToMiladi(Current.TookHoldStr);
            _DesignTrainingCourse.TrainingCourseId = Current.TrainingCourseId;
            _DesignTrainingCourse.TrainingVenueId = Current.TrainingVenueId;
            _DesignTrainingCourse.ExamDates = _General.ShamsiToMiladi(Current.ExamDatesStr);
            _DesignTrainingCourse.TypesOfTrainingId = Current.TypesOfTrainingId;
            _DesignTrainingCourse.MaximumScore = Current.MaximumScore;
            _DesignTrainingCourse.HoursHolding = Current.HoursHolding;
            _DesignTrainingCourse.MinutesHolding = Current.MinutesHolding;
            _DesignTrainingCourse.ListLearningAssistToolComment = Current.ListLearningAssistToolComment;
            _DesignTrainingCourse.EffectivenessOfCourse = Current.EffectivenessOfCourse;

            return _DesignTrainingCourseDAC.Edit(_DesignTrainingCourse);
        }
        public DesignTrainingCourseEntity Get(int ID)
        {
            DesignTrainingCourseEntity _DesignTrainingCourseEntity = new DesignTrainingCourseEntity();
            var q = _DesignTrainingCourseDAC.Get(ID);
            _DesignTrainingCourseEntity.CostCourses = q.CostCourses;
            _DesignTrainingCourseEntity.CourseContent = q.CourseContent;
            _DesignTrainingCourseEntity.CourseObjectives = q.CourseObjectives;
            _DesignTrainingCourseEntity.DesignTrainingCourseId = q.DesignTrainingCourseId;
            _DesignTrainingCourseEntity.Duration = q.Duration;
            _DesignTrainingCourseEntity.NumberOfParticipants = q.NumberOfParticipants;
            _DesignTrainingCourseEntity.OtherNotes = q.OtherNotes;
            _DesignTrainingCourseEntity.TeacherId = q.TeacherId;
            _DesignTrainingCourseEntity.TookHold = q.TookHold;
            _DesignTrainingCourseEntity.TrainingCourseId = q.TrainingCourseId;
            _DesignTrainingCourseEntity.TrainingVenueId = q.TrainingVenueId;
            _DesignTrainingCourseEntity.ExamDates = q.ExamDates;
            _DesignTrainingCourseEntity.TypesOfTrainingId = q.TypesOfTrainingId;
            _DesignTrainingCourseEntity.MaximumScore = q.MaximumScore;
            _DesignTrainingCourseEntity.HoursHolding = q.HoursHolding;
            _DesignTrainingCourseEntity.MinutesHolding = q.MinutesHolding;
            _DesignTrainingCourseEntity.ListLearningAssistToolComment = q.ListLearningAssistToolComment;
            _DesignTrainingCourseEntity.EffectivenessOfCourse = q.EffectivenessOfCourse;

            return _DesignTrainingCourseEntity;
        }
        public IQueryable<DesignTrainingCourseEntity> GetAll()
        {
            return (IQueryable<DesignTrainingCourseEntity>)_DesignTrainingCourseDAC.GetAll();
        }
        public IQueryable<DesignTrainingCourseEntity> GetAll(int designtrainingcoursedateid)
        {
            return _DesignTrainingCourseDAC.GetAllDesignTrainingCourse(designtrainingcoursedateid);
        }

        IQueryable<DesignTrainingCourseEntity> GetAllListEmployemeTrainingCourse(int designtrainingcoursedateid)
        {
            return _DesignTrainingCourseDAC.GetAllDesignTrainingCourse(designtrainingcoursedateid);
        }
        #region DesignTrainingCourseReport
        public IQueryable<DesignTrainingCourseEntity> GetDesignTrainingCourseListDPD(int trainingcourseid)
        {
            return _DesignTrainingCourseDAC.GetDesignTrainingCourseListDPD(trainingcourseid);
        }

        public DesignTrainingCourseReport GetDesignTrainingCourse(int ID)
        {
            General _General = new General();
            DesignTrainingCourseReport _DesignTrainingCourseReport = new DesignTrainingCourseReport();
            var q = _DesignTrainingCourseDAC.GetDesignTrainingCourse(ID);

            _DesignTrainingCourseReport.TrainingCourse = q.TrainingCourse;
            _DesignTrainingCourseReport.Teacher = q.Teacher;
            _DesignTrainingCourseReport.TookHoldStr = _General.MiladiToShamsi(q.TookHold);
            _DesignTrainingCourseReport.TrainingVenue = q.TrainingVenue;
            _DesignTrainingCourseReport.Duration = q.Duration;
            _DesignTrainingCourseReport.NumberOfParticipants = q.NumberOfParticipants;
            _DesignTrainingCourseReport.CostCourses = q.CostCourses;
            _DesignTrainingCourseReport.CourseObjectives = q.CourseObjectives;
            _DesignTrainingCourseReport.CourseContent = q.CourseContent;
            _DesignTrainingCourseReport.ListLearningAssistToolComment = q.ListLearningAssistToolComment;
            _DesignTrainingCourseReport.HoursHolding = q.HoursHolding;
            _DesignTrainingCourseReport.OtherNotes = q.OtherNotes;

            return _DesignTrainingCourseReport;
        }

        #endregion
    }
}
