using Android.OS;
using Android.App;
using Android.Widget;
using System.Threading.Tasks;
using Com.Epson.Moverio.Btcontrol;

namespace MoverioBt300BasicSample
{
    [Activity(Label = "MoverioBt300BasicSample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        DisplayControl _displayControl;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            //Initialize handlers those using MOVERIO API
            _displayControl = new DisplayControl(ApplicationContext);

            var button2DMode = FindViewById<Button>(Resource.Id.button2DMode);
            var button3DMode = FindViewById<Button>(Resource.Id.button3DMode);
            var buttonMute3sec = FindViewById<Button>(Resource.Id.buttonMute3Sec);
            var checkBoxShowToast = FindViewById<CheckBox>(Resource.Id.checkBoxShowToast);
            var seekBarIntensity = FindViewById<SeekBar>(Resource.Id.seekBarIntensity);


            button2DMode.Click += (_, __) => _displayControl.SetMode(DisplayControl.DisplayMode2d, checkBoxShowToast.Checked);
            button3DMode.Click += (_, __) => _displayControl.SetMode(DisplayControl.DisplayMode3d, checkBoxShowToast.Checked);

            buttonMute3sec.Click += (_, __) => Task.Run(async () =>             
            {
                _displayControl.SetMute(true);
                await Task.Delay(3000);
                _displayControl.SetMute(false);
            });

            seekBarIntensity.ProgressChanged += (_, e) => _displayControl.SetBacklight(e.Progress);            
        }
    }
}

