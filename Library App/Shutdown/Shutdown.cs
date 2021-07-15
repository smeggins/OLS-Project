using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class Shutdown
{
    public static void CloseApp(Shelf shelf, string audioFileName, string videoFileName, string videoGameFileName, string lituratureFileName)
    {
        using (Stream s = new FileStream(audioFileName, FileMode.Create))
        {
            byte[] newLine = Encoding.ASCII.GetBytes("\n");
            byte[] separationOfItemsLine = Encoding.ASCII.GetBytes("\n//\n\n");
            foreach (Audio audioItem in shelf.downCastAudio()) {
                foreach (String item in audioItem.GetValues())
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(item);
                    s.Write(bytes);
                    s.Write(newLine);
                }
                s.Write(separationOfItemsLine);
            }
        }

        using (Stream s = new FileStream(videoFileName, FileMode.Create))
        {
            byte[] newLine = Encoding.ASCII.GetBytes("\n");
            byte[] separationOfItemsLine = Encoding.ASCII.GetBytes("\n//\n\n");
            foreach (Video videoItem in shelf.downCastVideo())
            {
                foreach (String item in videoItem.GetValues())
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(item);
                    s.Write(bytes);
                    s.Write(newLine);
                }
                s.Write(separationOfItemsLine);
            }
        }

        using (Stream s = new FileStream(videoGameFileName, FileMode.Create))
        {
            byte[] newLine = Encoding.ASCII.GetBytes("\n");
            byte[] separationOfItemsLine = Encoding.ASCII.GetBytes("\n//\n\n");
            foreach (VideoGame videoGameItem in shelf.downCastVideoGame())
            {
                foreach (String item in videoGameItem.GetValues())
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(item);
                    s.Write(bytes);
                    s.Write(newLine);
                }
                s.Write(separationOfItemsLine);
            }
        }

        using (Stream s = new FileStream(lituratureFileName, FileMode.Create))
        {
            byte[] newLine = Encoding.ASCII.GetBytes("\n");
            byte[] separationOfItemsLine = Encoding.ASCII.GetBytes("\n//\n\n");
            foreach (Liturature lituratureItem in shelf.downCastLiturature())
            {
                foreach (String item in lituratureItem.GetValues())
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(item);
                    s.Write(bytes);
                    s.Write(newLine);
                }
                s.Write(separationOfItemsLine);
            }
        }


    }
}
