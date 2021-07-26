using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

class xmlParsing
{
    public static List<string> xElementEnumToStrings(IEnumerable<XElement> elements)
    {
        List<string> returnList = new List<string>();

        foreach (XElement element in elements)
        {
            returnList.Add(element.Value);
        }

        return returnList;
    }

    public static List<Person> xElementEnumToPersons(IEnumerable<XElement> elements)
    {
        List<Person> returnList = new List<Person>();

        foreach (XElement element in elements)
        {
            string[] name = element.Value.Split(' ');
            if (name.Length == 2)
            {
                returnList.Add(new Person(name[0], name[1]));
            }
        }

        return returnList;
    }

    public static List<VideoMedium> xElementEnumToVideoMediums(IEnumerable<XElement> elements)
    {
        List<VideoMedium> mediums = new List<VideoMedium>();

        foreach (var medium in elements.Descendants("medium"))
        {
            // Takes the value and attempts to parse it to the medium type
            // out creates and instatiates an audioMedium variable names mediumValue
            Enum.TryParse(medium.Value, out VideoMedium mediumValue);
            mediums.Add(mediumValue);
        }

        return mediums;
    }

    public static List<LituratureMedium> xElementEnumToLituratureMediums(IEnumerable<XElement> elements)
    {
        List<LituratureMedium> mediums = new List<LituratureMedium>();

        foreach (var medium in elements.Descendants("medium"))
        {
            // Takes the value and attempts to parse it to the medium type
            // out creates and instatiates an audioMedium variable names mediumValue
            Enum.TryParse(medium.Value, out LituratureMedium mediumValue);
            mediums.Add(mediumValue);
        }

        return mediums;
    }

    public static List<VideoGenre> xElementEnumToVideoGenres(IEnumerable<XElement> elements)
    {
        List<VideoGenre> genres = new List<VideoGenre>();

        foreach (var genre in elements.Descendants("genre"))
        {
            // Takes the value and attempts to parse it to the medium type
            // out creates and instatiates an audioMedium variable names mediumValue
            Enum.TryParse(genre.Value, out VideoGenre mediumValue);
            genre.Add(mediumValue);
        }

        return genres;
    }

    public static List<LituratureGenre> xElementEnumToLituratureGenres(IEnumerable<XElement> elements)
    {
        List<LituratureGenre> genres = new List<LituratureGenre>();

        foreach (var genre in elements.Descendants("genre"))
        {
            // Takes the value and attempts to parse it to the medium type
            // out creates and instatiates an audioMedium variable names mediumValue
            Enum.TryParse(genre.Value, out LituratureGenre mediumValue);
            genre.Add(mediumValue);
        }

        return genres;
    }
}
