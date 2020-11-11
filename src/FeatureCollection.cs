using System.Collections.Generic;

namespace Redpanda.Maps.GeoJson
{
    public class FeatureCollection : GeoJsonObject
    {
        public GeoJsonObjectType Type => GeoJsonObjectType.FeatureCollection;
        public IEnumerable<Feature> Features { get; set; }
    }
}
