using Microsoft.EntityFrameworkCore;
namespace Songs.Models;

public class SongContext:DbContext
{
  public DbSet<Song> Songs{ get; set; }
  public SongContext(DbContextOptions<SongContext> options): base(options)
  {}

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Song>()
    .HasData(
      new Song { SongId = 1, Name = "Eye of the Tiger", Artist = "Queen", Year = 1980 },
      new Song { SongId = 2, Name = "First Day of My Life", Artist = "Bright Eyes", Year = 1999 },
      new Song { SongId = 3, Name = "Bohemian Rhapsody", Artist = "Queen", Year = 1978 }
    );
  }


}