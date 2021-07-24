using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Shelf
{

    //StreamWriter sw = new StreamWriter("shelfList.txt");
    //FileStream fs = new FileStream("shelfList", FileMode.Open);

    //string fileName = "shelfList.txt";
    public Dictionary<Format, List<Entity>> LibraryShelf;
    public Dictionary<string, List<Entity>> titleSearchContainer;
    public Shelf() {
        LibraryShelf = new Dictionary<Format, List<Entity>>();
        LibraryShelf.Add(Format.Liturature, new List<Entity>());
        LibraryShelf.Add(Format.Audio, new List<Entity>());
        LibraryShelf.Add(Format.VideoGame, new List<Entity>());
        LibraryShelf.Add(Format.Video, new List<Entity>());
    }

    public enum searchParam
    {
        libraryCode,
        title
    }

    public List<Audio> downCastAudio()
    {
        return LibraryShelf[Format.Audio].Cast<Audio>().ToList();
    }
    public List<Liturature> downCastLiturature()
    {
        return LibraryShelf[Format.Liturature].Cast<Liturature>().ToList();
    }
    public List<VideoGame> downCastVideoGame()
    {
        return LibraryShelf[Format.VideoGame].Cast<VideoGame>().ToList();
    }
    public List<Video> downCastVideo()
    {
        return LibraryShelf[Format.Video].Cast<Video>().ToList();
    }

    public int search(Format type, searchParam theSearchParam, string identifier)
    {

        if (theSearchParam == searchParam.libraryCode)
        {
            for (int i = 0; i < LibraryShelf[type].Count(); i++)
            {
                if (LibraryShelf[type][i].libraryCode == identifier)
                {
                    return i;
                }
            } 
        }
        else if (theSearchParam == searchParam.title)
        {
            for (int i = 0; i < LibraryShelf[type].Count(); i++)
            {
                if (LibraryShelf[type][i].title == identifier)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public void addToList(List<Entity> items)
    {

        using (StreamWriter sw = new StreamWriter("shelfList.txt"))
        {
            foreach (Entity value in items)

            { 
                sw.WriteLine("Item Title: " + value.title);
            }
        }

        Console.WriteLine("yooooo");

        /*foreach(Entity value in items)
        {

            sw.Write("Item Title" + value.title);
        }*/

        //File.WriteAllText(fileName, "test writng");

        /*using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.Write("Item Title");
        }*/

        //sw.Write("Item Title");
    }


    public void add(Format type, List<Entity> list)
    {
        for (int i = 0; i < list.Count(); i++)
        {
            if (search(type,searchParam.libraryCode, list[i].libraryCode) == -1) {
                LibraryShelf[type].Add(list[i]);
            }
            else
            {
                Console.WriteLine(list[i].title + "already added. try addInventory() to add more items " +
                    "to the stock, or update() to update an items information");
            }
        }
    }

    public void add(Format type, Entity item)
    {
        if (search(type, searchParam.libraryCode, item.libraryCode) == -1)
        {
            LibraryShelf[type].Add(item);
        }
        else
        {
            Console.WriteLine(item.title + "already added. try addInventory() to add more copies " +
                "to the item.");
        }
    }

    public void addInventory(Format type, string title, int amount)
    {
        int itemindex = search(type, searchParam.title, title);
        if (itemindex != -1)
        {
            LibraryShelf[type][itemindex].copiesTotal += amount;
            LibraryShelf[type][itemindex].copiesAvailable += amount;
        }
        else
        {
            Console.WriteLine(title + " has not been added yet.");
        }        
    }

    public void removeInventory(Format type, string title, int amount)
    {
        int itemindex = search(type, searchParam.title, title);
        if (itemindex != -1)
        {
            LibraryShelf[type][itemindex].copiesTotal -= amount;
            LibraryShelf[type][itemindex].copiesAvailable -= amount;
        }
        else
        {
            Console.WriteLine(title + " has not been added yet.");
        }
    }
    // delete item
    public void delete(Format type, searchParam theSearchParam, string identifier)
    {
        int itemIndex = search(type, theSearchParam, identifier);
        if (itemIndex != -1)
        {
            LibraryShelf[type].RemoveAt(itemIndex);
            Console.WriteLine(identifier + " Deleted.");
        }
        else
        {
            Console.WriteLine("Delete failed, item not found.");
        }
    }

    public void delete(Format type)
    {
        Console.WriteLine("You are about to delete the the " + type + " category and all items containd within.");
        Console.WriteLine("Are you sure you want to delete " + type + ": 'Y/N'");
        string answer = "";
        while (true)
        {
            answer = Console.ReadLine();
            if (answer == "Y")
            {
                LibraryShelf.Remove(type);
                Console.WriteLine(type + " Deleted...");
                break;
            }
            else if (answer == "N")
            {
                Console.WriteLine("Action Aborted");
                break;
            }
            else
            {
                Console.WriteLine("'Y' to delete " + type + " or 'N' to take no action");
            }
        }
    }

    // return details of specific item
    public void read(Format type, string title)
    {
        int itemindex = search(type, searchParam.title, title);
        if (itemindex != -1)
        {
            LibraryShelf[type][itemindex].print();
        }
        else
        {
            Console.WriteLine(title + " Could not be found.");
        }
    }


    public void updateItem(Format type, string title)
    {
        int itemindex = search(type, searchParam.title, title);
        string newTitle = "";
        Object item;

        ///checks if the item is there
        if (itemindex != -1)
        {
            item = LibraryShelf[type][itemindex].title ;
            newTitle = Console.ReadLine();
            item = newTitle;
        }
        else
        {
            Console.WriteLine(title + " Could not be found. Please enter a valid title");
        }
    } 
}
