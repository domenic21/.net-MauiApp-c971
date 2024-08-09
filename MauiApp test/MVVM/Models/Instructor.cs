using MauiApp_test.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;



namespace MauiApp_test.MVVM.Models
{
    [Table("Instructor")]
    public class Instructor : TableData
    {
        [ForeignKey(typeof(Courses))] // Specify the foreign key relationship
        public int CourseId { get; set; } // Foreign key property

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)] // Specify the relationship type
        public Courses Course { get; set; } // Navigation property

        public string InstructorName { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorEmail { get; set; }
    }
}
