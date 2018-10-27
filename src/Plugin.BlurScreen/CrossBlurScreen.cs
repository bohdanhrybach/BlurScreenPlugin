using System;
using Plugin.BlurScreen.Abstractions;

namespace Plugin.BlurScreen
{
    /// <summary>
    /// Cross platform BlurScreen implementations
    /// </summary>
    public class CrossBlurScreen
    {
        static Lazy<IBlurScreen> implementation 
            = new Lazy<IBlurScreen>(
                () => CreateBlurScreen(),
                System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported 
            => implementation.Value != null;

        /// <summary>
        /// Current plugin implementation to use
        /// </summary>
        public static IBlurScreen Current
        {
            get
            {
                var ret = implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static IBlurScreen CreateBlurScreen()
        {
#if NETSTANDARD1_0
            return null;
#else
            return new BlurScreenImplementation();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException(@"This functionality is not implemented in the portable version of this assembly. You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
}
