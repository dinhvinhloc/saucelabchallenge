using SauceLabChallenge.Base;
using SauceLabChallenge.Pages;

namespace SauceLabChallenge.Tests
{
	public class CheckoutInfoTest : BasePage
	{
        LoginPage loginPage;
        ProductsPage productsPage;
        CartPage cartPage;
        CheckoutBuyerInfoPage checkoutBuyerInfoPage;

        [OneTimeSetUp]
        public void Setup()
        {
            Initialize();
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            cartPage = new CartPage(driver);
            checkoutBuyerInfoPage = new CheckoutBuyerInfoPage(driver);

            loginPage.Login("standard_user", "secret_sauce");
            productsPage.AddToCart("Sauce Labs Backpack");
            productsPage.AddToCart("Sauce Labs Bike Light");
            productsPage.AddToCart("Sauce Labs Fleece Jacket");
            productsPage.ClickOnCart();
            cartPage.ClickCheckout();
        }

        [Test, Order(1)]
        public void NoFirstNameTest()
        {
            checkoutBuyerInfoPage.ClickContinue();
            checkoutBuyerInfoPage.AssertErrorMessage("Error: First Name is required");
        }

        [Test, Order(2)]
        public void NoLastnameTest()
        {
            checkoutBuyerInfoPage.inputFirstName("First");
            checkoutBuyerInfoPage.ClickContinue();
            checkoutBuyerInfoPage.AssertErrorMessage("Error: Last Name is required");
        }
        [Test, Order(3)]
        public void NoZipCodeTest()
        {
            checkoutBuyerInfoPage.inputFirstName("First");
            checkoutBuyerInfoPage.inputLastName("Last");
            checkoutBuyerInfoPage.ClickContinue();
            checkoutBuyerInfoPage.AssertErrorMessage("Error: Postal Code is required");
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            TearDown();
        }
    }
}

