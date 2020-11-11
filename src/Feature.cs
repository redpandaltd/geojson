using System;

namespace Redpanda.Maps.GeoJson
{
    public class Feature : GeoJsonObject
    {
        public Feature()
        {
            Properties = new FeatureProperties();
        }

        public GeoJsonObjectType Type => GeoJsonObjectType.Feature;
        public FeatureProperties Properties { get; set; }
        public Geometry Geometry { get; set; }
    }
}
