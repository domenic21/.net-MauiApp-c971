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

    private async void DegreePlan_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InstructorPage());

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

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var courseId = (int)button.CommandParameter;

        bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this item?", "Yes", "No");
        if (answer)
        {
            // Call the DeleteRecord method in the CoursesRepo
            App.CoursesRepo.DeleteRecord(courseId);

           
            ((DetailsCourseViewModel)BindingContext).RefreshData();
          
        }
    }


    private async void EDIT_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var courseId = (int)button.CommandParameter;

        await Navigation.PushAsync(new EditCoursePage(courseId));
    }

    private async void View_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        int courseId = (int)button.CommandParameter;

        await Navigation.PushAsync(new ViewCoursePage(courseId));

    }
}