using Android.App;
using Android.Widget;
using Android.OS;
using SALLab12;
using System.Threading.Tasks;

namespace Lab12
{
    [Activity(Label = "Lab12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private const string Password = "i_am_p4$$w02d";
        private const string StudentEmail = "i_am_user@mailserver.org";

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var ValidationText = FindViewById<TextView>(Resource.Id.ValidationTextView);

            ValidationText.Text = await ValidateActivityAsync();
            //ValidationText.Text = await MockValidateAsync();

            var ListColors = FindViewById<ListView>(Resource.Id.ColorsListView);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(
                this, 
                Resource.Layout.ListViewItem, 
                Resource.Id.TitleTextView, 
                Resource.Id.HexValueTextView, 
                Resource.Id.ColorImageView);
        }

        /// <summary>
        /// | Validacion Lab12 XamarinDiplomado 3.0 |
        /// </summary>
        private async Task<string> ValidateActivityAsync()
        {
            ServiceClient Seviceclient = new ServiceClient();

            string MyDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await Seviceclient.ValidateAsync(StudentEmail, Password, MyDevice);
            return $"{Result.Status}\n{Result.FullName}\n{Result.Token}\n";
        }

        /// <summary>
        /// | Test Validacion XamarinDiplomado3.0 |
        /// </summary>
        private async Task<string> MockValidateAsync()
        {
            await Task.Delay(2000);
            return $"Mook-Success\nTony Simoes\n{StudentEmail}\n{Password}\nMS-0-1-2-00-000-0-1\nXamarinDiplomado3.0-Lab12";
        }
    }
}

