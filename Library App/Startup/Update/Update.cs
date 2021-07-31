using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public static class Update
{
    /// <summary>
    /// instantiates an update shelf from an xml file,
    /// if the shelf contains a new entity it is appended to the current shelf
    /// if an entity from the update shelf already exists but is different, replace the current entity with the updated version
    /// </summary>
    /// <param name="shelf">current working shelf</param>
    /// <param name="audioFileLocation">location of update shelf xml file without file extensions (ie test/audio)</param>
    /// <param name="videoFileLocation">location of update shelf xml file without file extensions (ie test/video)</param>
    /// <param name="videoGameFileLocation">location of update shelf xml file without file extensions (ie test/videoGame)</param>
    /// <param name="lituratureFileLocation">location of update shelf xml file without file extensions (ie test/liturature)</param>
    /// <returns>the new working shelf with updated values</returns>
    public static Shelf updateXml(  Shelf shelf, string audioFileLocation, string videoFileLocation,
                                    string videoGameFileLocation, string lituratureFileLocation)
    {
        // Note: I should probably abstract the foreach loops but i've decided to leave it considering there are only 2 instances of it and it wouldn't 
        // conceivably scale past 4. Also no one else went that far and i don't feel like doing it :)

        Shelf updateShelf = Load.loadXml(audioFileLocation, videoFileLocation, videoGameFileLocation, lituratureFileLocation);
        Shelf returnShelf = shelf;

        foreach (Entity entity in updateShelf.LibraryShelf[Format.Video])
        {
            // if the entity already exists in the working shelf
            if (returnShelf.LibraryShelf[Format.Video].Any(e => e.title == entity.title))
            {
                for (int i = 0; i < returnShelf.LibraryShelf[Format.Video].Count; i++)
                {
                    // get the location of that entity and replace it with the updated version
                    if (returnShelf.LibraryShelf[Format.Video][i].title == entity.title)
                    {
                        returnShelf.LibraryShelf[Format.Video][i] = entity;
                    }
                }
            }
            // else add the new entity to the returnShelf
            else
            {
                returnShelf.LibraryShelf[Format.Video].Add(entity);
            }
        }

        foreach (Entity entity in updateShelf.LibraryShelf[Format.Liturature])
        {
            // if the entity already exists in the working shelf
            if (returnShelf.LibraryShelf[Format.Liturature].Any(e => e.title == entity.title))
            {
                for (int i = 0; i < returnShelf.LibraryShelf[Format.Liturature].Count; i++)
                {
                    // get the location of that entity and replace it with the updated version
                    if (returnShelf.LibraryShelf[Format.Liturature][i].title == entity.title)
                    {
                        returnShelf.LibraryShelf[Format.Liturature][i] = entity;
                    }
                }
            }
            // else add the new entity to the returnShelf
            else
            {
                returnShelf.LibraryShelf[Format.Liturature].Add(entity);
            }
        }

        return returnShelf;
    }
}
