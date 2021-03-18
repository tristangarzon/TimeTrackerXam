using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.Models;

namespace TimeTrackerApp.Services.Statements
{
    public interface IStatementService
    {
        Task<List<PayStatement>> GetStatementHistoryAsync();
    }
}
