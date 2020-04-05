using Pedidos.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pedidos.Search
{//dbhielo
    public class ClienteSearchHandler:SearchHandler
    {
        public List<CliModel> Suggestions { get; set;  } =
            new List<CliModel>();
        public string consulta ="";
        public ICommand BuscarComand { get; set; }
        
        public ClienteSearchHandler()
        {
            //OnQueryConfirmed();
            //var helper = new SearchHelper();
            //Task.Run(async () =>
            //{
            //    Suggestions = await helper.GetSearchData();
            //    ItemsSource = Suggestions;

            //});
            //BuscarComand = new Command(async (param) =>
            //{

            //    // var product = param as Proveedor;


            //    if (param != null)
            //    {

            //    }


            //});


        }
        public async void buscador() 
        {
            // OnQueryConfirmed();
            var helper = new SearchHelper();
            await Task.Run(async () =>
            {
                Suggestions = await helper.GetSearchData();
                ItemsSource = Suggestions;
                
            });
        }
        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            //string algo = newValue;
            //await Task.Delay(5000);

            consulta = newValue;
            //var helper = new SearchHelper();
            //await Task.Run(async () =>
            //{
            //    //Suggestions = await helper.GetSearchData();
            //    //ItemsSource = Suggestions;
            //   await Task.Delay(5000);

            //    OnQueryConfirmed();
            //});
            


        }
        protected override async void OnQueryConfirmed()
        {
            base.OnQueryConfirmed();
            string query = Query.ToString();
            if (query!=null)
            {
                var helper = new SearchHelper();
                await Task.Run(async () =>
                {
                    Suggestions = await helper.GetSearchData();
                    ItemsSource = Suggestions;

                });
            }

            //string newquery=consulta.ToString();
            //if (newquery!=consulta)
            //{

            //}
            
        }

    }
}
