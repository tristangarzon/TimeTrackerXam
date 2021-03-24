using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerApp.Services;

namespace TimeTrackerApp.Models
{
    public class TestData : IIdentifiable
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public double Amount { get; set;  }
        public bool Flag { get; set; }
        public string Name { get; set; }
        public DateTime SomeDate { get; set; }
    }
}
