using Microsoft.EntityFrameworkCore;

namespace Songs.Models
{
  public class SongContext : DbContext
  {
    public DbSet<Song> Songs { get; set; }

    public SongContext(DbContextOptions<SongContext> options) : base(options)
    {
    }
  }
}