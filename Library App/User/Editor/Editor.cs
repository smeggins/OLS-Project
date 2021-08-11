using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Editor : User
{
    public Editor(Person a_user, Position a_position) : base(a_user, a_position) { }

    protected override void instantiateRole()
    {
        role = Role.Editor;
    }

    /// <summary>
    /// Adds a single entity to the shelf
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="type">The type of the item to search</param>
    /// <param name="item">item to add</param>
    public void addItemToShelf(Shelf shelf, Format type, Entity item)
    {
        shelf.add(type, item);
    }

    /// <summary>
    /// Adds a list of entities to the shelf
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="type">The type of the item to search</param>
    /// <param name="list">the list of items to be added</param>
    public void addItemsToShelf(Shelf shelf, Format type, List<Entity> list)
    {
        shelf.add(type, list);
    }

    //NOTE: Update Entity was one of the project parts Abbe was supposed to implement during the group portion of
    // of the project. he never did. Therefore, I added an update method that ties into the code he wrote but
    // the code just causes the app to crash so i've left it commented out.

    //public void updateShelfItem(Shelf shelf, Format type, string title)
    //{
    //    shelf.updateItem(type, title);
    //}

    /// <summary>
    /// deletes and item from the shelf
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="type">The type of the item to search</param>
    /// <param name="theSearchParam">whether searching by title or library code</param>
    /// <param name="identifier">Title or library code of the item to be deleted</param>
    public void deleteShelfItem(Shelf shelf, Format type, Shelf.searchParam theSearchParam, string identifier)
    {
        shelf.delete(type, theSearchParam, identifier);
    }

    /// <summary>
    /// deletes entire category of items from shelf
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="type">The type of the item to search</param>
    /// <param name="noCheck">skip safty check before deleting entire category from shelf</param>
    public void deleteShelfCategory(Shelf shelf, Format type, bool noCheck = false)
    {
        shelf.delete(type, noCheck);
    }

    /// <summary>
    /// increases the quantity of the specific item availible to be rented out
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="type">The type of the item to search</param>
    /// <param name="title">title of item to increase quanity</param>
    /// <param name="amount">amount you want to increas quantity by</param>
    public void increaseAvailible(Shelf shelf, Format type, string title, int amount)
    {
        shelf.addInventory(type, title, amount);
    }

    /// <summary>
    /// decreases the quantity of the specific item availible to be rented out
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="type">The type of the item to search</param>
    /// <param name="title">title of item to decreases quanity</param>
    /// <param name="amount">amount you want to decreases quantity by</param>
    public void decreaseAvailible(Shelf shelf, Format type, string title, int amount)
    {
        shelf.removeInventory(type, title, amount);
    }
}
