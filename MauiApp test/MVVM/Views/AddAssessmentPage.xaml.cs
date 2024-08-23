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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //PREVENT NULL VALUES ARE BEING SAVED
        if (string.IsNullOrEmpty(AssessmentName.Text) || string.IsNullOrEmpty(CourseName1.Text))
        {
            await DisplayAlert("Error", "Assessment Name or Course  Name is required", "OK");
            return;
        }
        else if (Start.Date >= End.Date)
        {
            await DisplayAlert("Error", "Start Date must be earlier than End Date", "OK");
            return;
        }
        else if (Due.Date >= End.Date)
        {
            await DisplayAlert("Error", "Due Date must be earlier than End Date", "OK");
            return;
        }
        else
        {
            var currentVm = (AddAssessmentViewModel)BindingContext;

            var message = currentVm.SaveAssessment();
            await DisplayAlert("Status", message, "OK");

            await Navigation.PopAsync();
        }
    }

    private async void ShareNotes_Clicked(object sender, EventArgs e)
    {
        var notes = NotesEntry.Text;
        if (string.IsNullOrEmpty(NotesEntry.Text))
        {
            notes = "No notes available";
        }

        await Share.RequestAsync(new ShareTextRequest
        {
            Text = notes,
            Title = "Share Notes"
        });


    }

    private void DeleteNote_Clicked(object sender, EventArgs e)
    {
        NotesEntry.Text = string.Empty;



    }


}