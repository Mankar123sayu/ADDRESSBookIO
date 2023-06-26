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
        public void SearchPerson()
        {
            Console.WriteLine("Enter the city or state to search:");
            string searchQuery = Console.ReadLine();

            List<Contact> searchResults = new List<Contact>();

            foreach (var addressBook in addressBooks)
            {
                foreach (var contact in addressBook.Contacts)
                {
                    if (contact.City.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                        contact.State.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                    {
                        searchResults.Add(contact);
                    }
                }
            }
            if (searchResults.Count > 0)
            {
                Console.WriteLine($"Search results for '{searchQuery}':");
                Console.WriteLine("----------------------------------");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"ZIP: {contact.Zip}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine("----------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"No results found for '{searchQuery}'.");
            }
        }
        public void ViewPersonsByCityOrState()
        {
            Console.WriteLine("Enter the city or state to view persons:");
            string searchQuery = Console.ReadLine();

            List<Contact> searchResults = new List<Contact>();

            foreach (var addressBook in addressBooks)
            {
                foreach (var contact in addressBook.Contacts)
                {
                    if (contact.City.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                        contact.State.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                    {
                        searchResults.Add(contact);
                    }
                }
            }
            if (searchResults.Count > 0)
            {
                Console.WriteLine($"Persons in '{searchQuery}':");
                Console.WriteLine("----------------------------------");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"ZIP: {contact.Zip}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine("----------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"No persons found in '{searchQuery}'.");
            }
        }
        public void SortContactsByName()
        {
            List<Contact> allContacts = addressBooks.SelectMany(ab => ab.Contacts).ToList();
            allContacts.Sort();

            Console.WriteLine("Sorted contacts by name:");
            Console.WriteLine("----------------------------------");

            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("----------------------------------");
            }
        }
        public void SortContactsByState()
        {
            List<Contact> allContacts = addressBooks.SelectMany(ab => ab.Contacts).ToList();
            allContacts = allContacts.OrderBy(c => c.State).ToList();

            Console.WriteLine("Sorted contacts by state:");
            Console.WriteLine("----------------------------------");

            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("----------------------------------");
            }
        }
        public void SortContactsByZip()
        {
            List<Contact> allContacts = addressBooks.SelectMany(ab => ab.Contacts).ToList();
            allContacts = allContacts.OrderBy(c => c.Zip).ToList();

            Console.WriteLine("Sorted contacts by ZIP:");
            Console.WriteLine("----------------------------------");

            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("----------------------------------");
            }
        }
        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var addressBook in addressBooks)
                {
                    writer.WriteLine($"Address Book: {addressBook.Name}");
                    writer.WriteLine("----------------------------------");

                    foreach (var contact in addressBook.Contacts)
                    {
                        writer.WriteLine(contact);
                        writer.WriteLine("----------------------------------");
                    }
                }
            }

            Console.WriteLine($"Address book saved to file: {fileName}");
        }
        public void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File not found: {fileName}");
                return;
            }

            addressBooks.Clear();

            Address currentAddressBook = null;
            Contact currentContact = null;

            foreach (string line in File.ReadLines(fileName))
            {
                if (line.StartsWith("Address Book:"))
                {
                    string addressBookName = line.Substring(line.IndexOf(':') + 1).Trim();
                    currentAddressBook = new Address(addressBookName);
                    addressBooks.Add(currentAddressBook);
                }
                else if (line.StartsWith("Name:"))
                {
                    currentContact = new Contact();
                    currentContact.FirstName = line.Substring(line.IndexOf(':') + 1).Trim();
                }
                else if (currentContact != null)
                {
                    if (line.StartsWith("Address:"))
                        currentContact.Address = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("City:"))
                        currentContact.City = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("State:"))
                        currentContact.State = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("ZIP:"))
                        currentContact.Zip = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("Phone:"))
                        currentContact.PhoneNumber = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("Email:"))
                    {
                        currentContact.Email = line.Substring(line.IndexOf(':') + 1).Trim();
                        currentAddressBook.Contacts.Add(currentContact);
                        currentContact = null;
                    }
                }
            }
            Console.WriteLine($"Address book loaded from file: {fileName}");
        }
        public void SaveToCsv(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var addressBook in addressBooks)
                {
                    writer.WriteLine($"Address Book: {addressBook.Name}");
                    writer.WriteLine("First Name,Last Name,Address,City,State,ZIP,Phone,Email");

                    foreach (var contact in addressBook.Contacts)
                    {
                        writer.WriteLine(contact);
                    }
                }
            }

            Console.WriteLine($"Address book saved as CSV file: {fileName}");
        }
        public void LoadFromCsv(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File not found: {fileName}");
                return;
            }

            addressBooks.Clear();

            Address currentAddressBook = null;
            bool isFirstLine = true;

            foreach (string line in File.ReadLines(fileName))
            {
                if (line.StartsWith("Address Book:"))
                {
                    string addressBookName = line.Substring(line.IndexOf(':') + 1).Trim();
                    currentAddressBook = new Address(addressBookName);
                    addressBooks.Add(currentAddressBook);
                }
                else if (!isFirstLine)
                {
                    string[] values = line.Split(',');
                    if (values.Length == 8)
                    {
                        Contact contact = new Contact
                        {
                            FirstName = values[0],
                            LastName = values[1],
                            Address = values[2],
                            City = values[3],
                            State = values[4],
                            Zip = values[5],
                            PhoneNumber = values[6],
                            Email = values[7]
                        };

                        currentAddressBook.Contacts.Add(contact);
                    }
                }

                isFirstLine = false;
            }

            Console.WriteLine($"Address book loaded from CSV file: {fileName}");
        }
    }
}


    


    

    

    

    

    

    

