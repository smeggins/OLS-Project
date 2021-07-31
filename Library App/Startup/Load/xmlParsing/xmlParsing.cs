using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

class xmlParsing
{
    /// <summary>
    /// Converts an Ienumarable of XElements into a list of strings
    /// </summary>
    /// <param name="elements">an XElement</param>
    /// <returns>List of strings of data</returns>
    public static List<string> xElementEnumToStrings(IEnumerable<XElement> elements)
    {
        List<string> returnList = new List<string>();

        foreach (XElement element in elements)
        {
            returnList.Add(element.Value);
        }

        return returnList;
    }

    /// <summary>
    /// Takes an Ienumerable of XElements of peoples names, 
    /// then splits the retrieved data and uses that to create a new person.
    /// </summary>
    /// <param name="elements">an XElement containing a Persons Name</param>
    /// <returns>a list of Persons</returns>
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

    /// <summary>
    /// Takes an Ienumerable of XElements of VideoMediums, 
    /// then splits the retrieved data and uses that to create a LituratureMedium.
    /// </summary>
    /// <param name="elements">an XElement containing aVideoMediums</param>
    /// <returns>a list of VideoMediums</returns>
    public static List<VideoMedium> xElementEnumToVideoMediums(IEnumerable<XElement> elements)
    {
        List<VideoMedium> mediums = new List<VideoMedium>();

        foreach (XElement medium in elements)
        {
            // Takes the value and attempts to parse it to the medium type
            // out creates and instatiates an audioMedium variable names mediumValue
            Enum.TryParse(medium.Value, out VideoMedium mediumValue);
            mediums.Add(mediumValue);
        }

        return mediums;
    }

    /// <summary>
    /// Takes an Ienumerable of XElements of LituratureMediums, 
    /// then splits the retrieved data and uses that to create a LituratureMedium.
    /// </summary>
    /// <param name="elements">an XElement containing aLituratureMediums</param>
    /// <returns>a list of LituratureMediums</returns>
    public static List<LituratureMedium> xElementEnumToLituratureMediums(IEnumerable<XElement> elements)
    {
        List<LituratureMedium> mediums = new List<LituratureMedium>();

        foreach (XElement medium in elements)
        {
            // Takes the value and attempts to parse it to the medium type
            // out creates and instatiates an audioMedium variable names mediumValue
            Enum.TryParse(medium.Value, out LituratureMedium mediumValue);
            mediums.Add(mediumValue);
        }

        return mediums;
    }

    /// <summary>
    /// Takes an Ienumerable of XElements of VideoGenre, 
    /// then splits the retrieved data and uses that to create a VideoGenre.
    /// </summary>
    /// <param name="elements">an XElement containing aVideoGenre</param>
    /// <returns>a list of VideoGenre</returns>
    public static List<VideoGenre> xElementEnumToVideoGenres(IEnumerable<XElement> elements)
    {
        List<VideoGenre> genres = new List<VideoGenre>();

        foreach (XElement genre in elements)
        {
            // Takes the value and attempts to parse it to the genre type
            // out creates and instatiates an audioMedium variable names genreValue
            Enum.TryParse(genre.Value, out VideoGenre genreValue);
            genres.Add(genreValue);
        }

        return genres;
    }

    /// <summary>
    /// Takes an Ienumerable of XElements of LituratureGenre, 
    /// then splits the retrieved data and uses that to create a LituratureGenre.
    /// </summary>
    /// <param name="elements">an XElement containing aLituratureGenre</param>
    /// <returns>a list of LituratureGenre</returns>
    public static List<LituratureGenre> xElementEnumToLituratureGenres(IEnumerable<XElement> elements)
    {
        List<LituratureGenre> genres = new List<LituratureGenre>();

        foreach(XElement genre in elements)
        {
            // Takes the value and attempts to parse it to the genre type
            // out creates and instatiates an audioMedium variable names genreValue
            Enum.TryParse(genre.Value, out LituratureGenre genreValue);
            genres.Add(genreValue);
        }

        return genres;
    }
}
