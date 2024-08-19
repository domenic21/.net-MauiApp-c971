using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;
using MauiApp_test.MVVM.Views;

using System;

namespace MauiApp_test.MVVM.Views;

public partial class AddAssessmentPage : ContentPage
{
	public AddAssessmentPage(string courseName)
	{
		InitializeComponent();
		CourseName.Text= courseName;
		BindingContext = new AddAssessmentViewModel();

		
	}

    private  void Button_Clicked(object sender, EventArgs e)
    {
		var currentVm = (AddAssessmentViewModel)BindingContext;

		var message = currentVm.SaveAssessment();
		DisplayAlert("Status", message, "OK");
    



    }
}