using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerApp.PageModels.Base;

namespace TimeTrackerApp.ViewModels
{
    public class LoginEntryViewModel : ExtendedBindableObject
    {
        private string _placeholder;
        public string Placeholder
        {
            get => _placeholder;
            set => SetProperty(ref _placeholder, value);
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private bool _isPassword;
        public bool IsPassword
        {
            get => _isPassword;
            set => SetProperty(ref _isPassword, value);
        }

        public LoginEntryViewModel(string placeholder, bool isPassword)
        {
            Placeholder = placeholder;
            IsPassword = isPassword;
        }
    }
}
