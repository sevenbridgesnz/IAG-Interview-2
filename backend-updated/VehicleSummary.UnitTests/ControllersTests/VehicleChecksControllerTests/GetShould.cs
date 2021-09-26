using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using VehicleSummary.Api.Controllers;
using VehicleSummary.Api.Interfaces;
using VehicleSummary.Api.Model;
using VehicleSummary.Api.Services.VehicleSummary;
using Xunit;

namespace VehicleSummary.UnitTests.ControllersTests.VehicleChecksControllerTests
{
    public class GetShould
    {
        private readonly VehicleChecksController vehicleChecksController;
        private readonly IVehicleSummaryService _fakeVehicleSummaryService;

        public GetShould()
        {
            _fakeVehicleSummaryService = A.Fake<IVehicleSummaryService>();
            vehicleChecksController = new VehicleChecksController(_fakeVehicleSummaryService);
        }
        

        [Fact]
        public async Task Call_VehicleSummaryService_with_given_make()
        {
            var make = "Lotus";

            A.CallTo(() => _fakeVehicleSummaryService.GetSummaryByMake(make))
                .Returns(new VehicleSummaryResponse());       

            var response = await vehicleChecksController.Makes(make);

            A.CallTo(() => _fakeVehicleSummaryService.GetSummaryByMake(make))
                .MustHaveHappened();
        }
    }
}