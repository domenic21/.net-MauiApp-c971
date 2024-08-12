using MauiApp_test.Data;
using MauiApp_test.MVVM.Models;
using System.Collections.ObjectModel;

namespace MauiApp_test.MVVM.ViewModels
{
    public class CoursesViewModel
    {
        public ObservableCollection<Instructor> Instructors { get; set; }
        public Courses Courses { get; set; } = new Courses
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now
        };
        public CoursesViewModel(int term)
        {
            this.Term = Term;
            AddInstructors();
            Instructors = new ObservableCollection<Instructor>(App.InstructorRepo.GetItems());
            Removeduplicates();

        }
        public string SaveCourse()
        {
            App.CoursesRepo.SaveItem(Courses);
            return App.CoursesRepo.StatusMessage;
        }
        public int Term { get; set; }

        //dummy data courses 

        public static void AddCourses()
        {

            foreach (var course in DummyData.GetCourses())
            {
                App.CoursesRepo.SaveItem(course);

            }
        }
        private void AddInstructors()
        {
            foreach (var instructor in DummyData.AddInstructors())
            {
                App.InstructorRepo.SaveItem(instructor);
            }
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


