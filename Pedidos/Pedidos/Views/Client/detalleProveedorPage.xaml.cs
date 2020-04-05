using Pedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos.Views.Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("idProv", "idDetallePago")]
    public partial class detalleProveedorPage : ContentPage
    {
        
       
        
        private string idProv1;

        //instanciar el viewmodel
        public DetalleProveedorViewModel vmProv { get; set; }
        public string idProv
        {
            get => idProv1; set
            {
                idProv1 = value;
                //vmProv = new DetalleProveedorViewModel(idProv1);
                //this.BindingContext = vmProv;
            }
        }
        public detalleProveedorPage()
        {
            
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            
            vmProv = new  DetalleProveedorViewModel(idProv1);
            
            await vmProv.CargarDetalleProv(idProv1);
           
            this.BindingContext = vmProv;
            
            
        }
        private async void ViewCell_Appearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;
            view.TranslationX = -100;
            await view.TranslateTo(0, 0, 250, Easing.SinIn);
        }
    }
}