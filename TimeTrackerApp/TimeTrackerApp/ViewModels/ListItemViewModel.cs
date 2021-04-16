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

        public ListItemViewModel(WorkItem model)
        {
            Name = model.JobName;
            StartEnd = $"{model.Start:h:mm:tt} - {model.End:h:mm tt}";
            Date = model.Start.ToString("MMMM d, yyyy");
        }
    }
}
