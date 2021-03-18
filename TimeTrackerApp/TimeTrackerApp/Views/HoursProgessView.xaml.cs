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
    public partial class HoursProgessView : ContentView
    {
        public static readonly BindableProperty MaxProperty = BindableProperty.Create(
            nameof(Max), typeof(double), typeof(HoursProgessView), 80.0d);

        public static readonly BindableProperty MinProperty = BindableProperty.Create(
            nameof(Min), typeof(double), typeof(HoursProgessView), 0.0d);

        public static readonly BindableProperty CurrentProperty = BindableProperty.Create(
            nameof(Current), typeof(double), typeof(HoursProgessView), 0.0d);

        public static readonly BindableProperty BarColorProperty = BindableProperty.Create(
            nameof(BarColor), typeof(Color), typeof(HoursProgessView), Color.Gray);

        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(
            nameof(FillColor), typeof(Color), typeof(HoursProgessView), Color.Blue);

        public Color BarColor
        {
            get => (Color)GetValue(BarColorProperty);
            set => SetValue(BarColorProperty, value);
        }

        public Color FillColor
        {
            get => (Color)GetValue(FillColorProperty);
            set => SetValue(FillColorProperty, value);
        }

        public double Max
        {
            get => (double)GetValue(MaxProperty);
            set => SetValue(MaxProperty, value);
        }

        public double Min
        {
            get => (double)GetValue(MinProperty);
            set => SetValue(MinProperty, value);
        }
        public double Current
        {
            get => (double)GetValue(CurrentProperty);
            set => SetValue(CurrentProperty, value);
        }


        public HoursProgessView()
        {
            InitializeComponent();
        }
    }
}