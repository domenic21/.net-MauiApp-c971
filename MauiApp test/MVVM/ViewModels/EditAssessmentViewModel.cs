using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MauiApp_test.MVVM.Models;
using PropertyChanged;

namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EditAssessmentViewModel
    {
      
        public  Assessment Assessments { get; set; }

        public ObservableCollection<AssessmentType> AssessmentTypes { get; set; }
        public EditAssessmentViewModel(int Id)
        {
            GetAssessments(Id);
            AssessmentTypes = new ObservableCollection<AssessmentType>(GetAssessmentTypes());
           
        }

        public void GetAssessments(int Id)
        {
            //retrieve the assessment based on the Id
            List<Assessment> assessmentsList = App.AssessmentRepo.GetItemsById(Id);
            if (assessmentsList.Count > 0)
            {
                // Populate the Assessments collection with the data from the database 
                Assessments = assessmentsList[0];
             
            }
            else
            {
               
                Assessments = new Assessment();
            }

        }
        public static List<AssessmentType> GetAssessmentTypes()
        {
            return new List<AssessmentType>
                {
                    AssessmentType.Objective,
                    AssessmentType.Performance
                };
        }
        public string SaveAssessment()
        {
            App.AssessmentRepo.SaveItem(Assessments);
            return App.AssessmentRepo.StatusMessage;

        }


    }
}
