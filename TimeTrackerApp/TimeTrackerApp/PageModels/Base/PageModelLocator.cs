using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerApp.Models;
using TimeTrackerApp.Pages;
using TimeTrackerApp.Services;
using TimeTrackerApp.Services.Account;
using TimeTrackerApp.Services.Navigation;
using TimeTrackerApp.Services.Statements;
using TimeTrackerApp.Services.Work;
using TinyIoC;
using Xamarin.Forms;

namespace TimeTrackerApp.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _lookupTable;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _lookupTable = new Dictionary<Type, Type>();

            //Register Pages and Page Models
            Register<DashboardPageModel, DashboardPage>();
            Register<LoginPageModel, LoginPage>();
            Register<LoginEmailPageModel, LoginEmailPage>();
            Register<LoginPhonePageModel, LoginPhonePage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<SettingsPageModel, SettingsPage>();
            Register<SummaryPageModel, SummaryPage>();
            Register<TimeClockPageModel, TimeClockPage>();

            Register<RecentActivityPageModel, RecentActivityPage>();

            // Register Services (Services are registered as Singletons by default)
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IAccountService>(DependencyService.Get<IAccountService>());
            _container.Register<IStatementService, MockStatementService>();
            _container.Register<IWorkService, MockWorkService>();
            //_container.Register(DependencyService.Get<IRepository<WorkItem>>());
            _container.Register(DependencyService.Get<IRepository<TestData>>()); // Regis Test Data, wont need in the future
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _lookupTable[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        //Private Utility Method to Register page and page model for page retrieval by it's specified page model type.
        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _lookupTable.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

    }
}
