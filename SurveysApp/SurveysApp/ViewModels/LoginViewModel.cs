using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using SurveysApp.PopUps;
using SurveysApp.Services.Interfaces;
using SurveysApp.ViewModels;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SurveysApp.Views
{
    internal class LoginViewModel : ViewModelBase
    {
        #region Constructor
        public LoginViewModel()
        {
            _loginService = DependencyService.Get<ILoginService>();
            LoginCommand = new Command(async () => await LoginActionAsync());
        }

        #endregion

        #region Services
        private readonly ILoginService _loginService;
        #endregion

        #region Attributes
        private string username;
        private string password;

        #endregion

        #region Properties
        public bool IsButtonEnabled
        {
            get { return Username.Length > 0 && Password.Length > 4;}
        }
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsButtonEnabled)); }
        }

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsButtonEnabled)); }
        }

        #endregion

        #region Commands
        public Command LoginCommand { get; }

        #endregion

        #region Methods
        private async Task LoginActionAsync()
        {
            var user = await _loginService.DoLogin(Username, Password);
            if (user != null)
            {
                // if ok save login preferences
                Preferences.Set("user", JsonConvert.SerializeObject(user));
                Preferences.Set("loggedIn", true);
                await Shell.Current.GoToAsync($"//{nameof(SurveyMainPage)}");
            } else
            {
                // show connection error message
                var animationPopup = new MessagePopUp("Ha ocurrido un error", "Ha ocurrido un error al conectar con el servidor. Revise la conexion a internet e intente nuevamente. Si el problema persiste...", true);
                await Shell.Current.Navigation.PushPopupAsync(animationPopup, true);
            }
        }
        #endregion
    }
}