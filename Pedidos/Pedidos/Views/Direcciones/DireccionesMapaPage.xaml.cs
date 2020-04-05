using Pedidos.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace Pedidos.Views.Direcciones
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DireccionesMapaPage : ContentPage
	{
        public GeoLocation _GeoLocation = new GeoLocation();
        public DireccionesMapaPage ()
		{
			InitializeComponent();
            configMap();
            moveToActualPosition();
        }
        void configMap()
        {
            mapa.UiSettings.CompassEnabled = true;
            mapa.UiSettings.MyLocationButtonEnabled = true;
            mapa.UiSettings.MapToolbarEnabled = true;
            mapa.MyLocationEnabled = true;
            mapa.FlowDirection = FlowDirection.LeftToRight;
            mapa.MapType = MapType.Street;
        }

        void moveToActualPosition()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await _GeoLocation.getLocationGPS();
                Position _position = new Position(GeoLocation.lat, GeoLocation.lng);
                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(_position, Distance.FromMeters(1000)), true);
            });
        }
    }
}