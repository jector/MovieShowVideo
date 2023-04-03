using System.Data;
using System.Net.Mime;
using System.Threading.Channels;
using Newtonsoft.Json;

namespace MovieShowVideo.Models;

public class Movie : Media
{
    [JsonProperty("genres")]
    public string genres { get; set; }

    public override void Display() {
        Console.WriteLine($"{Id}. {Title} at {genres}");

    }
    
    
}
