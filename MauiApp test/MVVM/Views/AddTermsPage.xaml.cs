using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class AddTermsPage : ContentPage
{
	public AddTermsPage()
	{
		InitializeComponent();
        BindingContext = new AddTermViewModel();
	
	}

    private async void Save_Clicked(object sender, EventArgs e)
    {
        var currentVm = (AddTermViewModel)BindingContext;

        if (currentVm.Terms.Term != 0)
        {
            var message = currentVm.SaveTerm();
            await DisplayAlert("Save", message, "OK");
            await Navigation.PushAsync(new TermPage());
            Navigation.RemovePage(this);
        }
        else
        {
            await DisplayAlert("Error", "Term cannot be 0", "OK");
        }
    }
}