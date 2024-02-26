
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceLabChallenge.Base;
using SeleniumExtras.PageObjects;

namespace SauceLabChallenge.Pages
{
    public class CartPage : BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }


        public void Remove(string itemName)
        {
            // Find the remove button for the specified item and click it
            IWebElement removeButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector($"button[data-test='remove-{itemName.ToLower().Replace(" ", "-")}']")));
            removeButton.Click();

            // Wait for the cart to update
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(removeButton));

            // Assert that the number of items in the cart is decreased
            AssertNumberOfItemsInCart();
        }

        public void AssertNumberOfItemsInCart()
        {
            // Get the number of items displayed in the cart badge
            IWebElement cartBadge = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".shopping_cart_badge")));
            int numberOfItemsInCart = int.Parse(cartBadge.Text);

            // Get the count of rows in the cart list
            ReadOnlyCollection<IWebElement> cartItems = driver.FindElements(By.CssSelector(".cart_item"));
            int numberOfCartItems = cartItems.Count;

            // Assert that the number of items in the cart is equal to the number of rows multiplied by quantity

            Assert.That(numberOfItemsInCart, Is.EqualTo(numberOfCartItems));

        }

        public void ClickCheckout()
        {
            // Click on the Checkout button
            IWebElement checkoutButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("checkout")));
            checkoutButton.Click();

            String title = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("title"))).Text;
            Assert.That(title, Is.EqualTo("Checkout: Your Information"));

        }

        public void ClickContinueShopping()
        {
            // Click on the Continue Shopping button
            IWebElement continueShoppingButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("continue-shopping")));
            continueShoppingButton.Click();

        }

    }
}

