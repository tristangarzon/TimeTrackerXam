using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TimeTrackerApp.Views.SKViews.Base
{
    public abstract class GradientViewBase : SKViewBase
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
            nameof(StartColor), typeof(Color), typeof(GradientViewBase), Color.White);
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
            nameof(EndColor), typeof(Color), typeof(GradientViewBase), Color.White);

        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }

        public GradientViewBase()
        {
            
        }

        protected virtual SKShader CreateGradientShader(SKImageInfo info)
        {
           return SKShader.CreateLinearGradient(
               new SKPoint(info.Width / 2, 0), //Start point (top middle)
               new SKPoint(info.Width / 2, info.Height),
               new SKColor[] { StartColor.ToSKColor(), EndColor.ToSKColor() },
               new float[] { 0, 1 },
               SKShaderTileMode.Repeat);
        }


        protected override void OnPaintSurface(SKImageInfo info, SKCanvas canvas, SKPaint paint)
        {
            paint.Shader = CreateGradientShader(info);

            DrawGradient(info, canvas, paint);
        }

        protected abstract void DrawGradient(SKImageInfo info, SKCanvas canvas, SKPaint paint);

    }
}
