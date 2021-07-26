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

    public Video(string a_libraryCode, string a_title, string a_releaseDate, int a_copiesTotal, 
        int a_copiesAvailable, List<Person> a_actors, List<Person> a_stars, List<Person> a_writers, 
        List<Person> a_producers, List<Person> a_directors, List<VideoMedium> a_mediums, 
        List<VideoGenre> a_genre, Person a_cinematogrophy, Person a_distributer, 
        string a_country, string a_editer, string a_music, int a_budget, int a_boxOffice, 
        int a_runningTime) : base(a_libraryCode, a_title, a_releaseDate, a_copiesTotal, a_copiesAvailable)
    {
        actors = a_actors;
        stars = a_stars;
        writers = a_writers;
        producers = a_producers;
        directors = a_directors;
        mediums = a_mediums;
        genre = a_genre;
        cinematogrophy = a_cinematogrophy;
        distributer = a_distributer;
        country = a_country;
        editer = a_editer;
        music = a_music;
        budget = a_budget;
        boxOffice = a_boxOffice;
        runningTime = a_runningTime;
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

    public List<String> GetValuesF()
    {
        List<String> values = new List<string>();

        values.AddRange(returnPropertiesF(this));

        values.AddRange(returnPersonListF(actors, "actors"));
        values.AddRange(returnPersonListF(stars, "stars"));
        values.AddRange(returnPersonListF(writers, "writers"));
        values.AddRange(returnPersonListF(producers, "producers"));
        values.AddRange(returnPersonListF(directors, "directors"));
        values.AddRange(returnListF<VideoMedium>(mediums, "mediums"));
        values.AddRange(returnListF<VideoGenre>(genre, "genre"));

        return values;
    }
    public List<List<string>> GetValues()
    {
        List<List<string>> values = returnProperties(this);

        values.Add(returnPersonList(actors, "actors"));
        values.Add(returnPersonList(stars, "stars"));
        values.Add(returnPersonList(writers, "writers"));
        values.Add(returnPersonList(producers, "producers"));
        values.Add(returnPersonList(directors, "directors"));
        values.Add(returnList<VideoMedium>(mediums, "mediums"));
        values.Add(returnList<VideoGenre>(genre, "genre"));

        return values;
    }
}
