using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReadJson
{

    public static void readAudioJson(string filename)
    {
       

        string jsonData = File.ReadAllText(filename);
        Console.WriteLine("Audio Data: ");
        Console.WriteLine(jsonData);

    } 

    public static void readVideoGameJson(string filename)
    {
       
        string jsonData = File.ReadAllText(filename);
        Console.WriteLine("Video Game Data: ");
        Console.WriteLine(jsonData);
    }

}

