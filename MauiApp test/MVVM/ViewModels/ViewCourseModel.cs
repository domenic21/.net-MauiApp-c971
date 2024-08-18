using MauiApp_test.MVVM.Models;
using MauiApp_test.Data;
using PropertyChanged;
using System.Collections.ObjectModel;


namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
   public  class ViewCourseModel
    {
       
        public Courses Course { get; set; }

        public ObservableCollection<Assessment> Assessments { get; set; }

        public ObservableCollection<Assessment> Objective { get; set; } = new ObservableCollection<Assessment>();
        public ObservableCollection<Assessment> Performance { get; set; } = new ObservableCollection<Assessment>();

        public  bool IsButtonVisibleObj { get; set; }
        public bool IsButtonVisiblePerf { get; set; }

        public bool IconVisible { get; set; }

        public bool IconVisibleObj { get; set; }
        public ViewCourseModel(int Id)
        {
            GetCourse(Id);
            InitAssessments();
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
        //iniciate the list assesments bringing all information from the database
        public void InitAssessments()
        {
            //clean the list
            if (Assessments == null)
            {
                Assessments = new ObservableCollection<Assessment>();

            }
            
            Assessments = new ObservableCollection<Assessment>(App.AssessmentRepo.GetItems());



            FillData();
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
        // Filter the data to match the courseName and create 2 lists, one objective and one performance, and filter them by the courseName
    


        private void FillData()
        {
           
      
            if (Assessments == null)
            {
                // Handle the case where Assessments is null
                Console.WriteLine("Error: Assessments collection is null.");
                return;
            }

            string courseName = GetCourseName(Course.Id);
            // Filter the assessments by CourseName and AssessmentType
            var objectiveAssessments = Assessments
                .Where(assessment => assessment.AssessmentType == AssessmentType.Objective && assessment.CourseName == courseName)
                .ToList();

            var performanceAssessments = Assessments
                .Where(assessment => assessment.AssessmentType == AssessmentType.Performance && assessment.CourseName == courseName)
                .ToList();

            // Clear the current collections before adding new data
            Objective.Clear();
            Performance.Clear();

            // Populate the ObservableCollections
            Objective = new ObservableCollection<Assessment>(objectiveAssessments);
            Performance = new ObservableCollection<Assessment>(performanceAssessments);


        }











    }
}
