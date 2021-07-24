using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Backup
{
    public static bool backupMode { get; set; } = false;

    /// <summary>
    /// returns the current date as dd-mm-yyyy
    /// Used to assign date prefix to backup name
    /// </summary>
    /// <returns>formattad current date as a string</returns>
    private static String getDate()
    {
        return DateTime.Now.ToString("dd-MM-yyyy");
    }

    /// <summary>
    /// Saves the current shelf to a backup folder with the current date prefixed onto its filename
    /// </summary>
    /// <param name="shelf">the current shelf</param>
    /// <param name="audioFileName">the basic f</param>
    /// <param name="videoFileName"></param>
    /// <param name="videoGameFileName"></param>
    /// <param name="lituratureFileName"></param>
    public static void createBackup(Shelf shelf)
    {
        Save.saveShelfToDocumentCSV(shelf, "backups/" + getDate() + "-audio", "backups/" + getDate() + "-video", "backups/" + getDate() + "-videoGame", "backups/" + getDate() + "-liturature");
    }

    /// <summary>
    /// If the current shelf is loaded from a back-up, save the current shelf as our default working shelf
    /// </summary>
    /// <param name="shelf">the shelf loaded from a back-up</param>
    public static void saveAsDefault(Shelf shelf)
    {
        if (backupMode == true)
        {
            Save.saveShelf(shelf);
            backupMode = false;
        }
    }
}
