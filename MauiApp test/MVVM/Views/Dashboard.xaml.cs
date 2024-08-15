using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
        InitializeComponent();
		BindingContext = new DashboardViewModel(); //this is the view model that is being binded to the view
        

    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var courseId = (int)button.CommandParameter;

        bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this item?", "Yes", "No");
        if (answer)
        {
            // Call the DeleteRecord method in the CoursesRepo
            App.CoursesRepo.DeleteRecord(courseId);
           
            ((DashboardViewModel)BindingContext).RefreshData();
        }
    }

   


    private void Home_Clicked(object sender, EventArgs e)
    {
        

    }

    private async void edit_Clicked_1(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var courseId = (int)button.CommandParameter;

        await Navigation.PushAsync(new EditCoursePage(courseId));
       



    }

    private async void DegreePlan_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TermPage());
        
    }

    private async void Instructor_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InstructorPage());
    }
}