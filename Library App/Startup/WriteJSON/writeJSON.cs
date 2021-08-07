
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
//using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


public class writeJSON
{
    public static void writeAudioJson(Shelf shelf, string songTitle, AudioMedium songMedium, string songArtist, string songLabel)
    {
        
        var audioItem = new audioData() {
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

        if(songMedium == AudioMedium.Record)
        {
            audioMedium = AudioMedium.Record;
        }
        else if(songMedium == AudioMedium.Digital) 
        {
            audioMedium = AudioMedium.Digital;
           
        }

        List<AudioMedium> audioMediums = new List<AudioMedium>();
        audioMediums.Add(audioMedium);
        Audio audio = new Audio(songTitle, audioMediums);


        shelf.add(Format.Audio, audio);


    } 

    public static void writeVideoGameJson(Shelf shelf, string gameTitle, VideoGameMedium medium, string gameStudio)
    {
        var videogameItem = new videoGameData()
        { 
            Title = gameTitle, 
            videoGameMedium = medium,
            Studio = gameStudio
        
        };
    
        
       

        var videogamestuff = new List<videoGameData>();

        videogamestuff.Add(videogameItem);

        string jsonString = JsonConvert.SerializeObject(videogameItem, Formatting.Indented);
        string filename = "json/videogameJson.json";
        File.AppendAllText(filename, jsonString);
        //File.AppendAllText(filename, ",");
        File.AppendAllText(filename, "\n");

        VideoGameMedium vidgameMedium = VideoGameMedium.PC;

        if(medium == VideoGameMedium.XboxOne)
        {
            vidgameMedium = VideoGameMedium.XboxOne;
        } 
        else if (medium == VideoGameMedium.PS5)
        {
            vidgameMedium = VideoGameMedium.PS5;
        }
        else if(medium == VideoGameMedium.Switch)
        {
            vidgameMedium = VideoGameMedium.Switch;
        }

        List<VideoGameMedium> vidgameMediums = new List<VideoGameMedium>();
        vidgameMediums.Add(vidgameMedium);
        VideoGame vidgame = new VideoGame(gameTitle, vidgameMediums);
        shelf.add(Format.VideoGame, vidgame);


    }

}

public class audioData
{
    public string Title { get; set; }
    public AudioMedium audioMedium { get; set; }
    public string artist { get; set; }
    public string label { get; set; } 
}

public class videoGameData
{
    //public string gameItem { get; set; }
    public string Title { get; set; }
   
    public VideoGameMedium videoGameMedium { get; set; }
    public string Studio { get; set; }

}

public class vidgameList
{
    public videoGameData[] lolinfo { get; set; } 
}
