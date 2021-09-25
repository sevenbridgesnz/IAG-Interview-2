using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using VehicleSummary.Api.Interfaces;
using VehicleSummary.Api.Model;

namespace VehicleSummary.Api.Services.VehicleSummary
{
    public class VehicleSummaryService : IVehicleSummaryService
    {
        private const int _cacheExpiryMinutes = 60;
        static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
        IRestDataService _restDataService;

        private Dictionary<string, VehicleSummaryCache> _vehicleSummaryCache = new Dictionary<string, VehicleSummaryCache>();

        public VehicleSummaryService(IRestDataService restDataService)
        {
            _restDataService = restDataService;
        }

        public async Task<VehicleMakesResponse> GetMakes()
        {
            List<string> makes = await getMakes();

            VehicleMakesResponse response = new VehicleMakesResponse(makes);

            return response;
        }

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

            return ageMinutes > _cacheExpiryMinutes;
        }

        private async Task<VehicleSummaryResponse> VehicleSummaryResponse(string make)
        {
            make = make.ToUpper();

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

        async Task<List<string>> getModelsOfMake(string make)
        {
            var response = await _restDataService.GetModelsOfMake(make);
                
            return response;
        }

        async Task<List<int>> geYearsOfModel(string make, string model)
        {
            var response = await _restDataService.GetYearsOfModel(make, model);

            return response;
        }

        async Task<List<string>> getMakes()
        {
            var response = await _restDataService.GetMakes();

            return response;
        }
    }
}