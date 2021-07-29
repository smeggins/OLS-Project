using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public static class Update
{
    
    public static Shelf updateXml(  Shelf shelf, string audioFileLocation, string videoFileLocation,
                                    string videoGameFileLocation, string lituratureFileLocation)
    {
        Shelf updateShelf = Load.loadXml(audioFileLocation, videoFileLocation, videoGameFileLocation, lituratureFileLocation);
        Shelf returnShelf = shelf;

        foreach (Entity entity in updateShelf.LibraryShelf[Format.Video])
        {
            if (returnShelf.LibraryShelf[Format.Video].Any(e => e.title == entity.title))
            {
                for (int i = 0; i < returnShelf.LibraryShelf[Format.Video].Count; i++)
                {
                    if (returnShelf.LibraryShelf[Format.Video][i].title == entity.title)
                    {
                        returnShelf.LibraryShelf[Format.Video][i] = entity;
                    }
                }
            }
            else
            {
                returnShelf.LibraryShelf[Format.Video].Add(entity);
            }
        }

        foreach (Entity entity in updateShelf.LibraryShelf[Format.Liturature])
        {
            if (returnShelf.LibraryShelf[Format.Liturature].Any(e => e.title == entity.title))
            {
                for (int i = 0; i < returnShelf.LibraryShelf[Format.Liturature].Count; i++)
                {
                    if (returnShelf.LibraryShelf[Format.Liturature][i].title == entity.title)
                    {
                        returnShelf.LibraryShelf[Format.Liturature][i] = entity;
                    }
                }
            }
            else
            {
                returnShelf.LibraryShelf[Format.Liturature].Add(entity);
            }
        }

        return returnShelf;
    }
}
