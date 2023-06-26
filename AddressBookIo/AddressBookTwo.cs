using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookIo
{
    public class AddressBookTwo
    {
        private List<Address> addressBooks;

        public AddressBookTwo()
        {
            addressBooks = new List<Address>();
        }
        public void CreateAddressBook()
        {
            Console.WriteLine("Enter a unique name for the address book:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name. Please try again.");
                return;
            }

            if (addressBooks.Exists(ab => ab.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Address book '{name}' already exists.");
                return;
            }

            addressBooks.Add(new Address(name));
            Console.WriteLine($"Address book '{name}' created successfully.");
        }
        public void AddContact()
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No address books found. Please create an address book first.");
                return;
            }

            Console.WriteLine("Enter the name of the address book to add the contact:");
            string addressBookName = Console.ReadLine();

            Address addressBook = addressBooks.Find(ab => ab.Name.Equals(addressBookName, StringComparison.OrdinalIgnoreCase));

            if (addressBook == null)
            {
                Console.WriteLine($"Address book '{addressBookName}' not found.");
                return;
            }
            Console.WriteLine("Enter contact details:");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.Write("ZIP: ");
            string zip = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            addressBook.Contacts.Add(new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                PhoneNumber = phoneNumber,
                Email = email
            });

            Console.WriteLine("Contact added successfully.");
        }
        public void DisplayAllContacts()
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No address books found.");
                return;
            }

            foreach (var addressBook in addressBooks)
            {
                Console.WriteLine($"Address Book: {addressBook.Name}");
                Console.WriteLine("-----------------------------");
                foreach (var contact in addressBook.Contacts)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"ZIP: {contact.Zip}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine("-----------------------------");
                }
                Console.WriteLine();
            }
        }
    }
}
    

