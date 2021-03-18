using Firebase.Auth;
using System;
using System.Threading.Tasks;
using TimeTrackerApp.Droid.Services;
using TimeTrackerApp.Services.Account;
using Xamarin.Forms;

[assembly: Dependency(typeof(AccountService))]
namespace TimeTrackerApp.Droid.Services
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
            FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(username, password)
                .ContinueWith((task) => OnAuthCompleted(task, tcs));
            return tcs.Task;
        }

        private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if(task.IsCanceled || task.IsFaulted)
            {
                //Something went wrong
                tcs.SetResult(false);
                return;
            }
            tcs.SetResult(true);
        }
    }
}