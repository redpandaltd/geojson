using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Redpanda.Maps.GeoJson.Serialization
{
    public class LineStringJsonConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( LineStringGeometry ) );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var token = JObject.Load( reader );

            var coordinates = token.GetValue( "coordinates", StringComparison.OrdinalIgnoreCase )
                .ToObject<IEnumerable<Position>>( serializer );

            return ( new LineStringGeometry
            {
                Coordinates = coordinates
            } );
        }

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            var geometry = (LineStringGeometry)value;

            JToken.FromObject( new
            {
                type = geometry.Type,
                coordinates = geometry.Coordinates
            } )
            .WriteTo( writer );
        }
    }
}
