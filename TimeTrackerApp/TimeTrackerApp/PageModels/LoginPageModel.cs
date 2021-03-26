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

        public LoginEntryViewModel EmailEntryViewModel { get; set; }
        public LoginEntryViewModel PasswordEntryViewModel { get; set; }

        private INavigationService _navigationService;

        public LoginPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            EmailEntryViewModel = new LoginEntryViewModel("email", false);

            PasswordEntryViewModel = new LoginEntryViewModel("password", true);
         
        }

        private void GoToPhoneLogin()
        {
            _navigationService.NavigateToAsync<LoginPhonePageModel>();
        }
    }
}
