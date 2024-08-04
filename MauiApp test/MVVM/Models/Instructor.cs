using MauiApp_test.Abstractions;
using SQLite;



namespace MauiApp_test.MVVM.Models
{
    [Table("Instructor")]
    public class Instructor : TableData
    {
      
        public string instructorPhone { get; set; }
        public string instructorName { get; set; }
        public string instructorEmail { get; set; }



    }
}
