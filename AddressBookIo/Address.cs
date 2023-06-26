using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookIo
{
    public class Address
    {
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }

        public Address(string name)
        {
            Name = name;
            Contacts = new List<Contact>();
        }
    }
}
