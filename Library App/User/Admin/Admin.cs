using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Admin : Editor
{
    public Admin(Person a_user, Position a_position) : base(a_user, a_position) { }

    protected override void instantiateRole()
    {
        role = Role.Admin;
    }

    /// <summary>
    /// retrieves the index of the searched user
    /// </summary>
    /// <param name="fullName">users full name (ie "Jim Jam")</param>
    /// <returns>the index of the user in the User.users List or null</returns>
    public int? userIndex(string fullName)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].user.fullName == fullName)
            {
                return i;
            }
        }

        return null;
    }

    /// <summary>
    /// checks if a user with this name exists in the system
    /// </summary>
    /// <param name="fullName">users full name (ie "Jim Jam")</param>
    /// <returns>true if the user is found</returns>
    public bool userExists(string fullName)
    {
        return userIndex(fullName) != null;
    }

    /// <summary>
    /// adds a new user to the User.users list
    /// </summary>
    /// <param name="a_user">and instantiated Person object</param>
    /// <param name="a_position">the position they occupy</param>
    /// <param name="role">the level of permissions the user has</param>
    public void addUser(Person a_user, Position a_position, Role role)
    {
        if (role == Role.Consumer)
        {
            new Consumer(a_user, a_position);
        }
        else if(role == Role.Editor)
        {
            new Editor(a_user, a_position);
        }
        else if (role == Role.Admin)
        {
            new Admin(a_user, a_position);
        }
    }

    /// <summary>
    /// updates the users permissions
    /// </summary>
    /// <param name="fullName">users full name (ie "Jim Jam")</param>
    /// <param name="newRole">the new level of permissions</param>
    public void changeRole(string fullName, Role newRole)
    {
        int? user = userIndex(fullName);

        if (user != null)
        {
            int i = (int)user;
            Person tempP = users[i].user;
            Position tempPos = users[i].position;
            users.RemoveAt(i);
            if (newRole == Role.Consumer)
            {
                new Consumer(tempP, tempPos);
            }
            else if (newRole == Role.Editor)
            {
                new Editor(tempP, tempPos);
            }
            else if (newRole == Role.Admin)
            {
                new Admin(tempP, tempPos);
            }
        }
    }

    /// <summary>
    /// updates the users position within the company
    /// </summary>
    /// <param name="fullName">users full name (ie "Jim Jam")</param>
    /// <param name="newPos">the users new position</param>
    public void updatePosition(string fullName, Position newPos)
    {
        int? index = userIndex(fullName);

        if (index != null)
        {
            users[(int)index].position = newPos;
        }
    }

    /// <summary>
    /// removes a user from the system
    /// </summary>
    /// <param name="fullName">users full name (ie "Jim Jam")</param>
    public void deleteUser(string fullName)
    {
        int? index = userIndex(fullName);

        if (index != null)
        {
            users.Remove(users[(int)index]);
        }
    }

    /// <summary>
    /// saves the current shelf as xml or Json
    /// </summary>
    /// <param name="shelf">the working shelf</param>
    /// <param name="saveType">json or xml</param>
    /// <param name="fileLocationJsonOrXmlAudio">the json location or the xml audio file location</param>
    /// <param name="fileLocationVideo">the xml video file location</param>
    /// <param name="fileLocationVideogame">the xml videogame file location</param>
    /// <param name="fileLocationLiturature">the xml liturature file location</param>
    public void saveShelf(Shelf shelf,Save.SaveOptions saveType, string fileLocationJsonOrXmlAudio, string fileLocationVideo="", string fileLocationVideogame="", string fileLocationLiturature="")
    {
        Save.saveAs(shelf, saveType, fileLocationJsonOrXmlAudio, fileLocationVideo, fileLocationVideogame, fileLocationLiturature);
    }

    /// <summary>
    /// Loads shelf and replaces working shelf
    /// </summary>
    /// <param name="fileLocation">location of shelf Json without postfix (ie fileLocation/thefile)</param>
    public void loadShelf(string fileLocation)
    {
        Load.loadJson(fileLocation);
    }

    /// <summary>
    /// creates a back-up of shelf.
    /// </summary>
    /// <param name="shelf">working shelf</param>
    public void backupShelf(Shelf shelf)
    {
        Backup.createBackup(shelf);
    }

    
    
    
    
    
    
    
    // There is no load back-up As that was part of my lab partners project that they never did so i didn't
    // bother adding that or set backup as default as there would be no way of testing and i don't want to
    // start coding all the stuff that they never contributed to the project.
}