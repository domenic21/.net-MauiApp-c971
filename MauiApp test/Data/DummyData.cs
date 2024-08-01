
using MauiApp_test.MVVM.Models;
using SQLitePCL;
using System.ComponentModel;

namespace MauiApp_test.Data
{
    public class DummyData
    {
        public static List<Courses> GetCourses()
        {
            var courses = new List<Courses>();

            var mathematicsCourse = new Courses
            {
                Name = "Mathematics",
                CourseCode = "MTH101",
                InstructorName = "Mr. John Doe",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = "Active",
                Notes = "This is a dummy course",
                Notifications = true
              
            };
            courses.Add(mathematicsCourse);

            var physicsCourse = new Courses
            {
                Name = "Physics",
                CourseCode = "PHY101",
                InstructorName = "Mr. John Doe",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = "Inactive",
                Notes = "This is a dummy course",
                Notifications = true
            };
            courses.Add(physicsCourse);

            var chemistryCourse = new Courses
            {
                Name = "Chemistry",
                CourseCode = "CHM101",
                InstructorName = "Mr. John Doe",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = "Active",
                Notes = "This is a dummy course",
                Notifications = true
            };
            courses.Add(chemistryCourse);

            var biologyCourse = new Courses
            {
                Name = "Biology",
                CourseCode = "BIO101",
                InstructorName = "Mr. John Doe",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = "Inactive",
                Notes = "This is a dummy course",
                Notifications = true
            };
            courses.Add(biologyCourse);

            var computerScienceCourse = new Courses
            {
                Name = "Computer Science",
                CourseCode = "CSC101",
                InstructorName = "Mr. John Doe",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = "Active",
                Notes = "This is a dummy course",
                Notifications = true
            };
            courses.Add(computerScienceCourse);

            var englishCourse = new Courses
            {
                Name = "English",
                CourseCode = "ENG101",
                InstructorName = "Mr. John Doe",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = "Inactive",
                Notes = "This is a dummy course",
                Notifications = true
            };
            courses.Add(englishCourse);
          

            return courses;
        }
        
      
    }
}
