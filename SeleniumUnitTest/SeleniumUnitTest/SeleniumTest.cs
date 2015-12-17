using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumUnitTest
{
    [TestClass]
    public class SeleniumTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestAddCountry()
        {
            // go to url
            driver.Navigate().GoToUrl("http://localhost/Selenium/");

            // get input by id selector
            IWebElement input = driver.FindElement(By.Id("addCountryInput"));

            // add value to input
            input.SendKeys("The Netherlands");

            // get add button by class name
            IWebElement addButton = driver.FindElement(By.ClassName("btn-primary"));
            addButton.Click();

            // List<IWebElement> countryList = driver.FindElement(By.Id("countryList")).FindElements(By.TagName("li")).ToList();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
