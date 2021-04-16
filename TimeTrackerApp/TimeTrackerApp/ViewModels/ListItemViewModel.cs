using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerApp.Models;
using TimeTrackerApp.PageModels.Base;

namespace TimeTrackerApp.ViewModels
{
    public class ListItemViewModel : ExtendedBindableObject
    {
        private string _name;
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        private string _startEnd;
        public string StartEnd { get => _startEnd; set => SetProperty(ref _startEnd, value); }

        private string _date;
        public string Date { get => _date; set => SetProperty(ref _date, value); }

        private double _totalHours;
        public double TotalHours { get => _totalHours; set => SetProperty(ref _totalHours, value); }

        private string _earnings;
        public string Earnings { get => _earnings; set => SetProperty(ref _earnings, value); }

        public ListItemViewModel(WorkItem model)
        {
            StartEnd = $"{model.Start:h:mm:tt} - {model.End:h:mm tt}";
            Date = model.Start.ToString("MMMM d, yyyy");
            TotalHours = model.Total.TotalHours;

            if(model.Job != null)
            {
                Name = model.Job.Name;
                Earnings = $"+{(model.Job.Rate * TotalHours):C}";
            }
            else
            {
                Name = "(undefined)";
                Earnings = "(undefined)";
            }
        }
    }
}
