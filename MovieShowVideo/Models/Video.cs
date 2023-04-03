namespace MovieShowVideo.Models;

public class Video : Media
{
    public string format { get; set; }
    public string length { get; set; }
    public string regions { get; set; }
    
    public override void Display() {
        Console.WriteLine($"{Id}. {Title}, format {format}, time {length}, and regions {regions}");
    }
}