
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceLabChallenge.Base;
using SeleniumExtras.PageObjects;

namespace SauceLabChallenge.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        private IWebDriver driver;


        public CheckoutOverviewPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Function to assert item total
        public void AssertItemTotal()
        {
            // Get the quantity of each item and its price
            var quantities = driver.FindElements(By.CssSelector(".cart_quantity"));
            var prices = driver.FindElements(By.CssSelector(".inventory_item_price"));

            double itemTotal = 0;

            // Calculate item total
            for (int i = 0; i < quantities.Count; i++)
            {
                int quantity = int.Parse(quantities[i].Text);
                double price = double.Parse(prices[i].Text.Replace("$", ""));
                itemTotal += quantity * price;
            }

            // Get the text of item total from the webpage
            string itemTotalText = driver.FindElement(By.CssSelector(".summary_subtotal_label")).Text.Replace("Item total: $", "");
            double itemTotalFromPage = double.Parse(itemTotalText);

            // Assert that calculated item total matches the item total from the webpage
            Assert.That(itemTotal, Is.EqualTo(itemTotalFromPage));
        }

        // Function to assert total
        public void AssertTotal()
        {
            // Get the item total and tax
            string itemTotalText = driver.FindElement(By.CssSelector(".summary_subtotal_label")).Text.Replace("Item total: $", "");
            double itemTotal = double.Parse(itemTotalText);

            string taxText = driver.FindElement(By.CssSelector(".summary_tax_label")).Text.Replace("Tax: $", "");
            double tax = double.Parse(taxText);

            // Get the total from the webpage
            string totalText = driver.FindElement(By.CssSelector(".summary_total_label")).Text.Replace("Total: $", "");
            double totalFromPage = double.Parse(totalText);

            // Assert that calculated total matches the total from the webpage
            Assert.That(totalFromPage, Is.EqualTo(itemTotal + tax));

        }

        // Function to click on the Finish button
        public void ClickFinish()
        {
            // Find and click on the Finish button
            driver.FindElement(By.Id("finish")).Click();
        }

        // Function to click on the Cancel button
        public void ClickCancel()
        {
            // Find and click on the Cancel button
            driver.FindElement(By.Id("cancel")).Click();
        }

    }
}

