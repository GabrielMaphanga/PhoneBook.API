using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PhoneBook.Core
{
    [DataContract]
    public class Entry
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
       public string Name { get; set; }
        [DataMember(Name = "number")]
        public string Number { get; set; }
    }
}
