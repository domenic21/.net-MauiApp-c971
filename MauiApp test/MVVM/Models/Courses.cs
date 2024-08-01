using MauiApp_test.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_test.MVVM.Models
{
    public class Courses : TableData
    {

        public string Name { get; set; }
        public string CourseCode { get; set; }
        public string Instructor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public bool Notifications { get; set; }

        //instructor info
        public string InstructorId { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorName { get; set; }

    }


}
