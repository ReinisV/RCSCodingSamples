using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // izveido kalkulēšanas objektu
            var calc = new Calculations();

            // paprasīt lietotājam vērtību
            int firstNumber = calc.AskUserForNumber();

            // paprasīt lietotājam otru vērtību
            int secondNumber = calc.AskUserForNumber();

            // saskaita
            int result = firstNumber / secondNumber;
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
