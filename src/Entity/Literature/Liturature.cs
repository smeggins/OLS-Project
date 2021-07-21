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

    public List<Person> authors;
    public List<Person> publishers;
    public List<Person> illustrators;
    public List<LituratureGenre> genre;
    public LituratureMedium medium { get; set; }
    public Person coverArtist { get; set; }
    public string countryOfOrigin { get; set; }
    public string LCClass { get; set; }//Library of Congress Number
    public Person editor { get; set; }
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
