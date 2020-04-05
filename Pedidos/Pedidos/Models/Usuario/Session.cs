using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pedidos.Models
{//dbhielo
    public partial class Session
    {
        [JsonProperty("cod_usu")]
        
        public long Cod_usu { get; set; }

        [JsonProperty("cod_emp")]
   
        public long Cod_emp { get; set; }

        [JsonProperty("nombre_usu")]
        public string Nombre_usu { get; set; }

        [JsonProperty("telefono_usu")]
        public string Telefono_usu { get; set; }

        [JsonProperty("ci_usu")]
        public string Ci_usu { get; set; }

        [JsonProperty("contra_usu")]
       
        public string Contra_usu { get; set; }

        [JsonProperty("correo_usu")]
        public string Correo_usu { get; set; }

        [JsonProperty("estado_usu")]
        public string Estado_usu { get; set; }
    }

    public partial class Session
    {
        public static Session FromJson(string json) => JsonConvert.DeserializeObject<Session>(json, Pedidos.Models.Converter.Settings);
    }

    //public static class Serialize
    //{
    //    public static string ToJson(this Session self) => JsonConvert.SerializeObject(self, Pedidos.Models.Converter.Settings);
    //}

    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters =
    //        {
    //            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
    //        },
    //    };
    //}

    //internal class ParseStringConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

    //    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.TokenType == JsonToken.Null) return null;
    //        var value = serializer.Deserialize<string>(reader);
    //        long l;
    //        if (Int64.TryParse(value, out l))
    //        {
    //            return l;
    //        }
    //        throw new Exception("Cannot unmarshal type long");
    //    }

    //    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    //    {
    //        if (untypedValue == null)
    //        {
    //            serializer.Serialize(writer, null);
    //            return;
    //        }
    //        var value = (long)untypedValue;
    //        serializer.Serialize(writer, value.ToString());
    //        return;
    //    }

    //    public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    //}
}
