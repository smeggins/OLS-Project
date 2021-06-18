using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Liturature : Entity
{
    public Liturature(string a_title, LituratureMedium a_medium) : base(a_title) 
    {
        authors = new List<string>();
        publishers = new List<string>();
        illustrators = new List<string>();
        medium = a_medium;
        genre = new List<VideoAndLituratureGenre>();
        libraryCode += "L." + (int)medium + "." + a_title[0];
    }

    public List<string> authors;
    public List<string> publishers;
    public List<string> illustrators;
    public List<VideoAndLituratureGenre> genre;
    public LituratureMedium medium { get; set; }
    public string coverArtist { get; set; }
    public string countryOfOrigin { get; set; }
    public string LCClass { get; set; }//Library of Congress Number
    public string editor { get; set; }
    public string setIn { get; set; }
    public int pages { get; set; }
    public int OCLC { get; set; }//Online Central Library Center Number

    public void print(Liturature instantiatedEntiy)
    {
        printProperties(instantiatedEntiy);

        printList<string>(authors, "authors");
        printList<string>(publishers, "publishers");
        printList<string>(illustrators, "illustrators");
        printList<VideoAndLituratureGenre>(genre, "genre");
    }
}
