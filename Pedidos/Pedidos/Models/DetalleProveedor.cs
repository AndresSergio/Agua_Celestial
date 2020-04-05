using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Models
{
    public class DetalleProveedor
    {
        public DETProveedor [] data { get; set; }
    }
    public class DETProveedor
    {
        public string id_cod_pago { get; set; }
        public string cod_prov { get; set; }
        public string pago_parcial_prov { get; set; }
        public string saldo_prov { get; set; }
        public string fecha_pago_prov { get; set; }
        public string estado_pago_prov { get; set; }

      

    }
}
