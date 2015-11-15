using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "MainApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ConsoleColor color;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            color = ConsoleColor.Blue;
            // Get our button from the layout resource,
            // and attach an event to it
            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.Back);
            Button button = FindViewById<Button>(Resource.Id.buttonColor);

            button.Click += OpenColorSelector;
        }

        private void OpenColorSelector(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

