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

            Console.WriteLine("TestLoad.testreadXmlToVideo(): " + TestLoad.testreadXmlToVideo());
            Console.WriteLine("TestLoad.testreadXmlToLiturature(): " + TestLoad.testreadXmlToLiturature());
            Console.WriteLine("TestUpdate.testUpdate(): " + TestUpdate.testUpdate());
        }
    }
}
