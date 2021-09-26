using System;
using System.Collections.Generic;
using System.Text;
using VehicleSummary.Api.Model;
using Xunit;

namespace VehicleSummary.UnitTests.ModelTest
{
    public class VehicleSummaryModelTest
    {
        [Fact]
        public void ConstructorTest()
        {
            VehicleSummaryModel vehicleSummaryModel = new VehicleSummaryModel("Some name", 7);

            Assert.Equal(7, vehicleSummaryModel.YearsAvailable);
            Assert.Equal("Some name", vehicleSummaryModel.Name);
        }
    }
}
