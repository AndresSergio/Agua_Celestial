using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Models.Clientes
{//bdhielo
    public class ClienteModel
    {
        public CliModel[] data { get; set; }

    }
    public class CliModel
    {
        public string id_clie { get; set; }
        public string nomb_clie { get; set; }
        public string ap_clie { get; set; }
        public string dire_clie { get; set; }
        public string fono_clie { get; set; }
        public string celu_clie { get; set; }
        public string credi_clie { get; set; }
        public string email_clie { get; set; }
        public string razon_clie { get; set; }
        public string nit_clie { get; set; }
        public string id_emp { get; set; }
        public string esta_clie { get; set; }
        public string id_gclie { get; set; }
        public string ci_clie { get; set; }
        public string nota_clie { get; set; }
        public string fecha_clie { get; set; }
        public string id_tpc { get; set; }
        public string id_zclie { get; set; }
        public string cargos_clie { get; set; }
        public string abonos_clie { get; set; }
        public string anticipos_clie { get; set; }
        public string id_gana { get; set; }
        public string id_ana { get; set; }
        public string id_vend { get; set; }
        public string id_esca { get; set; }
        public string web_clie { get; set; }
        public string id_list { get; set; }
        public string codigo { get; set; }
        public string cp { get; set; }
    }
}
