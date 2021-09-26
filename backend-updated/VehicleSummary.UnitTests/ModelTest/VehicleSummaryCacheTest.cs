using System;
using System.Collections.Generic;
using System.Text;
using VehicleSummary.Api.Model;
using Xunit;

namespace VehicleSummary.UnitTests.ModelTest
{
    public class VehicleSummaryCacheTest
    {
        [Fact]
        public void ConstructorTest()
        {
            List<VehicleSummaryModel> models = new List<VehicleSummaryModel> { new VehicleSummaryModel("Some make", 3), new VehicleSummaryModel("Other make", 4) };

            VehicleSummaryResponse vehicleSummaryResponse = new VehicleSummaryResponse("Lotus", models);

            VehicleSummaryCacheRecord vehicleSummaryCacheRecord = new VehicleSummaryCacheRecord(vehicleSummaryResponse);

            Assert.NotNull(vehicleSummaryCacheRecord.VehicleSummaryResponse);
            Assert.True(DateTime.Now >= vehicleSummaryCacheRecord.Created);
            Assert.Equal("Lotus", vehicleSummaryCacheRecord.VehicleSummaryResponse.Make);
            Assert.NotNull(vehicleSummaryCacheRecord.VehicleSummaryResponse.Models);
            Assert.Equal("Some make", vehicleSummaryCacheRecord.VehicleSummaryResponse.Models[0].Name);
            Assert.Equal(3, vehicleSummaryCacheRecord.VehicleSummaryResponse.Models[0].YearsAvailable);
        }
    }
}
