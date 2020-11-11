using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Redpanda.Maps.GeoJson.Serialization
{
    public class InheritJsonConverter : JsonConverter
    {
        public override bool CanRead => false;
        public override bool CanWrite => false;

        public override bool CanConvert( Type objectType ) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
