using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Video : Entity
{
    public Video(string a_title, List<VideoMedium> a_mediums) : base(a_title) 
    {
        actors = new List<Person>();
        stars = new List<Person>();
        writers = new List<Person>();
        producers = new List<Person>();
        mediums = new List<VideoMedium>();
        genre = new List<VideoAndLituratureGenre>();

        libraryCode += a_title[0] + ".";
        foreach (VideoMedium item in a_mediums)
        {
            libraryCode += (int)item + ".";
        }
        libraryCode += "V";
    }

    public List<Person> actors;
    public List<Person> stars;
    public List<Person> writers;
    public List<Person> producers;
    public List<VideoMedium> mediums;
    public List<VideoAndLituratureGenre> genre;
    public Person cinematogrophy { get; set; }
    public Person distributer { get; set; }
    public Person director { get; set; }
    public string country { get; set; }
    public string editer { get; set; }
    public string music { get; set; }
    public int budget { get; set; }
    public int boxOffice { get; set; }
    public int runningTime { get; set; }


    public override void print()
    {
        printProperties(this);

        printPersonList(actors, "actors");
        printPersonList(stars, "stars");
        printPersonList(writers, "writers");
        printPersonList(producers, "producers");
        printList<VideoMedium>(mediums, "mediums");
        printList<VideoAndLituratureGenre>(genre, "genre");
    }
}
