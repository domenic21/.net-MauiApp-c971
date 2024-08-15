
using MauiApp_test.Data;
using MauiApp_test.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace MauiApp_test.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TermsViewModel
    {
        public ObservableCollection<Terms> Terms { get; set; }

      


        public TermsViewModel()
        {
           FillData();
            Removeduplicates();
           GetTerms();
           RefreshData();
           
        }

        public void FillData()
        {
            var terms = App.TermsRepo.GetItems();
            terms = terms.OrderBy(t => t.Term).ToList();
            Terms = new ObservableCollection<Terms>(terms);
        }
        private void GetTerms()
        {
            foreach (var term in DummyData.GetTerms())
            {
                App.TermsRepo.SaveItem(term);
            }
        }
        private void Removeduplicates()
        {
            var duplicates = Terms.GroupBy(t => t.Term) //group by name
                .Where(g => g.Count() > 1)//if there are more than one
                .SelectMany(g => g.Skip(1));//skip the first one
            foreach (var termId in duplicates)//remove the duplicates
            {
                RemoveTermId(termId);
            }
        }

        public void RemoveTermId(Terms terms)
        {
            App.TermsRepo.DeleteItem(terms);
            Terms.Remove(terms);
        }

        public void RefreshData()
        {
           //clear the list
            Terms.Clear();
            //add the items
            Terms = new ObservableCollection<Terms>(App.TermsRepo.GetItems());
            Removeduplicates();
        }

        


    }
}
