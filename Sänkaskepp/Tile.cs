using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace Sänkaskepp
{
    class Tile
    {
        //Varje "tile" har en placering. Informationen om placeringen sparas som en 2dimensionel int[] och den representerar en koordinat.
        private int[] coordinate = new int[2];

        //Metod som skulle ha låtit programmet ta ut bara informationen om koordinaterna ur en "tile". Används dock aldrig och borde förmodligen ha tagit in en Tile, istället för en int[]
        public int[] GetCoorinate(int[] coordinate)
        {
            int[] extractedCoordinate = new int[2];
            extractedCoordinate[0] = coordinate[0];
            extractedCoordinate[1] = coordinate[1];
            return extractedCoordinate;
        }
        //Konstruktorn. Ett värde för både X och Y koordinaten sätts när Tilen skapas.
        public Tile(int x, int y)
        {
            coordinate[0] = x;
            coordinate[1] = y;
        }
        //En metod för att ändra på färgen av det som skrivs ut.
        //Denna används av metoden "PrintBoard" i mainkoden
        public void Print()
        {
            //När en Tile.Print metod körs används "this.GetType" för att få typen av just den Tilen.
            //Det finns två färger som kan användas, en för båtar och en för vatten. dessa har också speciella tecken för att skrivas ut.
            if (this.GetType() == typeof(Boat))
            {
                Console.ForegroundColor = Color.Beige;
                Console.Write("+");
            }
            else
            {
                Console.ForegroundColor = Color.LightSkyBlue;
                Console.Write("*");
            }
            //I slutet så sätts Foregroundcolor tillbaka till vit vilket är standarden för konsollen.
            Console.ForegroundColor = Color.White;

        }
    }
}
