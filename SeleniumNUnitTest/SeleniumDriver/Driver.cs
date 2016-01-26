using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumDriver
{
    public class Driver
    {
        public static IWebDriver driver;

        public static void Main(String[] args)
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.nl");
            driver.Manage().Window.Maximize();

            // DOM Manipulatie voor tweede demo
            //DOMManipulation();

            // Events voor derde demo
            //Events();  

            // driver.Close();
        }


        private static void DOMManipulation()
        {
            // Zoekveld van Google
            IWebElement searchbar = driver.FindElement(By.Id("lst-ib"));
            searchbar.SendKeys("Selenium framework");
        }

        private static void Events()
        {
            // Zoekbutton van Google
            IWebElement button = driver.FindElement(By.Name("btnG"));
            button.Click();
        }
    }
}