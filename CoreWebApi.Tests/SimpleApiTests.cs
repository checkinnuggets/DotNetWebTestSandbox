using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CoreWebApi.Models;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CoreWebApi.Tests
{
    public class SimpleApiTests
    {
        private TestHarness _testHarness;

        private const string ApiUrl = "http://localhost:45876";

        [OneTimeSetUp]
        public void BeforeAllTests()
        {

        }

        [SetUp]
        public void BeforeEachTest()
        {
            _testHarness = new TestHarness(ApiUrl);
        }



        [Test]
        public async Task WhenDatabaseIsEmptyListingShouldBeEmpty()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(ApiUrl)};

            var response = await httpClient.GetAsync("/AddressBook");

            response.StatusCode
                .Should().Be(HttpStatusCode.OK);


            var addressBookEntries = await DeserializeResponse<AddressBookEntry[]>(response);

            addressBookEntries.Length
                .Should().Be(0);
        }

        [Test]
        public async Task WhenDatabaseHasItemsTheyShouldBeReturned()
        {
            _testHarness.DataStore.AddEntry(new AddressBookEntry
            {
                Id = "123",
                FirstName = "Bill",
                LastName = "Gates",
                EmailAddress = "billg@microsoft.com",
                TelephoneNumber = "01234 567 890"
            });

            var httpClient = new HttpClient { BaseAddress = new Uri(ApiUrl) };

            var response = await httpClient.GetAsync("/AddressBook");

            response.StatusCode
                .Should().Be(HttpStatusCode.OK);


            var addressBookEntries = await DeserializeResponse<AddressBookEntry[]>(response);

            addressBookEntries.Length
                .Should().Be(1);

            addressBookEntries[0].FirstName
                .Should().Be("Bill");

            addressBookEntries[0].LastName
                .Should().Be("Gates");
        }





        [TearDown]
        public void AfterEachTest()
        {
            _testHarness.Dispose();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {

        }





        private static async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            var responseJson = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonConvert.DeserializeObject<T>(responseJson);

            return deserializedResponse;
        }

    }
}
