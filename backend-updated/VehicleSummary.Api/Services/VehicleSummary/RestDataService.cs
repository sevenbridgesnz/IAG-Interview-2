using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSummary.Api.Interfaces;
using Flurl.Http;

namespace VehicleSummary.Api.Services.VehicleSummary
{
    public class RestDataService : IRestDataService
    {
        private const string _subscriptionKey = "72ec78fb999e43be8dbdac94d7236cae";

        async public Task<List<string>> GetModelsOfMake(string make)
        {
            var modelsUrl = "https://api.iag.co.nz/vehicles/vehicletypes/makes/" + make + "/models?api-version=v1";

            var response = await modelsUrl
                .WithHeader("Ocp-Apim-Subscription-Key", _subscriptionKey)
                .GetJsonAsync<List<string>>();

            return response;
        }

        async public Task<List<int>> GetYearsOfModel(string make, string model)
        {
            var modelsUrl = "https://api.iag.co.nz/vehicles/vehicletypes/makes/" + make + "/models/" + model + "/years?api-version=v1";

            var response = await modelsUrl
                .WithHeader("Ocp-Apim-Subscription-Key", _subscriptionKey)
                .GetJsonAsync<List<int>>();

            return response;
        }
        async public Task<List<string>> GetMakes()
        {
            //this is hardcoded as it hits limit of this excercise
            List<string> makes = new List<string>();
            makes.Add("Lotus");
            makes.Add("This will fail");

            return makes;
        }
    }
}
