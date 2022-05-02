using OpenQA.Selenium;

namespace FrameworkWebApplication.Tests.PageObjects.AddressBook
{
    public class DetailsPage
    {
        private readonly IWebDriver _driver;

        public DetailsPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}