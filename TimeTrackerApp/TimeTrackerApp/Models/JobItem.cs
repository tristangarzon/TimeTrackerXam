using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerApp.Services;

namespace TimeTrackerApp.Models
{
    public class JobItem : IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
    }
}
