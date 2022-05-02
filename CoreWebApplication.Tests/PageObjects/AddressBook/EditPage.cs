using OpenQA.Selenium;

namespace CoreWebApplication.Tests.PageObjects.AddressBook
{
    public class EditPage
    {
        private readonly IWebDriver _driver;

        public EditPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}