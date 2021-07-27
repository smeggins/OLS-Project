using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public static class Load
{
    public static Entity readXmlToVideo(XElement elements)
    {
        string libraryCode = elements.Attributes().Where(e => e.Name == "libraryCode").First().Value;
        string title = elements.Attributes().Where(e => e.Name == "title").First().Value;
        string releaseDate = elements.Attributes().Where(e => e.Name == "releaseDate").First().Value;
        int copiesTotal;
        int copiesAvailable;

        int.TryParse(elements.Attributes().Where(e => e.Name == "copiesTotal").First().Value, out copiesTotal);
        int.TryParse(elements.Attributes().Where(e => e.Name == "copiesAvailable").First().Value, out copiesAvailable);
        
        List<Person> actors = xmlParsing.xElementEnumToPersons(elements.Descendants("actors"));
        List<Person> stars = xmlParsing.xElementEnumToPersons(elements.Descendants("stars"));
        List<Person> writers = xmlParsing.xElementEnumToPersons(elements.Descendants("writers"));
        List<Person> producers = xmlParsing.xElementEnumToPersons(elements.Descendants("producers"));
        List<Person> directors = xmlParsing.xElementEnumToPersons(elements.Descendants("directors"));
        List<VideoGenre> genre = xmlParsing.xElementEnumToVideoGenres(elements.Descendants("genre"));
        List<VideoMedium> mediums = xmlParsing.xElementEnumToVideoMediums(elements.Descendants("medium"));
        Person cinematogrophy;
        Person distributer;

        List<Person> checkValue = xmlParsing.xElementEnumToPersons(elements.Descendants("cinematogrophy"));
        if (checkValue.Count > 0)
        {
            cinematogrophy = xmlParsing.xElementEnumToPersons(elements.Descendants("cinematogrophy"))[0];
        }
        else
        {
            cinematogrophy = null;
        }

        checkValue = xmlParsing.xElementEnumToPersons(elements.Descendants("distributer"));
        if (checkValue.Count > 0)
        {
            distributer = xmlParsing.xElementEnumToPersons(elements.Descendants("distributer"))[0];
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

    public static Entity readXmlToLiturature(XElement elements)
    {
        string libraryCode = elements.Attributes().Where(e => e.Name == "libraryCode").First().Value;
        string title = elements.Attributes().Where(e => e.Name == "title").First().Value;
        string releaseDate = elements.Attributes().Where(e => e.Name == "releaseDate").First().Value;
        int copiesTotal;
        int copiesAvailable;

        int.TryParse(elements.Attributes().Where(e => e.Name == "copiesTotal").First().Value, out copiesTotal);
        int.TryParse(elements.Attributes().Where(e => e.Name == "copiesAvailable").First().Value, out copiesAvailable);

        List<Person> actors = xmlParsing.xElementEnumToPersons(elements.Descendants("actors"));
        List<Person> stars = xmlParsing.xElementEnumToPersons(elements.Descendants("stars"));
        List<Person> writers = xmlParsing.xElementEnumToPersons(elements.Descendants("writers"));
        List<Person> producers = xmlParsing.xElementEnumToPersons(elements.Descendants("producers"));
        List<Person> directors = xmlParsing.xElementEnumToPersons(elements.Descendants("directors"));
        List<VideoGenre> genre = xmlParsing.xElementEnumToVideoGenres(elements.Descendants("genre"));
        List<VideoMedium> mediums = xmlParsing.xElementEnumToVideoMediums(elements.Descendants("medium"));
        Person cinematogrophy;
        Person distributer;

        List<Person> checkValue = xmlParsing.xElementEnumToPersons(elements.Descendants("cinematogrophy"));
        if (checkValue.Count > 0)
        {
            cinematogrophy = xmlParsing.xElementEnumToPersons(elements.Descendants("cinematogrophy"))[0];
        }
        else
        {
            cinematogrophy = null;
        }

        checkValue = xmlParsing.xElementEnumToPersons(elements.Descendants("distributer"));
        if (checkValue.Count > 0)
        {
            distributer = xmlParsing.xElementEnumToPersons(elements.Descendants("distributer"))[0];
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


        return new Video(libraryCode, title, releaseDate, copiesTotal, copiesAvailable, actors,
                                        stars, writers, producers, directors, mediums, genre, cinematogrophy,
                                        distributer, country, editer, music, budget, boxOffice, runningTime);
    }

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

        return returnShelf;
    }
}
