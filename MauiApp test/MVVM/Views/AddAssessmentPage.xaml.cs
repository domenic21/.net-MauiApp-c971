using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;
using Plugin.LocalNotification;
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

    private void StartNoti_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (AddAssessmentViewModel)BindingContext;

        int notificationId = 100 + currentVm.Assessment.Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Performance Assessment " + currentVm.Assessment.AssessmentName,
                Description = $" starts on {currentVm.Assessment.StartDate:MMMM dd, yyyy} ends on {currentVm.Assessment.EndDate:MMMM dd, yyyy} and its due on {currentVm.Assessment.DueDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = currentVm.Assessment.StartDate.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
        else
        {
            //cancel notification
            LocalNotificationCenter.Current.Cancel(notificationId);
        }
    }

    private void EndNoti_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (AddAssessmentViewModel)BindingContext;

        int notificationId = 100 + currentVm.Assessment.Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Performance Assessment " + currentVm.Assessment.AssessmentName,
                Description = $" starts on {currentVm.Assessment.StartDate:MMMM dd, yyyy} ends on {currentVm.Assessment.EndDate:MMMM dd, yyyy} and its due on {currentVm.Assessment.DueDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = currentVm.Assessment.EndDate.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
        else
        {
            //cancel notification
            LocalNotificationCenter.Current.Cancel(notificationId);
        }
    }
}