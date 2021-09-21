using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSummary.Api.Services.VehicleSummary;

namespace VehicleSummary.Api.Model
{
    public class VehicleSummaryCache
    {
        public VehicleSummaryResponse VehicleSummaryResponse { get; set; }
        public DateTime Created { get; set; }

        public VehicleSummaryCache()
        {

        }

        public VehicleSummaryCache(VehicleSummaryResponse vehicleSummaryResponse)
        {
            VehicleSummaryResponse = vehicleSummaryResponse;
            Created = DateTime.Now;
        }

    }
}
