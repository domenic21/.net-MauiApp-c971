using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;
using Microsoft.Maui.Platform;
using Plugin.LocalNotification;


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
        await Navigation.PopToRootAsync();

    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
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

    private void NotificationStart_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (CoursesViewModel)BindingContext;

        int notificationId = 100 + currentVm.Courses.Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Course Notification " + currentVm.Courses.Name,
                Description = $"Course starts on {currentVm.Courses.StartDate:MMMM dd, yyyy} and ends on {currentVm.Courses.EndDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
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

    private void NotificationEnd_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (CoursesViewModel)BindingContext;

        int notificationId = 100 + currentVm.Courses.Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Course Notification " + currentVm.Courses.Name,
                Description = $"Course  ends on {currentVm.Courses.EndDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = currentVm.Courses.EndDate
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
