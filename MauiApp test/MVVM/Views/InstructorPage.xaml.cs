
using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class InstructorPage : ContentPage
{
	public InstructorPage()
	{
		InitializeComponent();
        BindingContext = new InstructorViewModel();

	}

    private async void DegreePlan_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TermPage());

    }

    private async  void Home_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();

    }

    private void Edit_Clicked(object sender, EventArgs e)
    {

    }

    private void Delete_Clicked(object sender, EventArgs e)
    {

    }

    private void AddInstructor_Clicked(object sender, EventArgs e)
    {

    }


}