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
    public class MainPageViewModel : RaizViewModel
    {
        private ObservableCollection<Proveedor> proveedors;

        public ObservableCollection<Proveedor> Proveedors { get => proveedors; set { proveedors = value; OnPropertyChanged(); } } 

        private ObservableCollection<Proveedor> oneproveedor;
        public ICommand SearchCommand { get; set; }
        public ObservableCollection<Proveedor> Oneproveedor { get => oneproveedor; set { oneproveedor = value; OnPropertyChanged(); } }

        public ICommand SelectedItemCommand { get; set; }
        
        public MainPageViewModel()
        {

            SearchCommand = new Command(async (param) =>
            {
                
                var product = param as Proveedor;
                

                if (product != null)
                {
                    this.Oneproveedor = new ObservableCollection<Proveedor>();

                    this.Oneproveedor.Add(new Proveedor() { 
                        nombre_prov = product.nombre_prov,
                        concepto_prov = product.concepto_prov,
                        monto_total_prov = product.monto_total_prov,
                        estado_prov = product.estado_prov });
                }
                else
                {
                    var url = "http://ferreteriaApi.ironthinks.com/api/proveedor/read.php";
                    var service = new HttpHelper<Proveedors>();
                    var products = await service.GetRestServiceDataAsync(url);
                    Oneproveedor = new ObservableCollection<Proveedor>(products.data);
                }
                
            });
            SelectedItemCommand = new Command(async (args) =>
            {
                var item =
                args as Proveedor;
                if (item!=null) {
                    await Shell.Current.GoToAsync($"detalleProveedorPage?idDetallePago={item.cod_prov}");
                }
            });
        }
        public async Task LoadProducts()
        {
            indicador = "True";    
            var url = "http://ferreteriaApi.ironthinks.com/api/proveedor/read.php";
            var service = new HttpHelper<Proveedors>();
            var products = await service.GetRestServiceDataAsync(url);
            Proveedors = new ObservableCollection<Proveedor>(products.data);
            Oneproveedor = new ObservableCollection<Proveedor>(products.data);
            //await Task.Delay(5000);
            indicador = "False";

        }





        //public ObservableCollection<Product> Products { get; set; }
        //public ObservableCollection<Customers> Customers { get; set; }

        //public ICommand SearchCommand { get; set; }
        //public MainPageViewModel()
        //{
        //    SearchCommand = new Command(async (param) =>
        //    {
        //        var product = param as Customers;
        //        if (product != null)
        //        {
        //            string url = $"http://ferreteriaApi.ironthinks.com/api/usuario/read_single.php?nombre_usu={product}";

        //            var service = new HttpHelper<Customers>();
        //            var productos = await service.GetRestServiceDataAsync(url);
        //            Customers = new ObservableCollection<Customers>(productos.data);
        //        }


        //    });
        //}
        //public async Task LoadProducts()
        //{
        //    //var url = "http://ecodeliveryApi.developerscz.com/api/products/read.php";
        //    //var service = new HttpHelper<Products>();
        //    //var products = await service.GetRestServiceDataAsync(url);
        //    //Products = new ObservableCollection<Product>(products.data);
        //}
    }
}
