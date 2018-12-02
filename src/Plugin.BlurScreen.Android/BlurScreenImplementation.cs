using System.Threading.Tasks;
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
        public Task BlurAsync()
        {
            var source = new TaskCompletionSource<Task>();

            CreateDialog();
            SetupDialog(source);
            ShowDialog();

            return source.Task;
        }

        private void CreateDialog()
        {
            _blurredDialog = new BlurFragmentDialog();
        }

        private void SetupDialog(TaskCompletionSource<Task> source)
        {
            _blurredDialog.BlurCompletionAction = () =>
            {
                source.SetResult(Task.FromResult(true));
            };
        }

        private void ShowDialog()
        {
            var activity = (AppCompatActivity)CrossCurrentActivity.Current.Activity;
            _blurredDialog.Show(activity.SupportFragmentManager, nameof(BlurFragmentDialog));
        }

        /// <summary>
        /// Unblurs entire screen
        /// </summary>
        public void Unblur()
        {
            if (_blurredDialog == null)
            {
                return;
            }

            _blurredDialog.Dismiss();
            _blurredDialog.Dispose();
            _blurredDialog = null;
        }

        private BlurFragmentDialog _blurredDialog;
    }
}
