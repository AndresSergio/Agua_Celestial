using Pedidos.Models;
using Pedidos.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pedidos.ViewModels
{
    public class DetalleProveedorViewModel : RaizViewModel
    {

        
        public ICommand SelectedItemCommand { get; set; }
        //public ObservableCollection<DetalleProveedor> detallePagos { get; set; } =
        //    new ObservableCollection<DetalleProveedor>();
        private ObservableCollection<DETProveedor> detallePagos;
       

        public ObservableCollection<DETProveedor> DetallePagos { get => detallePagos; set { detallePagos = value; OnPropertyChanged(); } }
        public DetalleProveedorViewModel(string _idProve)
        {
           indicador = "True";
            Isbusy = true;
            Task.Run(async () =>
            {
                await CargarDetalleProv(_idProve);

            });
            Isbusy = false;
           indicador = "False";

        }
        public async Task CargarDetalleProv(string _idProv)
        {

            var url = $"http://ferreteriaApi.ironthinks.com/api/pagoProveedor/read.php?cod_prov='{_idProv}'";
            var service = new HttpHelper<DetalleProveedor>();
            var detalle = await service.GetRestServiceDataAsync(url);
            //  Proveedors = new ObservableCollection<Proveedor>(products.data);
            DetallePagos = new ObservableCollection<DETProveedor>(detalle.data);
           // await Task.Delay(5000);
           
            
        }
    }
}
