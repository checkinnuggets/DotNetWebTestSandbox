using System;
using CoreWebApplication.Tests.PageObjects.AddressBook;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace CoreWebApplication.Tests
{
    public class SimpleTests : IDisposable
    {
        private const string BaseUrl = "http://localhost:11509";

        private readonly IWebDriver _driver;

        private readonly TestHarness _testHarness;

        public SimpleTests()
        {
            var driver = new FirefoxDriver(Environment.CurrentDirectory);
            //WebDriverHelpers.FixDriverCommandExecutionDelay(driver);
            _driver = driver;

            _testHarness = new TestHarness(BaseUrl);
        }

        [Fact]
        public void HappyPath()
        {
            var indexPage = new ListingPage(_driver, BaseUrl);
            indexPage.Open();

            indexPage.AddButton
                .Click();

            // Should now be on the 'Add Item' screen
            Assert.Equal("Create Address Book Entry", _driver.Title);

            var addScreen = new CreatePage(_driver, BaseUrl);

            addScreen.FirstNameInput
                .SendKeys("Bill");

            addScreen.LastNameInput
                .SendKeys("Gates");

            addScreen.EmailInput
                .SendKeys("billg@microsoft.com");

            addScreen.TelephoneInput
                .SendKeys("01234 567 890");

            addScreen.SubmitButton
                .Click();

            // Should now be back to the 'Listing' screen
            Assert.Equal("Address Book Entries", _driver.Title);

            // And should be 1 entry in table
            Assert.Single(indexPage.TableRows);
        }

        [Fact]
        public void FailedValidation()
        {
            var indexPage = new ListingPage(_driver, BaseUrl);
            indexPage.Open();

            indexPage.AddButton
                .Click();

            // Should now be on the 'Add Item' screen
            Assert.Equal("Create Address Book Entry", _driver.Title);

            var addScreen = new CreatePage(_driver, BaseUrl);

            addScreen.FirstNameInput
                .SendKeys("Bill");

            addScreen.LastNameInput
                .SendKeys("Gates");

            addScreen.EmailInput
                .SendKeys("not-a-valid-email-address");

            addScreen.TelephoneInput
                .SendKeys("01234 567 890");

            addScreen.SubmitButton
                .Click();

            // Should STILL be on the 'Add Item' screen
            Assert.Equal("Create Address Book Entry", _driver.Title);

            // Should see Validation Message
            Assert.True(addScreen.EmailInputErrorMessage.Displayed);


            // Click 'Cancel' button
            addScreen.CancelButton
                .Click();

            // Should now be back to the 'Listing' screen
            Assert.Equal("Address Book Entries", _driver.Title);

            // Table should have ZERO rows - Well, kind of.
            Assert.Empty(indexPage.TableRows);
        }

        public void Dispose()
        {
            _driver.Quit();

            _testHarness.Dispose();
        }
    }
}
