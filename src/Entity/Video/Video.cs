using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Video : Entity
{
    public Video(string a_title, List<VideoMedium> a_mediums) : base(a_title) 
    {
        libraryCode += a_title[0] + ".";
        foreach (VideoMedium item in a_mediums)
        {
            libraryCode += (int)item + ".";
        }
        libraryCode += "V";

        actors = new List<Person>();
        stars = new List<Person>();
        writers = new List<Person>();
        producers = new List<Person>();
        directors = new List<Person>();
        mediums = new List<VideoMedium>();
        genre = new List<VideoGenre>();

        
    }

    public List<Person> actors;
    public List<Person> stars;
    public List<Person> writers;
    public List<Person> producers;
    public List<Person> directors;
    public List<VideoMedium> mediums;
    public List<VideoGenre> genre;
    public Person cinematogrophy { get; set; }
    public Person distributer { get; set; }
    
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
        printPersonList(directors, "directors");
        printList<VideoMedium>(mediums, "mediums");
        printList<VideoGenre>(genre, "genre");
    }

    public List<String> GetValues()
    {
        List<String> values = new List<string>();

        values.AddRange(returnProperties(this));

        values.AddRange(returnPersonList(actors, "actors"));
        values.AddRange(returnPersonList(stars, "stars"));
        values.AddRange(returnPersonList(writers, "writers"));
        values.AddRange(returnPersonList(producers, "producers"));
        values.AddRange(returnPersonList(directors, "directors"));
        values.AddRange(returnList<VideoMedium>(mediums, "mediums"));
        values.AddRange(returnList<VideoGenre>(genre, "genre"));

        return values;
    }
}
