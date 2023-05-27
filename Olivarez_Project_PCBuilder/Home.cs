using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace Olivarez_Project_PCBuilder
{
    [Activity(Label = "Home", Theme = "@style/AppTheme")]
    public class Home : AppCompatActivity
    {
        ImageButton btnCreate, btnView, btnEdit, btnDelete;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);

            //Get references
            btnCreate = FindViewById<ImageButton>(Resource.Id.btncreatebuild);
            btnView = FindViewById<ImageButton>(Resource.Id.btnviewbuild);
            btnEdit = FindViewById<ImageButton>(Resource.Id.btneditbuild);
            btnDelete = FindViewById<ImageButton>(Resource.Id.btndeletebuild);

            btnCreate.Click += this.GotoCreate;
            btnView.Click += this.GotoView;
            btnEdit.Click += this.GotoUpdate;
            btnDelete.Click += this.GotoDelete;
        }

        public void GotoCreate(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Create));
            StartActivity(i);
        }

        public void GotoView(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(View));
            StartActivity(i);
        }

        public void GotoUpdate(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Update));
            StartActivity(i);
        }

        public void GotoDelete(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Delete));
            StartActivity(i);
        }
    }
}