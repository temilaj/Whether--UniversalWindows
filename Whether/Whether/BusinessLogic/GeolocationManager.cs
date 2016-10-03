using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace Whether.BusinessLogic
{
    class GeolocationManager
    {
        public static Geoposition position;
        public async static Task<Geoposition> GetPosition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus != GeolocationAccessStatus.Allowed)
            //throw new Exception();
            {
                var dialog = new MessageDialog("Please Enable Geolocation services");
                await dialog.ShowAsync();
            }

            var _geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };

            var _position = await _geolocator.GetGeopositionAsync();

            position = _position;

            return _position;
        }
    }
}
