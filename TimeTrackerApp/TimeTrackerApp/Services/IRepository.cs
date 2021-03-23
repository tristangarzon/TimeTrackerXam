using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackerApp.Services
{
    public interface IIdentifiable
    {
        string Id { get; }
    }

   public interface IRepository<T> where T : IIdentifiable
    {
        Task<T> Get(string id);
        Task<IList<T>> GetAll();
        Task<bool> Save();
        Task<bool> Delete();
    }
}
