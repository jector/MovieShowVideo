namespace MovieShowVideo.Models;

public class Show : Media
{
    public string season { get; set; }
    public string episode { get; set; }
    public string writer { get; set; }
    
    
    public override void Display() {
        Console.WriteLine($"{Id}. {Title}, season {season}, episode {episode}, and writing by {writer}");
    }
}
