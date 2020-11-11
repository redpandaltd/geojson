using System;
using System.IO;
using Newtonsoft.Json;
using Redpanda.Maps.GeoJson;
using Xunit;

namespace geojson.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Position()
        {
            string json1 = "[ 2.174901, 41.404263 ]";
            var position1 = JsonConvert.DeserializeObject<Position>( json1 );

            string json2 = JsonConvert.SerializeObject( position1 );
            var position2 = JsonConvert.DeserializeObject<Position>( json2 );

            Assert.Equal( position1, position2 );
        }

        [Fact]
        public void Point()
        {
            string json1 = File.ReadAllText("files/point.json");
            var geo1 = JsonConvert.DeserializeObject<PointGeometry>( json1 );

            string json2 = JsonConvert.SerializeObject( geo1 );
            var geo2 = JsonConvert.DeserializeObject<PointGeometry>( json2 );

            Assert.Equal( geo1, geo2 );

            var geo3 = JsonConvert.DeserializeObject<Geometry>( json1 );

            Assert.IsType<PointGeometry>( geo3 );
            Assert.Equal( geo1, geo3 );
        }

        [Fact]
        public void MultiPoint()
        {
            string json1 = File.ReadAllText("files/multipoint.json");
            var geo1 = JsonConvert.DeserializeObject<MultiPointGeometry>( json1 );

            string json2 = JsonConvert.SerializeObject( geo1 );
            var geo2 = JsonConvert.DeserializeObject<MultiPointGeometry>( json2 );

            Assert.Equal( geo1, geo2 );

            var geo3 = JsonConvert.DeserializeObject<Geometry>( json1 );

            Assert.IsType<MultiPointGeometry>( geo3 );
            Assert.Equal( geo1, geo3 );
        }

        [Fact]
        public void LineString()
        {
            string json1 = File.ReadAllText("files/linestring.json");
            var geo1 = JsonConvert.DeserializeObject<LineStringGeometry>( json1 );

            string json2 = JsonConvert.SerializeObject( geo1 );
            var geo2 = JsonConvert.DeserializeObject<LineStringGeometry>( json2 );

            Assert.Equal( geo1, geo2 );

            var geo3 = JsonConvert.DeserializeObject<Geometry>( json1 );

            Assert.IsType<LineStringGeometry>( geo3 );
            Assert.Equal( geo1, geo3 );
        }

        [Fact]
        public void Polygon()
        {
            string json1 = File.ReadAllText("files/polygon.json");
            var geo1 = JsonConvert.DeserializeObject<PolygonGeometry>( json1 );

            string json2 = JsonConvert.SerializeObject( geo1 );
            var geo2 = JsonConvert.DeserializeObject<PolygonGeometry>( json2 );

            Assert.Equal( geo1, geo2 );

            var geo3 = JsonConvert.DeserializeObject<Geometry>( json1 );

            Assert.IsType<PolygonGeometry>( geo3 );
            Assert.Equal( geo1, geo3 );
        }

        [Fact]
        public void MultiPolygon()
        {
            string json1 = File.ReadAllText("files/multipolygon.json");
            var geo1 = JsonConvert.DeserializeObject<MultiPolygonGeometry>( json1 );

            string json2 = JsonConvert.SerializeObject( geo1 );
            var geo2 = JsonConvert.DeserializeObject<MultiPolygonGeometry>( json2 );

            Assert.Equal( geo1, geo2 );

            var geo3 = JsonConvert.DeserializeObject<Geometry>( json1 );

            Assert.IsType<MultiPolygonGeometry>( geo3 );
            Assert.Equal( geo1, geo3 );
        }

        [Fact]
        public void TestingTesting()
        {
            string json1 = File.ReadAllText( "files/feature.json" );
            var feature = JsonConvert.DeserializeObject<Feature>( json1 );
        }
    }
}
