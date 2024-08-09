using MauiApp_test.Data;
using MauiApp_test.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DashboardViewModel
    {

        public ObservableCollection<Courses> Courses { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public Courses CurrentCourse { get; set; }

        public int Id { get; set; }
        public DashboardViewModel()
        {
            FillData();
            AddCourses();

            Removeduplicates();
            
        }

        private void FillData()
        {
            var courses =
                App.CoursesRepo.GetItems();
            courses = courses.OrderBy(c => c.StartDate).ToList();
            Courses = new ObservableCollection<Courses>(courses);

        }
        public void AddCourses()
        {
            foreach (var course in DummyData.GetCourses())
            {
                App.CoursesRepo.SaveItem(course);
            }
        }


        public void RemoveCourse(Courses course)
        {
            App.CoursesRepo.DeleteItem(course);
            Courses.Remove(course);
        }

        private void Removeduplicates()
        {
            var duplicates = Courses.GroupBy(c => c.Name) //group by name
                .Where(g => g.Count() > 1)//if there are more than one
                .SelectMany(g => g.Skip(1));//skip the first one
            foreach (var course in duplicates)//remove the duplicates
            {
                RemoveCourse(course);
            }
        }

      

        public void RefreshData()
        {
            Courses.Clear();
          Courses = new ObservableCollection<Courses>(App.CoursesRepo.GetItems());

            Removeduplicates();
            
            
          

        }

    }
}
