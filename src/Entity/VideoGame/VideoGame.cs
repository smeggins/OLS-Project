using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum VideoGameMode
{
    singlePlayer,
    localMulitplayer,
    onlineMultiplayer,
    onlineCoOp,
    couchCoOp,
    vs,
    onlineVS
}

public class VideoGame : Entity
{
    public VideoGame(string a_title, List<VideoGameMedium> a_platforms) : base(a_title) 
    {
        platforms = new List<VideoGameMedium>();
        genre = new List<VideoGameGenre>();
        modes = new List<VideoGameMode>();
        headProgrammers = new List<Person>();
        developers = new List<string>();
        publishers = new List<Person>();
        directors = new List<Person>();
        producers = new List<Person>();
        designers = new List<Person>();
        artists = new List<Person>();
        writers = new List<Person>();
        release = new List<string>();
        composer = new List<string>();

        libraryCode += a_title[0] + ".";
        foreach (VideoGameMedium item in a_platforms)
        {
            libraryCode += (int)item + ".";
        }
        libraryCode += "VG";
    }

    public List<VideoGameMedium> platforms;
    public List<VideoGameGenre> genre;
    public List<VideoGameMode> modes;
    public List<Person> headProgrammers;
    public List<string> developers;
    public List<Person> publishers;
    public List<Person> directors;
    public List<Person> producers;
    public List<Person> designers;
    public List<Person> artists;
    public List<Person> writers;
    public List<string> release;
    public List<string> composer;
    public string series { get; set; }

    public override void print()
    {
        printProperties(this);

        printPersonList(headProgrammers, "headProgrammers");
        printPersonList(publishers, "publishers");
        printPersonList(producers, "producers");
        printPersonList(directors, "directors");
        printPersonList(artists, "artists");
        printPersonList(writers, "writers");
        printList<string>(developers, "developers");
        printList<string>(release, "release");
        printList<string>(composer, "composer");
        printList<VideoGameMedium>(platforms, "platforms");
        printList<VideoGameGenre>(genre, "genre");
        printList<VideoGameMode>(modes, "modes");
    }

    public List<String> GetValuesF()
    {
        List<String> values = new List<string>();

        values.AddRange(returnPropertiesF(this));

        values.AddRange(returnPersonListF(headProgrammers, "headProgrammers"));
        values.AddRange(returnPersonListF(publishers, "publishers"));
        values.AddRange(returnPersonListF(producers, "producers"));
        values.AddRange(returnPersonListF(directors, "directors"));
        values.AddRange(returnPersonListF(artists, "artists"));
        values.AddRange(returnPersonListF(writers, "writers"));
        values.AddRange(returnListF<string>(developers, "developers"));
        values.AddRange(returnListF<string>(release, "release"));
        values.AddRange(returnListF<string>(composer, "composer"));
        values.AddRange(returnListF<VideoGameMedium>(platforms, "platforms"));
        values.AddRange(returnListF<VideoGameGenre>(genre, "genre")); 
        values.AddRange(returnListF<VideoGameMode>(modes, "modes"));

        return values;
    }

    public List<List<string>> GetValues()
    {
        List<List<string>> values = returnProperties(this);

        values.Add(returnPersonList(headProgrammers, "headProgrammers"));
        values.Add(returnPersonList(publishers, "publishers"));
        values.Add(returnPersonList(producers, "producers"));
        values.Add(returnPersonList(directors, "directors"));
        values.Add(returnPersonList(artists, "artists"));
        values.Add(returnPersonList(writers, "writers"));
        values.Add(returnList<string>(developers, "developers"));
        values.Add(returnList<string>(release, "release"));
        values.Add(returnList<string>(composer, "composer"));
        values.Add(returnList<VideoGameMedium>(platforms, "platforms"));
        values.Add(returnList<VideoGameGenre>(genre, "genre"));
        values.Add(returnList<VideoGameMode>(modes, "modes"));

        return values;
    }

    
    }
