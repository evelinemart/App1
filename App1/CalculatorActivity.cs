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

namespace App1
{
    [Activity(Label = "CalculatorActivity")]
    public class CalculatorActivity : Activity
    {
        string x;
        string y;
        string operation;
        double res;
        Button[] numbers;
        Button[] oper;
        Button getRes;
        TextView resText;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here

            SetContentView(Resource.Layout.Calculator);

            x = "";
            y = "";
            operation = "";
            res = 0;
            numbers = new Button[15];            
            numbers[0] = FindViewById<Button>(Resource.Id.button0);
            numbers[1] = FindViewById<Button>(Resource.Id.button1);
            numbers[2] = FindViewById<Button>(Resource.Id.button2);
            numbers[3] = FindViewById<Button>(Resource.Id.button3);
            numbers[4] = FindViewById<Button>(Resource.Id.button4);
            numbers[5] = FindViewById<Button>(Resource.Id.button5);
            numbers[6] = FindViewById<Button>(Resource.Id.button6);
            numbers[7] = FindViewById<Button>(Resource.Id.button7);
            numbers[8] = FindViewById<Button>(Resource.Id.button8);
            numbers[9] = FindViewById<Button>(Resource.Id.button9);
            oper = new Button[4];
            oper[0] = FindViewById<Button>(Resource.Id.buttonAdd);
            oper[1] = FindViewById<Button>(Resource.Id.buttonSub);
            oper[2] = FindViewById<Button>(Resource.Id.buttonMul);
            oper[3] = FindViewById<Button>(Resource.Id.buttonDel);
            getRes = FindViewById<Button>(Resource.Id.buttonRes);
            Button clear = FindViewById<Button>(Resource.Id.buttonClear);
            ImageButton ib = FindViewById<ImageButton>(Resource.Id.imageButtonBackCalc);
            resText = FindViewById<TextView>(Resource.Id.textViewRes);
            resText.Text = "";
            for(int i = 0; i < 15; i++)
                numbers[i].Click += ClickNum;
            for (int i = 0; i < 4; i++)
                oper[i].Click += ClickOper;
            getRes.Click += ClickGetRes;
            clear.Click += ClickClear;
            ib.Click += BackToMain;
        }

        private void BackToMain(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);            
        }

        private void ClickClear(object sender, EventArgs e)
        {
            x = "";
            y = "";
            operation = "";
            resText.Text = "0";
        }

        private void ClickGetRes(object sender, EventArgs e)
        {
            if (x != "" && operation != "" && y != "")
            {
                int ix;
                int iy;
                if (int.TryParse(x, out ix) && int.TryParse(y, out iy))
                {
                    switch (operation)
                    {
                        case "+":
                            res = ix + iy;
                            break;
                        case "-":
                            res = ix - iy;
                            break;
                        case "*":
                            res = ix * iy;
                            break;
                        case "/":
                            if (y != "0")
                                res = (double)((double)ix / (double)iy);
                            else
                                resText.Text = "Error: divide by zero.";
                            break;
                    }
                    resText.Text += " = " + res.ToString();
                    x = "";
                    y = "";
                    operation = "";                    
                }
                else
                    resText.Text = "Bad arguments.";
            }
        }

        private void ClickOper(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (x != "")
            {
                if (y == "")
                {
                    operation = b.Text;
                    resText.Text += " " + b.Text + " ";
                }  
            }
        }

        private void ClickNum(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (operation == "")
            {
                x += b.Text;
                resText.Text += b.Text;
            }
            else
            {
                y += b.Text;
                resText.Text += b.Text;
            }
        }
    }
}