using System;

namespace MovieList {
  internal class Program {

    private static void Main(string[] args) {
      ShowMovieList();
    }

    private static void ShowMovieList() {
      Console.WriteLine();
      Console.WriteLine("Your movie choices:");
      Console.WriteLine("1: Princess Bride (1987)");
      Console.WriteLine("2: Deadpool (2016)");
  
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
      Console.WriteLine("Can't add this yet");
      ShowMovieList();
    }

    private static void EditMovieNameYear(int id)
    {
      Console.WriteLine("Not implemented yet");

      ShowMovieList();
    }
  }
}