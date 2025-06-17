// Domain Layer
namespace domaindriven.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
    }
}

// Presentation Layer
using domaindriven.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace domaindriven
{
    public class ConsoleApp
    {
        private List<Movie> movies = new List<Movie>();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the Movie Console App!");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Edit Movie");
                Console.WriteLine("4. Delete Movie");
                Console.WriteLine("5. Find Movie");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ListMovies(); break;
                    case "2": AddMovie(); break;
                    case "3": EditMovie(); break;
                    case "4": DeleteMovie(); break;
                    case "5": FindMovie(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        private void ListMovies()
        {
            if (!movies.Any())
            {
                Console.WriteLine("No movies found.");
                return;
            }

            Console.WriteLine("List of Movies:");
            foreach (var m in movies)
            {
                Console.WriteLine($"Id: {m.Id}, Name: {m.Name}, Year: {m.Year}, Rating: {m.Rating}");
            }
        }

        private void AddMovie()
        {
            Console.WriteLine("Enter details for the new movie:");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Rating: ");
            double rating = double.Parse(Console.ReadLine());

            int newId = movies.Any() ? movies.Max(m => m.Id) + 1 : 1;
            movies.Add(new Movie { Id = newId, Name = name, Year = year, Rating = rating });

            Console.WriteLine("Movie added successfully!");
        }

        private void EditMovie()
        {
            Console.Write("Enter the Id of the movie to Edit: ");
            int id = int.Parse(Console.ReadLine());
            var movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                Console.WriteLine($"Movie with Id {id} not found.");
                return;
            }

            Console.WriteLine($"Editing details for movie with Id {id}:");
            Console.Write("Name: ");
            movie.Name = Console.ReadLine();
            Console.Write("Year: ");
            movie.Year = int.Parse(Console.ReadLine());
            Console.Write("Rating: ");
            movie.Rating = double.Parse(Console.ReadLine());

            Console.WriteLine("Movie edited successfully!");
        }

        private void DeleteMovie()
        {
            Console.Write("Enter the Id of the movie to Delete: ");
            int id = int.Parse(Console.ReadLine());
            var movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                Console.WriteLine($"Movie with Id {id} not found.");
                return;
            }

            movies.Remove(movie);
            Console.WriteLine("Movie deleted successfully!");
        }

        private void FindMovie()
        {
            Console.Write("Enter the Id of the movie to Find: ");
            int id = int.Parse(Console.ReadLine());
            var movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                Console.WriteLine($"Movie with Id {id} not found.");
                return;
            }

            Console.WriteLine($"Found Movie: Id: {movie.Id}, Name: {movie.Name}, Year: {movie.Year}, Rating: {movie.Rating}");
        }
    }
}

// Program.cs
namespace domaindriven
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp app = new ConsoleApp();
            app.Run();
        }
    }
}
