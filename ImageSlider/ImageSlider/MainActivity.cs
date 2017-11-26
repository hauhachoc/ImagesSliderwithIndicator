using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
 
using Android.Content.PM;
using Android.Support.V7.App;

namespace ImageSlider
{
    [Activity(Label = "ImageSlider", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            OpenFragment();
        }

        private void OpenFragment()
        {
           var tag = "MyFragment";
            Android.Support.V4.App.Fragment fragment = null;
           fragment = FragKusina.NewInstance();
            if (!string.IsNullOrEmpty(tag))
            {
                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.frameLayout, fragment, tag)
                    .Commit();
            }
        }
    }
}

