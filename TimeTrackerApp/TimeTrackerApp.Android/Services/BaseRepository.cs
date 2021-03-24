using Android.App;
using Android.Content;
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
using TimeTrackerApp.Droid.ServiceListeners;
using TimeTrackerApp.Services;

namespace TimeTrackerApp.Droid.Services
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IIdentifiable
    {

        public BaseRepository()
        {

        }

        protected abstract string DocumentPath { get; }

        public Task<bool> Delete(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(string id)
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));

            return tcs.Task;
        }

        public Task<IList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}