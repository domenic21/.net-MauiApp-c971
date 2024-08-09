using MauiApp_test.MVVM.ViewModels;


namespace MauiApp_test.MVVM.Views;

public partial class CoursesPage : ContentPage
{
    public CoursesPage(int Term)
    {
        InitializeComponent();
        BindingContext = new CoursesViewModel( Term);
        Termlbl.Text = Term.ToString();
        termEntry.Text = Term.ToString();

        


    }

    public void AddingCourses()
    {
        CoursesViewModel.AddCourses();

    }


    private async void Save_Clicked(object sender, EventArgs e)
    {
        var currentVm = (CoursesViewModel)BindingContext;
        var message = currentVm.SaveCourse();
        await DisplayAlert("Save", message, "OK");
        await Navigation.PushAsync(new Dashboard());
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
