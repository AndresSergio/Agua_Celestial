using Pedidos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pedidos.ViewModels
{
    //dbhielo
    public class SessionViewModel:BaseViewModel
    {
        private int id_usr;

        public int Id_usr
        {
            get { return id_usr; }
            set { id_usr = value; OnPropertyChanged(); }
        }
        private string nomb_usr;

        public string Nomb_usr
        {
            get { return nomb_usr; }
            set { nomb_usr = value; OnPropertyChanged(); }
        }
        private string login_usr;

        public string Login_usr
        {
            get { return login_usr; }
            set { login_usr = value; OnPropertyChanged(); }
        }
        private string passw_usr;

        public string Passw_usr
        {
            get { return passw_usr; }
            set { passw_usr = value; OnPropertyChanged(); }
        }
        private DateTime fechi_usr;

        public DateTime Fechi_usr
        {
            get { return fechi_usr; }
            set { fechi_usr = value; OnPropertyChanged(); }
        }
        private DateTime fechf_usr;

        public DateTime Fechf_usr
        {
            get { return fechf_usr; }
            set { fechf_usr = value; OnPropertyChanged(); }
        }
        private decimal nivel_usr;

        public decimal Nivel_usr
        {
            get { return nivel_usr; }
            set { nivel_usr = value; OnPropertyChanged(); }
        }
        private int id_rol;

        public int Id_rol
        {
            get { return id_rol; }
            set { id_rol = value; OnPropertyChanged(); }
        }
        private string dire_usr;

        public string Dire_usr
        {
            get { return dire_usr; }
            set { dire_usr = value; OnPropertyChanged(); }
        }
        private string fono_usr;

        public string Fono_usr
        {
            get { return fono_usr; }
            set { fono_usr = value; OnPropertyChanged(); }
        }
        private string celu_usr;

        public string Celu_usr
        {
            get { return celu_usr; }
            set { celu_usr = value; OnPropertyChanged(); }
        }
        private string email_usr;

        public string Email_usr
        {
            get { return email_usr; }
            set { email_usr = value; OnPropertyChanged(); }
        }
        private int id_cate;

        public int Id_cate
        {
            get { return id_cate; }
            set { id_cate = value; OnPropertyChanged(); }
        }
        private int id_sucu;

        public int Id_sucu
        {
            get { return id_sucu; }
            set { id_sucu = value; OnPropertyChanged(); }
        }
        private int id_emp;

        public int Id_emp
        {
            get { return id_emp; }
            set { id_emp = value; OnPropertyChanged(); }
        }
        private int esta_usr;

        public int Esta_usr
        {
            get { return esta_usr; }
            set { esta_usr = value; OnPropertyChanged(); }
        }
        private int ci_usr;

        public int Ci_usr
        {
            get { return ci_usr; }
            set { ci_usr = value; OnPropertyChanged(); }
        }
        private int costo_usr;

        public int Costo_usr
        {
            get { return costo_usr; }
            set { costo_usr = value; OnPropertyChanged(); }
        }
        private int autoriza_usr;

        public int Autoriza_usr
        {
            get { return autoriza_usr; }
            set { autoriza_usr = value; OnPropertyChanged(); }
        }
        private int devol_usr;

        public int Devol_usr
        {
            get { return devol_usr; }
            set { devol_usr = value; OnPropertyChanged(); }
        }
        private int regis_usr;

        public int Regis_usr
        {
            get { return regis_usr; }
            set { regis_usr = value; OnPropertyChanged(); }
        }
        private int conso_usr;

        public int Conso_usr
        {
            get { return conso_usr; }
            set { conso_usr = value; OnPropertyChanged(); }
        }
        private int compra_usr;

        public int Compra_usr
        {
            get { return compra_usr; }
            set { compra_usr = value; OnPropertyChanged(); }
        }
        private int id_perso;

        public int Id_perso
        {
            get { return id_perso; }
            set { id_perso = value; OnPropertyChanged(); }
        }

        
        //instanciar el modelo para pasar los datos a la vista
        public SessionViewModel()
        {
            id_usr = 1;
            nomb_usr = "JAC 91";
            
            ci_usr = 1;
            email_usr = "pato@gmail.com";
            celu_usr = "70878546";
        }
        public void LoginUser(Usuarios session) {
            this.id_usr = session.Id_usr;
            this.nomb_usr = session.Nomb_usr;
            this.login_usr = session.Login_usr;
            this.fechi_usr = session.Fechi_usr;
            this.fechf_usr = session.Fechf_usr;
            this.nivel_usr = session.Nivel_usr;
            this.id_rol = session.Id_rol;
            this.dire_usr = session.Dire_usr;
            this.fono_usr = session.Fono_usr;
            this.id_cate = session.Id_cate;
            this.id_sucu = session.Id_sucu;
            this.id_emp = session.Id_emp;
            this.esta_usr = session.Esta_usr;
            this.costo_usr = session.Costo_usr;
            this.autoriza_usr = session.Autoriza_usr;
            this.devol_usr = session.Devol_usr;
            this.regis_usr = session.Regis_usr;
            this.conso_usr = session.Conso_usr;
            this.compra_usr = session.Compra_usr;
            this.id_perso = session.Id_perso;
            this.email_usr = session.Email_usr;
            this.celu_usr = session.Celu_usr;
            this.ci_usr = session.Ci_usr;
        }
    }
}
