

using MauiApp_test.MVVM.Models;
using MauiApp_test.MVVM.ViewModels;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;




namespace MauiApp_test.MVVM.Views;

public partial class EditCoursePage : ContentPage
{
    
    public EditCoursePage(int courseId)
    {
        InitializeComponent();
        BindingContext = new EditViewModel(courseId);

        NavigationPage.SetHasNavigationBar(this, false);

        




    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        var currentVm = (EditViewModel)BindingContext;
        var message = currentVm.SaveCourse();
        await DisplayAlert("Save", message, "OK");

      

        await Navigation.PopToRootAsync();
        Navigation.RemovePage(this);
        await Navigation.PopToRootAsync();
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

            await Navigation.PopToRootAsync();
            Navigation.RemovePage(this);
        }

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

    private void editnotes_Clicked(object sender, EventArgs e)
    {
        //save notes only 
        var currentVm = (EditViewModel)BindingContext;
        var message = currentVm.SaveNote();
        DisplayAlert("Save", message, "OK");

    }

    //notifications switch
    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (EditViewModel)BindingContext;

        int notificationId = 100 + currentVm.Courses.Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId ,
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

    private void notificationEnd_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (EditViewModel)BindingContext;

        int notificationId = 200 + currentVm.Courses.Id;
        if (e.Value)
        {
            //schedule notification
            /*var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Course Notification " + currentVm.Courses.Name,
                Description = $"Course ends on {currentVm.Courses.EndDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1) 
                    
                    
                }
            };*/
            var request2 = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Course Notification " + currentVm.Courses.Name,
                Description = $"Course ends on {currentVm.Courses.EndDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)


                }
            };


            //LocalNotificationCenter.Current.Show(request);

            LocalNotificationCenter.Current.Show(request2);
        }
        else
        {
            //cancel notification
            LocalNotificationCenter.Current.Cancel(notificationId);
        }

    }
}
