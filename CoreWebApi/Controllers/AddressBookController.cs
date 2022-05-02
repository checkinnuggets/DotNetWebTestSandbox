using Microsoft.AspNetCore.Mvc;
using CoreWebApi.Db;
using CoreWebApi.Models;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookDataStore _dataStore;

        public AddressBookController(IAddressBookDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet, Route("AddressBook/")]
        public IActionResult Get()
        {
            var allEntries = _dataStore.GetAllEntries();
            return Ok(allEntries);
        }

        [HttpGet, Route("AddressBook/{id}")]
        public IActionResult Get(string id)
        {
            var entry = _dataStore.GetEntry(id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        [HttpPost, Route("/")]
        public IActionResult Post(AddressBookEntry entry)
        {
            _dataStore.AddEntry(entry);
            return new StatusCodeResult(201); // don't have the code to return the uri
        }
    }
}
