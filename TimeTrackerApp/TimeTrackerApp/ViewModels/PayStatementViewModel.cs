using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerApp.Models;
using TimeTrackerApp.PageModels.Base;

namespace TimeTrackerApp.ViewModels
{
    public class PayStatementViewModel : ExtendedBindableObject
    {
        private double _earnings;
        public double Earnings
        {
            get => _earnings;
            set => SetProperty(ref _earnings, value);
        }

        private double _totalHours;
        public double TotalHours
        {
            get => _totalHours;
            set => SetProperty(ref _totalHours, value);
        }

        private string _payRange;
        public string PayRange
        {
            get => _payRange;
            set => SetProperty(ref _payRange, value);
        }


        public PayStatementViewModel(PayStatement statement)
        {
            PayRange = statement.Start.ToString("MMMM d") + " - " + statement.End.ToString("MMMM d, yyyy");
            Earnings = statement.Amount;
            foreach(var item in statement.WorkItems)
            {
                TotalHours += item.Total.TotalHours;
            }
        }
    }
}
