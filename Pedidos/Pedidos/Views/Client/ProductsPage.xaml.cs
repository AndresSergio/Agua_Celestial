using Pedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos.Views.Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }
        public ProductsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ViewModel = new MainPageViewModel();

            await ViewModel.LoadProducts();
            this.BindingContext = ViewModel;
            
             
        }

        private async void ViewCell_Appearing(object sender, EventArgs e) 
        {
           // efecto para los view cell
            //var cell = sender as ViewCell;
            //var view = cell.View;
            //view.TranslationX = -100;
            //await view.TranslateTo(0,0,250,Easing.SinIn);
        }
    }
}