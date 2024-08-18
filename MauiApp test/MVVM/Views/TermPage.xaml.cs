using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class TermPage : ContentPage
{
	public TermPage()
	{
		InitializeComponent();
		BindingContext = new TermsViewModel();

	}

    private async void Delete_Clicked(object sender, EventArgs e)
    {

        var button = sender as ImageButton;
        var TermId = (int)button.CommandParameter;

        bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this item?", "Yes", "No");
        if (answer)
        {
            // Call the DeleteRecord method in the CoursesRepo
            App.TermsRepo.DeleteRecord(TermId);
   

          ((TermsViewModel)BindingContext).RefreshData();
        }
    }

    private async  void AddTerm_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTermsPage());

    }

    private async void Home_Clicked(object sender, EventArgs e)
    {

       await Navigation.PopToRootAsync();
        Navigation.RemovePage(this);

    }

    private async void ViewCoursesBtn_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        if (button.CommandParameter is int Term) // Check if the CommandParameter is an int and assign it to the variable  Term
        {
            await Navigation.PushAsync(new DetailsCoursePage(Term));
       
            Navigation.RemovePage(this);
        }
        else
        {
            // Handle the case where the CommandParameter is not an int
            await DisplayAlert("Error", "Invalid course ID", "OK");
        }





    }

   
}