using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TimeTrackerApp.Views.SKViews.Base
{
    public abstract class SKViewBase : ContentView
    {
        public SKViewBase()
        {
            var canvas = new SKCanvasView();
            canvas.PaintSurface += Canvas_PaintSurface;
            Content = canvas;
        }

        protected abstract void OnPaintSurface(SKImageInfo info, SKCanvas canvas, SKPaint paint);

        private void Canvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKCanvas canvas = e.Surface.Canvas;

            canvas.Clear();

            using(var paint = new SKPaint())
            {
                OnPaintSurface(info, canvas, paint);
            }
        }
    }
}
