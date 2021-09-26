using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;

namespace VehicleSummary.IntegrationTests.VehicleChecksControllerTests
{
    public class TestBase
    {
        protected IWebDriver _webDriver;
        protected WebDriverWait _wait;
        protected bool _isHeadless;
        protected string _websiteURL;

        public TestBase()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            _websiteURL = config["site-url"];
            _isHeadless = config["isHeadless"] == "true";
        }

        [SetUp]
        public void start_Browser()
        {
            // Local Selenium WebDriver
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            if (_isHeadless)
            {
                options.AddArgument("--headless");
            }

            _webDriver = new ChromeDriver(".", options);
            _webDriver.Manage().Window.Size = new Size(1400, 1200);

            _wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 0, 10));
        }

        [TearDown]
        public void close_Browser()
        {
            _webDriver.Quit();
        }

        public IWebElement FindElementById(string id)
        {
            var element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(id)));

            return element;
        }

        public IWebElement FindElementByXPathWait(string xpath)
        {
            var element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

            return element;
        }

    }
}
