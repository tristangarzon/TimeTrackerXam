using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackerApp.Models;
using UIKit;

namespace TimeTrackerApp.iOS.Services
{
    public class WorkItemRepository : BaseRepository<WorkItem>
    {
        public WorkItemRepository()
        {

        }

        public override string DocumentPath => 
            "users/"
            + Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid
            + "/work";
    }
}