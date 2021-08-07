using System;

public static class TestStartup
{
    public static void TestStartupapp()
    {

        Shelf libraryShelf = TestShelf.createTestShelf();
        //Startup.readfromCSV(libraryShelf, "newlitcsv2.txt", "newaudiocsv.txt", "newvideocsv.txt", "newvideogamecsv.txt");
        //Startup.readfromCSV(libraryShelf, "newlitcsv.csv", "newaudiocsv.csv", "videocsv.csv", "newvideogamecsv.csv");
        //CreateAdd.createLit("Harry Potter", "JK Rowling");
        //CreateAdd.createLit("Harry Potter 2", "JK Rowling 2");
        //CreateAdd.createaudio("Success", "Jay-Z");
        //CreateAdd.readFile("audiofile", );
        //CreateAdd.readFiles("litfile", "audiofile", "vidgamefile", "vidfile");
        //WriteCSV.createlitCSVfile("Adventures Huckleberry Finn,", "Mark Twain");
        /*WriteXML.createaudioXMLfile("NAVUZIMETRO#PT2", "Nav & Metro Boomin");
        
        WriteXML.createvideogameXMLfile("League of Legends,", "Riot Games");
        UpdateXML.updateAuidoXML("Success ", "Jay-Z");
        UpdateXML.updateVideoGameXML("Call of Duty: Modern Warefare 2", "Activison");
        ReadXML.readaudioXML();
        ReadXML.readvideogameXML();*/

        //writeJSON.writeAudioJson(libraryShelf, "Dipset Anthem", AudioMedium.Record, "The Diplomats", "Roc Nation");
        //writeJSON.writeAudioJson(libraryShelf, "Can We Live", AudioMedium.Record, "The Diplomats", "Roc Nation");
        //writeJSON.writeVideoGameJson(libraryShelf, "League of Legends", VideoGameMedium.PC, "Riot Games");
        //writeJSON.writeVideoGameJson(libraryShelf, "Call of Duty: Modern Warefare 2", VideoGameMedium.PS5, "Activison");
        //ReadJson.readAudioJson();
        ReadJson.readVideoGameJson("json/videogameJson.json");

        UpdateJSON.updateVideoGameJson("Call of Duty: Modern Warefare 2", "title", "Call of Duty: Modern Warefare 3");
        ReadJson.readVideoGameJson("json/updatedVidGame.json");
        ReadJson.readAudioJson("json/audioJson.json");
        UpdateJSON.updateAudioJson("Dipset Anthem", "label", "Def Jam");
        ReadJson.readAudioJson("json/updatedAudio.json");

    }
}
