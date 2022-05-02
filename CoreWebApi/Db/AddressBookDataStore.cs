using System.Collections.Generic;
using System.Linq;
using CoreWebApi.Models;

namespace CoreWebApi.Db
{
    public interface IAddressBookDataStore
    {
        void AddEntry(AddressBookEntry entry);
        void RemoveEntry(string id);
        AddressBookEntry GetEntry(string id);
        AddressBookEntry[] GetAllEntries();
    }


    public class InMemoryAddressBookDataStore : IAddressBookDataStore
    {
        private readonly List<AddressBookEntry> _entries;

        public InMemoryAddressBookDataStore()
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
    }
}