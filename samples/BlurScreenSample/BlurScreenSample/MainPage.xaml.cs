using System;
using Xamarin.Forms;
using Plugin.BlurScreen;

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
            await CrossBlurScreen.Current.BlurAsync();

            await DisplayAlert("BlurScreenSample", "Press Ok to unblur screen", "Ok");

            CrossBlurScreen.Current.Unblur();
        }
    }
}
