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