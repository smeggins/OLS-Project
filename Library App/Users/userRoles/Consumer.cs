using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Consumer
{
    private string firstName;
    private string lastName;
    private int employeeID;

    public static int consumerCount;

    public Consumer(string firstname, string lastname, int empID)
    {
        consumerCount++;

        firstName = firstname;
        lastName = lastname;
        employeeID = empID;
        Console.WriteLine("New Consumer Created");



    }

    public static void readItems(string filename, string type)
    {
        string jsonData = File.ReadAllText(filename);
        Console.WriteLine("{0} Data: ", type);
        Console.WriteLine(jsonData);
    }
}



public class consumerCreatedUSer
{


    public string firstName;
    public string lastName;
    public int employeeNumber;
}