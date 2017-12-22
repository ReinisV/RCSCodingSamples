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
            // TODO izlasīt materiālus par  try/catch un uztaisīt tā,
            // TODO lai aplikācija nenokrīt, kad ievadīta nevalīda matemātiskā darbība
            int result = parser.ParseMath(input);

            // izvada rezultātu uz ekrāna
            Console.WriteLine("your result " + result);
            Console.ReadLine();
        }
    }
}
