using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.IO;
using System.Net;

namespace Olivarez_Project_PCBuilder
{
    [Activity(Label = "Create Build", Theme = "@style/AppTheme")]
    public class Create : AppCompatActivity
    {
        EditText txtBuildname;
        TextView txtPrice;
        Spinner spinMboard, spinCpu, spinRam, spinStorage, spinGpu, spinPsu, spinCase;
        Button btnCreate;
        String name = "", mboard = "", cpu = "", ram = "", storage = "", gpu = "", psu = "", pcase = "", res = "", 
            mboard_id = "", cpu_id = "", ram_id = "", storage_id = "", gpu_id = "", psu_id = "", pcase_id = "";
        HttpWebResponse response;
        HttpWebRequest request;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_create);

            txtBuildname = FindViewById<EditText>(Resource.Id.txtcreatebuildname);

            spinMboard = FindViewById<Spinner>(Resource.Id.spincreatemotherboard);
            spinCpu = FindViewById<Spinner>(Resource.Id.spincreatecpu);
            spinRam = FindViewById<Spinner>(Resource.Id.spincreateram);
            spinStorage = FindViewById<Spinner>(Resource.Id.spincreatestorage);
            spinGpu = FindViewById<Spinner>(Resource.Id.spincreategpu);
            spinPsu = FindViewById<Spinner>(Resource.Id.spincreatepsu);
            spinCase = FindViewById<Spinner>(Resource.Id.spincreatecase);

            btnCreate = FindViewById<Button>(Resource.Id.btncreate);

            btnCreate.Click += this.CreateBuild;
        }

        public void CreateBuild(object sender, EventArgs e)
        {
            name = txtBuildname.Text;
            mboard = spinMboard.SelectedItem.ToString();
            cpu = spinCpu.SelectedItem.ToString();
            ram = spinRam.SelectedItem.ToString();
            storage = spinStorage.SelectedItem.ToString();
            gpu = spinGpu.SelectedItem.ToString();
            psu = spinPsu.SelectedItem.ToString();
            pcase = spinCase.SelectedItem.ToString();

            mboard_id = spinMboard.SelectedItemId.ToString();
            cpu_id = spinCpu.SelectedItemId.ToString();
            ram_id = spinRam.SelectedItemId.ToString();
            storage_id = spinStorage.SelectedItemId.ToString();
            gpu_id = spinGpu.SelectedItemId.ToString();
            psu_id = spinPsu.SelectedItemId.ToString();
            pcase_id = spinCase.SelectedItemId.ToString();

            request = (HttpWebRequest)WebRequest.Create("http://192.168.100.7/IT140P/MP/add_record.php?name=" + name + " &mboard=" + mboard + 
                " &cpu=" + cpu + " &ram=" + ram + " &storage=" + storage + " &gpu=" + gpu + " &pc_case=" + pcase + " &psu=" + psu + " &mboard_id=" + mboard_id +
                " &cpu_id=" + cpu_id + " &ram_id=" + ram_id + " &storage_id=" + storage_id + " &gpu_id=" + gpu_id + " &pc_case_id=" + pcase_id + " &psu_id=" + psu_id);
            response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();

            ClearFields();
            Toast.MakeText(this, res, ToastLength.Long).Show();
        }

        public void ClearFields()
        {
            txtBuildname.Text = "";

            spinMboard.SetSelection(0);
            spinCpu.SetSelection(0);
            spinRam.SetSelection(0);
            spinStorage.SetSelection(0);
            spinGpu.SetSelection(0);
            spinPsu.SetSelection(0);
            spinCase.SetSelection(0);
        }
    }
}