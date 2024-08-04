using MauiApp_test.Abstractions;
using SQLite;

namespace MauiApp_test.MVVM.Models
{
    [Table("Terms")]
    public class Terms : TableData
    {

        public int Term { get; set; }

        public string TermName { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime TermEnd { get; set; }

        public bool Notify { get; set; }
        public bool Status { get; set; }

    }
}
