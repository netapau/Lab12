using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab12
{
    [Activity(Label = "Lab12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var ListColors = FindViewById<ListView>(Resource.Id.ColorsListView);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(
                this, 
                Resource.Layout.ListViewItem, 
                Resource.Id.TitleTextView, 
                Resource.Id.HexValueTextView, 
                Resource.Id.ColorImageView);
        }
    }
}

