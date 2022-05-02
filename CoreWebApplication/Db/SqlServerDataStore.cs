using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CoreWebApplication.Models;
using Dapper.Contrib.Extensions;

namespace CoreWebApplication.Db
{
    public class SqlServerDataStore : IDataStore
    {
        private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DotNetWebTestSandbox;Integrated Security=true;";

        public void AddEntry(AddressBookEntry entry)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Insert(entry);
            }
        }

        public void RemoveEntry(string id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Delete(new AddressBookEntry { Id = id });
            }
        }

        public AddressBookEntry GetEntry(string id)
        {
            AddressBookEntry result;

            using (var connection = new SqlConnection(ConnectionString))
            {
                result = connection.Get<AddressBookEntry>(id);
            }

            return result;
        }

        public AddressBookEntry[] GetAllEntries()
        {
            IEnumerable<AddressBookEntry> result;

            using (var connection = new SqlConnection(ConnectionString))
            {
                result = connection.GetAll<AddressBookEntry>();
            }

            return result?.ToArray() ?? Array.Empty<AddressBookEntry>();
        }
    }
}