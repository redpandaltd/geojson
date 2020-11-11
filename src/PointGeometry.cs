using System;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( Serialization.PointJsonConverter ) )]
    public class PointGeometry : Geometry, IEquatable<PointGeometry>
    {
        public PointGeometry()
        : base( GeometryType.Point )
        {}

        public Position Coordinates { get; set; }

        public bool Equals( PointGeometry other )
        {
            if ( ReferenceEquals( this, other ) )
            {
                return ( true );
            }

            return ( ( Type == other.Type ) && Coordinates.Equals( other.Coordinates ) );
        }

        public override bool Equals(object obj)
        {
            if  ( ( obj == null ) || ( GetType() != obj.GetType() ) )
            {
                return ( false );
            }

            return Equals( (PointGeometry)obj );
        }

        public override int GetHashCode()
        {
            return ObjectHash.Hash( Type, Coordinates );
        }
    }
}
