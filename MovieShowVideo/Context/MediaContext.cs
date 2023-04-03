using System.Globalization;
using System.Net.Mime;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using MovieShowVideo.Models;

namespace MovieShowVideo.Context;

public class MediaContext
{
    public List<Movie> Movies { get; set; }
    public List<Show> Shows { get; set; }
    public List<Video> Videos { get; set; }
    
    public MediaContext()
    {
        
        string rootmovie = @"Data/movies.csv";
        StreamReader readMo = new StreamReader(rootmovie);
        Movies = new List<Movie>();
        readMo.ReadLine();
        while (!readMo.EndOfStream)
        {
            var line = readMo.ReadLine();
            string[] arr = line.Split(',');
            int ind = Convert.ToInt32(arr[0]);
            Movies.Add(new Movie(){Id = ind, Title = arr[1], genres = arr[2]});
        }


        string rootshow = @"Data/shows.csv";
        StreamReader readshow = new StreamReader(rootshow);
        Shows = new List<Show>();
        readshow.ReadLine();
        while (!readshow.EndOfStream)
        {
            var line = readshow.ReadLine();
            string[] arr = line.Split(',');
            int ind = Convert.ToInt32(arr[0]);
            Shows.Add(new Show(){Id = ind, Title = arr[1], season = arr[2], episode = arr[3], writer = arr[4]});
        }
        
        string rootVideo = @"Data/videos.csv";
        StreamReader readvideo = new StreamReader(rootVideo);
        Videos = new List<Video>();
        readvideo.ReadLine();
        while (!readvideo.EndOfStream)
        {
            var line = readvideo.ReadLine();
            string[] arr = line.Split(',');
            int ind = Convert.ToInt32(arr[0]);
            Videos.Add(new Video(){Id = ind, Title = arr[1], format = arr[2], length = arr[3], regions = arr[4]});
        }
    }
}

