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
using Android.Graphics;
using Java.Lang;

namespace App1
{
    [Activity(Label = "ColorSelectActivity")]
    public class ColorSelectActivity : Activity
    {
        View col;
        SeekBar r;
        SeekBar g;
        SeekBar b;
        Color color;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.ColorSelect);

            r = FindViewById<SeekBar>(Resource.Id.seekBarR);
            g = FindViewById<SeekBar>(Resource.Id.seekBarG);
            b = FindViewById<SeekBar>(Resource.Id.seekBarB);
            col = FindViewById<View>(Resource.Id.viewColor);
            ImageButton back = FindViewById<ImageButton>(Resource.Id.imageButtonBack);

            Bundle bun = Intent.GetBundleExtra("color");
            byte[] rgb = bun.GetByteArray("color");
            color = new Color(rgb.ElementAt(0), rgb.ElementAt(1), rgb.ElementAt(2));
            col.SetBackgroundColor(color);
            r.Progress = (color.R * 100) / 255;
            g.Progress = (color.G * 100) / 255;
            b.Progress = (color.B * 100) / 255;
            back.Click += BackToMain;
            r.ProgressChanged += UpdateColor;
        }

        private void UpdateColor(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            int colR = (r.Progress * 255) / 100;
            int colG = (g.Progress * 255) / 100;
            int colB = (b.Progress * 255) / 100;
            color = new Color(colR, colG, colB);
            col.SetBackgroundColor(color);
        }

        private void BackToMain(object sender, EventArgs e)
        {
            Intent.Extras.Remove("color");
            Bundle bun = new Bundle();
            bun.PutByteArray("newColor", new byte[] { color.R, color.G, color.B });
            var intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("newColor", bun);
            StartActivity(intent);                        
        }
    }
}