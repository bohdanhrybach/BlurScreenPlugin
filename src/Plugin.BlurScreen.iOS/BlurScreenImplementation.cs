using Foundation;
using Plugin.BlurScreen.Abstractions;
using UIKit;
using System.Threading.Tasks;

namespace Plugin.BlurScreen
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    [Preserve(AllMembers = true)]
    public class BlurScreenImplementation : IBlurScreen
    {
        /// <summary>
        /// Blurs entire screen async
        /// </summary>
        public Task BlurAsync()
        {
            var controller = UIApplication.SharedApplication.KeyWindow.RootViewController;
            _blurredView = CreateBlurEffectView(controller);
            controller.View.AddSubview(_blurredView);

            return Task.FromResult(true);
        }

        /// <summary>
        /// Unblurs entire screen
        /// </summary>
        public void Unblur()
        {
            if (_blurredView == null)
            {
                return;
            }

            _blurredView.RemoveFromSuperview();
            _blurredView.Dispose();
            _blurredView = null;
        }

        private UIVisualEffectView CreateBlurEffectView(UIViewController controller)
        {
            var blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
            var blurEffectView = new UIVisualEffectView(blurEffect);
            blurEffectView.Frame = controller.View.Bounds;
            blurEffectView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            return blurEffectView;
        }

        private UIVisualEffectView _blurredView;
    }
}
