using FrameworkWebApplication.Tests.PageObjects.AddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace FrameworkWebApplication.Tests
{
    [TestClass]
    public class SimpleTests
    {
        private const string BaseUrl = "http://localhost:49387/";

        private IWebDriver _driver;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new FirefoxDriver();
        }

        [TestMethod]
        public void HappyPath()
        {
            var indexPage = new ListingPage(_driver, BaseUrl);
            indexPage.Open();

            indexPage.AddButton
                .Click();

            // Should now be on the 'Add Item' screen
            Assert.AreEqual("Create Address Book Entry", _driver.Title);

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
            Assert.AreEqual("Address Book Entries", _driver.Title);

            // And should be 1 entry in table
            Assert.AreEqual(1, indexPage.TableRows.Length);
        }

        [TestMethod]
        public void FailedValidation()
        {
            var indexPage = new ListingPage(_driver, BaseUrl);
            indexPage.Open();

            indexPage.AddButton
                .Click();

            // Should now be on the 'Add Item' screen
            Assert.AreEqual("Create Address Book Entry", _driver.Title);

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
            Assert.AreEqual("Create Address Book Entry", _driver.Title);

            // Should see Validation Message
            Assert.IsTrue(addScreen.EmailInputErrorMessage.Displayed);


            // Click 'Cancel' button
            addScreen.CancelButton
                .Click();

            // Should now be back to the 'Listing' screen
            Assert.AreEqual("Address Book Entries", _driver.Title);

            // Table should have ZERO rows - Well, kind of.
            Assert.AreEqual(1, indexPage.TableRows.Length);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
