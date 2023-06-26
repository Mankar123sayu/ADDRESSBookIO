using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookIo
{
    public class AddressBookMain
    {

        Contact contact = new Contact();
        List<Contact> main = new List<Contact>();


        public void Addcontact()
        {
            Console.Write("Enter the first name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter the last name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Enter the address: ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter the city: ");
            contact.City = Console.ReadLine();

            Console.Write("Enter the state: ");
            contact.State = Console.ReadLine();

            Console.Write("Enter the Zip: ");
            contact.Zip = Console.ReadLine();

            Console.Write("Enter the phone number: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Enter the email: ");
            contact.Email = Console.ReadLine();

            main.Add(contact);
        }
        public void Display()
        {
            Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
        }
    }
}


