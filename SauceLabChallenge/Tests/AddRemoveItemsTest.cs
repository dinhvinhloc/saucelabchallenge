using SauceLabChallenge.Base;
using SauceLabChallenge.Pages;

namespace SauceLabChallenge.Tests
{
    public class AddRemoveItemsTest : BasePage
    {
        LoginPage loginPage;
        ProductsPage productsPage;


        [OneTimeSetUp]
        public void Setup()
        {
            Initialize();
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test, Order(1)]
        public void AddItemsToCart()
        {
            productsPage.AddToCart("Sauce Labs Backpack");
            productsPage.AddToCart("Sauce Labs Bike Light");

        }

        [Test, Order(2)]
        public void RemoveItems()
        {
            productsPage.ClickRemoveButton("Sauce Labs Backpack");
            productsPage.ClickRemoveButton("Sauce Labs Bike Light");

        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            TearDown();
        }
    }
}

