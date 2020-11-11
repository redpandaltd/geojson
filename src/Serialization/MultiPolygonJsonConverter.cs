using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Redpanda.Maps.GeoJson.Serialization
{
    public class MultiPolygonJsonConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( MultiPolygonGeometry ) );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var token = JObject.Load( reader );

            var coordinates = token.GetValue( "coordinates", StringComparison.OrdinalIgnoreCase )
                .ToObject<IEnumerable<IEnumerable<IEnumerable<Position>>>>( serializer );

            return ( new MultiPolygonGeometry
            {
                Coordinates = coordinates.Select( x => new PolygonGeometry
                {
                    Coordinates = x.Select( y => new LineStringGeometry
                    {
                        Coordinates = y
                    } ).ToArray()
                } ).ToArray()
            } );
        }

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            var geometry = (MultiPolygonGeometry)value;

            JToken.FromObject( new
            {
                type = geometry.Type,
                coordinates = geometry.Coordinates.Select( x => x.Coordinates.Select( y => y.Coordinates ) )
            } )
            .WriteTo( writer );
        }
    }
}
