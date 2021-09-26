using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSummary.Api.Services.VehicleSummary;

namespace VehicleSummary.Api.Model
{
    public class VehicleSummaryCacheRecord
    {
        public VehicleSummaryResponse VehicleSummaryResponse { get; set; }
        public DateTime Created { get; set; }

        public VehicleSummaryCacheRecord(VehicleSummaryResponse vehicleSummaryResponse)
        {
            VehicleSummaryResponse = vehicleSummaryResponse;
            Created = DateTime.Now;
        }

    }
}
