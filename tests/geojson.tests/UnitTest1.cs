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
            string json1 = "[100.0,1.5]";
            var position1 = JsonConvert.DeserializeObject<Position>( json1 );

            string json2 = JsonConvert.SerializeObject( position1 );
            var position2 = JsonConvert.DeserializeObject<Position>( json2 );

            Assert.Equal( position1, position2 );
            Assert.True( position1.Equals( position2 ) );
        }

        [Fact]
        public void PointGeometry()
        {
            string json1 = File.ReadAllText("files/point.json");
            var geo1 = JsonConvert.DeserializeObject<PointGeometry>( json1 );

            string json2 = JsonConvert.SerializeObject( geo1 );
            var geo2 = JsonConvert.DeserializeObject<PointGeometry>( json2 );

            Assert.Equal( geo1, geo2 );
            Assert.True( geo1.Equals( geo2 ) );

            var geo3 = JsonConvert.DeserializeObject<Geometry>( json1 );

            Assert.IsType<PointGeometry>( geo3 );
        }

        [Fact]
        public void TestingTesting()
        {
            string json1 = File.ReadAllText( "files/feature.json" );
            var feature = JsonConvert.DeserializeObject<Feature>( json1 );
        }
    }
}
