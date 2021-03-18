using System;
using System.Threading.Tasks;
using TimeTrackerApp.PageModels;
using TimeTrackerApp.PageModels.Base;
using TimeTrackerApp.Pages;
using TimeTrackerApp.Services.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTrackerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }

        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();
            return navService.NavigateToAsync<LoginPageModel>();
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
