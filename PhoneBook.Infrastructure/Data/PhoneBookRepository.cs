using Dapper;
using Microsoft.Extensions.Configuration;
using PhoneBook.Core;
using PhoneBook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PhoneBook.Infrastructure.Data
{
    public class PhoneBookRepository : IPhoneBookRepository
    {

        private readonly IConfiguration _config;

        public PhoneBookRepository(IConfiguration config){
            _config = config;
        }

        public IDbConnection Connection => new SqlConnection(_config.GetConnectionString("PhonebookDB"));
        public bool AddEntry(Entry entry)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO dbo.Entries (Name, Number)"
                    + "VALUES(@Name, @Number)";
                dbConnection.Open();
                int rowAffectd = dbConnection.Execute(sQuery, entry);
                if (rowAffectd > 0)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DeleteEntry(int entryId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM dbo.Entries WHERE Id =" + entryId;
                dbConnection.Open();
                int rowAffectd = dbConnection.Execute(sQuery);
                if (rowAffectd > 0)
                {
                    return true;
                }


            }
            return false;
        }

     

        public Entry FindEntry(string name)
        {
            Entry entry = new Entry();

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = $"SELECT * FROM dbo.Entries WHERE Name Like '" + "%" + name + "%'" ;
                entry = dbConnection.QueryFirst<Entry>(query);
                dbConnection.Close();
            }
            return entry;
        }

        public List<Entry> GetEntries()
        {
            IEnumerable<Entry> entries = new List<Entry>();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "SELECT * FROM dbo.Entries";
                entries = dbConnection.Query<Entry>(query);
                dbConnection.Close();
            }
            return entries.AsList<Entry>();
        }

        public Entry GetEntry(int entryId)
        {
            Entry entry = new Entry();

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = $"SELECT * FROM dbo.Entries WHERE Id= {entryId}";
                entry = dbConnection.QueryFirst<Entry>(query);
                dbConnection.Close();
            }
            return entry;
        }

    

        public Entry UpdateEntry(Entry entry)
        {

            var updateEntry = new Entry();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                var query = "UPDATE dbo.Entries SET Name = @Name, Number = @Number WHERE Id = @Id ";



                updateEntry = dbConnection.ExecuteScalar<Entry>(query, entry);

            }
            return updateEntry;


        }
    }
}
