using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLS.src;

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

    public string add(entityTypes type, List<Entity> list)
    {
        for (int i = 0; i < list.Count(); i++)
        {
            if (search(type,searchParam.libraryCode, list[i].libraryCode) == -1) {
                LibraryShelf[type].Add(list[i]);
            }
            else
            {
                return list[i].title + "already added. try addInventory() to add more items " +
                    "to the stock, or update() to update an items information";
            }
        }

        return "Your item has been added!";
    }

    public string add(entityTypes type, Entity item)
    {
        if (search(type, searchParam.libraryCode, item.libraryCode) == -1)
        {
            LibraryShelf[type].Add(item);
        }
        else
        {
            return item.title + "already added. try addInventory() to add more copies " +
                "to the item.";
        }

        return "Your item has been added";
    }

    public string addInventory(entityTypes type, string title, int amount)
    {
        int itemindex = search(type, searchParam.title, title);
        if (itemindex != -1)
        {
            LibraryShelf[type][itemindex].copiesTotal += amount;
            LibraryShelf[type][itemindex].copiesAvailable += amount;
        }
        else
        {
            return title + " has not been added yet.";
        }

        return title + " has been added!";
    }

    public string removeInventory(entityTypes type, string title, int amount)
    {
        int itemindex = search(type, searchParam.title, title);
        if (itemindex != -1)
        {
            LibraryShelf[type][itemindex].copiesTotal -= amount;
            LibraryShelf[type][itemindex].copiesAvailable -= amount;

            return "library Code search: The index of the sword of truth book is: " + title;
        }
        else
        {
            return title + " has not been added yet.";
        }


        //return "library Code search: The index of the sword of truth book is: " + title;


    }
    // delete item
    public string delete(entityTypes type, searchParam theSearchParam, string identifier)
    {
        int itemIndex = search(type, theSearchParam, identifier);
        if (itemIndex != -1)
        {
            LibraryShelf[type].RemoveAt(itemIndex);
            return identifier + " Deleted.";
        }
        else
        {
           return "Delete failed, item not found.";
        }


    }

    public string delete(entityTypes type)
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

        return "Item deleted";
    }

    // return details of specific item
    public string read(entityTypes type, string title)
    {
        int itemindex = search(type, searchParam.title, title);
        if (itemindex != -1)
        {
            return LibraryShelf[type][itemindex].ToString();

        }
        else
        {
            return title + " Could not be found." ;
        }
    }

    public string updateItem(entityTypes type, string title, string newTitle)
    {
        int itemindex = search(type, searchParam.title, title);
       
        Object item;

        if (itemindex != -1)
        {
            item = LibraryShelf[type][itemindex].title ;
            
            item = newTitle;
            return LibraryShelf[type][itemindex].title + "has updated to " + newTitle;
        }
        else
        {
            return title + " Could not be found. Please enter a valid title";
        }

    } 


}
