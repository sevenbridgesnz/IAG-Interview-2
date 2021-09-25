using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleSummary.Api.Services.VehicleSummary;
using Flurl.Http;
using System.Collections.Generic;
using VehicleSummary.Api.Interfaces;

namespace VehicleSummary.Api.Controllers
{
    public class VehicleChecksController : Controller
    {
        private readonly IVehicleSummaryService _vehicleSummaryService;

        public VehicleChecksController(IVehicleSummaryService vehicleSummaryService)
        {
           _vehicleSummaryService = vehicleSummaryService;
        }
        
        // GET
        [HttpGet]
        [Route("/vehicle-checks/makes/{make}")]
        public async Task<IActionResult> Makes(string make)
        {
            try
            {
                var response = await _vehicleSummaryService.GetSummaryByMake(make);

                return Ok(response);
            }
            catch (Exception caught)
            {
                Logging.Error("There was an error calling Makes(make) function", caught);

                //here, I would sanitize the exception or do other function,
                //depending on the enterprise pattern
                throw;
            }
        }

        [HttpGet]
        [Route("/vehicle-checks/makes")]
        public async Task<IActionResult> Makes()
        {
            try
            {
                //to comply with the requirements to use "Lotus" only, this will be hardcoded
                //the second car is included to demonstrate loading state and failure
                var response = await _vehicleSummaryService.GetMakes();

                return Ok(response);
            }
            catch (Exception caught)
            {
                Logging.Error("There was an error calling Makes() function", caught);

                //here, I would sanitize the exception or do other function,
                //depending on the enterprise pattern
                throw;
            }
        }
    }
}