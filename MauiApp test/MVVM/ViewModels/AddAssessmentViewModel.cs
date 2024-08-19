using PropertyChanged;
using MauiApp_test.MVVM.Models;
using System.Collections.ObjectModel;
using MauiApp_test.Data;


namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AddAssessmentViewModel
    {
        public Assessment Assessment { get; set; } = new Assessment();


        public ObservableCollection<Assessment> Assessments { get; set; }

        public ObservableCollection<AssessmentType> AssessmentTypes { get; set; }

        public AddAssessmentViewModel()
        {
          
            GetAssessments();
            AssessmentTypes = new ObservableCollection<AssessmentType>(GetAssessmentTypes());
        }

        public string SaveAssessment()
        {
            App.AssessmentRepo.SaveItem(Assessment);
            return App.AssessmentRepo.StatusMessage;

        }
        public static List<AssessmentType> GetAssessmentTypes()
        {
            return new List<AssessmentType>
                {
                    AssessmentType.Objective,
                    AssessmentType.Performance
                };
        }
        public void GetAssessments()
        {
            List<Assessment> assessmentsList = App.AssessmentRepo.GetItems();
           
            if (assessmentsList.Count > 0)
            {
                // Populate the Assessments collection with the data from the database 
                Assessments = new ObservableCollection<Assessment>(assessmentsList);
                //remove repeated items based on the assessment name
                Assessments = new ObservableCollection<Assessment>(
                    Assessments.GroupBy(a => a.AssessmentName).Select(g => g.First())
                );
        
            }
            else
            {
                Assessments = new ObservableCollection<Assessment>();
            
            }

        }


    }
}
