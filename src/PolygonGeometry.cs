using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( Serialization.PolygonJsonConverter ) )]
    public class PolygonGeometry : Geometry, IEquatable<PolygonGeometry>
    {
        public PolygonGeometry()
        : base( GeometryType.Polygon )
        {}

        public IEnumerable<LineStringGeometry> Coordinates { get; set; }

        public bool Equals( PolygonGeometry other )
        {
            if ( ReferenceEquals( this, other ) )
            {
                return ( true );
            }

            return ( Type == other.Type ) && Coordinates.SequenceEqual( other.Coordinates );
        }

        public override bool Equals(object obj)
        {
            if  ( ( obj == null ) || ( GetType() != obj.GetType() ) )
            {
                return ( false );
            }

            return Equals( (PolygonGeometry)obj );
        }

        public override int GetHashCode()
        {
            return ObjectHash.Hash( Type, Coordinates );
        }
    }
}
