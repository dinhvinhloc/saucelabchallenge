using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SauceLabChallenge.Base
{
//Initialize and setup driver
	
	public class BasePage
	{
        public static IWebDriver driver;
		public void Initialize()
		{
            // Configure ChromeOptions for headless mode
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--headless");

            driver = new ChromeDriver(options);

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

