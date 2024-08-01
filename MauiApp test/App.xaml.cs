using MauiApp_test.MVVM.Views;
using MauiApp_test.MVVM.Models;
using MauiApp_test.Repositories;

namespace MauiApp_test
{
    public partial class App : Application
    {
        public static BaseRepository<Courses>
            CoursesRepo{ get; private set; }
    
       
            public App(BaseRepository<Courses> _coursesRepo)
            {
                InitializeComponent();
                 CoursesRepo = _coursesRepo;
                MainPage = new NavigationPage(root: new Dashboard());
            }
        
    }
}
