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
        this.Navigation.RemovePage(this);

    }

    private async void Home_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
        this.Navigation.RemovePage(this);

    }

    private void Edit_Clicked(object sender, EventArgs e)
    {

    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var instructorId = (int)button.CommandParameter;

        bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this item?", "Yes", "No");
        if (answer)
        {
            // Call the DeleteRecord method in the CoursesRepo
            App.InstructorRepo.DeleteRecord(instructorId);
            ((InstructorViewModel)BindingContext).RefreshData();




        }

    }

    private async void AddInstructor_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddInstructorPage());
    }



    private async void View_Courses_Clicked(object sender, EventArgs e)

    {
        var button = sender as Button;
        var instructorName = (string)button.CommandParameter;
        await Navigation.PushAsync(new InstructorCourses(instructorName));

    }
}