using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum VideoGameMode
{
    singlePlayer,
    localMulitplayer,
    onlineMultiplayer,
    onlineCoOp,
    couchCoOp,
    vs,
    onlineVS
}

class VideoGame : Entity
{
    public VideoGame(string a_title, List<VideoGameMedium> a_platforms) : base(a_title) 
    {
        platforms = new List<VideoGameMedium>();
        genre = new List<VideoGameGenre>();
        modes = new List<VideoGameMode>();
        headProgrammers = new List<string>();
        developers = new List<string>();
        publishers = new List<string>();
        directors = new List<string>();
        producers = new List<string>();
        designers = new List<string>();
        artists = new List<string>();
        writers = new List<string>();
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
    public List<string> headProgrammers;
    public List<string> developers;
    public List<string> publishers;
    public List<string> directors;
    public List<string> producers;
    public List<string> designers;
    public List<string> artists;
    public List<string> writers;
    public List<string> release;
    public List<string> composer;
    public string series { get; set; }

    public void print(VideoGame instantiatedEntiy)
    {
        printProperties(instantiatedEntiy);

        printList<string>(headProgrammers, "headProgrammers");
        printList<string>(developers, "developers");
        printList<string>(publishers, "publishers");
        printList<string>(producers, "producers");
        printList<string>(directors, "directors");
        printList<string>(artists, "artists");
        printList<string>(writers, "writers");
        printList<string>(release, "release");
        printList<string>(composer, "composer");
        printList<VideoGameMedium>(platforms, "platforms");
        printList<VideoGameGenre>(genre, "genre");
        printList<VideoGameMode>(modes, "modes");
    }
}
