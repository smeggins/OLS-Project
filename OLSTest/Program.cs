﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Shelf libraryShelf = TestShelf.createTestShelf();

            //TestSave.testXml(libraryShelf);
            Console.WriteLine(TestLoad.testreadXmlToVideo());
            //Console.WriteLine( TestTest.testCompareListsofLists());
        }
    }
}
