using MauiApp_test.Data;
using MauiApp_test.MVVM.Models;

namespace MauiApp_test.MVVM.ViewModels
{
    public class CoursesViewModel
    {
        public Courses Courses { get; set; } = new Courses
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now
        };

        public string SaveCourse()
        {
            App.CoursesRepo.SaveItem(Courses);
            return App.CoursesRepo.StatusMessage;
        }

        //dummy data courses 

        public static void AddCourses()
        {

            foreach (var course in DummyData.GetCourses())
            {
                App.CoursesRepo.SaveItem(course);

            }
        }


    }


}


