using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace Sänkaskepp
{
    class Program
    {
        static void Main(string[] args)
        {
            //här skapas de två bräderna som kommer att användas i spelet.
            //Bräderna är en tvådimensionel array av klassen "Tile" där varje plats representerar kordinater
            Tile[,] boardA = new Tile[10, 10];
            Tile[,] boardB = new Tile[10, 10];

            //i en tile sparas två siffror som representerar X och Y värdet i koordinatsystemet
            for (int i = 0; i < boardA.GetLength(0); i++)
            {
                for (int a = 0; a < boardA.GetLength(1); a++)
                {
                    //A och I variablerna ökar för varje gång 4-loopen körs och därför blir varje koordinat unik
                    boardA[i, a] = new Tile(a, i);
                }
            }

            //En båt läggs ut för att testa
            boardA[0, 5] = new Boat(0 , 5);

            //Metod som skriver ut brädet i konsollen
            PrintBoard(boardA);
            System.Console.WriteLine(); System.Console.WriteLine();

            //While loop för att selecta positioner. 
            //Denna del av programmet är inte helt klar, men den tar in formatet [Bokstav mellan A-J]+[siffra 0-10] och gör om det till den respektive koordinat dessa representerar.
            bool placing = true;
            while(placing)
            {

                int[] selectedPos;
                System.Console.WriteLine("Skriv in den koordinat där du vill att fören av din båt ska vara!  (4 enheter lång)");
                //Getpos är en metod som jag tog från mitt gamla shack spel, och den kollar huruvida användarens input är valid, och returnerar en int[] som kan användas som en koordinat.
                selectedPos = GetPos();
                //här skriver programmet bara ut koordinaten användaren valt.
                System.Console.WriteLine(selectedPos[0].ToString() + selectedPos[1].ToString());
                System.Console.WriteLine();
            }
            System.Console.WriteLine("");
            System.Console.ReadLine();
        }

        static void PrintBoard(Tile[,] board)
        {
            //Skriver ut brädet med hjälp av 4-loopar. Använder sig av "Print" metoden som finns i Tile klassen
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write(" " + (9 - i) + "    ", Color.Gray);
                for (int a = 0; a < board.GetLength(1); a++)
                {
                    board[i, a].Print();
                    Console.Write(" ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            Console.WriteLine("      A B C D E F G H I J", Color.Gray);
        }
        static int[] GetPos()
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
