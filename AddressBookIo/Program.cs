using AddressBookIo;
using System;

namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Welcome to Address Book I/O");

             AddressBookMain book = new AddressBookMain();
             Console.Write("Enter the number of contact you want to save: ");
             int num = Convert.ToInt32(Console.ReadLine());

             for (int i = 1; i <= num; i++)
             {
                 book.Addcontact();
                 Console.WriteLine("\n");
                 book.Display();
                 Console.WriteLine("\n");
             }

             /*
                Console.WriteLine("\n");
                book.EditContact();
                Console.WriteLine("\n");
                book.Display();
                Console.WriteLine("\n");
                book.DeleteContact();
                */



            AddressBookTwo two = new AddressBookTwo();


            while (true)
            {
                Console.WriteLine("1. Create address book");
                Console.WriteLine("2. Add contact");
                Console.WriteLine("3. Display all contacts");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        two.CreateAddressBook();
                        break;
                    case 2:
                        two.AddContact();
                        break;
                    case 3:
                        two.DisplayAllContacts();
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
        
    

