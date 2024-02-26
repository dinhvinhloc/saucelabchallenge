
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceLabChallenge.Base;
using SeleniumExtras.PageObjects;

namespace SauceLabChallenge.Pages
{
    public class ProductsPage : BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        public ProductsPage(IWebDriver driver)
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
                IWebElement cartBadge = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".shopping_cart_badge")));
                return int.Parse(cartBadge.Text);
            } else
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

        public void AddToCart(string itemName)
        {

            // Get the initial item count
            int initialItemCount = GetCartItemCount();

            // Click on the "Add to cart" button for the specified item
            IWebElement addToCartButton = driver.FindElement(By.CssSelector($"#add-to-cart-{itemName.Replace(" ", "-").ToLower()}"));
            addToCartButton.Click();

            // Wait for the item count to increase
            wait.Until(driver => GetCartItemCount() == initialItemCount + 1);

        }

        public void ClickRemoveButton(string itemName)
        {
            // Get the initial item count
            int initialItemCount = GetCartItemCount();

            // Click on the "Remove" button for the specified item
            IWebElement removeButton = driver.FindElement(By.CssSelector($"#remove-{itemName.Replace(" ", "-").ToLower()}"));
            removeButton.Click();

            // Wait for the item count to decrease
            wait.Until(driver => GetCartItemCount() == initialItemCount - 1);
        }

        public void ClickOnProduct(string itemName)
        {
            IWebElement element = driver.FindElement(By.XPath($"//div[contains(@class, 'inventory_item_name') and text()='{itemName}']"));
            element.Click();
            System.Threading.Thread.Sleep(1000);

        }

        public void ClickOnCart()
        {
            IWebElement element = driver.FindElement(By.ClassName("shopping_cart_link"));
            element.Click();
            System.Threading.Thread.Sleep(1000);

        }

    }
}

