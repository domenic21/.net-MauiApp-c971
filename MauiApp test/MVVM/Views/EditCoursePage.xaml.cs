using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class EditCoursePage : ContentPage
{
    public Courses Course { get; set; } 
    public EditCoursePage(int Id)
    {
        InitializeComponent();
        BindingContext = new EditViewModel(Id);

        App.CoursesRepo.GetItemsById(Id);
        //get the instrucotr names to poblate the picker array

    
      
    }

    private void Save_Clicked(object sender, EventArgs e)
    {
        var currentVm = (EditViewModel)BindingContext;
        var message = currentVm.SaveCourse();
        DisplayAlert("Save", message, "OK");
        Navigation.PushAsync(new Dashboard());

    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        //navigation to the root page

        await Navigation.PopToRootAsync();
        Navigation.RemovePage(this);


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
}
