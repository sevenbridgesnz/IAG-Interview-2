using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSummary.Api.Model;

namespace VehicleSummary.Api.Interfaces
{
    public interface IVehicleSummaryService
    {
        Task<VehicleSummaryResponse> GetSummaryByMake(string make);
        Task<VehicleMakesResponse> GetMakes();
    }

}
