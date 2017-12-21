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
            MathParser parser;
            parser = new MathParser();

            // paprasīt lietotājam ievadīt ievadi
            Console.WriteLine("please enter darbība");
            string input = Console.ReadLine();

            // izsauc aprēķināšanas funkciju un saglabā rezultātu
            int result = parser.ParseMath(input);
            if (result == 0)
            {
                Console.WriteLine("operation unsucessful");
            }

            // izvada rezultātu uz ekrāna
            Console.WriteLine("your result " + result);
            Console.ReadLine();
        }
    }
}
