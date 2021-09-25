using System;
using System.Collections.Generic;
using System.Text;
using VehicleSummary.Api.Interfaces;
using VehicleSummary.Api.Model;
using VehicleSummary.Api.Services.VehicleSummary;
using VehicleSummary.UnitTests.Mocks;
using Xunit;

namespace VehicleSummary.UnitTests.ServicesTests
{
    public class VehicleSummaryServiceTest
    {
        IRestDataService _restMock;

        public VehicleSummaryServiceTest()
        {
            _restMock = new RestDataServiceMock();
        }

        [Fact]
        public async void GetMakes()
        {
            IVehicleSummaryService vehicleSummaryService = new VehicleSummaryService(_restMock);

            VehicleMakesResponse vehicleMakesResponse = await vehicleSummaryService.GetMakes();

            Assert.NotEmpty(vehicleMakesResponse.Makes);
        }

        [Fact]
        public async void GetMakes_HasAllRecords()
        {
            IVehicleSummaryService vehicleSummaryService = new VehicleSummaryService(_restMock);

            VehicleMakesResponse vehicleMakesResponse = await vehicleSummaryService.GetMakes();

            Assert.Equal(2, vehicleMakesResponse.Makes.Count);
        }

        [Fact]
        public async void GetMakes_HasLotusRecord()
        {
            IVehicleSummaryService vehicleSummaryService = new VehicleSummaryService(_restMock);

            VehicleMakesResponse vehicleMakesResponse = await vehicleSummaryService.GetMakes();

            Assert.Equal("Lotus", vehicleMakesResponse.Makes[0]);
        }

        [Fact]
        public async void GetModelSummary_LotusRecord()
        {
            IVehicleSummaryService vehicleSummaryService = new VehicleSummaryService(_restMock);

            VehicleSummaryResponse vehicleSummaryResponse = await vehicleSummaryService.GetSummaryByMake("Lotus");

            Assert.Equal(8, vehicleSummaryResponse.Models.Count);
        }

        [Fact]
        public async void GetModelSummary_Calculations()
        {
            IVehicleSummaryService vehicleSummaryService = new VehicleSummaryService(_restMock);

            VehicleSummaryResponse vehicleSummaryResponse = await vehicleSummaryService.GetSummaryByMake("Lotus");

            Assert.Equal(1, vehicleSummaryResponse.Models[0].YearsAvailable);
            Assert.Equal(2, vehicleSummaryResponse.Models[1].YearsAvailable);
            Assert.Equal(3, vehicleSummaryResponse.Models[2].YearsAvailable);
            Assert.Equal(4, vehicleSummaryResponse.Models[3].YearsAvailable);
            Assert.Equal(5, vehicleSummaryResponse.Models[4].YearsAvailable);
            Assert.Equal(6, vehicleSummaryResponse.Models[5].YearsAvailable);
            Assert.Equal(7, vehicleSummaryResponse.Models[6].YearsAvailable);
            Assert.Equal(8, vehicleSummaryResponse.Models[7].YearsAvailable);
        }
    }
}
