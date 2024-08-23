
using MauiApp_test.MVVM.ViewModels;

namespace MauiApp_test.MVVM.Views;

public partial class EditInstructoPage : ContentPage
{
    public EditInstructoPage(int Id)
    {
        InitializeComponent();
        BindingContext = new EditInstructorViewModel(Id);
    }

    private async void AddInstructorBtn_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            await DisplayAlert("Error", "Name is required.", "OK");
            return;
        }
        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                await DisplayAlert("Error", error.ToString(), "OK");
            }
            return;
        }
        if (phoneValidator.IsNotValid)
        {
            await DisplayAlert("Error", "Phone number is required in correct format. XXX-XXX-XXXX", "OK");
            return;
        }
        else
        {
            var currentVm = (EditInstructorViewModel)BindingContext;
            var message = currentVm.SaveInstructor();
            await DisplayAlert("Status", message, "OK");

           await Navigation.PushAsync(new InstructorPage());
        }

    }
}