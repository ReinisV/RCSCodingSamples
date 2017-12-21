using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmarterCalculator
{
    class MathParser
    {
        // funkcija, kas saņem lietotāja ievadītu tekstu
        // un saparsē to, veic matematiskās darbības,
        // un atgriež rezultātu
        public int ParseMath(string input)
        {
            // "16+5-4" skaits ir 5 pēdējā simbola pozīcija ir 4
            // "1a" skaits ir 2 pēdējā pozīcija ir 1
            // izveido mainīgo, kurā saglabā ievadīto ciparu tekstu
            string firstEnteredNumber = "";
            string secondEnteredNumber = "";
            char enteredOperation = ' ';
            bool operationFound = false;
            int counter = 0;
            while (counter < input.Length)
            {
                char symbol = input[counter];
                if (symbol == '+')
                {
                    // saglabā operāciju mainīgajā,
                    enteredOperation = symbol;
                    // ieliek karodziņu, ka kad tiks pabeigts
                    // ielasīt nākošo skaitli, operācija ir jāizpilda
                    operationFound = true;
                }
                else
                {
                    // kad cipars ir atrasts,
                    // ja operācija vēl nav bijusi, tad ierakstām vērtību
                    if (operationFound == false)
                    {
                        // pirmajā skaitlī,
                        firstEnteredNumber = firstEnteredNumber + symbol;
                    }
                    else
                    {
                        // ja operācija ir bijusi,
                        // ierakstām vērtību otrajā skaitlī
                        secondEnteredNumber = secondEnteredNumber + symbol;
                    }
                }

                counter = counter + 1;

                // ja iepriekšējā ciklā ir atrasta operācija,
                if (operationFound == true && counter == input.Length)
                {
                    // tad jāveic šī operācija
                    int result = Int32.Parse(firstEnteredNumber) + Int32.Parse(secondEnteredNumber);
                    return result;
                }
            }

            Console.WriteLine("bad input");
            return 0;
        }
    }
}
