using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace LocationApp
{
    class LocationManager
    {
        public static async Task<Geoposition> GetLocation()    // 비동기 함수는 Task<T> 형태로 반환 해야함
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus != GeolocationAccessStatus.Allowed) throw new Exception();

            var geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 0;     // 위치서비스에서 반환된 데이터의 미터단위 정확도를 설정함

            var position = await geolocator.GetGeopositionAsync();

            return position;
        }
    }
}
