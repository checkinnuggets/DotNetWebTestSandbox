using OpenQA.Selenium;

namespace CoreWebApplication.Tests.PageObjects.AddressBook
{
    public class DeletePage
    {
        private readonly IWebDriver _driver;

        public DeletePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}