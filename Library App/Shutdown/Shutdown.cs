using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class Shutdown
{
   

    /// <summary>
    /// calls all necessary methods to close the app.
    /// </summary>
    /// <param name="shelf">the shelf object for the app</param>
    /// <param name="audioFileName">the document name you'll save your shelf to</param>
    /// <param name="videoFileName">the document name you'll save your shelf to</param>
    /// <param name="videoGameFileName">the document name you'll save your shelf to</param>
    /// <param name="lituratureFileName">the document name you'll save your shelf to</param> help
    public static void CloseApp(Shelf shelf, string audioFileName, string videoFileName, string videoGameFileName, string lituratureFileName)
    {
        Save.saveShelf(shelf);
    }
}
