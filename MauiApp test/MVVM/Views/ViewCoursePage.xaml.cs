using MauiApp_test.MVVM.ViewModels;
using Plugin.LocalNotification;
namespace MauiApp_test.MVVM.Views;

public partial class ViewCoursePage : ContentPage
{
    public ViewCoursePage(int Id)
    {
        InitializeComponent();
        BindingContext = new ViewCourseModel(Id);

    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = (ViewCourseModel)BindingContext;
        vm.RefreshData();
    }


    private void edit_perform_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
      

        if (button.CommandParameter is int AssessmentIdPer)
        {
            Navigation.PushAsync(new EditAssessmentPage(AssessmentIdPer));
            Navigation.RemovePage(this);
        }
        else
        {
            DisplayAlert("Error", "Invalid course ID", "OK");
        }
    }

    private async void Delete_perform_Clicked(object sender, EventArgs e)
    {

        var button = sender as ImageButton;
        var AssessmentId = (int)button.CommandParameter;

        bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this item?", "Yes", "No");
        if (answer)
        {
            // Call the DeleteRecord 
            App.AssessmentRepo.DeleteRecord(AssessmentId);
            ((ViewCourseModel)BindingContext).Performance.Clear();
            ((ViewCourseModel)BindingContext).RefreshData();
            await DisplayAlert("Success", "Assessment Deleted", "OK");
            await Navigation.PushAsync(new ViewCoursePage(((ViewCourseModel)BindingContext).Course.Id));
            Navigation.RemovePage(this);
        }
    }

    private void edit_obj_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;


        if (button.CommandParameter is int AssessmentId)
        {
            Navigation.PushAsync(new EditAssessmentPage(AssessmentId));
            Navigation.RemovePage(this);
        }
        else
        {
            DisplayAlert("Error", "Invalid course ID", "OK");
        }
    }

    private async void Delete_obj_Clicked(object sender, EventArgs e)
    {


        var button = sender as ImageButton;
        var AssessmentId = (int)button.CommandParameter;

        bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this item?", "Yes", "No");
        if (answer)
        {
            // Call the DeleteRecord method in the CoursesRepo
            App.AssessmentRepo.DeleteRecord(AssessmentId);


            // ((TermsViewModel)BindingContext).RefreshData();
            ((ViewCourseModel)BindingContext).Objective.Clear();
            ((ViewCourseModel)BindingContext).RefreshData();
            await DisplayAlert("Success", "Assessment Deleted", "OK");
            await Navigation.PushAsync(new ViewCoursePage(((ViewCourseModel)BindingContext).Course.Id));
            Navigation.RemovePage(this);
        }

    }



    private async void AddAssessment2_Clicked(object sender, EventArgs e)
    {
        var Button = (Button)sender;
        if (Button.CommandParameter is string courseName)
        {
            await Navigation.PushAsync(new AddAssessmentPage(courseName));
            Navigation.RemovePage(this);
        }
        else
        {
            await DisplayAlert("Error", "Invalid course ID", "OK");
        }
    }

    private async void AddAssessment1_Clicked(object sender, EventArgs e)
    {
        var Button = (Button)sender;
        if (Button.CommandParameter is string courseName)
        {
            await Navigation.PushAsync(new AddAssessmentPage(courseName));
            Navigation.RemovePage(this);
        }
        else
        {
            await DisplayAlert("Error", "Invalid course ID", "OK");
        }
    }

    private void NotiEndObj_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (ViewCourseModel)BindingContext;

        int notificationId = 100 + currentVm.Objective[0].Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Objective Assessment" + currentVm.Objective[0].Name,
                Description = $"Assessment starts on {currentVm.Objective[0].StartDate:MMMM dd, yyyy} ,ends on {currentVm.Objective[0].EndDate:MMMM dd, yyyy} and due date{currentVm.Objective[0].DueDate:MMMM dd, yyyy} ",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = currentVm.Objective[0].StartDate.AddSeconds(1)
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

    private void NotiStartObj_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (ViewCourseModel)BindingContext;

        int notificationId = 100 + currentVm.Objective[0].Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Objective Assessment  " + currentVm.Objective[0].Name,
                Description = $" starts on {currentVm.Objective[0].StartDate:MMMM dd, yyyy} ",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = currentVm.Objective[0].StartDate.AddSeconds(1)
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

    private void NotiStartPer_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (ViewCourseModel)BindingContext;

        int notificationId = 100 + currentVm.Performance[0].Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Performance Assesment  " + currentVm.Performance[0].Name,
                Description = $" starts on {currentVm.Performance[0].StartDate:MMMM dd, yyyy} and its due on {currentVm.Performance[0].DueDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = currentVm.Performance[0].StartDate.AddSeconds(1)
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

    private void NotiEndPer_Toggled(object sender, ToggledEventArgs e)
    {
        var currentVm = (ViewCourseModel)BindingContext;

        int notificationId = 100 + currentVm.Performance[0].Id;
        if (e.Value)
        {
            //schedule notification
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Performance Assessment " + currentVm.Performance[0].Name,
                Description = $" starts on {currentVm.Performance[0].StartDate:MMMM dd, yyyy} ends on {currentVm.Performance[0].EndDate:MMMM dd, yyyy} and its due on {currentVm.Performance[0].DueDate:MMMM dd, yyyy}",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = currentVm.Performance[0].StartDate.AddSeconds(1)
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