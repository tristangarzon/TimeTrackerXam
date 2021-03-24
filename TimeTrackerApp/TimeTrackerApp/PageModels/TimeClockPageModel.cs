﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TimeTrackerApp.Models;
using TimeTrackerApp.PageModels.Base;
using TimeTrackerApp.Services;
using TimeTrackerApp.Services.Account;
using TimeTrackerApp.Services.Work;
using TimeTrackerApp.ViewModels.Buttons;

namespace TimeTrackerApp.PageModels
{
    public class TimeClockPageModel : PageModelBase
    {
        bool _isClockedIn;
        public bool IsClockedIn
        {
            get => _isClockedIn;
            set => SetProperty(ref _isClockedIn, value);
        }

        TimeSpan _runningTotal;
        public TimeSpan RunningTotal
        {
            get => _runningTotal;
            set => SetProperty(ref _runningTotal, value);
        }


        DateTime _currentStartTime;
        public DateTime CurrentStartTime
        {
            get => _currentStartTime;
            set => SetProperty(ref _currentStartTime, value);
        }


        public ObservableCollection<WorkItem> WorkItems
        {
            get => _workItems;
            set => SetProperty(ref _workItems, value);
        }

        double _todaysEarnings;
        public double TodaysEarnings
        {
            get => _todaysEarnings;
            set => SetProperty(ref _todaysEarnings, value);
        }

        ButtonModel _clockInOutButtonModel;
        public ButtonModel ClockInOutButtonModel
        {
            get => _clockInOutButtonModel;
            set => SetProperty(ref _clockInOutButtonModel, value);
        }

        private Timer _timer;
        private ObservableCollection<WorkItem> _workItems;
        private IAccountService _accountService;
        private IWorkService _workService;
        private double _hourlyRate;
        public TimeClockPageModel(IAccountService accountService, 
            IWorkService workService )
        {
            _accountService = accountService;
            _workService = workService;
            ClockInOutButtonModel = new ButtonModel("Clock In", OnClockInOutAction);
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Enabled = false;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunningTotal += TimeSpan.FromSeconds(1);
        }

        public override async Task InitializeAsync(object navigationDate)
        {
            RunningTotal = new TimeSpan();
            _hourlyRate = await _accountService.GetCurrentPayRateAsync();
            WorkItems = await _workService.GetTodaysWorkAsync();
            var result = await PageModelLocator.Resolve<IRepository<TestData>>().Save(new TestData

            {
                Age = 30,
                Amount = 100.0,
                Flag = false,
                Name = "Some Name",
                SomeDate = DateTime.Now
            }) ;
            if(result)
            {

            }
            await base.InitializeAsync(navigationDate);
        }

        private async void OnClockInOutAction()
        {
            if (IsClockedIn)
            {
                _timer.Enabled = false;
                TodaysEarnings += _hourlyRate * RunningTotal.TotalHours;
                RunningTotal = TimeSpan.Zero;
                ClockInOutButtonModel.Text = "Clock In";
                var item = new WorkItem
                {
                    Start = CurrentStartTime,
                    End = DateTime.Now
                };
                WorkItems.Insert(0, item);
                await _workService.LogWorkAsync(item);
            }
            else
            {
                CurrentStartTime = DateTime.Now;
                _timer.Enabled = true;
                ClockInOutButtonModel.Text = "Clock Out";
            }
            IsClockedIn = !IsClockedIn;
        }
    }
}
