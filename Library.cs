using Lab_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace better_grocery_store
{
    public class Library
    {
        private List<Book> libraryInventory;
        private bool available;

        public Library()
        {
            libraryInventory = new List<Book>
            {
                new Book("The Little Prince", "Antoine de Saint-Exupéry", 1943, true),
                new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 1997, true),
                new Book("The Alchemist", "Paulo Coelho", 1988, true),
                new Book("The Posthumous Memoirs of Brás Cubas", "Machado de Assis", 1881, true),
                new Book("The Prince", "Niccolò Machiavelli", 1532, true)
            };
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\nLibrary Inventory:");
            foreach (var book in libraryInventory) //loop to print all the books in the library (trying something new with the foreach loop)
            {
                Console.WriteLine($"{book.Title} by {book.Author} ({book.Year}) - {(book.Available ? "Available" : "Not Available")}");
                Console.WriteLine();
            }
        }

        public void AddBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author name: ");
            string author = Console.ReadLine();

            int year;
            while (true)
            {
                Console.Write("Enter publication year: ");
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid year.");
            }

            Book newBook = new Book(title, author, year, available);
            libraryInventory.Add(newBook);
            Console.WriteLine("Book added successfully!");
        }

        public void RemoveBook()
        {
            Console.Write("Enter the title of the book to remove: ");
            string titleToRemove = Console.ReadLine();

            Book bookToRemove = null;

            foreach (Book book in libraryInventory)
            {
                if (book.Title.ToLower() == titleToRemove.ToLower())
                {
                    bookToRemove = book;
                    break;
                }
            }

            if (bookToRemove != null) 
            {
                
                libraryInventory.Remove(bookToRemove); // If the book was found, remove it from the library
                Console.WriteLine($"{titleToRemove} has been removed from the library.");
            }
            else
            {
                
                Console.WriteLine("Book not found in the library."); // If didn't find the book, prints it
            }
        }

        public void UpdateBookInfo()
        {
            Console.Write("Enter the title of the book to update: ");
            string titleToUpdate = Console.ReadLine();

            Book bookToUpdate = null;//store the book is going to be updated

            foreach (Book book in libraryInventory)
            {
                if (book.Title.ToLower() == titleToUpdate.ToLower())
                {
                    bookToUpdate = book;
                    break;
                }
            }

            // Check if we found the book
            if (bookToUpdate != null)
            {   
                Console.Write("Enter new title (or press Enter to keep current): ");// Update title
                string newTitle = Console.ReadLine();
                if (newTitle != "" && newTitle != null)
                {
                    bookToUpdate.Title = newTitle;
                }
                Console.Write("Enter new author (or press Enter to keep current): ");
                string newAuthor = Console.ReadLine();
                if (newAuthor != "" && newAuthor != null)
                {
                    bookToUpdate.Author = newAuthor;
                }

                // Update year
                Console.Write("Enter new year (or press Enter to keep current): ");
                string yearInput = Console.ReadLine();
                if (yearInput != "" && yearInput != null)
                {
                    bool isValidYear = int.TryParse(yearInput, out int newYear); //had to use tryparse because I couldn't figure out a way to work with the int.parse
                    if (isValidYear)
                    {
                        bookToUpdate.Year = newYear;
                    }
                    else
                    {
                        Console.WriteLine("Invalid year input. Year not updated.");
                    }
                }

                Console.WriteLine("Book information updated successfully!");
            }
            else
            {
                Console.WriteLine("Book not found in the library.");
            }
        }
        public void SearchBook()
        {
            Console.Write("Enter search term (title or author): ");
            string searchTerm = Console.ReadLine().ToLower();

            var results = libraryInventory.FindAll(b =>
                b.Title.ToLower().Contains(searchTerm) ||
                b.Author.ToLower().Contains(searchTerm));

            if (results.Count > 0)
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var book in results)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} ({book.Year}) - {(book.Available ? "Checked Out" : "Available")}");
                }
            }
            else
            {
                Console.WriteLine("No books found matching your search term.");
            }
        }

        public void CheckOutBook()
        {
            Console.Write("Enter the title of the book to check out: ");
            string title = Console.ReadLine();

            Book bookToCheckOut = libraryInventory.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (bookToCheckOut != null)
            {
                bookToCheckOut.CheckOut();
            }
            else
            {
                Console.WriteLine("Book not found in the library.");
            }
        }

        public void ReturnBook()
        {
            Console.Write("Enter the title of the book to return: ");
            string title = Console.ReadLine();

            Book bookToReturn = libraryInventory.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (bookToReturn != null)
            {
                bookToReturn.Return();
            }
            else
            {
                Console.WriteLine("Book not found in the library.");
            }
        }
    }
}

