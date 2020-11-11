using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( Serialization.LineStringJsonConverter ) )]
    public class LineStringGeometry : Geometry, IEquatable<LineStringGeometry>
    {
        public LineStringGeometry()
        : base( GeometryType.LineString )
        {}

        public IEnumerable<Position> Coordinates { get; set; }

        public bool IsLinearRing()
        {
            // RFC 7946
            // * A linear ring is a closed LineString with four or more positions.
            // * The first and last positions are equivalent, and they MUST contain
            //   identical values; their representation SHOULD also be identical.
            return ( (  Coordinates.Count() < 4 ) && ( Coordinates.First().Equals( Coordinates.Last() ) ) );
        }

        public bool Equals( LineStringGeometry other )
        {
            if ( ReferenceEquals( this, other ) )
            {
                return ( true );
            }

            return ( Type == other.Type ) && Coordinates.SequenceEqual( other.Coordinates );
        }

        public override bool Equals( object obj )
        {
            if  ( ( obj == null ) || ( GetType() != obj.GetType() ) )
            {
                return ( false );
            }

            return Equals( (LineStringGeometry)obj );
        }

        public override int GetHashCode()
        {
            return ObjectHash.Hash( Type, Coordinates );
        }
    }
}
