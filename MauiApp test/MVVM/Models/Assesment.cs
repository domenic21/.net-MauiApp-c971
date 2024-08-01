using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp_test.Abstractions;


namespace MauiApp_test.MVVM.Models
{
    public  class Assesment : TableData
    {
        public Type TypeName { get; set; }
        public string Name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime dueDate { get; set; }
        public bool StartDateNotifications { get; set; }
        public DateTime StartDateNotifier { get; set; }
        public bool EndDateNotifications { get; set; }
        public DateTime EndDateNotifier { get; set; }
    }
}
