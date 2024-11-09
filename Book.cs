using better_grocery_store;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Book
    {
        public string Title;
        public string Author;
        public int Year;
        public bool Available;

        // the constructor that was mandatory even tho I hate using it
        public Book(string title, string author, int year, bool available)
        {
            Title = title;
            Author = author;
            Year = year;
            Available = available;
        }

        // The method to check the book out 
        public void CheckOut()
        {
            if (Available == true)
            {     
                Available = false;// If it is available, mark it as checked out
                Console.WriteLine($"You have checked out the book: {Title}");
            }
            else
            {     
                Console.WriteLine($"Sorry, {Title} is already checked out.");// If it's not available prints to the userr
            }
        }

        // The method to return the book
        public void Return()
        {
            
            if (Available == false)// Check the state of the book
            {
                
                Available = true;// If it is checked out, mark it as available
                Console.WriteLine($"Thank you for returning: {Title}");
            }
            else
            {
                
                Console.WriteLine($"{Title} is already in the library.");// If it's already in the library, prints to the user
            }
        }
    }
}
