using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Models
{
    public class Products
    {
        //cambiar por los productos de la ferreteria
      
        public Product[] data { get; set; }
    }

    public class Product
    {
        public DateTime DateCreated { get; set; }
        private string m_baseUrl = "http://ecodeliveryApi.developerscz.com/api/";
        public string id_products { get; set; }
        public string nombre_p { get; set; }
        public string imagen_p { get; set; }
        public string id_sucursal_p { get; set; }
        public string descripcion_p { get; set; }
        public string precio_p { get; set; }
        public string estado_p { get; set; }
        public string GetReadSingleURL(string nombre_p) { return m_baseUrl + "customers/read_single.php?id=" + nombre_p; }

    }


}
