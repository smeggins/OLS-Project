using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// A custom converter used to serialize and deserialize a libraryShelf into Json
/// </summary>
public class JsonShelfConverter : JsonConverter<Dictionary<Format, List<Entity>>>
{
    /// <summary>
    /// instantiates a Video entity object from a specific section of the reader then returns the readers current state
    /// </summary>
    /// <param name="reader">A reader pointed to the start of a video entity</param>
    /// <param name="returnReader">the readers state (or position) after reading the video entity</param>
    /// <returns> the instantiated Entity</returns>
    public static Entity readJsonToVideo(Utf8JsonReader reader, out Utf8JsonReader returnReader)
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //NOTE: I know these two methods are long. I could have abstracted more but I ran out of time (preparing for finals)////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        string libraryCode = "";
        string title = "";
        string releaseDate = "";
        int copiesTotal = 0;
        int copiesAvailable = 0;

        List<Person> actors = new List<Person>();
        List<Person> stars = new List<Person>();
        List<Person> writers = new List<Person>();
        List<Person> producers = new List<Person>();
        List<Person> directors = new List<Person>();
        List<VideoGenre> genre = new List<VideoGenre>();
        List<VideoMedium> mediums = new List<VideoMedium>();
        //used to store cast before adding to list
        VideoGenre castGenre;
        VideoMedium castMedium;

        Person cinematogrophy = null;
        Person distributer = null;

        string country = "";
        string editor = "";
        string music = "";
        int budget = 0;
        int boxOffice = 0;
        int runningTime = 0;

        while (reader.Read())
        {

            string valueName = "";

            // if a EndObject TokenType is not followed by a StartObject then we are finished adding items to the Entity List
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                valueName = reader.GetString();
            }


            switch (valueName)
            {
                case "libraryCode":
                    reader.Read();
                    libraryCode = reader.GetString();
                    break;
                case "title":
                    reader.Read();
                    title = reader.GetString();
                    break;
                case "releaseDate":
                    reader.Read();
                    releaseDate = reader.GetString();
                    break;
                case "copiesTotal":
                    reader.Read();
                    copiesTotal = reader.GetInt32();
                    break;
                case "copiesAvailable":
                    reader.Read();
                    copiesAvailable = reader.GetInt32();
                    break;




                case "cinematogrophy":
                    reader.Read();
                    cinematogrophy = (reader.GetString() != "") ? new Person(reader.GetString()) : null;
                    break;
                case "distributer":
                    reader.Read();
                    distributer = (reader.GetString() != "") ? new Person(reader.GetString()) : null;
                    break;
                case "country":
                    reader.Read();
                    country = reader.GetString();
                    break;
                case "editor":
                    reader.Read();
                    editor = reader.GetString();
                    break;
                case "music":
                    reader.Read();
                    music = reader.GetString();
                    break;
                case "budget":
                    reader.Read();
                    budget = reader.GetInt32();
                    break;
                case "boxOffice":
                    reader.Read();
                    boxOffice = reader.GetInt32();
                    break;
                case "runningTime":
                    reader.Read();
                    runningTime = reader.GetInt32();
                    break;


                case "actors":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            actors.Add(new Person(reader.GetString()));
                        }
                    }
                    break;
                case "stars":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            stars.Add(new Person(reader.GetString()));
                        }
                    }
                    break;
                case "writers":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            writers.Add(new Person(reader.GetString()));
                        }
                    }
                    break;
                case "producers":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            producers.Add(new Person(reader.GetString()));
                        }
                    }
                    break;
                case "directors":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            directors.Add(new Person(reader.GetString()));
                        }
                    }
                    break;
                case "genre":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {

                            Enum.TryParse(reader.GetString(), out castGenre);
                            genre.Add(castGenre);
                        }
                    }
                    break;
                case "mediums":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {

                            Enum.TryParse(reader.GetString(), out castMedium);
                            mediums.Add(castMedium);
                        }
                    }
                    break;
            }
        }

        returnReader = reader;
        return new Video(libraryCode, title, releaseDate, copiesTotal, copiesAvailable, actors,
                                        stars, writers, producers, directors, mediums, genre, cinematogrophy,
                                        distributer, country, editor, music, budget, boxOffice, runningTime);
    }

    /// <summary>
    /// instantiates a Liturature entity object from a specific section of the reader then returns the readers current state
    /// </summary>
    /// <param name="reader">A Utf8JsonReader pointed to the start of a video entity</param>
    /// <param name="returnReader">the Utf8JsonReader state (or position) after reading the video entity</param>
    /// <returns> the instantiated Entity</returns>
    public static Entity readJsonToLiturature(Utf8JsonReader reader, out Utf8JsonReader returnReader)
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //NOTE: I know these two methods are long. I could have abstracted more but I ran out of time (preparing for finals)////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        string libraryCode = "";
        string title = "";
        string releaseDate = "";
        int copiesTotal = 0;
        int copiesAvailable = 0;

        List<Person> authors = new List<Person>();
        List<Person> publishers = new List<Person>();
        List<Person> illustrators = new List<Person>();
        List<LituratureGenre> genre = new List<LituratureGenre>();

        //used to store cast genre before adding to list
        LituratureGenre castGenre;

        LituratureMedium medium = LituratureMedium.Book;
        Person coverArtist = null;
        Person editor = null;

        string countryOfOrigin = "";
        string LCClass = "";
        string setIn = "";
        int pages = 0;
        int OCLC = 0;

        while (reader.Read())
        {
            
            string valueName = "";

            // if a EndObject TokenType is not followed by a StartObject then we are finished adding items to the Entity List
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if(reader.TokenType == JsonTokenType.PropertyName)
            {
                valueName = reader.GetString();
            }
            

            switch (valueName)
            {
                case "libraryCode":
                    reader.Read();
                    libraryCode = reader.GetString();
                    break;
                case "title":
                    reader.Read();
                    title = reader.GetString();
                    break;
                case "releaseDate":
                    reader.Read();
                    releaseDate = reader.GetString();
                    break;
                case "copiesTotal":
                    reader.Read();
                    copiesTotal = reader.GetInt32();
                    break;
                case "copiesAvailable":
                    reader.Read();
                    copiesAvailable = reader.GetInt32();
                    break;
                case "coverArtist":
                    reader.Read();
                    coverArtist = (reader.GetString() != "") ? new Person(reader.GetString()) : null;
                    break;
                case "editor":
                    reader.Read();
                    editor = (reader.GetString() != "") ? new Person(reader.GetString()) : null;
                    break;
                case "medium":
                    reader.Read();
                    Enum.TryParse(reader.GetString(), out medium);
                    break;
                case "countryOfOrigin":
                    reader.Read();
                    countryOfOrigin = reader.GetString();
                    break;
                case "LCClass":
                    reader.Read();
                    LCClass = reader.GetString();
                    break;
                case "setIn":
                    reader.Read();
                    setIn = reader.GetString();
                    break;
                case "pages":
                    reader.Read();
                    pages = reader.GetInt32();
                    break;
                case "OCLC":
                    reader.Read();
                    OCLC = reader.GetInt32();
                    break;
                case "authors":
                    while(reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            authors.Add(new Person(reader.GetString()));
                        }
                    }
                    break;
                case "publishers":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            publishers.Add(new Person(reader.GetString()));
                        }
                    }
                    break;
                case "illustrators":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            illustrators.Add(new Person(reader.GetString()));
                        }
                    }
                    break;
                case "genre":
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            break;
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            
                            Enum.TryParse(reader.GetString(), out castGenre);
                            genre.Add(castGenre);
                        }
                    }
                    break;
            }
        }

        returnReader = reader;
        return new Liturature(libraryCode, title, releaseDate, copiesTotal, copiesAvailable, authors,
                                        publishers, illustrators, genre, medium, coverArtist, editor, countryOfOrigin,
                                        LCClass, setIn, pages, OCLC);
    }

    /// <summary>
    /// Generates the list of Entities for a given 'Format type' in the library shelf (ie Liturature/Video/etc)
    /// </summary>
    /// <param name="reader">a Utf8JsonReader positioned at the beginning of a list of entitys of a specific type</param>
    /// <param name="type">The type of entity you expect in this list</param>
    /// <param name="returnReader">the Utf8JsonReader state (or position) after reading the entity list</param>
    /// <returns>the instantiated list of entitys</returns>
    private static List<Entity> getEntityList(Utf8JsonReader reader, Format type, out Utf8JsonReader returnReader)
    {
        List<Entity> returnList = new List<Entity>();

        while (reader.Read())
        {
            // if a EndObject TokenType is not followed by a StartObject then we are finished adding items to the Entity List
            if (reader.TokenType == JsonTokenType.EndObject || reader.TokenType == JsonTokenType.EndArray)
            {
                reader.Read();
                if (reader.TokenType != JsonTokenType.StartObject)
                    break;
            }

            if (type == Format.Video)
            {
                returnList.Add(readJsonToVideo(reader, out reader));
            }
            else if (type == Format.Liturature)
            {
                returnList.Add(readJsonToLiturature(reader, out reader));
            }
        }

        returnReader = reader;
        return returnList;
    }

    /// <summary>
    /// The custom Read ran when JsonSerializer.Deserialize is called on a json document to load a libraryShelf
    /// </summary>
    /// <returns>an instanitated Dictionary to be appended to shelf.libraryShelf</returns>
    public override Dictionary<Format, List<Entity>> Read(ref Utf8JsonReader reader,
                                                            Type typeToConvert,
                                                            JsonSerializerOptions options)
    {
        var dictionary = new Dictionary<Format, List<Entity>>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                if (reader.GetString() == "Liturature")
                {
                    //read literature to shelf
                    dictionary[Format.Liturature] = getEntityList(reader, Format.Liturature, out reader);
                }
                else if (reader.GetString() == "Video")
                {
                    // read videos to shelf
                    dictionary[Format.Video] = getEntityList(reader, Format.Video, out reader);
                }
            }
        }

        return dictionary;
    }

    /// <summary>
    /// adds the values in a generic list of specific types to a Utf8JsonWriter to be later saved
    /// </summary>
    /// <typeparam name="T">valid types: Person, VideoMedium, VideoGenre, LituratureGenre</typeparam>
    /// <param name="writer">previously instantiated Utf8JsonWriter (handle output after this method)</param>
    /// <param name="title">list key/title</param>
    /// <param name="values">the list of generic values of specific types</param>
    private void writeList<T>(Utf8JsonWriter writer, string title, List<T> values)
    {
        writer.WriteStartArray(title);
        if (values.OfType<Person>().Any())
        {
            var castList = values.Cast<Person>();
            foreach (var actor in castList)
            {
                writer.WriteStringValue(actor.fullName);
            }
        }
        else if (values.OfType<VideoMedium>().Any())
        {
            var castList = values.Cast<VideoMedium>();
            foreach (var videoMedium in castList)
            {
                writer.WriteStringValue(videoMedium.ToString());
            }
        }
        else if (values.OfType<VideoGenre>().Any())
        {
            var castList = values.Cast<VideoGenre>();
            foreach (var genre in castList)
            {
                writer.WriteStringValue(genre.ToString());
            }
        }
        else if (values.OfType<LituratureGenre>().Any())
        {
            var castList = values.Cast<LituratureGenre>();
            foreach (var genre in castList)
            {
                writer.WriteStringValue(genre.ToString());
            }
        }

        writer.WriteEndArray();
    }

    /// <summary>
    /// adds the universal Entity values to a Utf8JsonWriter to be later saved
    /// </summary>
    /// <param name="writer">previously instantiated Utf8JsonWriter</param>
    /// <param name="entity">The entity whose values you want to save</param>
    private void writeCommon(Utf8JsonWriter writer, Entity entity)
    {
        writer.WriteString("libraryCode", entity.libraryCode);
        writer.WriteString("title", entity.title);
        writer.WriteString("releaseDate", entity.releaseDate);
        writer.WriteNumber("copiesTotal", entity.copiesTotal);
        writer.WriteNumber("copiesAvailable", entity.copiesAvailable);
    }

    /// <summary>
    /// The custom Write ran when JsonSerializer.Serialize is called on a json document to save a libraryShelf
    /// </summary>
    public override void Write(
        Utf8JsonWriter writer,
        Dictionary<Format, List<Entity>> dictionary,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("Formats");
        writer.WriteStartArray();
        foreach (var entitys in dictionary)
        {
            if (entitys.Value.Count > 0 && entitys.Value[0] as Video != null)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("Video");
                writer.WriteStartArray();
                foreach (var entity in entitys.Value)
                {
                    writer.WriteStartObject();
                    var workingEntity = entity as Video;

                    writeCommon(writer, workingEntity);

                    // requires extra check because its value is a single person object that may be null
                    writer.WriteString("cinematogrophy", (workingEntity.cinematogrophy is null) ? "" : workingEntity.cinematogrophy.fullName);
                    writer.WriteString("distributer", (workingEntity.distributer is null) ? "" : workingEntity.distributer.fullName);

                    writer.WriteString("country", workingEntity.country);
                    writer.WriteString("editor", workingEntity.editor);
                    writer.WriteString("music", workingEntity.music);

                    writer.WriteNumber("budget", workingEntity.budget);
                    writer.WriteNumber("boxOffice", workingEntity.boxOffice);
                    writer.WriteNumber("runningTime", workingEntity.runningTime);

                    writeList(writer, "actors", workingEntity.actors);
                    writeList(writer, "stars", workingEntity.stars);
                    writeList(writer, "writers", workingEntity.writers);
                    writeList(writer, "producers", workingEntity.producers);
                    writeList(writer, "directors", workingEntity.directors);
                    writeList(writer, "mediums", workingEntity.mediums);
                    writeList(writer, "genre", workingEntity.genre);

                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndObject();

            }
            else if (entitys.Value.Count > 0 && entitys.Value[0] as Liturature != null)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("Liturature");
                writer.WriteStartArray();
                foreach (var entity in entitys.Value)
                {
                    writer.WriteStartObject();
                    var workingEntity = entity as Liturature;

                    writeCommon(writer, workingEntity);

                    // requires extra check because its value is a single person object that may be null
                    writer.WriteString("coverArtist", (workingEntity.coverArtist is null) ? "" : workingEntity.coverArtist.fullName);
                    writer.WriteString("editor", (workingEntity.editor is null) ? "" : workingEntity.editor.fullName);

                    writer.WriteString("medium", workingEntity.medium.ToString());
                    writer.WriteString("countryOfOrigin", workingEntity.countryOfOrigin);
                    writer.WriteString("LCClass", workingEntity.LCClass);
                    writer.WriteString("setIn", workingEntity.setIn);

                    writer.WriteNumber("pages", workingEntity.pages);
                    writer.WriteNumber("OCLC", workingEntity.OCLC);

                    writeList(writer, "authors", workingEntity.authors);
                    writeList(writer, "publishers", workingEntity.publishers);
                    writeList(writer, "illustrators", workingEntity.illustrators);
                    writeList(writer, "genre", workingEntity.genre);

                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
    }
}