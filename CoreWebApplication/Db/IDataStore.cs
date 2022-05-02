using CoreWebApplication.Models;

namespace CoreWebApplication.Db
{
    public interface IDataStore
    {
        void AddEntry(AddressBookEntry entry);
        void RemoveEntry(string id);
        AddressBookEntry GetEntry(string id);
        AddressBookEntry[] GetAllEntries();
    }
}