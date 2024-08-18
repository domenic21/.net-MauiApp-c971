using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class AddAssessmentPage : ContentPage
{
	public AddAssessmentPage(string courseName)
	{
		InitializeComponent();
		CourseName.Text= courseName;
		BindingContext = new AddAssessmentViewModel();

		
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}