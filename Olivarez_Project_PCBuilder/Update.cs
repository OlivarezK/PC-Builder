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
    [Activity(Label = "Edit Builds", Theme = "@style/AppTheme")]
    public class Update : AppCompatActivity
    {
        EditText txtBuildname;
        Spinner spinMboard, spinCpu, spinRam, spinStorage, spinGpu, spinPsu, spinCase;
        Button btnLocate, btnUpdate;
        String name = "", mboard = "", cpu = "", ram = "", storage = "", gpu = "", psu = "", pcase = "", res = "",
            mboard_id = "", cpu_id = "", ram_id = "", storage_id = "", gpu_id = "", psu_id = "", pcase_id = "";
        HttpWebResponse response;
        HttpWebRequest request;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_update);

            txtBuildname = FindViewById<EditText>(Resource.Id.txtupdatebuildname);

            spinMboard = FindViewById<Spinner>(Resource.Id.spineditmotherboard);
            spinCpu = FindViewById<Spinner>(Resource.Id.spineditcpu);
            spinRam = FindViewById<Spinner>(Resource.Id.spineditram);
            spinStorage = FindViewById<Spinner>(Resource.Id.spineditstorage);
            spinGpu = FindViewById<Spinner>(Resource.Id.spineditgpu);
            spinPsu = FindViewById<Spinner>(Resource.Id.spineditpsu);
            spinCase = FindViewById<Spinner>(Resource.Id.spineditcase);

            btnLocate = FindViewById<Button>(Resource.Id.btnupdatelocate);
            btnUpdate = FindViewById<Button>(Resource.Id.btnupdate);

            DisableWidgets();

            btnLocate.Click += this.LocateBuild;
            btnUpdate.Click += this.UpdateBuild;
        }

        public void LocateBuild(object sender, EventArgs e)
        {
            name = txtBuildname.Text;
            request = (HttpWebRequest)WebRequest.Create("http://192.168.100.7/IT140P/MP/locate_record.php?name=" + name);
            response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();

            if (res == "PC Build Located")
            {
                Toast.MakeText(this, res, ToastLength.Long).Show();

                EnableWidgets();
                FillSpinners();

                txtBuildname.Enabled = false;
                btnLocate.Enabled = false;
            }
            else
            {
                Toast.MakeText(this, res, ToastLength.Long).Show();
            }

        }

        public void UpdateBuild(object sender, EventArgs e)
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

            request = (HttpWebRequest)WebRequest.Create("http://192.168.100.7/IT140P/MP/update_record.php?name=" + name + " &mboard=" + mboard +
                " &cpu=" + cpu + " &ram=" + ram + " &storage=" + storage + " &gpu=" + gpu + " &pc_case=" + pcase + " &psu=" + psu + " &mboard_id=" + mboard_id +
                " &cpu_id=" + cpu_id + " &ram_id=" + ram_id + " &storage_id=" + storage_id + " &gpu_id=" + gpu_id + " &pc_case_id=" + pcase_id + " &psu_id=" + psu_id);
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();
            Toast.MakeText(this, res, ToastLength.Long).Show();

            DisableWidgets();
            ClearFields();
            txtBuildname.Enabled = true;
            btnLocate.Enabled = true;
        }

        public void FillSpinners()
        {
            name = txtBuildname.Text;
            request = (HttpWebRequest)WebRequest.Create("http://192.168.100.7/IT140P/MP/select_records.php?name=" + name);
            response = (HttpWebResponse)request.GetResponse();
            res = response.ProtocolVersion.ToString();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd();

            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            var u1 = root[0];

            spinMboard.SetSelection(Convert.ToInt32(u1.GetProperty("Motherboard").ToString()));
            spinCpu.SetSelection(Convert.ToInt32(u1.GetProperty("CPU").ToString()));
            spinRam.SetSelection(Convert.ToInt32(u1.GetProperty("RAM").ToString()));
            spinStorage.SetSelection(Convert.ToInt32(u1.GetProperty("Storage").ToString()));
            spinGpu.SetSelection(Convert.ToInt32(u1.GetProperty("GPU").ToString()));
            spinPsu.SetSelection(Convert.ToInt32(u1.GetProperty("PSU").ToString()));
            spinCase.SetSelection(Convert.ToInt32(u1.GetProperty("PC_Case").ToString()));
        }

        public void DisableWidgets()
        {
            spinMboard.Enabled = false;
            spinCpu.Enabled = false;
            spinRam.Enabled = false;
            spinStorage.Enabled = false;
            spinGpu.Enabled = false;
            spinPsu.Enabled = false;
            spinCase.Enabled = false;
            btnUpdate.Enabled = false;
        }

        public void EnableWidgets()
        {
            spinMboard.Enabled = true;
            spinCpu.Enabled = true;
            spinRam.Enabled = true;
            spinStorage.Enabled = true;
            spinGpu.Enabled = true;
            spinPsu.Enabled = true;
            spinCase.Enabled = true;
            btnUpdate.Enabled = true;
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