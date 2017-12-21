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
            greet.Name = "Jānis";
            greet.HelloText = "Hello world!";
            greet.SayHello();
            
            PersonGreeter seaGreet;
            seaGreet = new PersonGreeter();
            seaGreet.Name = "Pēteris";
            seaGreet.HelloText = "Ahoy world!";
            seaGreet.SayHello();

            Console.ReadLine();
        }
    }
}
