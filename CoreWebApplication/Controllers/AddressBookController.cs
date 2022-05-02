using System;
using CoreWebApplication.Db;
using CoreWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApplication.Controllers
{
    public class AddressBookController : Controller
    {
        private readonly IDataStore _dataStore;

        public AddressBookController(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        // GET: AddressBook
        [HttpGet]
        public ActionResult Index()
        {
            var items = _dataStore.GetAllEntries();
            return View(items);
        }

        // GET: AddressBook/Details/5
        [HttpGet]
        public ActionResult Details(string id)
        {
            var item = _dataStore.GetEntry(id);
            return View(item);
        }

        // GET: AddressBook/Create
        [HttpGet]
        public ActionResult Create()
        {
            var newItem = new AddressBookEntry();
            return View(newItem);
        }

        // POST: AddressBook/Create
        [HttpPost]
        public ActionResult Create(AddressBookEntry viewModel)
        {
            try
            {
                // AddressBook: Add insert logic here
                viewModel.Id = Guid.NewGuid().ToString();
                _dataStore.AddEntry(viewModel);

                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View(viewModel);
            }
        }

        // GET: AddressBook/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var itemToEdit = _dataStore.GetEntry(id);
            return View(itemToEdit);
        }

        // POST: AddressBook/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AddressBookEntry updatedItem)
        {
            // AddressBook: Add update logic here
            _dataStore.RemoveEntry(id);
            _dataStore.AddEntry(updatedItem);

            return RedirectToAction("Index");
        }

        // GET: AddressBook/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var itemToDelete = _dataStore.GetEntry(id);
            return View(itemToDelete);
        }

        // POST: AddressBook/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            _dataStore.RemoveEntry(id);
            return RedirectToAction("Index");
        }
    }
}
