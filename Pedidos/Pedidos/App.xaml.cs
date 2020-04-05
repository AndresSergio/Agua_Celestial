
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pedidos.Services;
using Pedidos.Views;
using Pedidos.ViewModels;
using Pedidos.CustomRenderers;

namespace Pedidos
{
    public partial class App : Application
    {
        public static SessionViewModel Session;
        public App()
        {
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTMyMjU4QDMxMzcyZTMyMmUzMFArYk41QkVjODRjVXpCVVhydFQ0OFZid3pvMEJOQlYyNWZKaERFUExSYXM9");

            InitializeComponent();
            RegisterRoutes();
            Session = new SessionViewModel();
            DependencyService.Register<MockDataStore>();
            MainPage = new TransparentNavigationPage(new login());
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("detalleProveedorPage",typeof(Views.Client.detalleProveedorPage));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
