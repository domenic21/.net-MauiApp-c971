using MauiApp_test.MVVM.ViewModels;
using CommunityToolkit;

namespace MauiApp_test.MVVM.Views;

public partial class AddInstructorPage : ContentPage
{
	public AddInstructorPage()
	{
		InitializeComponent();
		BindingContext = new InstructorViewModel();
	}

    private async  void AddInstructorBtn_Clicked(object sender, EventArgs e)
    {
		var currentVm = (InstructorViewModel)BindingContext;
		var message = currentVm.SaveInstructor();
		await Navigation.PushAsync(new InstructorPage());
		this.Navigation.RemovePage(this);
    }
}