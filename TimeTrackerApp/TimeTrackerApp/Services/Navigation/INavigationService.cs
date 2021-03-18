using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.PageModels.Base;

namespace TimeTrackerApp.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation method to push onto the Navi Stack
        /// </summary>
        /// <typeparam name="TPageModelBase"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false)
            where TPageModelBase : PageModelBase;

        /// <summary>
        /// Navi method to pop off the Navi Stack 
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
