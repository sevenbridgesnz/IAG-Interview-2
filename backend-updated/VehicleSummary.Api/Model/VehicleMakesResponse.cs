using System.Collections.Generic;

namespace VehicleSummary.Api.Model
{
    public class VehicleMakesResponse
    {
        public List<string> Makes { get; set; }

        public VehicleMakesResponse(List<string> makes)
        {
            Makes = makes;
        }
    }
}