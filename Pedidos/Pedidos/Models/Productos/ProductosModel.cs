using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pedidos.Models.Productos
{//dbhieloPrueba
    public class Producto 
    {
        public ProductoSe[] data { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ProductoSe : INotifyPropertyChanged
    {
        private int quantity = 0;

        private double totalPrice = 0;
        public int id_cata { get; set; }
        public string code_cata { get; set; }
        public string code2_cata { get; set; }
        public string codbarra_cata { get; set; }
        public string nomb_cata { get; set; }
        public string nreal_cata { get; set; }
        public string id_fami { get; set; }
        public string id_sgrup { get; set; }
        public string id_grup { get; set; }
        public string id_unid { get; set; }
        public string id_marca { get; set; }
        public string id_orig { get; set; }
        public string ubic_cata { get; set; }
        public string pfob_cata { get; set; }
        public string porcefob_cata { get; set; }
        public double pcif_cata { get; set; }
        public string esta_cata { get; set; }
        public string id_emp { get; set; }
        public string desc_cata { get; set; }
        public string tipo_cata { get; set; }
        public string stockmin_cata { get; set; }
        public string stockmax_cata { get; set; }
        public string combo_cata { get; set; }
        public string unicaja_cata { get; set; }
        public string pesounicaja_cata { get; set; }
        public string pesototcaja_cata { get; set; }
        public string volunicaja_cata { get; set; }
        public string voltotcaja_cata { get; set; }
        public string volcbunicaja_cata { get; set; }
        public string volcbtotcaja_cata { get; set; }
        public string id_prov1 { get; set; }
        public string id_prov2 { get; set; }

        //nuevas propiedades
        public double Price { get; set; }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value; 
                    TotalPrice = quantity * pcif_cata;
                    //TotalPrice = quantity * Price; modifique por pcif_cata
                    RaisePropertyChanged("Quantity");
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
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
