using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.Models;

namespace TimeTrackerApp.Services.Work
{
    public interface IWorkService
    {
        Task<bool> LogWorkAsync(WorkItem item);
        Task<ObservableCollection<WorkItem>> GetTodaysWorkAsync();
        Task<List<WorkItem>> GetWorkForThisPeriodAsync();
    }
}
