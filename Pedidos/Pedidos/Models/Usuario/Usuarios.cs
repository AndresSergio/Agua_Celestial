using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Models
{//dbhielo
    public partial class Usuarios
    {
        public DateTime DateCreated { get; set; }
        private string m_baseUrl = "http://HieloApi.ironthinks.com/api/";
        [JsonProperty("id_usr")]
        private int id_usr;

        public int Id_usr
        {
            get { return id_usr; }
            set { id_usr = value; }
        }
        [JsonProperty("nomb_usr")]
        private string nomb_usr;

        public string Nomb_usr
        {
            get { return nomb_usr; }
            set { nomb_usr = value; }
        }
        [JsonProperty("login_usr")]
        private string login_usr;

        public string Login_usr
        {
            get { return login_usr; }
            set { login_usr = value; }
        }
        [JsonProperty("passw_usr")]
        private string passw_usr;

        public string Passw_usr
        {
            get { return passw_usr; }
            set { passw_usr = value; }
        }
        [JsonProperty("fechi_usr")]
        private DateTime fechi_usr;

        public DateTime Fechi_usr
        {
            get { return fechi_usr; }
            set { fechi_usr = value; }
        }
        [JsonProperty("fechaf_usr")]
        private DateTime fechf_usr;

        public DateTime Fechf_usr
        {
            get { return fechf_usr; }
            set { fechf_usr = value; }
        }
        [JsonProperty("nivel_usr")]
        private decimal nivel_usr;

        public decimal Nivel_usr
        {
            get { return nivel_usr; }
            set { nivel_usr = value; }
        }
        [JsonProperty("id_rol")]
        private int id_rol;

        public int Id_rol
        {
            get { return id_rol; }
            set { id_rol = value; }
        }
        [JsonProperty("dire_usr")]
        private string dire_usr;

        public string Dire_usr
        {
            get { return dire_usr; }
            set { dire_usr = value; }
        }
        [JsonProperty("fono_usr")]
        private string fono_usr;

        public string Fono_usr
        {
            get { return fono_usr; }
            set { fono_usr = value; }
        }
        [JsonProperty("celu_usr")]
        private string celu_usr;

        public string Celu_usr
        {
            get { return celu_usr; }
            set { celu_usr = value; }
        }
        [JsonProperty("email_usr")]
        private string email_usr;

        public string Email_usr
        {
            get { return email_usr; }
            set { email_usr = value; }
        }
        [JsonProperty("id_cate")]
        private int id_cate;

        public int Id_cate
        {
            get { return id_cate; }
            set { id_cate = value; }
        }
        [JsonProperty("id_sucu")]
        private int id_sucu;

        public int Id_sucu
        {
            get { return id_sucu; }
            set { id_sucu = value; }
        }
        [JsonProperty("id_emp")]
        private int id_emp;

        public int Id_emp
        {
            get { return id_emp; }
            set { id_emp = value; }
        }
        [JsonProperty("esta_usr")]
        private int esta_usr;

        public int Esta_usr
        {
            get { return esta_usr; }
            set { esta_usr = value; }
        }
        [JsonProperty("ci_usr")]
        private int ci_usr;

        public int Ci_usr
        {
            get { return ci_usr; }
            set { ci_usr = value; }
        }
        [JsonProperty("costo_usr")]
        private int costo_usr;

        public int Costo_usr
        {
            get { return costo_usr; }
            set { costo_usr = value; }
        }
        [JsonProperty("autoriza_usr")]
        private int autoriza_usr;

        public int Autoriza_usr
        {
            get { return autoriza_usr; }
            set { autoriza_usr = value; }
        }
        [JsonProperty("devol_usr")]
        private int devol_usr;

        public int Devol_usr
        {
            get { return devol_usr; }
            set { devol_usr = value; }
        }
        [JsonProperty("regis_usr")]
        private int regis_usr;

        public int Regis_usr
        {
            get { return regis_usr; }
            set { regis_usr = value; }
        }
        [JsonProperty("conso_usr")]
        private int conso_usr;

        public int Conso_usr
        {
            get { return conso_usr; }
            set { conso_usr = value; }
        }
        [JsonProperty("compra_usr")]
        private int compra_usr;

        public int Compra_usr
        {
            get { return compra_usr; }
            set { compra_usr = value; }
        }
        [JsonProperty("id_perso")]
        private int id_perso;

        public int Id_perso
        {
            get { return id_perso; }
            set { id_perso = value; }
        }
        public string GetLoginURL(string _login, string _password) { return m_baseUrl + "usuarios/login.php?login_usr=" + _login + "&passw_usr=" + _password; }
        public string GetJsonLogin()
        {
            JObject obj = new JObject();
            obj.Add("login_usr", Login_usr);
            obj.Add("passw_usr", Passw_usr);
            return obj.ToString();
        }
        public static Usuarios FromJson(string json) => JsonConvert.DeserializeObject<Usuarios>(json, Pedidos.Models.Converter.Settings);
        





















    }
}
