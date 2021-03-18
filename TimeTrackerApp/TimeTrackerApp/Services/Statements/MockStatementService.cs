using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.Models;

namespace TimeTrackerApp.Services.Statements
{
    public class MockStatementService : IStatementService
    {
        private List<PayStatement> _items;

        public MockStatementService()
        {
            _items = new List<PayStatement>()
            {
                new PayStatement
                {
                    Amount = 14.25,
                    Date = DateTime.Parse("03/12/2021"),
                    Start = DateTime.Parse("02/24/2021"),
                    End = DateTime.Parse("03/06/2020"),
                    WorkItems = new List<WorkItem>
                    {
                        new WorkItem
                        {
                            Start = DateTime.Parse("03/03/2021 12:00:00"),
                            End = DateTime.Parse("03/03/2021 13:00:00")
                        }
                    }
                }
            };
        }

        public Task<List<PayStatement>> GetStatementHistoryAsync()
        {
            return Task.FromResult(_items.OrderByDescending(s => s.Start).ToList());
        }
    }
}
