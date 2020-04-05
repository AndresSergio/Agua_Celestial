using Pedidos.Models;
using Pedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHeaderxaml : ContentView
    {
        //public static SessionViewModel Session= new SessionViewModel();

        public FlyoutHeaderxaml()
        {
            InitializeComponent();
            this.BindingContext = App.Session;

        }


    }
}