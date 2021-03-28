using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenFarmerGrainGame
{
    class Info
    {
        public void DisplayInfo(string assignment)
        {
            string aHeader = "**************************************************************************";
            Console.WriteLine(aHeader);
            Console.WriteLine("Name:\t\tShanell Spann");
            Console.WriteLine("Course:\t\tITDEV-115-200");
            Console.WriteLine("Instructor:\tMr Menzl");
            Console.WriteLine("Assignment:\t" + assignment);
            Console.WriteLine("Date:\t\t" + System.DateTime.Today.ToShortDateString());
            Console.WriteLine(aHeader);
        }
    }
}

