
using OpenQA.Selenium;
using SauceLabChallenge.Base;
using SeleniumExtras.PageObjects;

namespace SauceLabChallenge.Pages
{
    public class CheckoutBuyerInfoPage : BasePage
    {
        private IWebDriver driver;

        public CheckoutBuyerInfoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"firstName\"]")]

        private IWebElement firstNameText;

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"lastName\"]")]

        private IWebElement lastNameText;

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"postalCode\"]")]

        private IWebElement zipCodeText;

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"error\"]")]

        private IWebElement errorText;

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"continue\"]")]

        private IWebElement continueButton;

        [FindsBy(How = How.CssSelector, Using = "[data-test=\"cancel\"]")]

        private IWebElement cancelButton;

        public void inputFirstName(String firstName)
        {
            firstNameText.Clear();
            firstNameText.SendKeys(firstName);
        }

        public void inputLastName(String lastName)
        {
            lastNameText.Clear();
            lastNameText.SendKeys(lastName);
        }

        public void inputZipCode(String zipCode)
        {
            zipCodeText.Clear();
            zipCodeText.SendKeys(zipCode);
        }

        public void AssertErrorMessage(String message)
        {
            String errorMessage = errorText.Text;
            Assert.That(errorMessage, Is.EqualTo(message));
        }

        public void ClickContinue()
        {
            continueButton.Click();
        }

    }
}

