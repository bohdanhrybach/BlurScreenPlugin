using System;
using Android.Support.V7.App;
using Plugin.BlurScreen.Abstractions;
using Plugin.CurrentActivity;

namespace Plugin.BlurScreen
{
    public class BlurScreenImplementation : IBlurScreen
    {
        public void Blur()
        {
            _blurredDialog = new BlurFragmentDialog();

            var activity = (AppCompatActivity)CrossCurrentActivity.Current.Activity;
            _blurredDialog.Show(activity.SupportFragmentManager, nameof(BlurFragmentDialog));
        }

        public void Unblur()
        {
            _blurredDialog.Dismiss();
            _blurredDialog.Dispose();
            _blurredDialog = null;
        }

        private BlurFragmentDialog _blurredDialog;
    }
}
