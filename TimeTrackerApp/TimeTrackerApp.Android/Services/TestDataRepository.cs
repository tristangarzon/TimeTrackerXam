using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackerApp.Droid.Services;
using TimeTrackerApp.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataRepository))]
namespace TimeTrackerApp.Droid.Services
{
    public class TestDataRepository : BaseRepository<TestData>
    {
        protected override string DocumentPath =>
            "users/"
           + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
           + "/test";
    }
}