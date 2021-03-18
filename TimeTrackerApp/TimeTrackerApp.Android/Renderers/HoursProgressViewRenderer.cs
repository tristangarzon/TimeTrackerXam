using Android.Content;
using Android.Graphics;
using TimeTrackerApp.Droid.Renderers;
using TimeTrackerApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(HoursProgessView), typeof(HoursProgressViewRenderer))]
namespace TimeTrackerApp.Droid.Renderers
{
    public class HoursProgressViewRenderer : ViewRenderer
    {
        private HoursProgessView _view;

        public HoursProgressViewRenderer(Context context) : base (context)
        {
            SetWillNotDraw(false);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            _view = Element as HoursProgessView;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            var paint = new Paint();
            paint.Color = _view.BarColor.ToAndroid();
            paint.StrokeWidth = Context.ToPixels(5);
            canvas.DrawLine(0, canvas.Height / 2, canvas.Width, canvas.Height / 2, paint);

            var currentProgessWidth = (_view.Current - _view.Min) / (_view.Max - _view.Min);
            paint.Color = _view.FillColor.ToAndroid();
            canvas.DrawLine(0, canvas.Height / 2, (float)(canvas.Width * currentProgessWidth), canvas.Height / 2, paint);
        }

    }
}