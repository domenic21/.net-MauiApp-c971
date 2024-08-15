

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

    private async  void Save_Clicked(object sender, EventArgs e)
    {
        var currentVm = (EditViewModel)BindingContext;
        var message = currentVm.SaveCourse();
        await DisplayAlert("Save", message, "OK");
        await Navigation.PushAsync(new Dashboard());

        Navigation.RemovePage(this);
    
      

    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        //navigation to the root page

        await Navigation.PopToRootAsync();
        Navigation.RemovePage(this);


    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
       
        var courseId = Id.Text;

        bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this item?", "Yes", "No");
        if (answer)
        {
           
            App.CoursesRepo.DeleteRecord(Convert.ToInt32(courseId));

            //  ((DashboardViewModel)BindingContext).RefreshData();
            await Navigation.PushAsync(new Dashboard());
            Navigation.RemovePage(this);
        }
    }
}
