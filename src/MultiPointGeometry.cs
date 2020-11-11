using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( Serialization.MultiPointJsonConverter ) )]
    public class MultiPointGeometry : Geometry, IEquatable<MultiPointGeometry>
    {
        public MultiPointGeometry()
        : base( GeometryType.MultiPoint )
        {}

        public IEnumerable<Position> Coordinates { get; set; }

        public bool Equals( MultiPointGeometry other )
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

            return Equals( (MultiPointGeometry)obj );
        }

        public override int GetHashCode()
        {
            return ObjectHash.Hash( Type, Coordinates );
        }
    }
}
