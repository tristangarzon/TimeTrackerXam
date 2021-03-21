using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeTrackerApp.PageModels;
using TimeTrackerApp.PageModels.Base;
using TimeTrackerApp.Services.Account;
using TimeTrackerApp.Services.Navigation;
using TimeTrackerApp.ViewModels;
using Xamarin.Forms;

namespace TimeTrackerApp.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private LoginOptionViewModel _loginEmailViewModel;
        public LoginOptionViewModel LoginEmailViewModel
        {
            get => _loginEmailViewModel;
            set => SetProperty(ref _loginEmailViewModel, value);
        }

        private LoginOptionViewModel _loginPhoneViewModel;
        public LoginOptionViewModel LoginPhoneViewModel
        {
            get => _loginPhoneViewModel;
            set => SetProperty(ref _loginPhoneViewModel, value);
        }

        private INavigationService _navigationService;

        public LoginPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoginPhoneViewModel = new LoginOptionViewModel(
                "Sign in with phone", GoToPhoneLogin,
                Color.FromHex("#02bd7e") //Green Color
                ); 

            LoginEmailViewModel = new LoginOptionViewModel(
                "Sign in with email",
                GoToEmailLogin,
                Color.FromHex("#db4437") //Red Color
                );
        }

        private void GoToEmailLogin()
        {
            _navigationService.NavigateToAsync<LoginEmailPageModel>();
        }

        private void GoToPhoneLogin()
        {
            _navigationService.NavigateToAsync<LoginPhonePageModel>();
        }
    }
}
