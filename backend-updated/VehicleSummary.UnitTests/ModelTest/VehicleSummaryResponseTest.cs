using System;
using System.Collections.Generic;
using System.Text;
using VehicleSummary.Api.Model;
using Xunit;

namespace VehicleSummary.UnitTests.ModelTest
{
    public class VehicleSummaryResponseTest
    {
        [Fact]
        public void ConstructorTest()
        {
            List<VehicleSummaryModel> models = new List<VehicleSummaryModel> { new VehicleSummaryModel("Some make", 3), new VehicleSummaryModel("Other make", 4) };
            VehicleSummaryResponse vehicleSummaryResponse = new VehicleSummaryResponse("Lotus", models);

            Assert.Equal("Lotus", vehicleSummaryResponse.Make);
            Assert.Equal("Some make", vehicleSummaryResponse.Models[0].Name);
        }
    }
}
