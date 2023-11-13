using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Songs.Models;

namespace Songs.Controllers;

public class SongsController : ControllerBase
{
    private readonly SongContext _db;

    public SongsController(SongContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Song>>> Get()
    {
        return await _db.Songs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Song>> GetSong(int id)
    {
        Song song = await _db.Songs.FindAsync(id);

        if (song == null)
        {
            return NotFound();
        }

        return song;
    }


}
