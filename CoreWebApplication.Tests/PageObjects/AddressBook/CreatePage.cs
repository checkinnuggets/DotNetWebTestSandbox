using OpenQA.Selenium;

namespace CoreWebApplication.Tests.PageObjects.AddressBook
{
    public class CreatePage
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl;

        public CreatePage(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _baseUrl = baseUrl;
        }

        public IWebElement FirstNameInput => _driver.FindElement(By.Id("FirstName"));

        public IWebElement LastNameInput => _driver.FindElement(By.Id("LastName"));

        public IWebElement EmailInput => _driver.FindElement(By.Id("EmailAddress"));
        public IWebElement EmailInputErrorMessage => _driver.FindElement(By.Id("EmailAddress-error"));

        public IWebElement TelephoneInput => _driver.FindElement(By.Id("TelephoneNumber"));

        public IWebElement SubmitButton => _driver.FindElement(By.Id("btn-submit"));
        public IWebElement CancelButton => _driver.FindElement(By.Id("btn-cancel"));
    }
}