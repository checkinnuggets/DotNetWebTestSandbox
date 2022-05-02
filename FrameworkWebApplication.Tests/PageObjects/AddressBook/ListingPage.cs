using OpenQA.Selenium;
using WebDriverHelpers;

namespace FrameworkWebApplication.Tests.PageObjects.AddressBook
{
    public class ListingPage
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl;

        public ListingPage(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _baseUrl = baseUrl;
        }

        public IWebElement AddButton => _driver.FindElement(By.Id("create-new"));
        public IWebElement[] TableRows => _driver.FindElement(By.Id("address-book-entries")).GetRows();

        public void Open()
        {
            _driver.Url = $"{_baseUrl}/AddressBook/Index";
        }
    }
}
