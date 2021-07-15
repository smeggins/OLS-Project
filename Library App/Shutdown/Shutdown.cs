using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class Shutdown
{
    public static void CloseApp(string fileName, Shelf shelf)
    {
        using (Stream s = new FileStream(fileName, FileMode.Create))
        {
            byte[] newLine = Encoding.ASCII.GetBytes("\n");
            foreach (Audio audioItem in shelf.downCastAudio()) {
                foreach (String item in audioItem.GetValues())
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(item);
                    s.Write(bytes);
                    s.Write(newLine);
                }
            }
            //string author = "Mahesh Chand";
            // Convert a C# string to a byte array  
            //byte[] bytes = Encoding.ASCII.GetBytes(author);
            //s.Write(bytes);
            //Console.WriteLine("Here we go");
            //foreach (byte b in bytes)
            //{
            //    Console.WriteLine(b);
            //}
            //s.WriteAsync("This is a test");
            //s.WriteAsync("This is a test2");

            ////byte[] bytes = { 1, 2, 3, 4, 5, 6 };
            ////s.Write(bytes, 0, bytes.Length);

            //Console.WriteLine("Stream Length: {0}", s.Length);
            //Console.WriteLine("positon {0}:", s.Position);

            //s.Position = 0;

            //Console.WriteLine("new Position[0]: {0}", s.ReadByte());
            //Console.WriteLine("new Position[1]: {0}", s.ReadByte());

            //var block = new byte[10];
            //var bytesRead = s.Read(block, 0, bytes.Length);

            //Console.WriteLine("block: {0}", block);

        }
    }        
}
