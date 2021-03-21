using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;
using System.Windows.Input;
using TimeTrackerApp.PageModels.Base;
using Xamarin.Forms;

namespace TimeTrackerApp.ViewModels
{
    public class LoginOptionViewModel : ExtendedBindableObject
    {
        private Color _backgroundColor;
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private ICommand _tapCommand;
        private string v;
        private Action goToPhoneLogin;

        public ICommand TapCommad
        {
            get => _tapCommand;
            set => SetProperty(ref _tapCommand, value);
        }



        public LoginOptionViewModel(string text, Action tapAction, Color bgColor, string icon = "")
        {
            Text = text;
            TapCommad = new Command(tapAction);
            BackgroundColor = bgColor;
            Icon = icon;
        }

        public LoginOptionViewModel(string v, Action goToPhoneLogin)
        {
            this.v = v;
            this.goToPhoneLogin = goToPhoneLogin;
        }
    }
}
