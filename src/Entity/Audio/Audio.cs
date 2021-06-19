using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Audio : Entity
{
    public List<string> artists;
    public List<string> featuredArtists;
    public List<string> producers;
    public string songTitle { get; set; }
    public List<AudioGenre> genre;
    public AudioMedium medium { get; set; }
    public List<string> Labels;

    public Audio(string a_songTitle, AudioMedium a_medium) : base(a_songTitle)
    {
        //songTitle = a_songTitle;
        artists = new List<string>();
        producers = new List<string>();
        medium = a_medium;
        featuredArtists = new List<string>();
        genre = new List<AudioGenre>();
        libraryCode += "A." + (int)medium + "." + a_songTitle;
        Labels = new List<string>();
    }

    public void print(Audio instantiatedEntiy)
    {
        printProperties(instantiatedEntiy);

        printList<string>(artists, "artists");
        printList<string>(featuredArtists, "Featured Artists");
        printList<string>(producers, "Producers");
        printList<string>(Labels, "Labels");
        printList<AudioGenre>(genre, "Genre");
        //printList<AudioMedium>(medium, "Medium");
       

    }

    

}
