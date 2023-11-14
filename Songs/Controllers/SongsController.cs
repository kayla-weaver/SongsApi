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

    public SongsController(SongContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<List<Song>> Get(string artist, string name, int year)
    {
      IQueryable<Song> query = _db.Songs.AsQueryable();

      if (artist != null)
      {
        query = query.Where(entry => entry.Artist == artist);
      }

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (year > 0)
      {
        query = query.Where(entry => entry.Year == year);
      }

      return await query.ToListAsync();
    }
  }
};