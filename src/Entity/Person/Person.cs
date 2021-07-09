using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Person
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fullName { get; set; }
    public string ID { get; set; }
    public List<Audio> audioProjects;
    public List<Liturature> literatureProjects;
    public List<Video> videoProjects;
    public List<VideoGame> videoGameProjects;
    public static int numberOfPeople;

    public Person (string a_firstName, string a_lastName)
    {
        firstName = a_firstName;
        lastName = a_lastName;
        ++numberOfPeople;
        ID = "" + firstName[0] + lastName[0] + numberOfPeople;
        fullName = firstName + " " + lastName;
    }

    public string addProject(Entity item, Format format)
    {
        string successMsg = "Item Sucessfully Added";
        string failureMsg = "Item NOT Added, please check that format and item type match and try again...";

        if (format == Format.Audio)
        {
            try
            {
                Audio newItem = (Audio)item;
                this.audioProjects.Add(newItem);
                return successMsg;
            }
            catch 
            {
                return failureMsg;
            }
        }
        else if (format == Format.Liturature)
        {
            try
            {
                Liturature newItem = (Liturature)item;
                this.literatureProjects.Add(newItem);
                return successMsg;
            }
            catch
            {
                return failureMsg;
            }
        }
        else if (format == Format.Video)
        {
            try
            {
                Video newItem = (Video)item;
                this.videoProjects.Add(newItem);
                return successMsg;
            }
            catch
            {
                return failureMsg;
            }
        }
        else if (format == Format.VideoGame)
        {
            try
            {
                VideoGame newItem = (VideoGame)item;
                this.videoGameProjects.Add(newItem);
                return successMsg;
            }
            catch
            {
                return failureMsg;
            }
        }
        else
        {
            return "trying to add a format that has not been initialized yet";
        }
    }

}
