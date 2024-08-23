using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class InstructorCourses : ContentPage
{
	public InstructorCourses(string InstructorName)
	{
		InitializeComponent();
        BindingContext = new InstructorCoursesViewModel(InstructorName);
        NavigationPage.SetHasNavigationBar(this, false);

    }


  

    private async void Home_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
        Navigation.RemovePage(this);
    }

    private async void Instructor_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InstructorPage());
        Navigation.RemovePage(this);
    }


    private async void edit_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        int courseId = (int)button.CommandParameter;

        await Navigation.PushAsync(new EditCoursePage(courseId));
        Navigation.RemovePage(this);
    }

    private async void delete_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        int courseId = (int)button.CommandParameter;

        bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this item?", "Yes", "No");
        if (answer)
        {
            // Call the DeleteRecord method in the CoursesRepo
            App.CoursesRepo.DeleteRecord(courseId);

            ((DashboardViewModel)BindingContext).RefreshData();
        }
    }

    private async void View_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        int courseId = (int)button.CommandParameter;
        await Navigation.PushAsync(new ViewCoursePage(courseId));
        Navigation.RemovePage(this);

    }
}