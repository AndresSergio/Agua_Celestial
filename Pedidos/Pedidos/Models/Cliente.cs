using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Pedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Pedidos.Models
{
    

    public partial class Cliente:BaseViewModel
    {
       // public Customer[] data { get; set; }
        public DateTime DateCreated { get; set; }
        private string m_baseUrl = "http://celestial.ironthinks.com/api/";
        private int id_cli;

        public int Id_cli
        {
            get { return id_cli; }
            set { id_cli = value; }
        }
        private string nombre_cli;

        public string Nombre_cli
        {
            get { return nombre_cli; }
            set { nombre_cli = value; }
        }
        private int telefono_cli;

        public int Telefono_cli
        {
            get { return telefono_cli; }
            set { telefono_cli = value; }
        }
        private int ci_cli;

        public int Ci_cli
        {
            get { return ci_cli; }
            set { ci_cli = value; }
        }
        private string direccion_cli;

        public string Direccion_cli
        {
            get { return direccion_cli; }
            set { direccion_cli = value; }
        }
        private string correo_cli;

        public string Correo_cli
        {
            get { return correo_cli; }
            set { correo_cli = value; }
        }
        private string latitud;

        public string Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
        private string longitud;

        public string Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }






        public string GetJson()

        {
            JObject jobject = new JObject();

            //rellenar los campos
            jobject.Add("nombre_cli", nombre_cli);
            jobject.Add("telefono_cli", Telefono_cli);
            jobject.Add("ci_cli", Ci_cli);
            jobject.Add("direccion_cli", Direccion_cli);
            jobject.Add("correo_cli", Correo_cli);
            jobject.Add("latitud", Latitud);
            jobject.Add("longitud", Longitud);
            return jobject.ToString();
        }
        public string GetJsonLogin() {
            JObject obj = new JObject();
            obj.Add("telefono_cli", Telefono_cli);
            return obj.ToString();
        }
       
        public string GetCreateURL() { return m_baseUrl + "cliente/create.php"; }
        public string GetUpdateURL() { return m_baseUrl + "usuario/update.php"; }
        public string GetReadURL() { return m_baseUrl + "usuario/read.php"; }
        public string GetReadSingleURL(string _id) { return m_baseUrl+"usuario/read_single.php?id=" + _id; }
        public string GetDeleteURL() { return m_baseUrl + "usuario/delete.php"; }
        public string GetLoginURL(string _telefono) { return m_baseUrl+ "cliente/login.php?telefono_cli=" + _telefono; }

    }

    public partial class Cliente
    {
        public Cliente[] data { get; set; }
        public static Cliente FromJson(string json) => JsonConvert.DeserializeObject<Cliente>(json, Pedidos.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Cliente self) => JsonConvert.SerializeObject(self, Pedidos.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
