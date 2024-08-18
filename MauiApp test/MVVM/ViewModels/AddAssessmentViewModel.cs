using PropertyChanged;
using MauiApp_test.MVVM.Models;
using System.Collections.ObjectModel;
using MauiApp_test.Data;


namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AddAssessmentViewModel
    {
        public Assessment assessment { get; set; }


        public ObservableCollection<Assessment> Assessments { get; set; }

        public AddAssessmentViewModel()
        {
            

        }

        public string SaveAssessment()
        {
            App.AssessmentRepo.SaveItem(assessment);
            return App.AssessmentRepo.StatusMessage;

        }
     

    }
}
