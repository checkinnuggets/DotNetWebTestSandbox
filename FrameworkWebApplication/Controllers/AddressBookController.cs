using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkWebApplication.Controllers
{
    public class AddressBookController : Controller
    {
        // Pretend we have a database...
        private static readonly List<AddressBookEntry> items 
            = new List<AddressBookEntry>();

        // GET: AddressBook
        [HttpGet]
        public ActionResult Index()
        {
            return View(items);
        }

        // GET: AddressBook/Details/5
        [HttpGet]
        public ActionResult Details(string id)
        {
            var item = items.Single(x => x.Id == id);

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
                items.Add(viewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: AddressBook/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var itemToEdit = items.Single(x => x.Id == id);
            return View(itemToEdit);
        }

        // POST: AddressBook/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AddressBookEntry updatedItem)
        {
            // AddressBook: Add update logic here
            items.RemoveAll(x=>x.Id == id);
            items.Add(updatedItem);

            return RedirectToAction("Index");
        }

        // GET: AddressBook/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var itemToDelete = items.Single(x => x.Id == id);
            return View(itemToDelete);
        }

        // POST: AddressBook/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            items.RemoveAll(x => x.Id == id);
            return RedirectToAction("Index");
        }
    }
}
