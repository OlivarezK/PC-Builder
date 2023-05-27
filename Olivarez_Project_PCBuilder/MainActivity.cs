using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Content;
using Android.Widget;
using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace Olivarez_Project_PCBuilder
{
    [Activity(Label = "PC Builder", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnContinue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Get references
            btnContinue = FindViewById<Button>(Resource.Id.btncontinue);

            btnContinue.Click += this.Continue; 
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void Continue(Object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Home));
            StartActivity(i);
        }
    }
}