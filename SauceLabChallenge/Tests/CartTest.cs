using SauceLabChallenge.Base;
using SauceLabChallenge.Pages;

namespace SauceLabChallenge.Tests
{
    public class CartTest : BasePage
    {
        LoginPage loginPage;
        ProductsPage productsPage;
        CartPage cartPage;


        [OneTimeSetUp]
        public void Setup()
        {
            Initialize();
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            cartPage = new CartPage(driver);
            
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test, Order(1)]
        public void NumberOfItemInCartTest()
        {
            productsPage.AddToCart("Sauce Labs Backpack");
            productsPage.AddToCart("Sauce Labs Bike Light");
            productsPage.AddToCart("Sauce Labs Fleece Jacket");
            productsPage.ClickOnCart();
            cartPage.AssertNumberOfItemsInCart();

        }
        [Test, Order(2)]
        public void RemoveItemFromCart()
        {
            cartPage.AssertNumberOfItemsInCart();
            cartPage.Remove("Sauce Labs Bike Light");
        }
        [Test, Order(3)]
        public void ClickOnCheckoutTest()
        {
            cartPage.ClickCheckout();
        }


        [OneTimeTearDown]
        public void CloseDriver()
        {
            TearDown();
        }
    }
}

