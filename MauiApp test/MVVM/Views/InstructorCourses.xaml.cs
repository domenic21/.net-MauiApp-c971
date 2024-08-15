using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class InstructorCourses : ContentPage
{
	public InstructorCourses(string InstructorName)
	{
		InitializeComponent();
        BindingContext = new InstructorCoursesViewModel(InstructorName);

	}


  

    private void Home_Clicked(object sender, EventArgs e)
    {

    }

    private void Instructor_Clicked(object sender, EventArgs e)
    {

    }
}