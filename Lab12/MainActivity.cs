using Android.App;
using Android.Widget;
using Android.OS;
using SALLab12;
using System.Threading.Tasks;

namespace Lab12
{
    [Activity(Label = "designer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private const string Password       =  "i_am_p4$$w02d";
        private const string StudentEmail   =  "i_am_user@mailserver.org";
        TextView ValidacionTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            ValidacionTextView = FindViewById<TextView>(Resource.Id.ValidationTextView);
            //ValidacionAsync();
            MockValidateAsync();

            var ListColors = FindViewById<ListView>(Resource.Id.ColorsListView);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(
                this, 
                Resource.Layout.ListViewItem, 
                Resource.Id.TitleTextView, 
                Resource.Id.HexValueTextView, 
                Resource.Id.ColorImageView);
        }

        private async void ValidacionAsync()
        {
            ServiceClient Seviceclient = new ServiceClient(); // Validation
            string MyDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var Result = await Seviceclient.ValidateAsync(StudentEmail, Password, MyDevice);
            ValidacionTextView.Text = $"{Result.Status}\n{Result.FullName}\n{Result.Token}\n";
        }

        /// <summary>
        /// | Test Validacion XamarinDiplomado3.0 |
        /// </summary>
        private async void MockValidateAsync()
        {
            await Task.Delay(1000);
            ValidacionTextView.Text = $"Mook-Success\nTony Simoes\nMS-0-0-0-00-000-0-1\nXamarinDiplomado3.0-Lab12";
        }
    }
}