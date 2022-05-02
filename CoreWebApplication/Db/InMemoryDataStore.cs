using System.Collections.Generic;
using System.Linq;
using CoreWebApplication.Models;

namespace CoreWebApplication.Db
{
    public class InMemoryDataStore : IDataStore
    {
        private readonly List<AddressBookEntry> _entries;

        public InMemoryDataStore()
        {
            _entries = new List<AddressBookEntry>();
        }

        public void AddEntry(AddressBookEntry entry)
        {
            _entries.Add(entry);
        }

        public void RemoveEntry(string id)
        {
            _entries.RemoveAll(x => x.Id == id);
        }

        public AddressBookEntry GetEntry(string id)
        {
            return _entries.SingleOrDefault(x => x.Id == id);
        }

        public AddressBookEntry[] GetAllEntries()
        {
            return _entries.ToArray();
        }

        public void Clear()
        {
            _entries.Clear();
        }
    }
}