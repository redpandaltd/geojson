using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Redpanda.Maps.GeoJson
{
    [JsonConverter( typeof( StringEnumConverter ) )]
    public enum GeometryType
    {
        Point,
        MultiPoint,
        LineString,
        MultiLineString,
        Polygon,
        MultiPolygon,
        GeometryCollection
    }
}
