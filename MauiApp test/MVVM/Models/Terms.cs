using MauiApp_test.Abstractions;
namespace MauiApp_test.MVVM.Models
{
    public class Terms : TableData
    {

        public string termName { get; set; }
        public DateTime termStart { get; set; }
        public DateTime termEnd { get; set; }

    }
}
