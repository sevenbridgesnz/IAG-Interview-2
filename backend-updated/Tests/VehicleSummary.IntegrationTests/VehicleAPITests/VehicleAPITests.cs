using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace VehicleSummary.IntegrationTests.VehicleAPITests
{
    public class VehicleAPITests
    {
        private string _apiURL;

        public VehicleAPITests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
            _apiURL = config["api-url"];
        }

        [Test]
        public async Task TestMakesAsync()
        {
            var modelsUrl = _apiURL + "vehicle-checks/makes";

            var response = await modelsUrl
                .GetStringAsync();

            var definition = new { makes = new List<string>() };

            var data = JsonConvert.DeserializeAnonymousType(response, definition);

            Assert.IsNotEmpty(data.makes);
            Assert.IsTrue(data.makes.Count > 0);
        }

        [Test]
        public async Task ReadLotusData()
        {
            var modelsUrl = _apiURL + "vehicle-checks/makes/Lotus";

            var response = await modelsUrl
                .GetStringAsync();

            var definition = new { make = "", models = new[] { new { name = "", yearsAvailable = 0 } } };

            var data = JsonConvert.DeserializeAnonymousType(response, definition);

            Assert.AreEqual("LOTUS", data.make);
            Assert.IsNotNull(data.models);
            Assert.IsNotEmpty(data.models);
        }
    }
}
