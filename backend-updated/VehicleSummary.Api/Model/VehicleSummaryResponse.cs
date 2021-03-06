using System.Collections.Generic;
using VehicleSummary.Api.Model;

namespace VehicleSummary.Api.Model
{
    public class VehicleSummaryResponse
    {
        public string Make { get; set; }
        public List<VehicleSummaryModel> Models { get; set; }

        public VehicleSummaryResponse(string make, List<VehicleSummaryModel> models)
        {
            Make = make;
            Models = models;
        }

        public VehicleSummaryResponse()
        {
        }

        public string ToString()
        {
            return Make + " (" + Models.Count + " models)";
        }

    }
}