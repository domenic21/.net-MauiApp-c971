using MauiApp_test.Abstractions;
using SQLite;

namespace MauiApp_test.MVVM.Models
{
    [Table("Courses")]
    public class Courses : TableData
    {

        public string Name { get; set; }
        public string CourseCode { get; set; }
        public string Instructor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public int Term { get; set; } 
        public bool Notifications { get; set; }

        //instructor info
        public int InstructorId { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorName { get; set; }

    }


}
