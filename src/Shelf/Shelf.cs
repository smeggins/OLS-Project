using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum entityTypes
{
    Audio,
    Liturature,
    Video,
    VideoGame
}
class Shelf
{
    public Shelf() {
        LibraryShelf = new Dictionary<entityTypes, List<Entity>>();
        LibraryShelf.Add(entityTypes.Liturature, new List<Entity>());
        LibraryShelf.Add(entityTypes.Audio, new List<Entity>());
        LibraryShelf.Add(entityTypes.VideoGame, new List<Entity>());
        LibraryShelf.Add(entityTypes.Video, new List<Entity>());
    }

    public Dictionary<entityTypes, List<Entity>> LibraryShelf;

    public enum searchParam
    {
        libraryCode,
        title
    }

    public int search(entityTypes type, searchParam theSearchParam, string identifier)
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

    public void add(entityTypes type, List<Entity> list)
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

    public void add(entityTypes type, Entity item)
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

    public void addInventory(entityTypes type, string title, int amount)
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

    public void removeInventory(entityTypes type, string title, int amount)
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
    public void delete(entityTypes type, searchParam theSearchParam, string identifier)
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

    public void delete(entityTypes type)
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
    public void read(entityTypes type, string title)
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

    public void updateItem(entityTypes type, string title)
    {
        int itemindex = search(type, searchParam.title, title);
        string newTitle = "";
        Object item;

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
