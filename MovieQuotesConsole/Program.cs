using System;
using System.Linq;
using MovieList;

namespace MovieList {
  internal class Program {
    private static MovieContext _context = new MovieContext();

    private static void Main(string[] args) {
      ShowMovieList();
    }

    private static void ShowMovieList() {
      Console.WriteLine();
      Console.WriteLine("Your movie choices:");
      Console.WriteLine("1: Princess Bride");
      Console.WriteLine("2: Brazil");
      var movies = _context.Movies.ToList();
      foreach (var movie in movies) Console.WriteLine($"{movie.Id}: {movie.Title} ({movie.ReleaseYear})");

      ShowMovieMenu();
    }

    private static void ShowMovieMenu() {
      Console.WriteLine();
      Console.WriteLine("(A)dd Movie");
      Console.WriteLine("(#) of Movie to Edit");
      Console.WriteLine("(Q)uit");

      var choice = Console.ReadKey(true).KeyChar.ToString();
      int id;
      if (int.TryParse(choice, out id)) EditMovieNameYear(id);
      else
        switch (choice.ToUpper()) {
          case "A":
            EnterMovieNameYear();
            break;

          case "Q":
            return;

          default:
            ShowMovieList();
            break;
        }
    }

    private static void EnterMovieNameYear() {
      Console.Write("Name of movie: ");
      var title = Console.ReadLine();
      Console.Write("Year released: ");
      var year = Console.ReadLine();

      _context.Movies.Add(new Movie { Title = title, ReleaseYear = year });
      _context.SaveChanges();
      ShowMovieList();
    }

    private static void EditMovieNameYear(int id) {
      var movie = _context.Movies.Find(id);
      if (movie == null) {
        Console.WriteLine("Not Found");
      }
      else {
        Console.Write($"Title) {movie.Title}(Enter for no change): ");
        var title = Console.ReadLine();
        if (!string.IsNullOrEmpty(title)) movie.Title = title;

        Console.Write($"Year) {movie.ReleaseYear} (Enter for no change): ");
        var year = Console.ReadLine();
        if (!string.IsNullOrEmpty(year)) movie.ReleaseYear = year;
        _context.SaveChanges();
      }

      ShowMovieList();
    }
  }
}