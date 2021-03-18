using Firebase.Auth;
using FirebaseAdmin.Auth;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.iOS.Services;
using TimeTrackerApp.Services.Account;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AccountService))]
namespace TimeTrackerApp.iOS.Services
{
    public class AccountService : IAccountService
    {
        public AccountService()
        {

        }

        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(10d);
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            FirebaseAuth.DefaultInstance.GenerateSignInWithEmailLinkAsync(username, null)
                .ContinueWith((task) => OnAuthCompleted(task, tcs));
            return tcs.Task;
        }

        private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                //Something went wrong
                tcs.SetResult(false);
                return;
            }
            tcs.SetResult(true);
        }
    }
}