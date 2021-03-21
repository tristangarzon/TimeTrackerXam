using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackerApp.Services.Account
{
    public class MockAccountService : IAccountService
    {
        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(14.25);
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            //Set for now, will login in the user regardless of what is entered into the username / password
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult(false);
            }
            return Task.Delay(1000).ContinueWith((task) => true);
        }

        public Task<bool> SendOtpCodeAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyOtpCodeAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
