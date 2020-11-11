using System;
using System.Collections.Generic;

namespace Redpanda.Maps.GeoJson
{
    public class FeatureProperties : Dictionary<string, object>
    {
        public FeatureProperties()
            : base( StringComparer.OrdinalIgnoreCase )
        { }
    }
}
