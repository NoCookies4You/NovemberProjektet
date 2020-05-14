using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace Sänkaskepp
{
    class Board
    {
        //En instans av en Board sparar ett rutnät av Tiles med en bestämd storlek
        public Tile[,] tiles;
        private int size = 10;

        //När en Board skapas väljs huruvida den ska fyllas upp av FriendlyTiles eller EnemyTiles.
        public Board(bool friendly)
        {
            //En Tile array skapas med storleken baserad på "size" variabeln
            tiles = new Tile[size, size];
            //FillBoard används för att fylla i den tomma arrayen med en av subklasserna av Tile
            if (friendly == true)
            {
                tiles = FillBoard<FriendlyTile>(tiles);
            }
            else
            {
                tiles = FillBoard<EnemyTile>(tiles);
            }
        }

        //generisk klass. Tar in någon typ av Tile och fyller upp brädet med instanser av antingen EnemyTile eller FriendlyTile
        private Tile[,] FillBoard<T>(Tile[,] board) where T : Tile
        {
            if (typeof(T) == typeof(FriendlyTile))
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int a = 0; a < board.GetLength(1); a++)
                    {
                        //A och I variablerna ökar för varje gång 4-loopen körs och därför blir varje koordinat unik
                        board[i, a] = new FriendlyTile(a, i);
                    }
                }
                return board;
            }
            else
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int a = 0; a < board.GetLength(1); a++)
                    {
                        //A och I variablerna ökar för varje gång 4-loopen körs och därför blir varje koordinat unik
                        board[i, a] = new EnemyTile(a, i);
                    }
                }
                return board;
            }
        }

        //Printar ut ett helt bräde med hjälp av Tiles print metod
        public void Print()
        {
            
            Tile[,] board = this.tiles;
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

        public void EditSelectedVariable(int[] position, bool value, bool friendly)
        {

        }
    }
}
