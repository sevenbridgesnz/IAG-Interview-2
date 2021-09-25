using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleSummary.Api.Interfaces;

namespace VehicleSummary.UnitTests.Mocks
{
    public class RestDataServiceMock : IRestDataService
    {
        public async Task<List<string>> GetMakes()
        {
            List<string> makes = new List<string>();
            makes.Add("Lotus");
            makes.Add("This will fail");

            return makes;
        }

        public async Task<List<string>> GetModelsOfMake(string make)
        {
            if (make.ToUpper() == "LOTUS")
            {
                string json = Properties.Resources.mockModels_Lotus;
                List<string> makes = JsonConvert.DeserializeObject<List<string>>(json);

                return makes;
            }

            throw new Exception("Make not found");
        }

        public async Task<List<int>> GetYearsOfModel(string make, string model)
        {
            if (make.ToUpper() == "LOTUS")
            {
                string json = Properties.Resources.mockMakes_Lotus;
                Dictionary<string, List<int>> makes = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(json);

                List<int> years = makes[model];

                return years;
            }

            throw new Exception("Make not found");
        }
    }
}
