using System;
using Android.Graphics.Drawables;
using Android.Runtime;
using Plugin.CurrentActivity;

namespace Plugin.BlurScreen
{
    [Preserve(AllMembers = true)]
    public class BlurFragmentDialog : Android.Support.V4.App.DialogFragment
    {
        public Action BlurCompletionAction { get; set; }

        public override void OnStart()
        {
            base.OnStart();

            var blurredScreenBitmap = BlurUtility.GetBlurredScreen(CrossCurrentActivity.Current.Activity);
            var draw = new BitmapDrawable(Resources, blurredScreenBitmap);
            Dialog.Window.SetBackgroundDrawable(draw);

            BlurCompletionAction?.Invoke();
        }
    }
}
