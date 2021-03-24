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
using TimeTrackerApp.Droid.Extensions;
using TimeTrackerApp.Services;
using Task = Android.Gms.Tasks.Task;

namespace TimeTrackerApp.Droid.ServiceListeners 
{
    public class OnDocumentCompleteListener<T> : Java.Lang.Object, IOnCompleteListener
        where T : IIdentifiable
    {
        private TaskCompletionSource<T> _tcs;

        public OnDocumentCompleteListener(TaskCompletionSource<T> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Task task)
        {
            if(task.IsSuccessful)
            {
                var docObj = task.Result;
                if(docObj is DocumentSnapshot docRef)
                {
                    _tcs.TrySetResult(docRef.Convert<T>());
                    return;
                }
            }
            //Something went wrong
            _tcs.TrySetResult(default);
        }
    }
}