using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Android.Gms.Tasks.Task;

namespace TimeTrackerApp.Droid.ServiceListeners
{
    public class OnCreateCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<string> _tcs;

        public OnCreateCompleteListener(TaskCompletionSource<string> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Task task)
        {
            if(task.IsSuccessful)
            {
                if(task.Result is DocumentReference doc)
                {
                    _tcs.TrySetResult(doc.Id);
                    return;
                }
            }
            _tcs.TrySetResult(default);
        }
    }
}