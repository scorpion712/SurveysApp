using Rg.Plugins.Popup.Extensions;
using SurveysApp.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveysApp.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        ICommand closeCommand;
        public MessagePopUp(string title, string body, bool showBtn = false, bool twoBtns = false)
        {
            InitializeComponent();
            TwoButtons = twoBtns;
            PopUpTitle.Text = title;
            PopUpBody.Text = body;
            PopUpDivider.IsVisible = showBtn || twoBtns;
            PopUpBtn.IsVisible = !twoBtns;
            GridBtns.IsVisible = twoBtns;
            if (!String.IsNullOrEmpty(title))
            {
                PopUpBody.Padding = new Thickness(10, 10, 10, 10);
                PopUpBody.Margin = new Thickness(0, 5, 0, 5);
                PopUpTitle.IsVisible = true;
            }
            if (!showBtn && !twoBtns && !String.IsNullOrEmpty(title))
            {
                closeCommand = new Command(async () => ClosePopUp());
                closeCommand.Execute(null);
            }
        }
        private bool _twoButtons = false;
        public bool TwoButtons { get { return _twoButtons; } set { _twoButtons = value; } }

        protected override bool OnBackButtonPressed()
        {
            Shell.Current.Navigation.PopPopupAsync(true);
            return true;
        }

        private async void ClosePopUp()
        {
            await Task.Delay(800);
            try
            {
                await Shell.Current.Navigation.PopPopupAsync(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async void PopUpBtn_Clicked(object sender, EventArgs e)
        {
            if (TwoButtons)
            {
                //MessagingCenter.Send(new ConfirmPopUpData() { Confirm = true }, "ConfirmPopUpData");
                await Shell.Current.Navigation.PopPopupAsync(true);
            }
            else
            {
                //MessagingCenter.Send(new ConfirmPopUpData() { Confirm = true }, "ConfirmPopUpData");
                await Shell.Current.Navigation.PopPopupAsync(true);
            }
        }
        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(new ConfirmPopUpData() { Confirm = false }, "ConfirmPopUpData");
            await Shell.Current.Navigation.PopPopupAsync(true);
        }
    }
}