using System;
using Android.Graphics.Drawables;
using Plugin.CurrentActivity;

namespace Plugin.BlurScreen
{
    public class BlurFragmentDialog : Android.Support.V4.App.DialogFragment
    {
        public override void OnStart()
        {
            base.OnStart();

            var blurredScreenBitmap = BlurUtility.GetBlurrecScreen(CrossCurrentActivity.Current.Activity);
            var draw = new BitmapDrawable(Resources, blurredScreenBitmap);
            Dialog.Window.SetBackgroundDrawable(draw);
        }
    }
}
