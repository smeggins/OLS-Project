using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Liturature : Entity
{
    public Liturature(string a_title, LituratureMedium a_medium) : base(a_title) 
    {
        authors = new List<Person>();
        publishers = new List<Person>();
        illustrators = new List<Person>();
        medium = a_medium;
        genre = new List<LituratureGenre>();
        libraryCode += "L." + (int)medium + "." + a_title[0];
    }

    public Liturature(  string a_libraryCode, string a_title, string a_releaseDate, int a_copiesTotal,
                        int a_copiesAvailable, List<Person> a_authors, List<Person> a_publishers, 
                        List<Person> a_illustrators, List<LituratureGenre> a_genre, 
                        LituratureMedium a_medium, Person a_coverArtist, Person a_editor,
                        string a_countryOfOrigin, string a_LCClass, string a_setIn, int a_pages, int a_OCLC
                        ) : base(a_libraryCode, a_title, a_releaseDate, a_copiesTotal, a_copiesAvailable)
    {
        authors = a_authors;
        publishers = a_publishers;
        illustrators = a_illustrators;
        genre = a_genre;
        medium = a_medium;
        coverArtist = a_coverArtist;
        editor = a_editor;
        countryOfOrigin = a_countryOfOrigin;
        LCClass = a_LCClass;
        setIn = a_setIn;
        pages = a_pages;
        OCLC = a_OCLC;
    }

    public List<Person> authors;
    public List<Person> publishers;
    public List<Person> illustrators;
    public List<LituratureGenre> genre;
    public LituratureMedium medium { get; set; }
    public Person coverArtist { get; set; }
    public Person editor { get; set; }
    public string countryOfOrigin { get; set; }
    public string LCClass { get; set; }//Library of Congress Number
    public string setIn { get; set; }
    public int pages { get; set; }
    public int OCLC { get; set; }//Online Central Library Center Number

    public override void print()
    {
        printProperties(this);

        printPersonList(authors, "authors");
        printPersonList(publishers, "publishers");
        printPersonList(illustrators, "illustrators");
        printList<LituratureGenre>(genre, "genre");
    }

    public List<string> GetValuesF()
    {
        List<string> values = new List<string>();

        values.AddRange(returnPropertiesF(this));

        values.AddRange(returnPersonListF(authors, "authors"));
        values.AddRange(returnPersonListF(publishers, "publishers"));
        values.AddRange(returnPersonListF(illustrators, "illustrators"));
        values.AddRange(returnListF<LituratureGenre>(genre, "genre"));

        return values;
    }
    public List<List<string>> GetValues()
    {
        List<List<string>> values = returnProperties(this);

        values.Add(returnPersonList(authors, "authors"));
        values.Add(returnPersonList(publishers, "publishers"));
        values.Add(returnPersonList(illustrators, "illustrators"));
        values.Add(returnList<LituratureGenre>(genre, "genre"));

        return values;
    }
}
