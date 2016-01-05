using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace SeleniumNUnit
{
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class TestClass<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            driver = new TWebDriver();
            driver.Navigate().GoToUrl("http://localhost/selenium-demo/");
        }

        [Test]
        public void AddCountryTest()
        {
            String country = "The Netherlands";

            // get and set input by id selector
            IWebElement input = driver.FindElement(By.Id("country"));
            input.SendKeys(country);

            // get submit button by class name
            IWebElement button = driver.FindElement(By.ClassName("btn-large"));
            button.Click();

            // get last added item
            List<IWebElement> list = driver.FindElement(By.Id("list")).FindElements(By.TagName("li")).ToList();
            String value = list.Last().Text;

            // check if last value is equal to added country
            Assert.AreEqual(country, value);
        }

        [Test]
        public void CheckCountryTest()
        {
            // get last added item and select checkbox
            List<IWebElement> list = driver.FindElement(By.Id("list")).FindElements(By.TagName("li")).ToList();
            IWebElement checkbox = list.Last().FindElement(By.TagName("input"));
            IWebElement label = list.Last().FindElement(By.TagName("label"));
            label.Click();

            // check if checkbox is selected
            Assert.IsTrue(checkbox.Selected);
        }

        [Test]
        public void ArchiveTest()
        {
            // click on archive button
            IWebElement archive = driver.FindElement(By.ClassName("archive"));
            archive.Click();

            // get values of todos
            int total = Int32.Parse(driver.FindElement(By.ClassName("total-todos")).Text);
            int remaining = Int32.Parse(driver.FindElement(By.ClassName("remaining-todos")).Text);

            // check if total is equal to remaining
            Assert.AreEqual(total, remaining);
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver.Quit();
            }              
        }
    }
}
