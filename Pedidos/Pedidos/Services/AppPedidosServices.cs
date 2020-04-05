using Pedidos.Models;
using Pedidos.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Services
{
    public class AppPedidosServices
    {
        
        public AppPedidosServices()
        {

        }
       
        public static async Task<bool> Post(Cliente _model)
        {
            HttpClient client = new HttpClient();

            var response = await client.PostAsync(_model.GetCreateURL(), new StringContent(_model.GetJson()));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        public static async Task<bool> Login(Cliente _model)
        {
            

            HttpClient client = new HttpClient();

            var response = await client.PostAsync(_model.GetLoginURL(Convert.ToString(_model.Telefono_cli)),new StringContent(_model.GetJsonLogin()));

            string json = response.Content.ReadAsStringAsync().Result;
            Usuarios modelo = Usuarios.FromJson(json);
           
            App.Session.LoginUser(modelo);

            return response.IsSuccessStatusCode;
        }
      
    }
}
