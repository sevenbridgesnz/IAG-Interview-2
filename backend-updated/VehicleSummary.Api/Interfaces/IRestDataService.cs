using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSummary.Api.Interfaces
{
    public interface IRestDataService
    {
        Task<List<int>> GetYearsOfModel(string make, string model);
        Task<List<string>> GetModelsOfMake(string make);
        Task<List<string>> GetMakes();
    }
}
