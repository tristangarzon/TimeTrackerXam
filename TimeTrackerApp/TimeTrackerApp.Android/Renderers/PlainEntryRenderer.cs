using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Xamarin.Forms;
using TimeTrackerApp.Views.Entries;
using TimeTrackerApp.Droid.Renderers;

[assembly: ExportRenderer(typeof(PlainEntry), typeof(PlainEntryRenderer))]
namespace TimeTrackerApp.Droid.Renderers
{
    public class PlainEntryRenderer : EntryRenderer
    {
        public PlainEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Control.SetBackground(null);
                Control.SetPadding(0, 0, 0, 0);
            }
        }

    }
}