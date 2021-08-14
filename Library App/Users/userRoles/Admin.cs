using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;


public class Admin
{
    private string firstName;
    private string lastName;
    private int employeeID;

    public static int adminCount;


    public Admin(string firstname, string lastname, int empID)
    {
        adminCount++;

        firstName = firstname;
        lastName = lastname;
        employeeID = empID;
        Console.WriteLine("New Admin Created");


    }


    public static void addnewUser(Admin admin, string firstname, string lastname, int empnum)
    {


        var user1 = new consumerCreatedUSer()
        {
            firstName = firstname,
            lastName = lastname,
            employeeNumber = empnum
        };
        

        Console.WriteLine("New Consumer Creater: {0}", user1.firstName);

        
    }

   

    public static void createnewUser(string firstname, string lastname, int employeenum) 
    {

        var user = new adminCreatedUSer()
        {
            firstName = firstname,
            lastName = lastname,
            employeeNumber = employeenum
        };

        /*List<adminCreatedUSer> newUsers = new List<adminCreatedUSer>();
        string userslol = user.firstName;
        //newUsers.Add(user.firstName);
        
        adminCreatedUSer[] userList = newUsers.ToArray(); */

        Console.WriteLine("New User: {0}", user.firstName);


       

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

public class adminCreatedUSer
{

  
    public string firstName;
    public string lastName; 
    public int employeeNumber;
}



public class adminConsumerCreate
{

    public string firstName;
    public string lastName;
    public int employeeNumber;
}
