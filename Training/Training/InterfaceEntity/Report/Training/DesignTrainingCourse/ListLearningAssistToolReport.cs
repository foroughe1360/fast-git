using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEntity.Report.Training.DesignTrainingCourse
{
    public class ListLearningAssistToolReport
    {
        public enum ListLearningAssistTool : int
        {
            PersianBook = 130,
            PersianLeaflet = 131,
            BooksInEnglish = 132,
            PamphletsInEnglish = 133,
            OriginalPersian = 134,
            EnglishArticle = 135,
            PowerpointPersian = 136,
            PowerpointEnglish = 137,
            VideoProjector = 138,
            Whiteboard = 139,
            DVD = 140,
            Other = 141
        }
        public bool PersianBook { get; set; }
        public bool PersianLeaflet { get; set; }
        public bool PamphletsInEnglish { get; set; }
        public bool BooksInEnglish { get; set; }
        public bool OriginalPersian { get; set; }
        public bool PowerpointPersian { get; set; }
        public bool PowerpointEnglish { get; set; }
        public bool VideoProjector { get; set; }
        public bool Whiteboard { get; set; }
        public bool DVD { get; set; }
        public bool EnglishArticle { get; set; }
        public bool Other { get; set; }
        public string Description { get; set; }

        public ListLearningAssistToolReport()
        {
            PersianBook = false;
            PersianLeaflet = false;
            PamphletsInEnglish = false;
            BooksInEnglish = false;
            OriginalPersian = false;
            PowerpointPersian = false;
            PowerpointEnglish = false;
            VideoProjector = false;
            Whiteboard = false;
            DVD = false;
            EnglishArticle = false;
            Other = false;
        }
    }
}
