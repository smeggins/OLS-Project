using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public static class Load
{
    /// <summary>
    /// Takes an Xelement of a Video Entity and returns the data as an Entity
    /// </summary>
    /// <param name="elements">An XElement of an Video Entity</param>
    /// <returns>a Video Object</returns>
    public static Entity readXmlToVideo(XElement elements)
    {
        string libraryCode = elements.Attributes().Where(e => e.Name == "libraryCode").First().Value;
        string title = elements.Attributes().Where(e => e.Name == "title").First().Value;
        string releaseDate = elements.Attributes().Where(e => e.Name == "releaseDate").First().Value;
        int copiesTotal;
        int copiesAvailable;

        int.TryParse(elements.Attributes().Where(e => e.Name == "copiesTotal").First().Value, out copiesTotal);
        int.TryParse(elements.Attributes().Where(e => e.Name == "copiesAvailable").First().Value, out copiesAvailable);
        
        List<Person> actors = xmlParsing.xElementEnumToPersons(elements.Descendants("actors").Descendants("value"));
        List<Person> stars = xmlParsing.xElementEnumToPersons(elements.Descendants("stars").Descendants("value"));
        List<Person> writers = xmlParsing.xElementEnumToPersons(elements.Descendants("writers").Descendants("value"));
        List<Person> producers = xmlParsing.xElementEnumToPersons(elements.Descendants("producers").Descendants("value"));
        List<Person> directors = xmlParsing.xElementEnumToPersons(elements.Descendants("directors").Descendants("value"));
        List<VideoGenre> genre = xmlParsing.xElementEnumToVideoGenres(elements.Descendants("genre").Descendants("value"));
        List<VideoMedium> mediums = xmlParsing.xElementEnumToVideoMediums(elements.Descendants("medium").Descendants("value"));
        Person cinematogrophy;
        Person distributer;

        List<Person> checkValue = xmlParsing.xElementEnumToPersons(elements.Descendants("cinematogrophy").Descendants("value"));
        if (checkValue.Count > 0)
        {
            cinematogrophy = xmlParsing.xElementEnumToPersons(elements.Descendants("cinematogrophy").Descendants("value"))[0];
        }
        else
        {
            cinematogrophy = null;
        }

        checkValue = xmlParsing.xElementEnumToPersons(elements.Descendants("distributer").Descendants("value"));
        if (checkValue.Count > 0)
        {
            distributer = xmlParsing.xElementEnumToPersons(elements.Descendants("distributer").Descendants("value"))[0];
        }
        else
        {
            distributer = null;
        }

        string country = elements.Descendants("country").First().Value;
        string editer = elements.Descendants("editor").First().Value;
        string music = elements.Descendants("music").First().Value;
        int budget;
        int boxOffice;
        int runningTime;

        int.TryParse(elements.Descendants("budget").First().Value, out budget);
        int.TryParse(elements.Descendants("boxOffice").First().Value, out boxOffice);
        int.TryParse(elements.Descendants("runningTime").First().Value, out runningTime);
        

        return new Video( libraryCode, title, releaseDate, copiesTotal, copiesAvailable, actors, 
                                        stars, writers, producers, directors, mediums, genre, cinematogrophy, 
                                        distributer, country, editer, music, budget, boxOffice, runningTime);
    }

    /// <summary>
    /// Takes an Xelement of a Liturature Entity and returns the data as an Entity
    /// </summary>
    /// <param name="elements">An XElement of an Liturature Entity</param>
    /// <returns>a Liturature Object</returns>
    public static Entity readXmlToLiturature(XElement elements)
    {
        string libraryCode = elements.Attributes().Where(e => e.Name == "libraryCode").First().Value;
        string title = elements.Attributes().Where(e => e.Name == "title").First().Value;
        string releaseDate = elements.Attributes().Where(e => e.Name == "releaseDate").First().Value;
        int copiesTotal;
        int copiesAvailable;

        int.TryParse(elements.Attributes().Where(e => e.Name == "copiesTotal").First().Value, out copiesTotal);
        int.TryParse(elements.Attributes().Where(e => e.Name == "copiesAvailable").First().Value, out copiesAvailable);

        List<Person> authors = xmlParsing.xElementEnumToPersons(elements.Descendants("authors").Descendants("value"));
        List<Person> publishers = xmlParsing.xElementEnumToPersons(elements.Descendants("publishers").Descendants("value"));
        List<Person> illustrators = xmlParsing.xElementEnumToPersons(elements.Descendants("illustrators").Descendants("value"));
        List<LituratureGenre> genre = xmlParsing.xElementEnumToLituratureGenres(elements.Descendants("genre").Descendants("value"));

        LituratureMedium medium;
        Enum.TryParse(elements.Descendants("editor").First().Value, out medium);

        Person coverArtist;
        Person editor;

        List<Person> checkValue = xmlParsing.xElementEnumToPersons(elements.Descendants("coverArtist"));
        if (checkValue.Count > 0)
        {
            coverArtist = xmlParsing.xElementEnumToPersons(elements.Descendants("coverArtist"))[0];
        }
        else
        {
            coverArtist = null;
        }

        checkValue = xmlParsing.xElementEnumToPersons(elements.Descendants("editor"));
        if (checkValue.Count > 0)
        {
            editor = xmlParsing.xElementEnumToPersons(elements.Descendants("editor"))[0];
        }
        else
        {
            editor = null;
        }

        string countryOfOrigin = elements.Descendants("countryOfOrigin").First().Value;
        string LCClass = elements.Descendants("LCClass").First().Value;
        string setIn = elements.Descendants("setIn").First().Value;
        int pages;
        int OCLC;

        int.TryParse(elements.Descendants("pages").First().Value, out pages);
        int.TryParse(elements.Descendants("OCLC").First().Value, out OCLC);

        return new Liturature(libraryCode, title, releaseDate, copiesTotal, copiesAvailable, authors,
                                        publishers, illustrators, genre, medium, coverArtist, editor, countryOfOrigin,
                                        LCClass, setIn, pages, OCLC);
    }

    /// <summary>
    /// Loads all xml files
    /// </summary>
    /// <param name="audioFileLocation">xml file location without the file type (ie testxml/audio )</param>
    /// <param name="videoFileLocation">xml file location without the file type (ie testxml/video )</param>
    /// <param name="videoGameFileLocation">xml file location without the file type (ie testxml/videoGame )</param>
    /// <param name="lituratureFileLocation">xml file location without the file type (ie testxml/liturature )</param>
    /// <returns>returns an instantiated shelf</returns>
    public static Shelf loadXml(string audioFileLocation, string videoFileLocation, 
                                string videoGameFileLocation, string lituratureFileLocation)
    {
        Shelf returnShelf = new Shelf();

        XDocument videoFile = XDocument.Load(videoFileLocation + ".xml");
        XDocument lituratureFile = XDocument.Load(lituratureFileLocation + ".xml");

        foreach (var item in videoFile.Descendants("entity"))
        {
            returnShelf.add(Format.Video, readXmlToVideo(item));
        }

        foreach (var item in lituratureFile.Descendants("entity"))
        {
            returnShelf.add(Format.Liturature, readXmlToLiturature(item));
        }

        return returnShelf;
    }
}
