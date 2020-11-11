using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( Serialization.InheritJsonConverter ) )]
    public class GeometryCollection : Geometry, IEquatable<GeometryCollection>
    {
        public GeometryCollection()
        : base( GeometryType.GeometryCollection )
        {}

        public IEnumerable<Geometry> Geometries { get; set; }

        public bool Equals( GeometryCollection other )
        {
            if ( ReferenceEquals( this, other ) )
            {
                return ( true );
            }

            return ( Type == other.Type ) && Geometries.SequenceEqual( other.Geometries );
        }

        public override bool Equals( object obj )
        {
            if  ( ( obj == null ) || ( GetType() != obj.GetType() ) )
            {
                return ( false );
            }

            return Equals( (GeometryCollection)obj );
        }

        public override int GetHashCode()
        {
            return ObjectHash.Hash( Type, Geometries );
        }
    }
}
