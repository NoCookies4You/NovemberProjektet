using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sänkaskepp
{
    class InputHelper
    {
        public int[] GetPos()
        {
            int[] pos = new int[2];

            bool Choosing = true;
            while (Choosing)
            {
                //If statements stackade på varandra där varje slutar med en else och en förklaring för varför den bröt ut där.
                string input = Console.ReadLine();
                if (input.Length == 2)
                {
                    string[] acceptableLetters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
                    bool acceptableLetter = false;
                    for (int i = 0; i < 10; i++)
                    {
                        if (input[0].ToString().ToLower() == acceptableLetters[i])
                        {
                            acceptableLetter = true;
                        }
                    }
                    if (acceptableLetter)
                    {
                        bool isNum = false;
                        int numCollector;
                        isNum = int.TryParse(input[1].ToString(), out numCollector);
                        if (isNum)
                        {
                            if (numCollector <= 9 && numCollector >= 0)
                            {
                                //Här vet vi att inputen är en acceptabel bokstav samt siffra. Bara att överföra dem till kordinater.
                                pos[0] = 9 - numCollector;
                                for (int i = 0; i < 10; i++)
                                {
                                    if (input[0].ToString().ToLower() == acceptableLetters[i])
                                    {
                                        pos[1] = i;
                                    }
                                }
                                Choosing = false;
                            }
                            else
                            {
                                System.Console.WriteLine("Skriv ett nummer mellan 0 och 9!");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Den andra karaktären ska vara ett nummer som är mellan 0 och 9!");
                        }

                    }
                    else
                    {
                        System.Console.WriteLine("Den första karaktären ska vara en bokstav mellan A och J!");
                    }
                }
                else
                {
                    System.Console.WriteLine("Skriv bara 2 karaktärer; först en bokstav följt av en siffra!");
                }
            }
            //Returnerar en int[] som jag kan använda som kordinater för båtarna
            return pos;
        }
    }
}
