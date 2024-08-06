using MauiApp_test.MVVM.Models;
using System.Collections.ObjectModel;



namespace MauiApp_test.MVVM.ViewModels
{

    public class AddTermViewModel
    {
        public Terms Terms { get; set; } = new Terms
        {
            TermStart = DateTime.Now,
            TermEnd = DateTime.Now
        };
        

        public string SaveTerm()
        {
            App.TermsRepo.SaveItem(Terms);
            return App.TermsRepo.StatusMessage;
        }
   




    }
}
