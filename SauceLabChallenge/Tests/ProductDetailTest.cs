using SauceLabChallenge.Base;
using SauceLabChallenge.Pages;

namespace SauceLabChallenge.Tests
{
    public class ProductDetailTest : BasePage
    {
        LoginPage loginPage;
        ProductsPage productPage;
        ProductDetailsPage productDetailsPage;


        [OneTimeSetUp]
        public void Setup()
        {
            Initialize();
            loginPage = new LoginPage(driver);
            productPage = new ProductsPage(driver);
            productDetailsPage = new ProductDetailsPage(driver);
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test, Order(1)]
        public void AddProductToCartFromProductDetailPage()
        {
            productPage.ClickOnProduct("Sauce Labs Backpack");
            productDetailsPage.AddToCart();
        }

        [Test, Order(2)]
        public void RemoveProductToCartFromProductDetailPage()
        {
            productDetailsPage.Remove();

        }
        [Test, Order(3)]
        public void BackToProductsPage()
        {
            productDetailsPage.BackToProducts();
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            TearDown();
        }
    }
}
