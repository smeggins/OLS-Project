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

    public List<string> GetValuesF()
    {
        List<string> values = new List<string>();

        values.AddRange(returnPropertiesF(this));

        values.AddRange(returnPersonListF(artists, "artists"));
        values.AddRange(returnPersonListF(featuredArtists, "Featured Artists"));
        values.AddRange(returnPersonListF(producers, "Producers"));
        values.AddRange(returnListF<string>(Labels, "Labels"));
        values.AddRange(returnListF<AudioGenre>(genre, "Genre"));

        return values;
    }

    public List<List<string>> GetValues()
    {
        List<List<string>> values = returnProperties(this);

        values.Append(returnPersonList(artists));
        values.Append(returnPersonList(featuredArtists));
        values.Append(returnPersonList(producers));
        values.Append(returnList<string>(Labels));
        values.Append(returnList<AudioGenre>(genre));

        return values;
    }

}
