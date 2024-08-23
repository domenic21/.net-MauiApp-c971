
using MauiApp_test.MVVM.Models;
using System;

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
                InstructorName = "John Doe",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = "Active",
                Notes = "This is a dummy course",
           
                Term = 1

            };
            courses.Add(mathematicsCourse);


          return courses;
        }

        public static List<Terms> GetTerms()
        {
            var terms = new List<Terms>();

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
 
           var instructor2 = new Instructor
            {
                InstructorName = "Anika Patel",
                InstructorPhone = "555-123-4567",
                InstructorEmail = "anika.patel@strimeuniversity.edu"

            };
            instructors.Add(instructor2);
            return instructors;
        }

        public static List<Assessment> AddAssesment()
        {
            var assessment = new List<Assessment>();

            var assessment1 = new Assessment
            {
                AssessmentName = "Midterm",
                AssessmentType = AssessmentType.Performance,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                DueDate = DateTime.Now,
                StartDateNotifications = true,
                EndDateNotifications = true,
                NotificationDueDate = true,
                IsButtonVisible = true,
                CourseName = "Mathematics"


            };
            assessment.Add(assessment1);
         

            var assessment2 = new Assessment
            {
                AssessmentName = "Midterm",
                AssessmentType = AssessmentType.Objective,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                DueDate = DateTime.Now,
                StartDateNotifications = true,
                EndDateNotifications = true,
               
                IsButtonVisible = true,
                CourseName = "Mathematics"


            };
            assessment.Add(assessment2);
            return assessment;
        }
    }
}
