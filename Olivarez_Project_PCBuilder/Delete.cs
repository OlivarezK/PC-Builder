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
    [Activity(Label = "Delete Builds", Theme = "@style/AppTheme")]
    public class Delete : AppCompatActivity
    {
        EditText txtBuildname;
        Button btnLocate, btnDelete;
        String name = "", res = "";
        HttpWebResponse response;
        HttpWebRequest request;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_delete);

            txtBuildname = FindViewById<EditText>(Resource.Id.txtdelbuildname);

            btnLocate = FindViewById<Button>(Resource.Id.btndellocate);
            btnDelete = FindViewById<Button>(Resource.Id.btndelete);

            btnDelete.Enabled = false;
            btnDelete.Click += this.DeleteBuild;
            btnLocate.Click += this.LocateBuild;
        }

        public void LocateBuild(object sender, EventArgs e)
        {
            name = txtBuildname.Text;
            request = (HttpWebRequest)WebRequest.Create("http://192.168.100.7/IT140P/MP/locate_record.php?name=" + name);
            response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();

            if(res == "PC Build Located")
            {
                Toast.MakeText(this, res, ToastLength.Long).Show();
                btnDelete.Enabled = true;
                txtBuildname.Enabled = false;
                btnLocate.Enabled = false;
            }
            else
            {
                Toast.MakeText(this, res, ToastLength.Long).Show();
            }
            
        }

        public void DeleteBuild(object sender, EventArgs e)
        {
            request = (HttpWebRequest)WebRequest.Create("http://192.168.100.7/IT140P/MP/delete_record.php?name=" + name);
            response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();

            if (res == "PC Build Deleted")
            {
                Toast.MakeText(this, res, ToastLength.Long).Show();
                txtBuildname.Text = "";
                btnDelete.Enabled = false;
                txtBuildname.Enabled = true;
                btnLocate.Enabled = true;
            }
            else
            {
                Toast.MakeText(this, res, ToastLength.Long).Show();
            }
        }
    }
}