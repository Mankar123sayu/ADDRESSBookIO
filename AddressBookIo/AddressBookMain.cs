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
        public void EditContact()
        {
            Console.WriteLine("Enter Wheather you want to edit or not: \n 1.yes \n 2.no");
            int select = Convert.ToInt32(Console.ReadLine());

            switch (select)
            {
                case 1:
                    Console.WriteLine("Edit using first name: ");
                    string name = Console.ReadLine();

                    foreach (var data in main)
                    {
                        if (data.FirstName == name)
                        {
                            Console.WriteLine("Choose any parameter to edit: \n1.FirstName \n2.LastName \n3.Address \n4.City \n5.State \n6.Zip \n7.PhoneNumber \n8.Email");
                            int option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    Console.Write("Enter new first name: ");
                                    contact.FirstName = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Write("Enter new last name: ");
                                    contact.LastName = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.Write("Enter new address: ");
                                    contact.Address = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.Write("Enter new city: ");
                                    contact.City = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.Write("Enter new state: ");
                                    contact.State = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.Write("Enter new Zip: ");
                                    contact.Zip = Console.ReadLine();
                                    break;
                                case 7:
                                    Console.Write("Enter new phone number: ");
                                    contact.PhoneNumber = Console.ReadLine();
                                    break;
                                case 8:
                                    Console.Write("Enter new email: ");
                                    contact.Email = Console.ReadLine();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
    



