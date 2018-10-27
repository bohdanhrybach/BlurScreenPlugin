using Android.Runtime;
using Android.Support.V7.App;
using Plugin.BlurScreen.Abstractions;
using Plugin.CurrentActivity;

namespace Plugin.BlurScreen
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    [Preserve(AllMembers = true)]
    public class BlurScreenImplementation : IBlurScreen
    {
        /// <summary>
        /// Blurs entire screen
        /// </summary>
        public void Blur()
        {
            _blurredDialog = new BlurFragmentDialog();

            var activity = (AppCompatActivity)CrossCurrentActivity.Current.Activity;
            _blurredDialog.Show(activity.SupportFragmentManager, nameof(BlurFragmentDialog));
        }

        /// <summary>
        /// Unblurs entire screen
        /// </summary>
        public void Unblur()
        {
            _blurredDialog.Dismiss();
            _blurredDialog.Dispose();
            _blurredDialog = null;
        }

        private BlurFragmentDialog _blurredDialog;
    }
}
