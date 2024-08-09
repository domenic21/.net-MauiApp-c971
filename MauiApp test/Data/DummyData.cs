
using MauiApp_test.MVVM.Models;

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
                Notifications = true,
                Term = 1

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
                Notifications = true,
                Term = 1
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
                Notifications = true,
                Term = 1
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
                Notifications = true,
                Term = 1
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
                Notifications = true,
                Term = 1
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
                Notifications = true,
                Term = 2
            };
            courses.Add(englishCourse);


            return courses;
        }

        public static List<Terms> GetTerms()
        {
            var terms = new List<Terms>();

            var TermTest = new Terms
            {

                Term = 3,
                TermStart = DateTime.Now,
                TermEnd = DateTime.Parse("12/31/2024"),
                Status = "Active",
                Notify = true,
                TermName = "Fall 2024"
            };
            terms.Add(TermTest);

            var Term1 = new Terms
            {

                Term = 1,
                TermStart = DateTime.Now,
                TermEnd = DateTime.Parse("12/31/2024"),
                Status = "Active",
                Notify = true,
                TermName = "Fall 2025"
            };
            terms.Add(Term1);

            return terms;
        }

        public static List<Instructor> AddInstructors()
        {
            var instructors = new List<Instructor>();

            var instructor1 = new Instructor
            {
                InstructorName = "Anika Patel",
                InstructorPhone = "555-123-4567",
                InstructorEmail = "anika.patel@strimeuniversity.edu"

            };
            instructors.Add(instructor1);
            return instructors;
        }


    }
}
