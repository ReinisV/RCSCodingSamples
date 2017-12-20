using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmarterCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // izveido kalkulatora objektu

            // paprasīt lietotājam ievadīt ievadi
            Console.WriteLine("please enter darbība");
            string input = Console.ReadLine();
            // "1 + 5 - 4"
            int result;
            int counter = 0;
            while (counter <= 3)
            {
                char symbol = input[counter];
                if (symbol == '+')
                {
                    Console.WriteLine("plus");
                }
                else
                {
                    int number;
                    number = Int32.Parse(symbol.ToString());
                    Console.WriteLine("number " + number);

                }

                counter = counter + 1;
            }

            Console.ReadLine();
        }
    }
}
