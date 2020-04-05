
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Pedidos.ViewModels.Productos;
using Pedidos.Search;

namespace Pedidos.Views.Productos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadMore : ContentPage
    {

        LoadMoreViewModel load = new LoadMoreViewModel();
        
        public LoadMore()
        {
            InitializeComponent();




        }

        public void BUSCAR_Clicked(object sender, EventArgs e)
        {
           //string busc= buscador.Query.ToString();
           // ClienteSearchHandler cli = new ClienteSearchHandler();

           // //load.buscarCliente(busc);
           // cli.buscador();
            
          






        }
    }
}