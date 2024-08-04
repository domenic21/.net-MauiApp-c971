using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MauiApp_test.MVVM.Models;
using PropertyChanged;
using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.ViewModels
{

    public class EditViewModel
    {
        public Courses Courses { get; set; }

        public EditViewModel(int Id)
        {
            GetCourses(Id);
        }

        public void GetCourses(int Id)
        {
            List<Courses> coursesList = App.CoursesRepo.GetItemsById(Id);
            if (coursesList.Count > 0)
            {
                Courses = coursesList[0];
            }
            else
            {
                Courses = new Courses();
               
            }
           
        }

        public string SaveCourse()
        {
            App.CoursesRepo.SaveItem(Courses);
            return App.CoursesRepo.StatusMessage;
        }
    }
}
