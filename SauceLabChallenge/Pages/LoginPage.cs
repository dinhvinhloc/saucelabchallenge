
using OpenQA.Selenium;
using SauceLabChallenge.Base;
using SeleniumExtras.PageObjects;

namespace SauceLabChallenge.Pages
{
    public class LoginPage : BasePage
	{
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"username\"]")]

        private IWebElement usernameText;

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"password\"]")]

        private IWebElement passwordText;

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"login-button\"]")]

        private IWebElement loginBtn;

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"error\"]")]

        private IWebElement errorText;

        public void InputUsername(String username)
        {
            usernameText.Clear();
            usernameText.SendKeys(username);
        }

        public void InputPassword(String password)
        {
            usernameText.Clear();
            passwordText.SendKeys(password);
        }

        public void ClickLogin()
        {
            loginBtn.Click();
        }

        public void AssertErrorMessage(String message)
        {
            String errorMessage = errorText.Text;
            Assert.That(errorMessage, Is.EqualTo(message));
        }

        public void Login(String username, String password)
        {
            this.InputUsername(username);
            this.InputPassword(password);
            this.ClickLogin();
        }

    }
}

