using System.Collections.Generic;
using VehicleSummary.Api.Model;

namespace VehicleSummary.Api.Services.VehicleSummary
{
    public class VehicleSummaryResponse
    {
        public string Make { get; set; }
        public List<VehicleSummaryModel> Models { get; set; }

        public VehicleSummaryResponse()
        {

        }

        public VehicleSummaryResponse(string make, List<VehicleSummaryModel> models)
        {
            Make = make;
            Models = models;
        }

        public string ToString()
        {
            return Make + " (" + Models.Count + " models)";
        }

    }
}