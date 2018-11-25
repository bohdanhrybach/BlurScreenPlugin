using System;
using Xamarin.Forms;
using Plugin.BlurScreen;
using System.Threading.Tasks;

namespace BlurScreenSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void Handle_BlurScreenPressed(object sender, EventArgs e)
        {
            CrossBlurScreen.Current.Blur();

            await ShowAlert();

            CrossBlurScreen.Current.Unblur();
        }

        private async Task ShowAlert() 
        {
            // NOTE: Some trouble when showing alert on Android
            //       Probably dialog shows quicker than screen blurs
            if (Device.RuntimePlatform == Device.Android)
            {
                await Task.Delay(1000);
            }

            await DisplayAlert("BlurScreenSample", "Press Ok to unblur screen", "Ok");
        }
    }
}
