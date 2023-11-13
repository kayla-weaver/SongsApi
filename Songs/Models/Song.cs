using System.Collections.Generic;
using System;
// using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Songs.Models
{
  public class Song
  {
    public int SongId { get; set; }
    public string Name { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    // public static List<Song> GetSongs()
    // {
    //   Task<string> apiCallTask = ApiHelper.GetAll();
    //   string result = apiCallTask.Result;
    //   List<Song> songList = JsonConvert.DeserializeObject<List<Song>>(jsonResponse.ToString());

    //   return songList;
    // }
    }
  }
