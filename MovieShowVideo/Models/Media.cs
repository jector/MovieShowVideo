using Newtonsoft.Json;

namespace MovieShowVideo.Models;

public abstract class Media
{
    [JsonProperty("Id")]
    public int Id { get; set; }
    [JsonProperty("Title")]
    public string Title { get; set; }

    public virtual void Display()
    {
        Console.WriteLine($"{Id}. This is {Title}");
    }
}