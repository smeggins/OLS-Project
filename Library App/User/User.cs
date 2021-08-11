using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class User
{
    public Person user;
    public Role role;
    public Position position;

    public static List<User> users = new List<User>();

    public User(Person a_user, Position a_position)
    {
        user = a_user;
        position = a_position;
        instantiateRole();

        users.Add(this);
    }

    /// <summary>
    /// Instanitates the permission role of the user when created
    /// </summary>
    protected abstract void instantiateRole();

    /// <summary>
    /// find the index of a shelf item by title or library code
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="format">The format of the item to search</param>
    /// <param name="searchParam">whether searching by title or library code</param>
    /// <param name="titleOrLCode">the library code or item title</param>
    /// <returns></returns>
    public int search(Shelf shelf, Format format, Shelf.searchParam searchParam, string titleOrLCode)
    {
        return shelf.search(format, searchParam, titleOrLCode); 
    }

    /// <summary>
    /// prints all the properties of the searched shelf item
    /// </summary>
    /// <param name="shelf">the current working shelf</param>
    /// <param name="format">The format of the item to search</param>
    /// <param name="title">item title</param>
    public void readEntity(Shelf shelf, Format format, string title)
    {
        shelf.read(format, title);
    }
}
