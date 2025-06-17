using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domaindriven.Models;

namespace domaindriven
{
    public class ConsoleApp
    {
        private List<Book> books=new List<Book>();

        void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}, Rating: {book.Rating}");
        }
    }

      void FindBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine($"Book with Id {id} not found.");
            return;
        }
        Console.WriteLine($"Found Book: Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}, Rating: {book.Rating}");
    }

     void AddBook()
    {
        Console.Write("Enter Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Author: ");
        string author = Console.ReadLine();
        Console.Write("Enter Year: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Enter Rating: ");
        double rating = double.Parse(Console.ReadLine());

        int newId = books.Count == 0 ? 1 : books.Max(b => b.Id) + 1;
        books.Add(new Book { Id = newId, Title = title, Author = author, Year = year, Rating = rating });
        Console.WriteLine("Book added successfully.");
    }

     void EditBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine($"Book with Id {id} not found.");
            return;
        }

        Console.Write("Enter new Title: ");
        book.Title = Console.ReadLine();
        Console.Write("Enter new Author: ");
        book.Author = Console.ReadLine();
        Console.Write("Enter new Year: ");
        book.Year = int.Parse(Console.ReadLine());
        Console.Write("Enter new Rating: ");
        book.Rating = double.Parse(Console.ReadLine());

        Console.WriteLine("Book edited successfully.");
    }

     void DeleteBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine($"Book with Id {id} not found.");
            return;
        }

        books.Remove(book);
        Console.WriteLine("Book deleted successfully.");
    }


        public void Run()
        {

            while (true)
        {
            Console.WriteLine("\nWelcome to Book Console App");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. List Books");
            Console.WriteLine("2. Find Book");
            Console.WriteLine("3. Add Book");
            Console.WriteLine("4. Edit Book");
            Console.WriteLine("5. Delete Book");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice(1-6): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                     Console.WriteLine("Books:");
                    ListBooks();
                    break;
                case "2":
                    Console.Write("Enter Book Id: ");
                    FindBook(int.Parse(Console.ReadLine()));
                    break;
                case "3":
                    AddBook();
                    break;
                case "4":
                    Console.Write("Enter Book Id to Edit: ");
                    EditBook(int.Parse(Console.ReadLine()));
                    break;
                case "5":
                    Console.Write("Enter Book Id to Delete: ");
                    DeleteBook(int.Parse(Console.ReadLine()));
                    break;
                case "6":
                    Console.WriteLine("Exiting application...");
                    return;
                default:
                    Console.WriteLine("Exiting the Book Console App! Good Bye");
                    break;
            }
        }

        }
    }
}

// Write methods here
// 1. ListBooks()
// 2. FindBook()
// 3. AddBook()
// 4. EditBook()
// 5. DeleteBook()
