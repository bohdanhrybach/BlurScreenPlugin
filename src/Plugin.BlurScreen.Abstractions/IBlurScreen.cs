using System.Threading.Tasks;

namespace Plugin.BlurScreen.Abstractions
{
    /// <summary>
    /// Interface for BlurScreen
    /// </summary>
    public interface IBlurScreen
    {
        /// <summary>
        /// Blurs entire screen async
        /// </summary>
        Task BlurAsync();

        /// <summary>
        /// Unblurs entire screen
        /// </summary>
        void Unblur();
    }
}
