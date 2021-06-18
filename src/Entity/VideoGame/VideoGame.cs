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
enum VideoGameMedium
{
    PC,
    XboxOne,
    PS5,
    Switch
}
class VideoGame : Entity
{
    public VideoGame(string a_libraryCode) : base(a_libraryCode) { }

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

    public void print(Liturature instantiatedEntiy)
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
