using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;
using MauiApp_test.MVVM.Views;

using System;

namespace MauiApp_test.MVVM.Views;

public partial class EditAssessmentPage : ContentPage
{
	public EditAssessmentPage(int Id)
	{
		InitializeComponent();
        BindingContext = new EditAssessmentViewModel(Id);
 

	}

    private async  void ShareNotes_Clicked(object sender, EventArgs e)
    {
        var notes = NotesEntry.Text;
        if (string.IsNullOrEmpty(NotesEntry.Text))
        {
            notes = "No notes available";
            await DisplayAlert("Error", "Notes Empty ", "OK");
            return;
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

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();


    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
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


            var currentVm = (EditAssessmentViewModel)BindingContext;

            var message = currentVm.SaveAssessment();
            await DisplayAlert("Status", message, "OK");

            await Navigation.PopAsync();
        }
        
    }
}