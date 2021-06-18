using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Liturature : Entity
{
    public Liturature(string a_libraryCode) : base(a_libraryCode) 
    {
        authors = new List<string>();
        publishers = new List<string>();
        illustrators = new List<string>();
        genre = new List<VideoAndLituratureGenre>();
    }

    public List<string> authors;
    public List<string> publishers;
    public List<string> illustrators;
    public List<VideoAndLituratureGenre> genre;
    public string medium { get; set; }
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
