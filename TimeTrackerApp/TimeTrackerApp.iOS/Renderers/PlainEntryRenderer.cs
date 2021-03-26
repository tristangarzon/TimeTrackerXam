using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackerApp.iOS.Renderers;
using TimeTrackerApp.Views.Entries;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(PlainEntry), typeof(PlainEntryRenderer))]
namespace TimeTrackerApp.iOS.Renderers
{
    public class PlainEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
}