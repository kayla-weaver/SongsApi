using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Songs.Models;

namespace Songs.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SongsController : ControllerBase
  {
    private readonly SongContext _db;

    public AnimalsController(SongContext db)
    {
      _db = db;
    }
[HttpGet]
    public async Task<List<Song>> Get(string artist, string name, int year)
    {
      IQueryable<Song> query = _db.Songs.AsQueryable();

      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (Year > 0)
      {
        query = query.Where(entry => entry.Age >= minimumAge);
      }

      return await query.ToListAsync();
    }
  }
};