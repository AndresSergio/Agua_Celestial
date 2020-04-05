using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Pedidos.CustomRenderers;
using Pedidos.Droid.CustomRenderers;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(TransparentNavigationPage), typeof(TransparentNavigationRenderer))]
namespace Pedidos.Droid.CustomRenderers
{
    class TransparentNavigationRenderer : NavigationPageRenderer
    {
        public TransparentNavigationRenderer(Context context) : base(context)
        {
        }

        IPageController PageController => Element as IPageController;
        TransparentNavigationPage CustomNavigationPage => Element as TransparentNavigationPage;

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            CustomNavigationPage.IgnoreLayoutChange = true;
            base.OnLayout(changed, l, t, r, b);
            CustomNavigationPage.IgnoreLayoutChange = false;

            int containerHeight = b - t;

            PageController.ContainerArea = new Rectangle(0, 0, Context.FromPixels(r - l), Context.FromPixels(containerHeight));

            for (var i = 0; i < ChildCount; i++)
            {
                Android.Views.View child = GetChildAt(i);

                if (child is Android.Support.V7.Widget.Toolbar)
                {
                    continue;
                }

                child.Layout(0, 0, r, b);
            }
        }
    }
}