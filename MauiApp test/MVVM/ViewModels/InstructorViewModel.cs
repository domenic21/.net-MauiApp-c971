using System;
using MauiApp_test.Data;
using MauiApp_test.MVVM.Models;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class InstructorViewModel
    {
        public ObservableCollection<Instructor> Instructors { get; set; }

        public Instructor Instructor { get; set; } = new Instructor();

      


        public InstructorViewModel()
        {
            AddInstructors();
            Instructors = new ObservableCollection<Instructor>(App.InstructorRepo.GetItems());
            RemoveDuplicates();
            RefreshData();
            
        }

        private void AddInstructors()
        {
            foreach (var instructor in DummyData.AddInstructors())
            {
                App.InstructorRepo.SaveItem(instructor);
            }
        }

        private void RemoveDuplicates()
        {
            var duplicates = Instructors.GroupBy(i => i.InstructorName)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g.Skip(1));
            foreach (var instructor in duplicates)
            {
                App.InstructorRepo.DeleteItem(instructor);
                Instructors.Remove(instructor);
            }
        }

        public string SaveInstructor()
        {
            App.InstructorRepo.SaveItem(Instructor);
            return App.InstructorRepo.StatusMessage;
        }

        public void RefreshData()
        {
            //clear the list
            Instructors.Clear();
            //add the items

            Instructors = new ObservableCollection<Instructor>(App.InstructorRepo.GetItems());
            
            

        }

      
    }
}
