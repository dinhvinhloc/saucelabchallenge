using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceLabChallenge.Base
{
//Initialize and setup driver
	
	public class BasePage
	{
        public static IWebDriver driver;
		public void Initialize()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.saucedemo.com/");
			//driver.Manage().Window.Maximize();
		}

		public static void TearDown()
		{
            System.Threading.Thread.Sleep(2000);
            driver.Close();
			driver.Dispose();
		}
	}
}

