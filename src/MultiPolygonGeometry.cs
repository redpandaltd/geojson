using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( Serialization.MultiPolygonJsonConverter ) )]
    public class MultiPolygonGeometry : Geometry, IEquatable<MultiPolygonGeometry>
    {
        public MultiPolygonGeometry()
        : base( GeometryType.MultiPolygon )
        {}

        public IEnumerable<PolygonGeometry> Coordinates { get; set; }

        public bool Equals( MultiPolygonGeometry other )
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

            return Equals( (MultiPolygonGeometry)obj );
        }

        public override int GetHashCode()
        {
            return ObjectHash.Hash( Type, Coordinates );
        }
    }
}
