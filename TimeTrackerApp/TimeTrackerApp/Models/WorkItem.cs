using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackerApp.Models
{
   public class WorkItem
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Total
        {
            get => End - Start;
        }
    }
}
