

using MauiApp_test.MVVM.Models;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EditInstructorViewModel
    {



        public ObservableCollection<Instructor> Instructors { get; set; }

        public Instructor Instructor { get; set; } = new Instructor();




        public EditInstructorViewModel(int Id)
        {
  
            
            LoadInstructor(Id);

        }

      
        public void LoadInstructor(int Id)
        {
            
            List<Instructor> instructorList = App.InstructorRepo.GetItemsById(Id);
            if (instructorList.Count > 0)
            {
                // Populate the Assessments collection with the data from the database 
                Instructor = instructorList[0];

            }
            else
            {
                Instructor = new Instructor();
            }

        }
     

        public string SaveInstructor()
        {
            App.InstructorRepo.SaveItem(Instructor);
            return App.InstructorRepo.StatusMessage;
        }


      

    }

}
