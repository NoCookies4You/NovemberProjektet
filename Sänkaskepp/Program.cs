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
            //En tom instans av InputHelper som låter koden använda sig av metod / metoder som finns i klassen
            InputHelper inputHelper = new InputHelper();

            //Två instanser av klassen Board skapas. Boolen väljer huruvida den ska fyllas av friendlyTiles eller enemyTiles
            Board friendlyBoard = new Board(true);
            Board enemyBoard = new Board(false);

            //Printar ut båda bräderna med hjälp av Boards print metod
            enemyBoard.Print();
            friendlyBoard.Print();
            System.Console.WriteLine(); System.Console.WriteLine();


    

            int[] boatSizes = new int[] { 5, 4, 3, 3, 2 };
            List<int[]> previewTiles = new List<int[]>();
            int[] selectedPos = new int[] { 1, 1 };
            int direction = 1;
            bool user_Placing_Boat = true;
            //4-loop som körs så många gåner som det finns båtar. Varje gång den körs ska en instans av en båt skapas i slutändan
            for (int i = 0; i < boatSizes.Length; i++)
            {

                while (user_Placing_Boat)
                {

                    System.Console.WriteLine("Skriv in den koordinat där du vill att fören av din båt ska vara!  (" + boatSizes[i] + " enheter lång)");

                    //Getpos är en metod som jag tog från mitt gamla shack spel, och den kollar huruvida användarens input är valid, och returnerar en int[] som kan användas som en koordinat.
                    selectedPos = inputHelper.GetPos();
                    //Den valda positionens tile i spelarens bräde blir "selected"
                    friendlyBoard.tiles[selectedPos[0], selectedPos[1]].makeSelected(true);


                    enemyBoard.Print();
                    friendlyBoard.Print();

                    friendlyBoard.tiles[selectedPos[0], selectedPos[1]].makeSelected(false);

                    System.Console.WriteLine();
                }

            }
  
            System.Console.WriteLine("");
            System.Console.ReadLine();
        }

       
    }

}
