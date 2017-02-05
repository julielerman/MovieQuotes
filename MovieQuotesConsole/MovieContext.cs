using Microsoft.EntityFrameworkCore;

namespace MovieList {
  public class MovieContext:DbContext {
    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Filename=movies.db");
    }
  }
}
