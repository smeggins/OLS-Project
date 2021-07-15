using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Entity 
{
    public Entity(string a_title)
    {
        uniqueItems += 1;
        libraryCode += uniqueItems;
        title = a_title;
        copiesTotal = 1;
        copiesAvailable = 1;
    }
    // format: (uniqueItem number)(Generic Type).(medium Enum Numbers separated by periods).(first letter of title)
    // example for movie alien: 1V.0.1.A
   
    public string libraryCode { get; set; } 
    public string title { get; set; }
    public string releaseDate { get; set; } //format: 11/26/1986 
    public int copiesTotal { get; set; }
    public int copiesAvailable { get; set; }
    List<Entity> preceededBy;
    List<Entity> followedBy;
    private static int uniqueItems = 0;

    public abstract void print();
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

    public List<String> returnProperties(Entity instatiatedEntity)
    {
        // iterates through all properties of class and prints them
        // does not print Lists, handle those in child class
        // requires using System.Reflection;
        Type type = instatiatedEntity.GetType();
        PropertyInfo[] properties = type.GetProperties();

        List<String> propertiesList = new List<string>();
        String workingString;

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
                    workingString = property.Name + " = " + propertyValue;
                    propertiesList.Add(workingString);
                }
            }
        }
        return propertiesList;
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

    public List<String> returnList<T>(List<T> list, string Header)
    {
        List<String> propertiesList = new List<string>();
        String workingString;

        if (list.Count() != 0)
        {
            workingString = Header + ":";
            propertiesList.Add(workingString);
            workingString = "";

            for (int i = 0; i < list.Count; i++)
            {
                if (i != list.Count)
                {
                    workingString += list[i] + ", ";
                }
                else
                {
                    workingString += list[i] + ".";
                }
            }
            //foreach (var item in list)
            //{
            //    workingString += item + ", ";
               
            //    Console.WriteLine(item);
            //}
            propertiesList.Add(workingString);
        }
        return propertiesList;
    }

    public void printPersonList(List<Person> list, string Header)
    {
        if (list.Count() != 0)
            Console.WriteLine(Header + ": ");
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.firstName + " " + item.lastName);
            }
        }
    }

    public List<String> returnPersonList(List<Person> list, string Header)
    {
        List<String> personList = new List<string>();
        String workingString;

        if (list.Count() != 0)
        {
            workingString = Header + ":";
            personList.Add(workingString);
            workingString = "";

            for (int i = 0; i < list.Count; i++)
            {
                if (i != list.Count)
                {
                    workingString += list[i].firstName + " " + list[i].lastName + ", ";
                }
                else
                {
                    workingString += list[i].firstName + " " + list[i].lastName + ".";
                }
            }
            personList.Add(workingString);
        }
        return personList;
    }
}
