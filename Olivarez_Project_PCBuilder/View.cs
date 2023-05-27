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
    [Activity(Label = "View Builds", Theme = "@style/AppTheme")]
    public class View : AppCompatActivity
    {
        EditText txtBuildname;
        TextView txtMboard, txtCpu, txtRam, txtStorage, txtGpu, txtPsu, txtCase;
        Button btnSearch;
        String res = "", name = "";
        HttpWebResponse response;
        HttpWebRequest request;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_view);

            txtBuildname = FindViewById<EditText>(Resource.Id.txtviewbuildname);

            txtMboard = FindViewById<TextView>(Resource.Id.txtmotherboard);
            txtCpu = FindViewById<TextView>(Resource.Id.txtcpu);
            txtRam = FindViewById<TextView>(Resource.Id.txtram);
            txtStorage = FindViewById<TextView>(Resource.Id.txtstorage);
            txtGpu = FindViewById<TextView>(Resource.Id.txtgpu);
            txtPsu = FindViewById<TextView>(Resource.Id.txtpsu);
            txtCase = FindViewById<TextView>(Resource.Id.txtcase);
            
            btnSearch = FindViewById<Button>(Resource.Id.btnsearch);

            btnSearch.Click += this.SearchBuild;
        }

        public void SearchBuild(object sender, EventArgs e)
        {
            name = txtBuildname.Text;
            request = (HttpWebRequest)WebRequest.Create("http://192.168.100.7/IT140P/MP/search_record.php?name=" + name);
            response = (HttpWebResponse)request.GetResponse();
            res = response.ProtocolVersion.ToString();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd();

            if (result == "PC Build Not Found")
            {
                Toast.MakeText(this, result, ToastLength.Long).Show();
                ClearFields();
            }
            else
            {
                using JsonDocument doc = JsonDocument.Parse(result);
                JsonElement root = doc.RootElement;
                
                var u1 = root[0];

                txtMboard.Text = u1.GetProperty("Motherboard").ToString();
                txtCpu.Text = u1.GetProperty("CPU").ToString();
                txtRam.Text = u1.GetProperty("RAM").ToString();
                txtStorage.Text = u1.GetProperty("Storage").ToString();
                txtGpu.Text = u1.GetProperty("GPU").ToString();
                txtPsu.Text = u1.GetProperty("PSU").ToString();
                txtCase.Text = u1.GetProperty("PC_Case").ToString();

                Toast.MakeText(this, "PC Build Found", ToastLength.Long).Show();
            }
        }

        public void ClearFields()
        {
            txtBuildname.Text = "";
            txtMboard.Text = "-- --";
            txtCpu.Text = "-- --";
            txtRam.Text = "-- --";
            txtStorage.Text = "-- --";
            txtGpu.Text = "-- --";
            txtPsu.Text = "-- --";
            txtCase.Text = "-- --";
        }
    }
}