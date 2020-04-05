using Pedidos.Models.Clientes;
using Pedidos.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Search
{
    public class SearchHelper
    {
        public SearchHelper()
        {

        }
        public async Task<List<CliModel>> GetSearchData()
        {
            List<CliModel> collectionList =
                new List<CliModel>();
            var url = "http://HieloApi.ironthinks.com/api/customer/read.php?nomb_clie=MARIA"; 

            var service = new HttpHelper<ClienteModel>();
            var client = await service.GetRestServiceDataAsync(url);
            //var client = new UnsplasharpClient(App.ServiceId);
           // Proveedors = new ObservableCollection<Proveedor>(products.data);
           var collections = new List<CliModel>(client.data);
            foreach (var collection in collections)
            {
                var newCollection = new CliModel
                {
                    id_clie = collection.id_clie,
                    nomb_clie = collection.nomb_clie,
                    razon_clie = collection.razon_clie,
                    fono_clie = collection.fono_clie,
                    nit_clie = collection.nit_clie
                };

                collectionList.Add(newCollection);
            }

            return collectionList;
        }
    }
}
