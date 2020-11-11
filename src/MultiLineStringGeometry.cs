using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( Serialization.MultiLineStringJsonConverter ) )]
    public class MultiLineStringGeometry : Geometry, IEquatable<MultiLineStringGeometry>
    {
        public MultiLineStringGeometry()
        : base( GeometryType.MultiLineString )
        {}

        public IEnumerable<LineStringGeometry> Coordinates { get; set; }

        public bool Equals( MultiLineStringGeometry other )
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

            return Equals( (MultiLineStringGeometry)obj );
        }

        public override int GetHashCode()
        {
            return ObjectHash.Hash( Type, Coordinates );
        }
    }
}
