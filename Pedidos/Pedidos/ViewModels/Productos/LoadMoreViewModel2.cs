using Pedidos.Models.Productos;
using Pedidos.Search;
using Pedidos.Services;
using Pedidos.Views.Productos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;



namespace Pedidos.ViewModels.Productos
{//dbhielo
    [Preserve(AllMembers = true)]
    public class LoadMoreViewModel2 : INotifyPropertyChanged
    {
        private int totalItems = 22;
        private ProductRepository productRepository;
        //mi clase
        private ProductoSe productos;


        private int totalOrderedItems = 0;
        private double totalPrice = 0;
        private bool isVisible;
        private ObservableCollection<ProductoSe> productos2;
        private ObservableCollection<ProductoSe> orders2;

        public bool Isvisible
        {
            get { return isVisible; }
            set { isVisible = value; RaisePropertyChanged("Isvisible"); }
        }

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> Products1 { get; set; }
        public ObservableCollection<Product> Orders { get; set; }
        public ObservableCollection<ProductoSe> Productos2 { get => productos2; set { productos2 = value; RaisePropertyChanged("Productos2"); } }
        public ObservableCollection<ProductoSe> Productos22 { get; set; }
        public ObservableCollection<ProductoSe> Orders2 { get => orders2; set { orders2 = value; RaisePropertyChanged("Orders2"); } }



        public Command<object> AddCommand { get; set; }

        public Command<object> LoadMoreItemsCommand { get; set; }

        public Command<object> OrderListCommand { get; set; }

        public Command<object> RemoveOrderCommand { get; set; }
        public Command<string> BuscarComand { get; set; }

        public Command CheckoutCommand { get; set; }

        public int TotalOrderedItems
        {
            get { return totalOrderedItems; }
            set
            {
                if (totalOrderedItems != value)
                {
                    totalOrderedItems = value;
                    RaisePropertyChanged("TotalOrderedItems");
                }
            }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                if (totalPrice != value)
                {
                    totalPrice = value;
                    RaisePropertyChanged("TotalPrice");
                }
            }
        }

        public LoadMoreViewModel2()
        {
            //original                                          //reemplazo
            productRepository = new ProductRepository();        //productos = new ProductoSe();
            Products = new ObservableCollection<Product>(); Productos2 = new ObservableCollection<ProductoSe>();
            Products1 = new ObservableCollection<Product>(); Productos22 = new ObservableCollection<ProductoSe>();
            Orders = new ObservableCollection<Product>(); Orders2 = new ObservableCollection<ProductoSe>();

            GenerateSource();//mismo metodo

            if (Device.Idiom == TargetIdiom.Tablet)
                AddProducts(0, 11);
            else
                AddProducts(0, 6);

            AddCommand = new Command<object>(AddQuantity);
            OrderListCommand = new Command<object>(NavigateOrdersPage);
            CheckoutCommand = new Command(CheckOut);
            RemoveOrderCommand = new Command<object>(RemoveOrder);
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems, CanLoadMoreItems);


            BuscarComand = new Command<string>(buscarCliente);
        }

        public async void buscarCliente(string algo)
        {
            //string algo = algo2;
            //string algo = newValue;
            //await Task.Delay(5000);

            var helper = new SearchHelper();
            var clientHelp = new ClienteSearchHandler();
            await Task.Run(async () =>
            {
                clientHelp.Suggestions = await helper.GetSearchData();
                clientHelp.ItemsSource = clientHelp.Suggestions;
                //clientHelp.DisplayMemberName = "nomb_clie";
                //clientHelp.ShowsResults = true;


            });
            //   isVisible = true;
        }

        private void RemoveOrder(object obj)
        {
            var p = obj as ProductoSe;
            p.Quantity = 0;
        }

        private async void CheckOut(object obj)
        {
            var checkout = await Application.Current.MainPage.DisplayAlert("Checkout", "Do you want to checkout?", "Yes", "No");
            if (checkout)
            {
                while (Orders2.Count > 0)
                {
                    Orders2[Orders2.Count - 1].Quantity = 0;
                }

                await Application.Current.MainPage.DisplayAlert("", "Your order has been placed.", "OK");

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (obj != null)
                        (obj as ContentPage).Navigation.PopAsync();
                });
            }
        }

        private void NavigateOrdersPage(object obj)
        {
            var sampleView = obj as ContentPage;
            var ordersPage = new LoadMoreOrders();
            ordersPage.BindingContext = this;
            sampleView.Navigation.PushAsync(ordersPage);
        }

        private async void AddProducts(int index, int count)
        {
            //for (int i = index; i < index + count; i++)
            //{
            //    var name = productRepository.Names[i];
            //    var p = new Product()
            //    {
            //        Name = name,
            //        Weight = productRepository.Weights[i],
            //        Price = productRepository.Prices[i],
            //        Image = productRepository.FruitNames[i] + ".jpg"
            //    };


            //    p.PropertyChanged += (s, e) =>
            //    {
            //        var product = s as Product;
            //        if (e.PropertyName == "Quantity")
            //        {
            //            if (Orders.Contains(product) && product.Quantity <= 0)
            //                Orders.Remove(product);
            //            else if (!Orders.Contains(product) && product.Quantity > 0)
            //                Orders.Add(product);

            //            TotalOrderedItems = Orders.Count;
            //            TotalPrice = 0;
            //            for (int j = 0; j < Orders.Count; j++)
            //            {
            //                var order = Orders[j];
            //                TotalPrice += order.TotalPrice;
            //            }
            //        }
            //    };

            //    Products.Add(p);
            //}

            var url = "http://HieloApi.ironthinks.com/api/productos/read.php";
            var service = new HttpHelper<Producto>();
            var products = await service.GetRestServiceDataAsync(url);
            Productos2 = new ObservableCollection<ProductoSe>(products.data);//bien continuar aqui
            foreach (ProductoSe prod in Productos2)
            {
                prod.PropertyChanged += (s, e) =>
                {
                    var product = s as ProductoSe;
                    if (e.PropertyName == "Quantity")
                    {
                        if (Orders2.Contains(product) && product.Quantity <= 0)
                            Orders2.Remove(product);
                        else if (!Orders2.Contains(product) && product.Quantity > 0)
                            Orders2.Add(product);

                        TotalOrderedItems = Orders2.Count;
                        TotalPrice = 0;
                        for (int j = 0; j < Orders2.Count; j++)
                        {
                            var order = Orders2[j];
                            TotalPrice += order.TotalPrice;
                        }
                    }
                };
            }

        }

        private async void GenerateSource()
        {
            //for (int i = 0; i < productRepository.Names.Count(); i++)
            //{
            //    var name = productRepository.Names[i];
            //    var p = new Product()
            //    {
            //        Name = name,
            //        Weight = productRepository.Weights[i],
            //        Price = productRepository.Prices[i],
            //        Image = productRepository.FruitNames[i] + ".jpg"
            //    };

            //    Products1.Add(p);
            //}

            //var url = "http://HieloApi.ironthinks.com/api/productos/read.php";
            //var service = new HttpHelper<Producto>();
            //var products = await service.GetRestServiceDataAsync(url);
            //Productos2 = new ObservableCollection<ProductoSe>(products.data);//bien continuar aqui
        }

        private bool CanLoadMoreItems(object obj)
        {
            if (Products.Count >= totalItems)
                return false;
            return true;
        }

        private async void LoadMoreItems(object obj)
        {
            var listview = obj as Syncfusion.ListView.XForms.SfListView;
            listview.IsBusy = true;
            await Task.Delay(2500);

            var index = Products.Count;
            var count = index + 3 >= totalItems ? totalItems - index : 3;
            AddProducts(index, count);

            listview.IsBusy = false;
        }

        private void AddQuantity(object obj)
        {
            var p = obj as ProductoSe;
            p.Quantity += 1;
        }

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
