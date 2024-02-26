
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceLabChallenge.Base;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace SauceLabChallenge.Pages
{
    public class ProductDetailsPage : BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        public ProductDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }



        public int GetCartItemCount()
        {

            // Check if the cart badge is present
            bool isCartBadgePresent = IsElementPresent(By.CssSelector(".shopping_cart_badge"));

            if (isCartBadgePresent)
            {
                IWebElement cartBadge = driver.FindElement(By.CssSelector(".shopping_cart_badge"));
                return int.Parse(cartBadge.Text);
            }
            else
            {
                return 0;
            }

        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public void AddToCart()
        {

            // Get the initial item count
            int initialItemCount = GetCartItemCount();

            // Click on the "Add to cart" button
            IWebElement addToCartButton = driver.FindElement(By.XPath($"//button[contains(@class, 'btn_primary') and text()='Add to cart']"));

            addToCartButton.Click();

            // Wait for the item count to increase
            wait.Until(driver => GetCartItemCount() == initialItemCount + 1);

        }
        public void Remove()
        {

            // Get the initial item count
            int initialItemCount = GetCartItemCount();

            // Click on the "Remove" button
            IWebElement removeButton = driver.FindElement(By.XPath($"//button[contains(@class, 'btn_secondary') and text()='Remove']"));
            removeButton.Click();

            // Wait for the item count to increase
            wait.Until(driver => GetCartItemCount() == initialItemCount - 1);

        }

        public void BackToProducts()
        {
            // Find the "Back to products" button
            IWebElement backButton = driver.FindElement(By.Id("back-to-products"));

            // Click the button
            backButton.Click();
        }

    }
}

