using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Audio : Entity
{
    public Audio(string a_title, List<AudioMedium> a_mediums) : base(a_title)
    {
        //songTitle = a_songTitle;
        artists = new List<Person>();
        producers = new List<Person>();
        mediums = a_mediums;
        featuredArtists = new List<Person>();
        genre = new List<AudioGenre>();
        Labels = new List<string>();

        libraryCode += a_title[0] + ".";
        foreach (VideoMedium item in a_mediums)
        {
            libraryCode += (int)item + ".";
        }
        libraryCode += "A";
    }
    public List<Person> artists;
    public List<Person> featuredArtists;
    public List<Person> producers;
    public List<AudioGenre> genre;
    public List<AudioMedium> mediums;
    public List<string> Labels;

    

    public override void print()
    {
        printProperties(this);

        printPersonList(artists, "artists");
        printPersonList(featuredArtists, "Featured Artists");
        printPersonList(producers, "Producers");
        printList<string>(Labels, "Labels");
        printList<AudioGenre>(genre, "Genre");
        //printList<AudioMedium>(medium, "Medium");
       

    }

    public List<String> GetValues()
    {
        List<String> values = new List<string>();

        values.AddRange(returnProperties(this));

        values.AddRange(returnPersonList(artists, "artists"));
        values.AddRange(returnPersonList(featuredArtists, "Featured Artists"));
        values.AddRange(returnPersonList(producers, "Producers"));
        values.AddRange(returnList<string>(Labels, "Labels"));
        values.AddRange(returnList<AudioGenre>(genre, "Genre"));

        return values;
    }

}
