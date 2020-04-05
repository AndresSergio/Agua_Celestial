using Pedidos.ViewModels.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos.Views.Ventas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductSelectPage : ContentPage
    {
        LoadMoreViewModel load = new LoadMoreViewModel();
        public ProductSelectPage()
        {
            InitializeComponent();
        }
    }
}