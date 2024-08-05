using MauiTempoAgora.Models;
using MauiTempoAgora.Service;
using Microsoft.Maui.Devices.Sensors;
using System.Diagnostics;


namespace MauiTempoAgora

{
    public partial class MainPage : ContentPage
    {
        CancellationTokenSource _cancelTokenSouce;
        bool _isCheckingLocation;

        string? cidade;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                _cancelTokenSouce = new CancellationTokenSource();

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                Location? location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSouce.Token);

                if (location != null)
                {
                    lbl_latitude.Text = location.Latitude.ToString();
                    lbl_longitude.Text = location.Longitude.ToString();

                    Debug.WriteLine("-------------------------------------------");
                    Debug.WriteLine(location);
                    Debug.WriteLine("-------------------------------------------");

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Erro: Dispositivo Não Suporta", fnsEx.Message, "Ok");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }

}
