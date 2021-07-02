using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using LibVLCSharp.Forms.Shared;
using Xamarin.Forms;
using Android.Graphics;
using Android.Content;

namespace XanimeX.Droid
{
    [Activity(Label = "XanimeX", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            LibVLCSharpFormsRenderer.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            //Typeface typeface = Typeface.CreateFromAsset(getAssets(), "fonts/" + Font);
            //Typeface.CreateFromAsset(, "FontAwesome5Regular.ttf");
            //var tf = Android.Graphics.Typeface.CreateFromAsset(Assets, "fonts/fontawesome-webfont.ttf");
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}