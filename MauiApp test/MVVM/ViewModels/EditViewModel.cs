
using MauiApp_test.MVVM.Models;
using MauiApp_test.Data;

using System.Collections.ObjectModel;

namespace MauiApp_test.MVVM.ViewModels
{

    public class EditViewModel
    {
        public Courses Courses { get; set; }

        public ObservableCollection<Instructor> Instructors { get; set; }
     

        public EditViewModel(int Id)
        {
            GetCourses(Id);
            AddInstructors();
            Instructors = new ObservableCollection<Instructor>(App.InstructorRepo.GetItems());
            Removeduplicates();
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
        private void AddInstructors()
        {
            foreach (var instructor in DummyData.AddInstructors())
            {
                App.InstructorRepo.SaveItem(instructor);
            }
        }

        public string SaveCourse()
        {
            App.CoursesRepo.SaveItem(Courses);
            return App.CoursesRepo.StatusMessage;
        }

        public void DeleteCourse()
        {
            App.CoursesRepo.DeleteItem(Courses);
        }
        public void RemoveInstructor(Instructor instructor)
        {
            App.InstructorRepo.DeleteItem(instructor);
            Instructors.Remove(instructor);
            
        }
        private void Removeduplicates()
        {
            var duplicates = Instructors.GroupBy(i => i.InstructorName)//group by name
                .Where(g => g.Count() > 1)//if there are more than one
                .SelectMany(g => g.Skip(1));//skip the first one
            foreach (var Instructors in duplicates)//remove the duplicates
            {
                RemoveInstructor(Instructors);
            }
        }

    }
}
