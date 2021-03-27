using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeTrackerApp.PageModels;
using TimeTrackerApp.PageModels.Base;
using TimeTrackerApp.Services.Account;
using TimeTrackerApp.Services.Navigation;
using TimeTrackerApp.ViewModels;
using TimeTrackerApp.ViewModels.Buttons;
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

        public LoginEntryViewModel EmailEntryViewModel { get; set; }
        public LoginEntryViewModel PasswordEntryViewModel { get; set; }

        public ButtonModel ForgotPasswordModel { get; set; }
        public ButtonModel LogInModel { get; set; }
        public ButtonModel UsePhoneModel { get; set; }

        private IAccountService _accountService;
        private INavigationService _navigationService;

        public LoginPageModel(INavigationService navigationService,
            IAccountService accountService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
            EmailEntryViewModel = new LoginEntryViewModel("email", false);
            PasswordEntryViewModel = new LoginEntryViewModel("password", true);

            ForgotPasswordModel = new ButtonModel("forgot password", OnForgotPassword);
            LogInModel = new ButtonModel("LOG IN", OnLogin);
            UsePhoneModel = new ButtonModel("USE PHONE NUMBER", GoToPhoneLogin);
        }

        private async void OnLogin()
        {
            var logininAttemp = await _accountService.LoginAsync(EmailEntryViewModel.Text, PasswordEntryViewModel.Text);

            if (logininAttemp)
            {
                //Navigate to the Dashboard
                await _navigationService.NavigateToAsync<RecentActivityPageModel>();
            }
            else
            {
                //To Do:  Displat an Alert for Failure
            }
        }

        private void OnForgotPassword()
        {
           
        }

        private void GoToPhoneLogin()
        {
            _navigationService.NavigateToAsync<LoginPhonePageModel>();
        }
    }
}
