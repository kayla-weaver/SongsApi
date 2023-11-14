using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Songs.Models
{
  public class Song
  {
    public int SongId { get; set; }
    public string Name { get; set; }
    public string Artist { get; set; }
    public int Year { get; set; }

  }
}