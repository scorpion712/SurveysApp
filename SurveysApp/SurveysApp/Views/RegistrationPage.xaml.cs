using SurveysApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveysApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private RegisterViewModel _viewModel;

        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RegisterViewModel();
        }
    }
}