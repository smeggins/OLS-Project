using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Video : Entity
{
    public Video(string a_title, List<VideoMedium> a_mediums) : base(a_title) 
    {
        actors = new List<string>();
        stars = new List<string>();
        writers = new List<string>();
        producers = new List<string>();
        mediums = new List<VideoMedium>();
        genre = new List<VideoAndLituratureGenre>();

        libraryCode += a_title[0] + ".";
        foreach (VideoMedium item in a_mediums)
        {
            libraryCode += (int)item + ".";
        }
        libraryCode += "V";
    }

    public List<string> actors;
    public List<string> stars;
    public List<string> writers;
    public List<string> producers;
    public List<VideoMedium> mediums;
    public List<VideoAndLituratureGenre> genre;
    public string cinematogrophy { get; set; }
    public string distributer { get; set; }
    public string director { get; set; }
    public string country { get; set; }
    public string editer { get; set; }
    public string music { get; set; }
    public int budget { get; set; }
    public int boxOffice { get; set; }
    public int runningTime { get; set; }


    public override void print()
    {
        printProperties(this);

        printList<string>(actors, "actors");
        printList<string>(stars, "stars");
        printList<string>(writers, "writers");
        printList<string>(producers, "producers");
        printList<VideoMedium>(mediums, "mediums");
        printList<VideoAndLituratureGenre>(genre, "genre");
    }
}
