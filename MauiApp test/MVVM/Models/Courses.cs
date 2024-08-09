using MauiApp_test.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;

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

        // Foreign key and relationship to the Instructor table
        [ForeignKey(typeof(Instructor))]
        public string InstructorName { get; set; }
        public int InstructorId { get; set; }

        // Navigation property to access the related Instructor object
        [Ignore] // Ignore this property during database operations
        public Instructor Instructors { get; set; }
        public bool HasCourse { get; set; } = true;

        public bool IsButtonVisible { get; set; }
    }


}
