using better_grocery_store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Giovanni Sinobolli - 200589722
namespace Lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.WriteLine();
                Console.WriteLine("=================================================================");
                Console.WriteLine("Welcome to the Public Barrie Library System!");
                Console.WriteLine();

                Console.WriteLine("1. View all books");
                Console.WriteLine();

                Console.WriteLine("2. Add a new book");
                Console.WriteLine();

                Console.WriteLine("3. Remove a book");
                Console.WriteLine();

                Console.WriteLine("4. Update book information");
                Console.WriteLine();

                Console.WriteLine("5. Search for a book");
                Console.WriteLine();

                Console.WriteLine("6. Check out a book");
                Console.WriteLine();

                Console.WriteLine("7. Return a book");
                Console.WriteLine();

                Console.WriteLine("8. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice (1-8): ");
                Console.WriteLine();

                string choice = Console.ReadLine();

                switch (choice) //really big switch for the options, with each case calling a different method from the class library
                {
                    case "1":
                        library.DisplayAllBooks();
                    break;

                    case "2":
                        library.AddBook();
                    break;

                    case "3":
                        library.RemoveBook();
                    break;

                    case "4":
                        library.UpdateBookInfo();
                    break;

                    case "5":
                        library.SearchBook();
                    break;

                    case "6":
                        library.CheckOutBook();
                    break;

                    case "7":
                        library.ReturnBook();
                    break;

                    case "8":
                        exitProgram = true;
                        Console.WriteLine("Thank you for using the Library Management System. Goodbye!");
                    break;

                    default:
                        Console.WriteLine("Please try again.");
                    break;
                }
            }
        }
    }
}

