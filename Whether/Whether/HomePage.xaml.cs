using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Whether.BusinessLogic;
using Whether.Model;
using Whether.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Whether
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        WeatherViewModel _weatherVM = App.weatherVM;
        public HomePage()
        {
            this.InitializeComponent();
        }

        private async void LoadData()
        {
            try
            {
                var _position = await GeolocationManager.GetPosition();
                //var _position = GeolocationManager.position;
                _weatherVM.Latitude = (float)_position.Coordinate.Latitude;
                _weatherVM.Longitude = (float)_position.Coordinate.Longitude;
                _weatherVM.WeatherData = await WeatherData.GetCurrentWeather(
                            _weatherVM.Latitude,
                            _weatherVM.Latitude);

                RootObject CurrentWeather = _weatherVM.WeatherData;

                if (CurrentWeather.cod == 404)
                {
                    var dialog = new MessageDialog("Unable to get weather at this time");
                    await dialog.ShowAsync();
                }
                else
                {
                    DisplayWeather(CurrentWeather);
                }
            }
            catch (Exception)
            {
                LocationTB.Text = "Unable to get weather at this time.";
            }
        }

        private void DisplayWeather(RootObject vm)
        {
            string icon = string.Format("ms-appx:///Assets/Weather/{0}.png", vm.weather[0].icon);
            resultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            //ResultTextBlock.Text = myWeather.name + " - " + ((int)myWeather.main.temp).ToString() + " -" + myWeather.weather[0].description;

            TemperatureTB.Text = ((int)vm.main.temp).ToString() + "°c";
            DescriptionTB.Text = vm.weather[0].description;
            LocationTB.Text = vm.name + ", " + vm.sys.country;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
             LoadData();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
                LoadData();
        }
    }
}
