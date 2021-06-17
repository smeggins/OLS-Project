using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum VideoMedium
{
    DVD,
    Blueray
}

public class Video : Entity
{
    public Video(string a_libraryCode) : base(a_libraryCode) { }

    List<string> actors;
    List<string> stars;
    List<string> writers;
    List<string> producers;
    List<VideoMedium> mediums;
    List<VideoAndLituratureGenre> genre;
    string cinematogrophy { get; set; }
    string distributer { get; set; }
    string director { get; set; }
    string country { get; set; }
    string editer { get; set; }
    string music { get; set; }
    int budget { get; set; }
    int boxOffice { get; set; }
    int runningTime { get; set; }


    public void print(Video instantiatedEntiy)
    {
        printProperties(instantiatedEntiy);

        printList<string>(actors, "actors");
        printList<string>(stars, "stars");
        printList<string>(writers, "writers");
        printList<string>(producers, "producers");
        printList<VideoMedium>(mediums, "mediums");
        printList<VideoAndLituratureGenre>(genre, "genre");
    }
}
