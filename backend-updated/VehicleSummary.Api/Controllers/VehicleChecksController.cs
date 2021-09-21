using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleSummary.Api.Services.VehicleSummary;
using Flurl.Http;
using System.Collections.Generic;

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
            var response = await _vehicleSummaryService.GetSummaryByMake(make);
            
            return Ok(response);
        }

        [HttpGet]
        [Route("/vehicle-checks/makes")]
        public async Task<IActionResult> Makes()
        {
            //for completeness and to support the front end, I will also do API that returns list of makes
            //to comply with the requirements to use "Lotus" only, this will be hardcoded
            //the second car is included to demonstrate loading state
            List<string> makes = new List<string>();
            makes.Add("Lotus");
            makes.Add("This will fail");

            return Ok(makes);
        }
    }
}