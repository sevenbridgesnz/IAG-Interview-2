using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSummary.Api.Services.VehicleSummary
{
    public interface IVehicleSummaryService
    {
        Task<VehicleSummaryResponse> GetSummaryByMake(string make);
    }

}
