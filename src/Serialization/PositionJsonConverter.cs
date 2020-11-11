using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Redpanda.Maps.GeoJson.Serialization
{
    public class PositionJsonConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( Position ) );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var token = JArray.Load( reader );

            var longitude = token.ElementAt( 0 ).ToObject<double>( serializer );
            var latitude = token.ElementAt( 1 ).ToObject<double>( serializer );

            return ( new Position
            {
                Latitude = latitude,
                Longitude = longitude
            } );
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var position = (Position)value;

            JToken.FromObject( new double[2] { position.Longitude, position.Latitude } )
                .WriteTo( writer );
        }
    }    
}
