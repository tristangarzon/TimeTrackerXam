using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.iOS.Extensions;
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
                    tcs.TrySetResult(snapshot.Convert<T>());
                });
            return tcs.Task;
        }

        public virtual Task<IList<T>> GetAll()
        {
            var tcs = new TaskCompletionSource<IList<T>>();
            var list = new List<T>();
            Firebase.CloudFirestore.Firestore.SharedInstance
                .GetCollection(DocumentPath)
                .GetDocuments((snapshot, error) =>
                {
                    if (error != null)
                    {
                        //Something went wrong
                        tcs.TrySetResult(default);
                        return;
                    }
                    var docs = snapshot.Documents;
                    foreach(var doc in docs)
                    {
                        var item = doc.Convert<T>();
                        list.Add(item);
                        tcs.TrySetResult(list);
                    }
                });

            return tcs.Task;
        }

        public virtual Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}