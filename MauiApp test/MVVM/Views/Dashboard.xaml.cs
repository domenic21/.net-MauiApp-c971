using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
        InitializeComponent();
		BindingContext = new DashboardViewModel();

	}

    private void Delete_Clicked(object sender, EventArgs e)
    {
       /* var currentVm = (DashboardViewModel)BindingContext;
        var message = currentVm.RemoveCourse(Courses course);
        await DisplayAlert("Save", message, "OK");*/

    }

   

    private void edit_Clicked(object sender, EventArgs e)
    {

    }

    private void Home_Clicked(object sender, EventArgs e)
    {
        

    }

    private void edit_Clicked_1(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var courseId = button.CommandParameter;

        //Navigation.PushAsync(new CoursesPage(courseId));
    }
}