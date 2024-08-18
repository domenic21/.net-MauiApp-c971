
using MauiApp_test.MVVM.Models;
using MauiApp_test.Data;

using System.Collections.ObjectModel;
using PropertyChanged;

namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class EditViewModel
    {
        public Courses Courses { get; set; }

        public ObservableCollection<Instructor> Instructors { get; set; }
     
  

        public ObservableCollection<string> InstructorNames { get; set; }

     

        public EditViewModel(int Id)
        {
            GetCourses(Id);
            AddInstructors();
            Instructors = new ObservableCollection<Instructor>(App.InstructorRepo.GetItems());
            Removeduplicates();
            var instructors = App.InstructorRepo.GetItems();
            InstructorNames = new ObservableCollection<string>(instructors.Select(i => i.InstructorName));
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

        public string SaveCourse()
        {
            App.CoursesRepo.SaveItem(Courses);
            return App.CoursesRepo.StatusMessage;
        }

        public void RefreshData(int Id)
        {
            //clear the list courses
            Instructors.Clear();
             GetCourses(Id);

            
        }
    }
}
