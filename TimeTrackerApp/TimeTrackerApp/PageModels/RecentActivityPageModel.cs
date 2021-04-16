using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerApp.PageModels.Base;
using TimeTrackerApp.Services.Work;
using TimeTrackerApp.ViewModels;
using TimeTrackerApp.ViewModels.Buttons;

namespace TimeTrackerApp.PageModels
{
    public class RecentActivityPageModel : PageModelBase
    {
        private ButtonModel _viewAllModel;
        private IWorkService _workService;

        public ButtonModel ViewAllModel
        {
            get => _viewAllModel;
            set => SetProperty(ref _viewAllModel, value);
        }

        private ButtonModel _clockInModel;
        public ButtonModel ClockInModel
        {
            get => _clockInModel;
            set => SetProperty(ref _clockInModel, value);
        }

        private List<ListItemViewModel> _items;
        public List<ListItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }


        public RecentActivityPageModel(IWorkService workService)
        {
            _workService = workService;

            ViewAllModel = new ButtonModel("View All", OnViewAll);
            ClockInModel = new ButtonModel("CLOCK IN", OnClockIn);
        }
        public override async Task InitializeAsync(object navigationDate)
        {
            var workItems = await _workService.GetWorkForThisPeriodAsync();
            if(workItems != null)
            {
                Items = workItems.Select(w => new ListItemViewModel(w)).ToList();
            }

            await base.InitializeAsync(navigationDate);
        }

        private void OnClockIn()
        {
        }

        private void OnViewAll()
        {
        }
    }
}
