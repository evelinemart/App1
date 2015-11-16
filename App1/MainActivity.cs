using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Collections;
using System.Collections.Generic;
using Java.Lang;

namespace App1
{
    [Activity(Label = "MainApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
         Color color;       

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            if(Intent.HasExtra("newColor"))
            {
                Bundle b = Intent.GetBundleExtra("newColor");
                byte[] rgb = b.GetByteArray("newColor");
                color = new Color(rgb[0], rgb[1], rgb[2]);
            }
            else
                color = Color.DarkBlue;
            // Get our button from the layout resource,
            // and attach an event to it
            RelativeLayout layout = FindViewById<RelativeLayout>(Resource.Id.Back);
            layout.SetBackgroundColor(color);

            ImageButton bCalc = FindViewById<ImageButton>(Resource.Id.buttonCalc);
            
            
            ImageButton bTasks = FindViewById<ImageButton>(Resource.Id.buttonTasks);
           

            ImageButton bColor = FindViewById<ImageButton>(Resource.Id.buttonColor);
            

            bColor.Click += OpenColorSelector;
            bCalc.Click += OpenCalc;
        }

        private void OpenCalc(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CalculatorActivity));            
            StartActivity(intent);
        }

        private void OpenColorSelector(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ColorSelectActivity));
            Bundle b = new Bundle();
            b.PutByteArray("color", new byte[] { color.R, color.G, color.B });
            intent.PutExtra("color", b);
            StartActivity(intent);

        }
    }
}

