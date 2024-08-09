
using MauiApp_test.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;



namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DetailsCourseViewModel
    {
        public int Term { get; set; }
        public ObservableCollection<Courses> CourseList { get; set; }

        public DetailsCourseViewModel(int Term)
        {
            this.Term = Term;
            FillData(Term);

            LimitCourseList();
        }

        private void FillData(int Term)
        {
            var courses = App.CoursesRepo.GetItemsByTerm(Term);
            courses = courses.OrderBy(c => c.Status).ToList();

            CourseList = new ObservableCollection<Courses>();

            foreach (var course in courses.Take(6))
            {
                course.HasCourse = true; // Course is present
                course.IsButtonVisible = false; // No need to show the button
                CourseList.Add(course);
            }

            int emptySlots = 6 - CourseList.Count;
            for (int i = 0; i < emptySlots; i++)
            {
                CourseList.Add(new Courses
                {
                    HasCourse = false, // No course present
                    IsButtonVisible = true,// Show button only on the first empty slot
                    Term = Term
                });
            }
        }

        public void RemoveCourse(Courses course)
        {
            App.CoursesRepo.DeleteItem(course);
            CourseList.Remove(course);
        }




        private void LimitCourseList()
        {
            if (CourseList.Count > 6)
            {
                CourseList = new ObservableCollection<Courses>(CourseList.Take(6));

     
            }
        }
    }
}
