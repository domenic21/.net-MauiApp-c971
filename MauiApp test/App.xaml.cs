using MauiApp_test.MVVM.Views;
using MauiApp_test.MVVM.Models;
using MauiApp_test.Repositories;

namespace MauiApp_test
{
    public partial class App : Application
    {
        public static BaseRepository<Courses>
            CoursesRepo{ get; private set; }

        public static BaseRepository<Terms>
            TermsRepo{ get; private set; }


        public static BaseRepository<Instructor>
            InstructorRepo{ get; private set; }

    
       
            public App(BaseRepository<Courses> _coursesRepo , BaseRepository<Terms> _termsRepo, 
                BaseRepository<Instructor>_instructor)
            {
                InitializeComponent();
                 CoursesRepo = _coursesRepo;
                 TermsRepo = _termsRepo;
          
               InstructorRepo = _instructor;
                MainPage = new NavigationPage(root: new Dashboard());
            }
        
    }
}
