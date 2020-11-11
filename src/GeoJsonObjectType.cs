using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( StringEnumConverter ) )]
    public enum GeoJsonObjectType
    {
        Geometry,
        Feature,
        FeatureCollection
    }
}
