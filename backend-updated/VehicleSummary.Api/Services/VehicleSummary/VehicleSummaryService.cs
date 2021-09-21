using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using VehicleSummary.Api.Model;

namespace VehicleSummary.Api.Services.VehicleSummary

{

    public class VehicleSummaryService : IVehicleSummaryService
    {
        private const string _subscriptionKey = "72ec78fb999e43be8dbdac94d7236cae";
        private const int _cacheExpiryMinutes = 1;
        static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        private Dictionary<string, VehicleSummaryCache> _vehicleSummaryCache = new Dictionary<string, VehicleSummaryCache>();

        public async Task<VehicleSummaryResponse> GetSummaryByMake(string make)
        {
            VehicleSummaryResponse vehicleSummaryResponse = await VehicleSummaryCachedResponse(make);

            return vehicleSummaryResponse;
        }

        private async Task<VehicleSummaryResponse> VehicleSummaryCachedResponse(string make)
        {
            string upMake = make.ToUpper();

            if (!_vehicleSummaryCache.ContainsKey(upMake) || CacheExpired(_vehicleSummaryCache[upMake].Created))
            {
                //double-locking in case of simultaneous access 
                await _semaphoreSlim.WaitAsync();
                try
                {
                    if (!_vehicleSummaryCache.ContainsKey(upMake) || CacheExpired(_vehicleSummaryCache[upMake].Created))
                    {
                        VehicleSummaryResponse vehicleSummaryResponseCalc = await VehicleSummaryResponse(make);

                        _vehicleSummaryCache[upMake] = new VehicleSummaryCache(vehicleSummaryResponseCalc);
                    }
                }
                finally
                {
                    _semaphoreSlim.Release();
                }
            }

            VehicleSummaryResponse vehicleSummaryResponse = _vehicleSummaryCache[upMake].VehicleSummaryResponse;

            return vehicleSummaryResponse;
        }

        private bool CacheExpired(DateTime cacheDate)
        {
            var ageMinutes = (DateTime.Now - cacheDate).TotalMinutes;

            // return ageMinutes > _cacheExpiryMinutes;
            return true;
        }

        private async Task<VehicleSummaryResponse> VehicleSummaryResponse(string make)
        {
            VehicleSummaryResponse vehicleSummaryResponse = new VehicleSummaryResponse();

            List<VehicleSummaryModel> models = new List<VehicleSummaryModel>();

            List<string> modelsOfMake = await getModelsOfMake(make);

            foreach (string modelOfMake in modelsOfMake)
            {
                List<int> yearsOfModel = await geYearsOfModel(make, modelOfMake);

                VehicleSummaryModel summaryModel = new VehicleSummaryModel(modelOfMake, yearsOfModel.Count);

                models.Add(summaryModel);
            }

            vehicleSummaryResponse.Make = make;
            vehicleSummaryResponse.Models = models;

            return vehicleSummaryResponse;
        }

        //Here's a small helper. We're using Flurl for http requests. (Change it if you wish)
        //https://flurl.dev/

        async Task<List<string>> getModelsOfMake(string make)
        {   
            var modelsUrl = "https://api.iag.co.nz/vehicles/vehicletypes/makes/" + make + "/models?api-version=v1";

            var response = await modelsUrl
                .WithHeader("Ocp-Apim-Subscription-Key", _subscriptionKey)
                .GetJsonAsync<List<string>>();
                
            return response;
        }

        async Task<List<int>> geYearsOfModel(string make, string model)
        {
            var modelsUrl = "https://api.iag.co.nz/vehicles/vehicletypes/makes/"+ make + "/models/"+ model + "/years?api-version=v1";

            var response = await modelsUrl
                .WithHeader("Ocp-Apim-Subscription-Key", _subscriptionKey)
                .GetJsonAsync<List<int>>();

            return response;
        }

    }
}