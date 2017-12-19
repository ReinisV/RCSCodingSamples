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
            PersonGreeter greet;
            greet = new PersonGreeter();
            greet.SayHello();
            Console.ReadLine();
        }
    }
}
