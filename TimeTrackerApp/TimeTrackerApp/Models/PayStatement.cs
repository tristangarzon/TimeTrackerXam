using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackerApp.Models
{
    public class PayStatement
    {
        
        public DateTime Start { get; set; }//Pay Period Start Date
        public DateTime End { get; set; }//Pay Period End Date
        public DateTime Date { get; set; }//Payout Date for Period
        public double Amount { get; set; }//Payout Amount
        public List<WorkItem> WorkItems { get; set; }//A List of Associated Work Items for the Pay Period
    }
}
