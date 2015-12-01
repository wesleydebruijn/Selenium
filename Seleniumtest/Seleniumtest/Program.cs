using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;



namespace Seleniumtest
{
    class Program
    {
         

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/todo/");
            driver.Manage().Window.Maximize();


            IWebElement countryInput = driver.FindElement(By.Id("addCountryInput"));

            countryInput.SendKeys("verwegistan");

            IWebElement addButton = driver.FindElement(By.ClassName("btn-primary"));
            addButton.Click();



            List<IWebElement> countryList = driver.FindElement(By.Id("countryList")).FindElements(By.TagName("li")).ToList();
 
            foreach(var li in countryList)
            {
                Console.WriteLine("Land" + li.GetAttribute("innerHTML"));
            }
            Console.ReadLine();

        }


    }
}
