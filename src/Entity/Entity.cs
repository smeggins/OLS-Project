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

    public Entity(string a_libraryCode, string a_title, string a_releaseDate, int a_copiesTotal, int a_copiesAvailable)
    {
        libraryCode = a_libraryCode;
        title = a_title;
        releaseDate = a_releaseDate;
        copiesTotal = a_copiesTotal;
        copiesAvailable = a_copiesAvailable;
    }
    // format: (uniqueItem number)(Generic Type).(medium Enum Numbers separated by periods).(first letter of title)
    // example for movie alien: 1V.0.1.A

    public string libraryCode { get; set; } 
    public string title { get; set; }
    public string releaseDate { get; set; } //format: 11/26/1986 
    public int copiesTotal { get; set; }
    public int copiesAvailable { get; set; }
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

    public List<string> returnPropertiesF(Entity instatiatedEntity)
    {
        // iterates through all properties of class and prints them
        // does not print Lists, handle those in child class
        // requires using System.Reflection;
        Type type = instatiatedEntity.GetType();
        PropertyInfo[] properties = type.GetProperties();

        List<string> propertiesList = new List<string>();
        string workingString;

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
            else
            {
                workingString = property.Name + " = .";
                propertiesList.Add(workingString);
            }
        }
        return propertiesList;
    }

    /// <summary>
    /// accepts a library entity and extracts the name, value pairs of all properties in that object, then returns them as a list of string arrays ( string[propertyName, propertyValue] )
    /// </summary>
    /// <param name="instatiatedEntity">A library entity like a movie or a book</param>
    /// <returns>
    /// List<string[propertyName, propertyValue]>
    /// </returns>
    public List<List<string>> returnProperties(Entity instatiatedEntity)
    {
        // iterates through all properties of class and prints them
        // does not print Lists, handle those in child class
        // requires using System.Reflection;
        Type type = instatiatedEntity.GetType();
        PropertyInfo[] properties = type.GetProperties();

        List<List<string>> propertiesList = new List<List<string>>();

        try
        {
            foreach (PropertyInfo property in properties)
            {
                var propertyValue = property.GetValue(instatiatedEntity, null);
                List<string> propertyInfo = new List<string>();

                if (propertyValue != null)
                {
                    Type propertyType = propertyValue.GetType();

                    // Special logic if a Person (must cast to access class
                    if (propertyType == typeof(Person))
                    {
                        Person person = propertyValue as Person;

                        if (person != null)
                        {
                            propertyInfo.Add(property.Name);
                            propertyInfo.Add(person.fullName);
                        }
                        else
                        {
                            propertyInfo.Add(property.Name);
                            propertyInfo.Add("Error casting to Person");
                        }
                    }
                    else
                    {
                        propertyInfo.Add(property.Name);
                        propertyInfo.Add(propertyValue.ToString());
                    }
                }
                else
                {
                    propertyInfo.Add(property.Name);
                    propertyInfo.Add("");
                }
                propertiesList.Add(propertyInfo);
            }
        }
        catch (Exception exception)
        {
            throw new InvalidCastException("Invalid cast in Entity.returnProperties");
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

    public List<string> returnListF<T>(List<T> list, string Header)
    {
        List<string> propertiesList = new List<string>();
        string workingString;

        workingString = Header + ":";
        propertiesList.Add(workingString);
        workingString = "";

        if (list.Count() == 0)
        {
            workingString = ".";
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (i + 1 == list.Count)
            {
                workingString += list[i] + ".";
            }
            else
            {
                workingString += list[i] + ", ";
            }
        }
        propertiesList.Add(workingString);
        
        return propertiesList;
    }

    public List<string> returnList<T>(List<T> list, string Header)
    {
        List<string> propertyInfo = new List<string>();

        propertyInfo.Add(Header);

        if (list.Count() != 0)
        {
            foreach (var item in list)
            {
                propertyInfo.Add(item.ToString());
            }
        }

        return propertyInfo;
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

    public List<string> returnPersonListF(List<Person> list, string Header)
    {
        List<string> personList = new List<string>();
        string workingString;

        
        workingString = Header + ":";
        personList.Add(workingString);
        workingString = "";
        if (list.Count() == 0)
        {
            workingString = ".";
        }
        for (int i = 0; i < list.Count; i++)
        {
            if (i + 1 == list.Count)
            {
                workingString += list[i].firstName + " " + list[i].lastName + ".";
            }
            else
            {
                workingString += list[i].firstName + " " + list[i].lastName + ", ";
            }
        }
        personList.Add(workingString);
        
        return personList;
    }

    public List<string> returnPersonList(List<Person> list, string Header)
    {
        List<string> propertyInfo = new List<string>();

        propertyInfo.Add(Header);

        if (list.Count() != 0)
        {
            foreach (Person item in list)
            {
                propertyInfo.Add(item.fullName);
            }
        }

        return propertyInfo;
    }
}
