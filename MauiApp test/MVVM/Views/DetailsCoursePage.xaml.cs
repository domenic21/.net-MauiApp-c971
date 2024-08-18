using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class DetailsCoursePage : ContentPage
{
	public DetailsCoursePage(int Term)
	{
       InitializeComponent();
		BindingContext = new DetailsCourseViewModel(Term); 
        TermNum.Text = Term.ToString();

   

    }

    private void DegreePlan_Clicked(object sender, EventArgs e)
    {
        

    }

    private async void Home_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private  async void AddCourse_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        // Check if CommandParameter is not null and is of type int
        if (button.CommandParameter is int term)
        {
            // Pass the term to the CoursesPage
            await Navigation.PushAsync(new CoursesPage(term));

            // Optionally remove the current page from navigation stack
            Navigation.RemovePage(this);
        }
        else
        {
            // Handle the case where the CommandParameter is not an int
            await DisplayAlert("Error", "Invalid course ID", "OK");
        }



    }

  
}