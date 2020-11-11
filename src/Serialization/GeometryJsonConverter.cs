using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Redpanda.Maps.GeoJson.Serialization
{
    public class GeometryJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( Geometry ) );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if ( reader.TokenType == JsonToken.Null )
            {
                return ( null );
            }

            var token = JObject.Load( reader );
            var typeToken = token.GetValue( "type", StringComparison.OrdinalIgnoreCase );

            var geometryType = Geometry.GetType( typeToken.ToObject<GeometryType>() );

            if ( existingValue == null || existingValue.GetType() != geometryType )
            {
                return ( token.ToObject( geometryType, serializer ) );
            }
            else
            {
                using ( var typeReader = token.CreateReader() )
                {
                    serializer.Populate( typeReader, existingValue );
                }

                return ( existingValue );
            }
        }

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            throw new NotImplementedException();
        }
    }
}
