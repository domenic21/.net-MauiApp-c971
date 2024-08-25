using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;
using Plugin.LocalNotification;
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

    private void StartNoti_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (EditAssessmentViewModel)BindingContext;

        int notificationId = 100 + currentVm.Assessments.Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Performance Assessment " + currentVm.Assessments.AssessmentName,
                Description = $" starts on {currentVm.Assessments.StartDate:MMMM dd, yyyy} ends on {currentVm.Assessments.EndDate:MMMM dd, yyyy} and its due on {currentVm.Assessments.DueDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = currentVm.Assessments.StartDate.AddSeconds(1)
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
        var currentVm = (EditAssessmentViewModel)BindingContext;

        int notificationId = 100 + currentVm.Assessments.Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Performance Assessment " + currentVm.Assessments.AssessmentName,
                Description = $" starts on {currentVm.Assessments.StartDate:MMMM dd, yyyy} ends on {currentVm.Assessments.EndDate:MMMM dd, yyyy} and its due on {currentVm.Assessments.DueDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = currentVm.Assessments.EndDate.AddSeconds(1)
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