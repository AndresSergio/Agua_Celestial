using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Models
{
    public class Proveedors
    {
        public Proveedor[] data { get; set; }
    }
    public class Proveedor
    {
        public string cod_prov { get; set; }
        public string nombre_prov { get; set; }
        public string concepto_prov { get; set; }
        public string monto_total_prov { get; set; }
        public string fecha_crea_prov { get; set; }
        public string estado_prov { get; set; }

    }
}
