using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.Services;
using UIKit;

namespace TimeTrackerApp.iOS.Services
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IIdentifiable
    {

        public abstract string DocumentPath { get;  }

        public virtual Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> Get(string id)
        {
            var tcs = new TaskCompletionSource<T>();


            Firebase.CloudFirestore.Firestore.SharedInstance
                .GetCollection(DocumentPath)
                .GetDocument(id)
                .GetDocument((snapshot, error) =>
                {
                    if(error != null)
                    {
                        //Something went wrong
                        tcs.TrySetResult(default);
                        return;
                    }
                });
            return tcs.Task;
        }

        public virtual Task<IList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}