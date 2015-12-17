using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace SeleniumNUnit
{
    [TestFixture]
    public class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TestAddCountryTest()
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
            Assert.IsTrue(true);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
