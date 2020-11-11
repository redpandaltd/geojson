using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( Serialization.GeoJsonObjectJsonConverter ) )]
    public abstract class GeoJsonObject
    {
        private static readonly IDictionary<GeoJsonObjectType, Type> typeMapping = new Dictionary<GeoJsonObjectType, Type>
        {
            { GeoJsonObjectType.Geometry, typeof( Geometry )  },
            { GeoJsonObjectType.Feature, typeof( Feature )  },
            { GeoJsonObjectType.FeatureCollection, typeof( FeatureCollection )  }
        };

        public GeoJsonObject()
        {}

        public static Type GetType( GeoJsonObjectType type )
        {
            if ( !typeMapping.ContainsKey( type ) )
            {
                return ( null );
            }

            return ( typeMapping[type] );
        }
    }
}
