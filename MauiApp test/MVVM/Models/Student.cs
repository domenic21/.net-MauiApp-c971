using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
using MauiApp_test.Abstractions;
using MauiApp_test.MVVM.Models;

namespace MauiApp_test.MVVM.Models
{
    public  class Student : TableData
    {

        public string studentName { get; set; }
        public string studentEmail { get; set; }
        public string studentPhone { get; set; }

        
    
  
    }
}
