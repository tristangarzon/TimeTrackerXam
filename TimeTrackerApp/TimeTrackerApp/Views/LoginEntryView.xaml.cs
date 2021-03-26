using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTrackerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginEntryView : ContentView
    {
        public LoginEntryView()
        {
            InitializeComponent();
            entInput.Focused += EntInput_Focused;
            entInput.Unfocused += EntInput_Focused;
        }

        private async void EntInput_Focused(object sender, FocusEventArgs e)
        {
            if(e.IsFocused)
            {
                await Task.WhenAll(bvUnderLine.FadeTo(1),
                    grdUnderline.ScaleXTo(1));
            }
            else
            {
                await Task.WhenAll(bvUnderLine.FadeTo(0.5),
                    grdUnderline.ScaleXTo(0));    
            }
        }
    }
}