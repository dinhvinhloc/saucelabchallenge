using SauceLabChallenge.Base;
using SauceLabChallenge.Pages;

namespace SauceLabChallenge.Tests
{
	public class LoginTest : BasePage
	{
		LoginPage loginPage;


        [OneTimeSetUp]
        public void Setup()
        {
            Initialize();
            loginPage = new LoginPage(driver);
        }

        [Test,Order(1)]
		public void NoUsernameTest()
		{
            loginPage.ClickLogin();
            loginPage.AssertErrorMessage("Epic sadface: Username is required");
        }

        [Test,Order(2)]
        public void NoPasswordTest()
        {
            loginPage.InputUsername("Any_user");
            loginPage.ClickLogin();
            loginPage.AssertErrorMessage("Epic sadface: Password is required");
        }
        [Test, Order(2)]
        public void LockedoutUserTest()
        {
            loginPage.InputUsername("locked_out_user");
            loginPage.InputPassword("secret_sauce");
            loginPage.ClickLogin();
            loginPage.AssertErrorMessage("Epic sadface: Sorry, this user has been locked out.");
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            TearDown();
        }
    }
}

