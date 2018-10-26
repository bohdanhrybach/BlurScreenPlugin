namespace Plugin.BlurScreen.Abstractions
{
    /// <summary>
    /// Interface for BlurScreen
    /// </summary>
    public interface IBlurScreen
    {
        /// <summary>
        /// Blurs entire screen
        /// </summary>
        void Blur();

        /// <summary>
        /// Unblurs entire screen
        /// </summary>
        void Unblur();
    }
}
