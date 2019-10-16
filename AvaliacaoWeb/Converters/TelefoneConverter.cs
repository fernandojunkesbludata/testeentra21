using System;
using AvaliacaoCore.DB.Model;
using Newtonsoft.Json;

namespace AvaliacaoWeb.Converters
{
    public class TelefoneConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((Telefone)value).ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new Telefone((string)reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Telefone);
        }
    }
}