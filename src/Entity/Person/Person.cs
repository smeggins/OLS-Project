using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Person
{
    public string firstName { get; set; }
    public string lastName { get; set; }
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
    }

    public void addProject(Entity item, Format format)
    {
        if (format == Format.Audio)
        {
            Audio newItem = (Audio)item;
            this.audioProjects.Add(newItem);
        }
        else if (format == Format.Liturature)
        {
            Liturature newItem = (Liturature)item;
            this.literatureProjects.Add(newItem);
        }
        else if (format == Format.Video)
        {
            Video newItem = (Video)item;
            this.videoProjects.Add(newItem);
        }
        else if (format == Format.VideoGame)
        {
            VideoGame newItem = (VideoGame)item;
            this.videoGameProjects.Add(newItem);
        }
    }

    public void addAudio(List<Entity> items, Format format)
    {
        if (format == Format.Audio)
        {
            foreach (var item in items)
            {
                Audio newItem = (Audio)item;
                this.audioProjects.Add(newItem);
            }
        }
        else if (format == Format.Liturature)
        {
            foreach (var item in items)
            {
                Liturature newItem = (Liturature)item;
                this.literatureProjects.Add(newItem);
            }
        }
        else if (format == Format.Video)
        {
            
            foreach (var item in items)
            {
                Video newItem = (Video)item;
                this.videoProjects.Add(newItem);
            }
        }
        else if (format == Format.VideoGame)
        {
            
            foreach (var item in items)
            {
                VideoGame newItem = (VideoGame)item;
                this.videoGameProjects.Add(newItem);
            }
        }
    }

}
