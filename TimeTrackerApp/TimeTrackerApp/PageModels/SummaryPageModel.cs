using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.Models;
using TimeTrackerApp.PageModels.Base;
using TimeTrackerApp.Services.Account;
using TimeTrackerApp.Services.Statements;
using TimeTrackerApp.Services.Work;
using TimeTrackerApp.ViewModels;

namespace TimeTrackerApp.PageModels
{
    public class SummaryPageModel : PageModelBase
    {
        private string _currentPayDateRange;
        public string CurrentPayDateRange
        {
            get => _currentPayDateRange;
            set => SetProperty(ref _currentPayDateRange, value);
        }

        private double _currentPeriodEarnings;
        public double CurrentPeriodEarnings
        {
            get => _currentPeriodEarnings;
            set => SetProperty(ref _currentPeriodEarnings, value);
        }

        private DateTime _currentPeriodPayDate;
        public DateTime CurrentPeriodPayDate
        {
            get => _currentPeriodPayDate;
            set => SetProperty(ref _currentPeriodPayDate, value);
        }


        private List<PayStatementViewModel> _statements;
        public List<PayStatementViewModel> Statements
        {
            get => _statements;
            set => SetProperty(ref _statements, value);
        }

        private IAccountService _accountService;
        private IStatementService _statementService;
        private IWorkService _workService;
        private double _hourlyRate;

        public SummaryPageModel(IStatementService statementService, IWorkService workservice, IAccountService accountService)
        {
            _accountService = accountService;
            _statementService = statementService;
            _workService = workservice;
        }

        public override async Task InitializeAsync(object navigationDate)
        {
            _hourlyRate = await _accountService.GetCurrentPayRateAsync();
            var statements = await _statementService.GetStatementHistoryAsync();
            if(statements != null)
            {
                Statements = statements.Select(s => new PayStatementViewModel(s)).ToList();
                var lastStatement = statements.FirstOrDefault();
                if(lastStatement != null)
                {
                    var today = DateTime.Now;
                    var max = 100;
                    var currentCount = 0;
                    var currentEnd = lastStatement.End;
                    while (lastStatement.End < today && currentCount < max)
                    {
                        currentEnd = currentEnd.AddDays(14);
                        ++currentCount;
                    }
                    if (currentEnd > today)
                    {
                        if (currentEnd.AddDays(-13) < today)
                        {
                            SetDateRange(currentEnd.AddDays(-13), currentEnd);
                        }
                    }
                }
            }

            var currentPeroidItems = await _workService.GetWorkForThisPeriodAsync();
            foreach(var item in currentPeroidItems)
            {
                CurrentPeriodEarnings += item.Total.TotalHours * _hourlyRate;
            }
            await base.InitializeAsync(navigationDate);
        }

        private void SetDateRange(DateTime start, DateTime end)
        {
            CurrentPayDateRange = start.ToString("MMMM d") + " - " + end.ToString("MMMM d, yyyy");
            CurrentPeriodPayDate = end.AddDays(6);
        }
    }
}
