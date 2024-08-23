using MauiApp_test.Data;
using MauiApp_test.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System;
using System.Collections.Generic;



namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ViewCourseModel 
    {

        public Courses Course { get; set; }

        public ObservableCollection<Assessment> Assessments { get; set; }

        public ObservableCollection<Assessment> Objective { get; set; } = new ObservableCollection<Assessment>();
        public ObservableCollection<Assessment> Performance { get; set; } = new ObservableCollection<Assessment>();

        public bool IsButtonVisibleObj { get; set; }
        public bool IsButtonVisiblePerf { get; set; }

        public bool IconVisible { get; set; }

        public bool IconVisibleObj { get; set; }

        // Property to hold all the enum values for binding
        public ObservableCollection<AssessmentType> AssessmentTypes { get; set; }

        /// 

        public ViewCourseModel(int Id)
        {
            GetCourse(Id);
            AssessmentMaxFilter();
            CheckButton();
            AddAssessment();
         
         
        }

    


        public void GetCourse(int Id)
        {
            List<Courses> coursesList = App.CoursesRepo.GetItemsById(Id);
            if (coursesList.Count > 0)
            {
                Course = coursesList[0];
            }
            else
            {
                Course = new Courses();

            }

        }

        public void AddAssessment()
        {
            if (Assessments == null)
            {
                Assessments = new ObservableCollection<Assessment>();
            }

            foreach (var assessment in DummyData.AddAssesment())
            {
                App.AssessmentRepo.SaveItem(assessment);
                Assessments.Add(assessment);
            }
            //add dummy data assesment by type to the other lists to test the filter
            string courseName = GetCourseName(Course.Id);
            foreach (var assessment in DummyData.AddAssesment())
            {
                App.AssessmentRepo.SaveItem(assessment);
                // Clear the current collections before adding new data
                //Objective.Clear();
                //Performance.Clear();
                if (assessment.AssessmentType == AssessmentType.Objective && assessment.CourseName == courseName)
                {
                    Objective.Add(assessment);
                    //if Performance is empty put button visible to true to show the button

                }

                if (assessment.AssessmentType == AssessmentType.Performance && assessment.CourseName == courseName)
                {
                    Performance.Add(assessment);


                }
                CheckButton();


            }

        }
        /// 
        public void AssessmentMaxFilter()
        {
            if (Assessments == null)
            {
                Assessments = new ObservableCollection<Assessment>();
            }

            // Retrieve assessments from the database
            List<Assessment> assessments1 = App.AssessmentRepo.GetItems();
            // Remove repeated items based on the assessment name
            List<Assessment> assessmentsList = assessments1.GroupBy(a => a.AssessmentName).Select(g => g.Last()).ToList();

            //then add the filtered items to the collection 

            // Save the retrieved assessments to the Assessments collection
            foreach (var assessment in assessmentsList)
            {

                App.AssessmentRepo.SaveItem(assessment);
                Assessments.Add(assessment);
            }

            // Filter and add assessments to the Objective and Performance collections based on the course name
            string courseName = GetCourseName(Course.Id);
            foreach (var assessment in assessmentsList)
            {
                if (assessment.AssessmentType == AssessmentType.Objective && assessment.CourseName == courseName)
                {
                    Objective.Add(assessment);
                }

                if (assessment.AssessmentType == AssessmentType.Performance && assessment.CourseName == courseName)
                {
                    Performance.Add(assessment);
                }
            }

            CheckButton();
        }



        //button control check function to show the button if the performance list is empty
        public void CheckButton()
        {
            if (Performance.Count == 0)
            {
                IsButtonVisiblePerf = true;
            }
            else
            {
                IsButtonVisiblePerf = false;
                IconVisible = true;
            }
            if (Objective.Count == 0)
            {
                IsButtonVisibleObj = true;
            }
            else
            {
                IsButtonVisibleObj = false;
                IconVisibleObj = true;
            }
        }
    





        //get courseName by the passes courseId
        public string GetCourseName(int Id)
        {
            List<Courses> coursesList = App.CoursesRepo.GetItemsById(Id);
            if (coursesList.Count > 0)
            {
                return coursesList[0].Name;
            }
            else
            {
                return "";
            }
        }
        
        //refresh the data
        public void RefreshData()
        {
            // Clear the current collections before adding new data
          
            Objective.Clear();
            Performance.Clear();
            AssessmentMaxFilter();
        }

    }
}
