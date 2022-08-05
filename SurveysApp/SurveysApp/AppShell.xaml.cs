using SurveysApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SurveysApp
{
    public partial class AppShell : Shell
    {
        public  AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage),
                typeof(LoginPage));

            Routing.RegisterRoute(nameof(SurveyMainPage),
                typeof(SurveyMainPage));

            Routing.RegisterRoute(nameof(RegistrationPage),
                typeof(RegistrationPage));
        }
    }
}
