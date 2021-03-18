using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeTrackerApp.PageModels;
using TimeTrackerApp.PageModels.Base;
using TimeTrackerApp.Services.Account;
using TimeTrackerApp.Services.Navigation;
using Xamarin.Forms;

namespace TimeTrackerApp.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get => _loginCommand;
            set => SetProperty(ref _loginCommand, value);
        }

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        private INavigationService _navigationService;
        private IAccountService _accountService;

        public LoginPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;

            //Init our Signin Command
            LoginCommand = new Command(OnSignInAction);
        }

        private async void OnSignInAction()
        {
            var logininAttemp = await _accountService.LoginAsync(Username, Password);

            if (logininAttemp)
            {
                //Navigate to the Dashboard
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }else
            {
                //To Do:  Displat an Alert for Failure
            }

        }
    }
}
