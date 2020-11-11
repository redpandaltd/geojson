using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof(Serialization.GeometryJsonConverter) )]
    public abstract class Geometry : GeoJsonObject
    {
        private static readonly IDictionary<GeometryType, Type> geometryTypeMapping = new Dictionary<GeometryType, Type>
        {
            { GeometryType.Point, typeof( PointGeometry )  },
            { GeometryType.MultiPoint, typeof( MultiPointGeometry )  },
            { GeometryType.LineString, typeof( LineStringGeometry )  },
            { GeometryType.MultiLineString, typeof( MultiLineStringGeometry )  },
            { GeometryType.Polygon, typeof( PolygonGeometry )  },
            { GeometryType.MultiPolygon, typeof( MultiPolygonGeometry )  },
            { GeometryType.GeometryCollection, typeof( GeometryCollection )  },
        };

        public Geometry()
        {}

        public Geometry( GeometryType type )
        {
            Type = type;
        }

        public GeometryType Type { get; }

        public static Type GetType( GeometryType geometryType )
        {
            if ( !geometryTypeMapping.ContainsKey( geometryType ) )
            {
                return ( null );
            }

            return ( geometryTypeMapping[geometryType] );
        }
    }
}
