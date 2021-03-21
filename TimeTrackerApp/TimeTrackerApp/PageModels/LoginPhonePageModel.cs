using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeTrackerApp.PageModels.Base;
using TimeTrackerApp.Services.Account;
using Xamarin.Forms;

namespace TimeTrackerApp.PageModels
{
    public class LoginPhonePageModel : PageModelBase
    {
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private string _code;
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private bool _codeSent;
        public bool CodeSent
        {
            get => _codeSent;
            set => SetProperty(ref _codeSent, value);
        }
        private string _buttonText = "Send Code";
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        private ICommand _nextCommand;
        public ICommand NextCommand
        {
            get => _nextCommand;
            set => SetProperty(ref _nextCommand, value);
        }


        private IAccountService _accountService;
        private bool _codeRequested;

        public LoginPhonePageModel(IAccountService accountService)
        {
            _accountService = accountService;

            NextCommand = new Command(OnNextAction);
        }

        private void OnNextAction(object obj)
        {
            if(_codeRequested)
            {
                // Verify code that user entered
            }
            else
            {
                _codeRequested = true;
                ButtonText = "Verify Code";
                CodeSent = true;
                _accountService.SendOtpCodeAsync(PhoneNumber);
            }
        }
    }
}
