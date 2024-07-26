
using MauiApp_test.MVVM.Views;

namespace MauiApp_test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Dashboard();
        }
    }
}
