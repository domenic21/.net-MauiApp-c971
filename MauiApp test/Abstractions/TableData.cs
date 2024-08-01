using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp_test.Abstractions;
using MauiApp_test.MVVM.Models;

namespace MauiApp_test.Abstractions
{
     public class TableData
     {
          [PrimaryKey, AutoIncrement]
          public int Id { get; set; }
     }
}
