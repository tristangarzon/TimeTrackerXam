using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerApp.Views.SKViews.Base;

namespace TimeTrackerApp.Views.SKViews
{
    public class CircleGradientView : GradientViewBase
    {


        protected override void DrawGradient(SKImageInfo info, SKCanvas canvas, SKPaint paint)
        {
            var radius = Math.Min(info.Width, info.Height) / 2;
            canvas.DrawCircle(info.Width / 2, info.Height / 2, radius, paint);
        }
    }
}
