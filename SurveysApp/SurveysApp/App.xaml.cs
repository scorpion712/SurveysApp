using StoreApp.WebServices;
using SurveysApp.Services;
using SurveysApp.Services.Interfaces; 
using Xamarin.Forms; 

namespace SurveysApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            #region Dependencies
            DependencyService.Register<IHttpClientAccess, HttpClientAccess>();
            DependencyService.Register<ILoginService, LoginService>();
            #endregion

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
