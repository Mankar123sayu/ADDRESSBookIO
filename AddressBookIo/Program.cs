using AddressBookIo;
using System;

namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book I/O");

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
        }
        /*
           Console.WriteLine("\n");
           book.EditContact();
           Console.WriteLine("\n");
           book.Display();
           Console.WriteLine("\n");
           book.DeleteContact();
           */
    }
}