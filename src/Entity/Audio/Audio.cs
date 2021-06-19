using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Audio : Entity
{
    public Audio(string a_title, List<AudioMedium> a_mediums) : base(a_title)
    {
        //songTitle = a_songTitle;
        artists = new List<string>();
        producers = new List<string>();
        mediums = a_mediums;
        featuredArtists = new List<string>();
        genre = new List<AudioGenre>();
        Labels = new List<string>();

        libraryCode += a_title[0] + ".";
        foreach (VideoMedium item in a_mediums)
        {
            libraryCode += (int)item + ".";
        }
        libraryCode += "A";
    }
    public List<string> artists;
    public List<string> featuredArtists;
    public List<string> producers;
    public string songTitle { get; set; }
    public List<AudioGenre> genre;
    public List<AudioMedium> mediums;
    public List<string> Labels;

    

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
