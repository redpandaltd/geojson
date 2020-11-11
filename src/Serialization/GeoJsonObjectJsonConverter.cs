using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Redpanda.Maps.GeoJson.Serialization
{
    public class GeoJsonObjectJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( GeoJsonObject) );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if ( reader.TokenType == JsonToken.Null )
            {
                return ( null );
            }

            var token = JObject.Load( reader );
            var typeToken = token.GetValue( "type", StringComparison.OrdinalIgnoreCase );

            var type = Geometry.GetType( typeToken.ToObject<GeoJsonObjectType>() );

            if ( existingValue == null || existingValue.GetType() != type )
            {
                return ( token.ToObject( type, serializer ) );
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
