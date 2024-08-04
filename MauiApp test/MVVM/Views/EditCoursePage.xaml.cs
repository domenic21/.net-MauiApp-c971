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
      
    }

}
