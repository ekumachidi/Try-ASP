using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramControl
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 7)
                {
                    Console.WriteLine(i);
                    Console.WriteLine("Found seven");
                    break;
                }

            }
            Console.ReadLine();
        }
    }
}
