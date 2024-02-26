using SauceLabChallenge.Base;
using SauceLabChallenge.Pages;

namespace SauceLabChallenge.Tests
{
	public class CheckoutOverviewTest : BasePage
	{
        LoginPage loginPage;
        ProductsPage productsPage;
        CartPage cartPage;
        CheckoutBuyerInfoPage checkoutBuyerInfoPage;
        CheckoutOverviewPage checkoutOverviewPage;


        [OneTimeSetUp]
        public void Setup()
        {
            Initialize();
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            cartPage = new CartPage(driver);
            checkoutBuyerInfoPage = new CheckoutBuyerInfoPage(driver);
            checkoutOverviewPage = new CheckoutOverviewPage(driver);

            loginPage.Login("standard_user", "secret_sauce");
            productsPage.AddToCart("Sauce Labs Backpack");
            productsPage.AddToCart("Sauce Labs Bike Light");
            productsPage.AddToCart("Sauce Labs Fleece Jacket");
            productsPage.ClickOnCart();
            cartPage.ClickCheckout();
            checkoutBuyerInfoPage.inputFirstName("Firt");
            checkoutBuyerInfoPage.inputLastName("Last");
            checkoutBuyerInfoPage.inputZipCode("ABC XYZ");
            checkoutBuyerInfoPage.ClickContinue();
        }

        [Test, Order(1)]
        public void AssertCheckoutOverviewTest()
        {
            checkoutOverviewPage.AssertItemTotal();
            checkoutOverviewPage.AssertTotal();
        }


        [OneTimeTearDown]
        public void CloseDriver()
        {
            TearDown();
        }
    }
}

