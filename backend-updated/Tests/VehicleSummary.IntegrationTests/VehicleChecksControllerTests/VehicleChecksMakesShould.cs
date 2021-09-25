using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace VehicleSummary.IntegrationTests.VehicleChecksControllerTests
{
    public class VehicleChecksMakesShould: TestBase
    {
        [Test]
        public void BasicTest()
        {
            _webDriver.Url = _websiteURL;

            var selectElement = FindElementById("modelSelect");
            
            //wait till text is loaded from API
            _wait.Until((d) => { return selectElement.Text != ""; });

            //if the select element has text it means it was loaded
            string selectedValue = selectElement.Text.Trim();
            Assert.IsNotEmpty(selectedValue);
        }

        [Test]
        public void DataAreLoaded()
        {
            _webDriver.Url = _websiteURL;

            //make sure that a make list was loaded - find a row in the table
            var firstRowElement = FindElementByXPathWait("//*[@id=\"root\"]/div[3]/table/tbody/tr[1]");

            //does the table have data loaded?
            var table = _webDriver.FindElement(By.TagName("table"));
            var rows = table.FindElements(By.TagName("tr"));

            //the count includes header
            Assert.IsTrue(1 < rows.Count);
        }

        [Test]
        public void DataFilteringWorks()
        {
            _webDriver.Url = _websiteURL;

            //make sure that a make list was loaded - find a row in the table
            var firstRowElement = FindElementByXPathWait("//*[@id=\"root\"]/div[3]/table/tbody/tr[1]");
            
            var filterElement = FindElementById("filter-id");
            filterElement.SendKeys("2 Eleven");

            //wait to give the filtering function time
            System.Threading.Thread.Sleep(500);

            var table = _webDriver.FindElement(By.TagName("table"));
            var rows = table.FindElements(By.TagName("tr"));

            //the count includes header
            Assert.AreEqual(2, rows.Count);
        }

        [Test]
        public void FailingSelectionOfMake()
        {
            _webDriver.Url = _websiteURL;

            var selectElement = FindElementById("modelSelect");
            
            //drop down
            selectElement.Click();

            //find invalid drop down entry
            var failSelectElement = FindElementByXPathWait("//*[text()='This will fail']");
            failSelectElement.Click();

            //wait till the error message appears
            var failMessageElement = FindElementById("load-error-label");
        }
    }
}