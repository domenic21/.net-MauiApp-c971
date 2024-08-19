using MauiApp_test.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;
using MauiApp_test.MVVM.Models;

namespace MauiApp_test.MVVM.Models
{
    public enum AssessmentType
    {
        Objective,
        Performance
    }

    [Table("Assessment")]
    public class Assessment : TableData
    {
      
        public string AssessmentName { get; set; }
        public  AssessmentType AssessmentType { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool StartDateNotifications { get; set; }

        public string Notes { get; set; }

        public bool EndDateNotifications { get; set; }
        public bool NotificationDueDate { get; set; }

        public bool IsButtonVisible { get; set; } =false; // will set default value to false for IsButtonVisible to not show the button

        public string Name { get; set; } //testing
        public string CourseName { get; set; }
    }
}
