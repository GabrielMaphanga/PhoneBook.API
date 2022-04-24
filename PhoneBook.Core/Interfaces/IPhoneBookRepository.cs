using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Interfaces
{
    public interface IPhoneBookRepository
    {
        Entry GetEntry(int entryId);
        List<Entry> GetEntries();
        bool DeleteEntry(int entryId);
        Entry UpdateEntry(Entry entry);
        bool AddEntry(Entry entry);

        Entry FindEntry(string name);
    }
}
