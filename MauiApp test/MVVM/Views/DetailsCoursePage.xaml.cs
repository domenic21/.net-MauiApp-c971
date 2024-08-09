using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class DetailsCoursePage : ContentPage
{
	public DetailsCoursePage(int Term)
	{
       InitializeComponent();
		BindingContext = new DetailsCourseViewModel(Term); 


   

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
        await Navigation.PushAsync(new CoursesPage());

    }

  
}