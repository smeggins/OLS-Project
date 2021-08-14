using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;


public class Editor
{
    private string firstName;
    private string lastName;
    private int employeeID;

    public static int editorCount;


    public Editor(string firstname, string lastname, int empID)
    {
        editorCount++;

        firstName = firstname;
        lastName = lastname;
        employeeID = empID; 
        Console.WriteLine("New Editor Created");


        
    }


    public static void readItems(string filename, string type)
    {
        string jsonData = File.ReadAllText(filename);
        Console.WriteLine("{0} Data: ", type);
        Console.WriteLine(jsonData);
    }

    public static void writeAudioJson(Shelf shelf, string songTitle, AudioMedium songMedium, string songArtist, string songLabel)
    {

        var audioItem = new audioData()
        {
            Title = songTitle,
            audioMedium = songMedium,
            artist = songArtist,
            label = songLabel,
        };




        var jsonString = JsonConvert.SerializeObject(audioItem, Formatting.Indented);
        string filename = "json/audioJson.json";
        File.AppendAllText(filename, jsonString);


        File.AppendAllText(filename, "\n");




        AudioMedium audioMedium = AudioMedium.CD;

        if (songMedium == AudioMedium.Record)
        {
            audioMedium = AudioMedium.Record;
        }
        else if (songMedium == AudioMedium.Digital)
        {
            audioMedium = AudioMedium.Digital;

        }

        List<AudioMedium> audioMediums = new List<AudioMedium>();
        audioMediums.Add(audioMedium);
        Audio audio = new Audio(songTitle, audioMediums);


        shelf.add(Format.Audio, audio);


    }

    public static void updateVideoGameJson(string title, string updateItem, string newInfo)
    {
        var filename = "json/videogameJson.json";
        string jsonData = File.ReadAllText(filename);

        
        List<videoGameData> jsonItems = JsonConvert.DeserializeObject<List<videoGameData>>(jsonData);

        foreach (var item in jsonItems)
        {
            if (item.Title == title)
            {
                if (updateItem == "title")
                {
                    item.Title = newInfo;
                    Console.WriteLine(item.Title);
                    string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                    File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                }

                if (updateItem == "medium")
                {
                    if (newInfo == "XBOX")
                    {
                        item.videoGameMedium = VideoGameMedium.XboxOne;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                    }
                    if (newInfo == "PS5")
                    {
                        item.videoGameMedium = VideoGameMedium.PS5;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                    }
                    if (newInfo == "PC")
                    {
                        item.videoGameMedium = VideoGameMedium.PC;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                    }
                    if (newInfo == "Switch")
                    {
                        item.videoGameMedium = VideoGameMedium.Switch;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                    }
                }

                if (updateItem == "studio")
                {
                    item.Studio = newInfo;
                    string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                    File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                }

            }
        }
    }





}

