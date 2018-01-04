using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsFromSymbolsLookup
{
    class Program
    {
        static void Main(string[] args)
        {
            // paprasīt lietotājam ievadīt tekstu
            Console.WriteLine("Please write any combinations of letters, program will generate all possible words from those letters");
            string inputAsText = Console.ReadLine();

            // iegūt no ievadītā teksta visus unikālos burtus
            // izveidot mainīgo, kurā glabāsim tekstu, kas saturēs unikālos burtus
            var UniqueLetters = inputAsText.Distinct().ToArray();
            
            // ciklā iet cauri lietotāja ievadītajam tekstam pa vienam burtam
            // ja šis burts neatrodas mūsu izveidotajā unikālo burtu teksta mainīgajā, tad pievienot šo burtu šim teksta mainīgajam
            // kad viss teksts apskatīts, atgriezt rezultāta teksta mainīgo ar unikālajiem burtiem
            
            // nolasīt visus vārdus no faila, ierakstot tos sarakstā, kur katrs ieraksts ir viens vārds
            string[] Lines = System.IO.File.ReadAllLines(@"../../Words.txt");

            PrintCorrectWords(UniqueLetters, Lines);

            Console.ReadLine();

            // ja visi simboli no vārda atrodas unikālo simbolu virknē un visi unikālie simboli atrodas vārdā, izvadīt to uz ekrāna
        }

        private static void PrintCorrectWords(char[] uniqueLetters, string[] lines)
        {
            foreach (string wordFromFile in lines)
            {
                bool wordFromFileDoesNotMatch = DoesWordMatch(uniqueLetters, wordFromFile);

                if (wordFromFileDoesNotMatch == false)
                {
                    Console.WriteLine(wordFromFile);
                }
            }
        }

        private static bool DoesWordMatch(char[] uniqueLetters, string wordFromFile)
        {
            // izveidojam ķeksīti, kur atzīmējam, ka pagaidām nav atrasts neviens iztrūkstošs burts
            bool wordFromFileDoesNotMatch = false;

            // iet cauri šobrīdējam vārdam no faila pa vienam simbolam
            foreach (char letterFromFileWord in wordFromFile)
            {
                // pārbaudīt, vai šis simbols atrodas mūsu unikālo burtu tekstā
                if (uniqueLetters.Contains(letterFromFileWord) == false)
                {
                    // ja simbols neatrodas starp unikālajiem simboliem, tad atzīmēt, 
                    // ka vārds ir nederīgs
                    wordFromFileDoesNotMatch = true;
                    // pārstāt apstrādāt vārdu (pārstāt veikt ciklu)
                    break;
                }
            }

            return wordFromFileDoesNotMatch;
        }
    }
}
