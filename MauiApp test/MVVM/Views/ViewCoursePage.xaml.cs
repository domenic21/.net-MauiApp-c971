
using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;
namespace MauiApp_test.MVVM.Views;

public partial class ViewCoursePage : ContentPage
{
	public ViewCoursePage(int Id)
	{
		InitializeComponent();
		BindingContext = new ViewCourseModel(Id);

	}


    private void edit_perform_Clicked(object sender, EventArgs e)
    {

    }

    private void Delete_perform_Clicked(object sender, EventArgs e)
    {

    }

    private void edit_obj_Clicked(object sender, EventArgs e)
    {

    }

    private void Delete_obj_Clicked(object sender, EventArgs e)
    {

    }

    

    private async void AddAssesment2_Clicked(object sender, EventArgs e)
    {
        var Button = (Button)sender;
        if (Button.CommandParameter is string courseName )
        {
            await Navigation.PushAsync(new AddAssessmentPage(courseName));
            Navigation.RemovePage(this);
        }
        else
        {
            await DisplayAlert("Error", "Invalid course ID", "OK");
        }
    }

    private async void AddAssesment_Clicked_1(object sender, EventArgs e)
    {
        var Button = (Button)sender;
        if (Button.CommandParameter is string courseName)
        {
            await Navigation.PushAsync(new AddAssessmentPage(courseName));
            Navigation.RemovePage(this);
        }
        else
        {
            await DisplayAlert("Error", "Invalid course ID", "OK");
        }
    }
}