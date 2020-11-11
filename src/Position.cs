using System;
using Newtonsoft.Json;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( Serialization.PositionJsonConverter ) )]
    public class Position : IEquatable<Position>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return ( $"[{Latitude},{Longitude}]" );
        }

        public override bool Equals(object obj)
        {
            if  ( ( obj == null ) || ( GetType() != obj.GetType() ) )
            {
                return ( false );
            }

            return Equals( (Position)obj );
        }

        public bool Equals( Position other )
        {
            if ( ReferenceEquals( this, other ) )
            {
                return ( true );
            }

            return ( ( Latitude == other.Latitude ) && ( Longitude == other.Longitude ) );
        }

        public override int GetHashCode()
        {
            return ObjectHash.Hash( Latitude, Longitude );
        }
    }
}
