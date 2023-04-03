using System;
using System.Net.Http.Headers;
using MovieShowVideo.Context;
using MovieShowVideo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;

namespace MovieShowVideo.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    public MainService()
    {
        
    }
//https://www.youtube.com/watch?v=N6JBjzPssQI
    public void Invoke() // Consider this your program.cs Main
    {
       // Write code here
       
       MediaContext context = new MediaContext(); 
       
       List<Media> media = new List<Media>();
       media.AddRange(context.Movies);
       media.AddRange(context.Shows);
       media.AddRange(context.Videos);


       var json = JsonConvert.SerializeObject(context.Movies);
       //Console.WriteLine($"Json string is {json}");
       using (var sw = new StreamWriter(@"Data/movies.json"))
       {
           sw.WriteLine(json);
       }

       using (var sr = new StreamReader(@"Data/movies.json"))
       {
           var line = sr.ReadLine();
           var model = JsonConvert.DeserializeObject<Movie[]>(line);
           /*foreach (var mu in model)
           {
               Console.WriteLine($"{mu.Id}. {mu.Title} / {mu.genres}");
           }*/
           Console.WriteLine("What movie are you looking for?");
          var searchString = Console.ReadLine();
          List<Movie> movies = model.Where(m => m.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                         
          List<Media> results = new List<Media>();
          results.AddRange(movies);
                         
          foreach (var medi in results)
          {
              // used a trick here to get the type of the object
              // this is using something called 'reflection' 
              Console.WriteLine($"Your {medi.GetType().Name}: {medi.Title}");
              Console.WriteLine("I will keep working with this");
          }
       }
       
       /* 
 
        string choice = "";
        string choiceAction = "";
        
        do
        {
            Console.WriteLine("Please choice different format of media:");
            Console.WriteLine("'M' for Movies | 'S' for Shows | 'V' for Videos");
            Console.WriteLine("Enter to quit");
            choice = Console.ReadLine();
            if (choice == "M" || choice == "m" )
            {
                choice = "Movie";
                do
                {
                   Console.WriteLine($"\n1) Add {choice}: ");
                  Console.WriteLine($"2) Display {choice}s: ");
                  Console.WriteLine($"3) Search a {choice}: ");
                  Console.WriteLine("Enter to quit");
                  choiceAction = Console.ReadLine();
                  if (choiceAction == "1")
                  {
                      Console.WriteLine("SORRY I AM WORKING WITH THIS");
                  }
                  else if (choiceAction == "2")
                  {
                      foreach (var m in context.Movies)
                      {
                          m.Display();
                      }
                  }else if ( choiceAction == "3")
                  {
                      Console.WriteLine("What movie are you looking for?");
                      var searchString = Console.ReadLine();
                      List<Movie> movies = context.Movies.Where(m => m.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                      
                      List<Media> results = new List<Media>();
                      results.AddRange(movies);
                      
                      foreach (var medi in results)
                      {
                          // used a trick here to get the type of the object
                          // this is using something called 'reflection' 
                          Console.WriteLine($"Your {medi.GetType().Name}: {medi.Title}");
                      }
                  }
  
                } while (choiceAction == "1" || choiceAction == "2" || choiceAction == "3");
                
            }
            else if (choice == "S" || choice == "s")
            {
                choice = "Shows";
            }else if (choice == "V" || choice == "v")
            {
                choice = "Videos";
            }
            
            
            
 
        } while (choice == "M" || choice == "S" || choice == "V");
        
        */






       /*
       foreach (var m in context.Videos)
       {
           m.Display();
       }*/
    }
}
