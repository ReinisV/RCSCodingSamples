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
            // TODO izpētīt prezentācijas slaidus un piemēra koda gabalus, kas apraksta
            // TODO for ciklu un aizvietot while ciklu ar for ciklu
            
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                // TODO pievienot nosacījumus šim ifam, kas ļautu piefiksēt arī citas darbības
                if (symbol == '+' || symbol == '-')
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

                // ja iepriekšējā ciklā ir atrasta operācija,
                bool endOfInputReached = i == input.Length;
                if (operationFound == true && endOfInputReached == true)
                {
                    // TODO izveidot vairākus izpildes zarus, kas pārbaud iepriekš saglabāto operācijas tipu,
                    // TODO un veic pareizo darbību
                    // tad jāveic šī operācija
                    if (enteredOperation == )
                    int result = Int32.Parse(firstEnteredNumber) - Int32.Parse(secondEnteredNumber);
                    return result;
                }
            }

            throw new Exception("Invalid mathematical izteiksme entered");
        }
    }
}
