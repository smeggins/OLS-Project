using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

using System.Text.Json;
using System.Threading.Tasks;


public class UpdateJSON
{
    public static void updateVideoGameJson(string title, string updateItem, string newInfo)
    {
        var filename = "json/videogameJson.json";
        string jsonData = File.ReadAllText(filename);

        //dynamic jsonItems = JsonSerializer.Deserialize<List<videoGameData>>(jsonData);
        List<videoGameData> jsonItems = JsonConvert.DeserializeObject<List<videoGameData>>(jsonData);

        foreach(var item in jsonItems)
        {
            if(item.Title == title)
            {
                if(updateItem == "title")
                {
                    item.Title = newInfo;
                    Console.WriteLine(item.Title);
                    string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                    File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                }

                if(updateItem == "medium")
                {
                    if(newInfo == "XBOX")
                    {
                        item.videoGameMedium = VideoGameMedium.XboxOne;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                    }
                    if(newInfo == "PS5")
                    {
                        item.videoGameMedium = VideoGameMedium.PS5;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                    }
                    if(newInfo == "PC")
                    {
                        item.videoGameMedium = VideoGameMedium.PC;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                    }
                    if(newInfo == "Switch")
                    {
                        item.videoGameMedium = VideoGameMedium.Switch;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                    }
                }

                if(updateItem == "studio")
                {
                    item.Studio = newInfo;
                    string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                    File.WriteAllText("json/updatedVidGame.json", newjsonItems);
                }
           
            }
        }
    }

    public static void updateAudioJson(string title, string updateItem, string newInfo)
    {

        var filename = "json/audioJson.json";
        string jsonData = File.ReadAllText(filename);
        List<audioData> jsonItems = JsonConvert.DeserializeObject<List<audioData>>(jsonData);


        foreach (var item in jsonItems)
        {
            if (item.Title == title)
            {
                if (updateItem == "title")
                {
                    item.Title = newInfo;
                    Console.WriteLine(item.Title);
                    string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                    File.WriteAllText("json/updatedAudio.json", newjsonItems);
                }

                if (updateItem == "medium")
                {
                    if (newInfo == "CD")
                    {
                        item.audioMedium = AudioMedium.CD;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedAudio.json", newjsonItems);
                    }
                    if (newInfo == "Record")
                    {
                        item.audioMedium = AudioMedium.Record;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedAudio.json", newjsonItems);
                    }
                    if (newInfo == "Digital")
                    {
                        item.audioMedium = AudioMedium.Digital;
                        string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                        File.WriteAllText("json/updatedAudio.json", newjsonItems);
                    }
                    
                }

                if (updateItem == "label")
                {
                    item.label = newInfo;
                    string newjsonItems = JsonConvert.SerializeObject(jsonItems, Formatting.Indented);
                    File.WriteAllText("json/updatedAudio.json", newjsonItems);
                }

            }
        }
    }

}

