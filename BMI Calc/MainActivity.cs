using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace BMI_Calc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView tHeight, tWeight, tResult1, tResult2;
        EditText eHeight, eWeight, eResult1, eResult2;
        Button btConv, btClr;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            tHeight = (TextView)FindViewById(Resource.Id.tvHeight);
            tWeight = (TextView)FindViewById(Resource.Id.tvWeight);
            tResult1 = (TextView)FindViewById(Resource.Id.tvResult1);
            tResult2= (TextView)FindViewById(Resource.Id.tvResult2);
            eHeight = (EditText)FindViewById(Resource.Id.etHeight);
            eWeight = (EditText)FindViewById(Resource.Id.etWeight);
            eResult1 = (EditText)FindViewById(Resource.Id.etResult1);
            eResult2 = (EditText)FindViewById(Resource.Id.etResult2);
            btConv = (Button)FindViewById(Resource.Id.btnConv);
            btClr = (Button)FindViewById(Resource.Id.btnClr);

            btClr.Click += delegate
            {
                eHeight.Text = "";
                eWeight.Text = "";
                eResult1.Text = "";
                eResult2.Text = "";
            };

            btConv.Click += delegate
            {
                if(eHeight.Text != "" && eWeight.Text != "")
                {
                    double res1,eHei, eWei;
                    eHei = double.Parse(eHeight.Text);
                    eWei = double.Parse(eWeight.Text);
                    res1 = Math.Round(eWei / (eHei * eHei), 1);
                    eResult1.Text = res1.ToString();

                    if(res1 <= 18.5)
                    {
                        eResult2.Text = "Underweight";
                    }
                    else if(res1 >18.5 && res1 <= 24.9)
                    {
                        eResult2.Text = "Normal";
                    }
                    else if (res1 >= 25)
                    {
                        eResult2.Text = "Overweight";
                    }
                }
                else
                {
                    Toast.MakeText(this, "Please enter both the height and the weight to continue", ToastLength.Long).Show();
                }

            };



        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

