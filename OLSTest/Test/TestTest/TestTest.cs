using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TestTest
{
    public static bool testCompareListsofLists()
    {
        List<List<string>> list1 = new List<List<string>>();
        List<List<string>> list2 = new List<List<string>>();

        list1.Add(new List<string>() {"a", "b", "c"});
        list1.Add(new List<string>() { "d", "e", "f" });

        list2.Add(new List<string>() { "d", "g", "f" });
        list2.Add(new List<string>() { "a", "b", "c" });
        

        return !Test.compareListsofLists(list1, list2);
    }
}
