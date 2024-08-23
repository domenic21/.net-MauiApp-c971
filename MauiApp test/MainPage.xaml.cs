using Plugin.LocalNotification;
using System;

namespace MauiApp_test
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var request = new NotificationRequest
            {
                NotificationId = 100,
                Title = "Course Notification " ,
                Description = $"Course starts on ",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }

            };
            LocalNotificationCenter.Current.Show(request);
        }
    }

}
