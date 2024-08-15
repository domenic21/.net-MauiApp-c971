using MauiApp_test.Data;
using MauiApp_test.MVVM.Models;
using PropertyChanged;


namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class InstructorCoursesViewModel
    {
        public List<Courses> CourseList { get; set; }
        public List<Courses> Courses { get; set; }

        public InstructorCoursesViewModel(string InstructorName)
        {

             Courses = new List<Courses>(App.CoursesRepo.GetItems());

            //filter the list to show only the courses for the selected instructor
            CourseList = Courses.Where(c => c.InstructorName == InstructorName).ToList();



        }
    }

   

}
