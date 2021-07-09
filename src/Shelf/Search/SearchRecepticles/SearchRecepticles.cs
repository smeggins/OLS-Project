using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class SearchRecepticles
{
    //Abbe
    public static Dictionary<string, Entity> Lit;
    public static Dictionary<string, Entity> audio;
    public static IEnumerable<int> userNumbers; // need to initialize with a list or array of all user numbers

    //Phil
    public static Dictionary<string, List<Entity>> videoGame = new Dictionary<string, List<Entity>>();
    public static Dictionary<string, List<Entity>> video = new Dictionary<string, List<Entity>>();

    /// <summary>
    /// adds item to dictionary
    /// overloaded for each entity type
    /// </summary>
    /// <param name="a_outputDic">the dictionary it will be added too</param>
    /// <param name="item">the entity you are adding</param>
    /// <returns>the updated dictionary</returns>
    static Dictionary<string, List<Entity>> checkKeyAddValue(Dictionary<string, List<Entity>> a_outputDic, Audio item)
    {
        Dictionary<string, List<Entity>> outputDic = a_outputDic;

        foreach (var producers in item.artists)
        {
            if (outputDic.ContainsKey(producers.fullName))
            {
                outputDic[producers.fullName].Add(item);
            }
            else
            {
                outputDic[producers.fullName] = new List<Entity>();
                outputDic[producers.fullName].Add(item);
            }
        }

        return outputDic;
    }

    static Dictionary<string, List<Entity>> checkKeyAddValue(Dictionary<string, List<Entity>> a_outputDic, Video item)
    {
        Dictionary<string, List<Entity>> outputDic = a_outputDic;

        foreach (var directors in item.directors)
        {
            if (outputDic.ContainsKey(directors.fullName))
            {
                outputDic[directors.fullName].Add(item);
            }
            else
            {
                outputDic[directors.fullName] = new List<Entity>();
                outputDic[directors.fullName].Add(item);
            }
        }

        return outputDic;
    }

    static Dictionary<string, List<Entity>> checkKeyAddValue(Dictionary<string, List<Entity>> a_outputDic, Liturature item)
    {
        Dictionary<string, List<Entity>> outputDic = a_outputDic;

        foreach (var authors in item.authors)
        {
            if (outputDic.ContainsKey(authors.fullName))
            {
                outputDic[authors.fullName].Add(item);
            }
            else
            {
                outputDic[authors.fullName] = new List<Entity>();
                outputDic[authors.fullName].Add(item);
            }
        }

        return outputDic;
    }

    static Dictionary<string, List<Entity>> checkKeyAddValue(Dictionary<string, List<Entity>> a_outputDic, VideoGame item)
    {
        Dictionary<string, List<Entity>> outputDic = a_outputDic;

        foreach (var developers in item.developers)
        {
            if (outputDic.ContainsKey(developers))
            {
                outputDic[developers].Add(item);
            }
            else
            {
                outputDic[developers] = new List<Entity>();
                outputDic[developers].Add(item);
            }
        }

        return outputDic;
    }

    /// <summary>
    /// iterates through a list of entities and adds each one to a search dictionary
    /// </summary>
    /// <param name="dic">the dictionary you want to add too</param>
    /// <param name="inputList">The list of entities you are adding</param>
    /// <param name="typeOfData">the specific entity type so it can be cast</param>
    /// <returns>the updated dictionary</returns>
    public static Dictionary<string, List<Entity>> generateDictionary(Dictionary<string, List<Entity>> dic, List<Entity> inputList, Format typeOfData)
    {
        Dictionary<string, List<Entity>> outputDic = dic;

        if (typeOfData == Format.Audio)
        {
            foreach (var item in inputList)
            {
                Audio castItem = (Audio)item;
                checkKeyAddValue(outputDic, castItem);
            }
        }

        if (typeOfData == Format.Liturature)
        {
            foreach (var item in inputList)
            {
                Liturature castItem = (Liturature)item;
                checkKeyAddValue(outputDic, castItem);
            }
        }

        if (typeOfData == Format.Video)
        {
            foreach (var item in inputList)
            {
                Video castItem = (Video)item;
                checkKeyAddValue(outputDic, castItem);
            }
        }

        if (typeOfData == Format.VideoGame)
        {
            foreach (var item in inputList)
            {
                VideoGame castItem = (VideoGame)item;
                checkKeyAddValue(outputDic, castItem);
            }
        }

        return outputDic;
    }

    public static void instantiateSearchDictionaries(Shelf shelf)
    {
        video = generateDictionary(video, shelf.LibraryShelf[Format.Video], Format.Video);
        videoGame = generateDictionary(videoGame, shelf.LibraryShelf[Format.VideoGame], Format.VideoGame);
        //TODO ABBE add your dictionaries here and test
    }
}
