using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackerApp.iOS.Services;
using TimeTrackerApp.Models;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataRepository))]
namespace TimeTrackerApp.iOS.Services
{
    public class TestDataRepository : BaseRepository<TestData>
    {
        public override string DocumentPath =>
              "users/"
            + Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid
            + "/test";
    }
}