using System;

namespace Redpanda.Maps.GeoJson
{
    internal static class ObjectHash
    {
        public static int Hash( params object[] args )
        {
            int value = 37;

            foreach ( var obj in args )
            {
                value *= 397;

                if ( obj != null )
                {
                    value += obj.GetHashCode();
                }
            }

            return ( value );
        }
    }
}