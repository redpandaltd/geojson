using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Redpanda.Maps.GeoJson.Serialization
{
    public class PolygonJsonConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( PolygonGeometry ) );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var token = JObject.Load( reader );

            var coordinates = token.GetValue( "coordinates", StringComparison.OrdinalIgnoreCase )
                .ToObject<IEnumerable<IEnumerable<Position>>>( serializer );

            return ( new PolygonGeometry
            {
                Coordinates = coordinates.Select( x => new LineStringGeometry
                {
                    Coordinates = x
                } ).ToArray()
            } );
        }

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            var geometry = (PolygonGeometry)value;

            JToken.FromObject( new
            {
                type = geometry.Type,
                coordinates = geometry.Coordinates.Select( x => x.Coordinates ).ToArray()
            } )
            .WriteTo( writer );
        }
    }
}
