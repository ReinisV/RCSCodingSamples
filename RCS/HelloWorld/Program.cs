using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string goodBye = "good bye Reinis";
            string myName;
            myName = Console.ReadLine();
            Console.WriteLine("Hello, world!" + myName);
            Console.WriteLine(goodBye);
            Console.ReadLine();
        }
    }
}
