using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Entity 
{
    public Entity(string a_title)
    {
        uniqueItems += 1;
        libraryCode += uniqueItems;
        title = a_title;
    }
    // format: (uniqueItem number)(Generic Type).(medium Enum Numbers separated by periods).(first letter of title)
    // example for movie alien: 1V.0.1.A
    public string libraryCode { get; set; } 
    public string title { get; set; }
    public string releaseDate { get; set; } //format: 11/26/1986 
    List<Entity> preceededBy;
    List<Entity> followedBy;
    private static int uniqueItems = 0;

    public void printProperties(Entity instatiatedEntity)
    {
        // iterates through all properties of class and prints them
        // does not print Lists, handle those in child class
        // requires using System.Reflection;
        Type type = instatiatedEntity.GetType();
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            var propertyValue = property.GetValue(instatiatedEntity, null);
            if (propertyValue != null)
            {
                Type propertyType = propertyValue.GetType();

                // used to handle default/empty entry
                if (propertyType == "a".GetType() && propertyValue == "") { }
                else if (propertyType == 1.GetType() && (int)propertyValue == 0) { }
                else
                {
                    Console.WriteLine("{0} = {1}", property.Name, propertyValue);
                }
            }
        }
    }

    public void printList<T>(List<T> list, string Header)
    {
        if (list.Count() != 0)
            Console.WriteLine(Header + ": ");
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
