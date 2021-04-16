using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.Models;

namespace TimeTrackerApp.Services.Work
{
    public class MockWorkService : IWorkService
    {
        public List<WorkItem> Items { get; set; }

        private JobItem _job;

        public MockWorkService()
        {
            Items = new List<WorkItem>();
            _job = new JobItem
            {
                Id = "1",
                Name = "Default Name",
                Rate = 30.25
            };
        }

        public Task<bool> LogWorkAsync(WorkItem item)
        {
            Items.Add(item);
            return Task.FromResult(true);
        }

        public Task<ObservableCollection<WorkItem>> GetTodaysWorkAsync()
        {
            return Task.FromResult(new ObservableCollection<WorkItem>(Items)); 
        }

        public Task<List<WorkItem>> GetWorkForThisPeriodAsync()
        {
            return Task.FromResult(new List<WorkItem>
            {
                new WorkItem
                {
                    Start = DateTime.Now.AddDays(-2),
                    End = DateTime.Now.AddDays(-2).AddHours(1),
                    Job = _job
                },
                new WorkItem
                {
                    Start = DateTime.Now.AddDays(-1),
                    End = DateTime.Now.AddDays(-1).AddHours(1),
                    Job = _job
                }, 
            });
        }
    }
}
