using System;
using System.Collections.Generic;
using System.Text;
using VehicleSummary.Api.Model;
using Xunit;

namespace VehicleSummary.UnitTests.ModelTest
{
    public class VehicleMakesResponseTest
    {
        [Fact]
        public void ConstructorTest()
        {
            List<string> makes = new List<string> { "Lotus", "BMW" };
            VehicleMakesResponse vehicleMakesResponse = new VehicleMakesResponse(makes);

            Assert.Equal(2, vehicleMakesResponse.Makes.Count);
            Assert.Equal("Lotus", vehicleMakesResponse.Makes[0]);
        }
    }
}
