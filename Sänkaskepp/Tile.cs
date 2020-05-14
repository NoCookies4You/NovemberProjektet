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
        //Dessa två bools skulle användas för att måla ut Tiles i andra färger 
        protected bool selected = false;
        protected bool preview = false;

        //Konstruktorn. Ett värde för både X och Y koordinaten sätts när Tilen skapas.
        public Tile(int x, int y)
        {
            coordinate[0] = x;
            coordinate[1] = y;

        }
        //Låter mainkoden ändra på den protected boolen "selected"
        public void makeSelected(bool value)
        {
            if(value == true)
            {
                this.selected = true;
            }
            else
            {
                this.selected = false;
            }
        }
        //En metod för att ändra på färgen av det som skrivs ut.
        //Båda subklasserna har en Override metod som använder sig av olika färger
        public virtual void Print()
        {

        }
    }
    class EnemyTile : Tile
    {
        public EnemyTile(int x, int y) : base(x, y)
        {

        }
        public override void Print()
        {
            //När en Tile.Print metod körs kollar den ifall det finns någon information på Tilen för att skriva ut den.
            //Ifall det inte finns något speciellt på den tilen så skrivs den ut som vatten!
            //Colorfull Consloe används för att ge texten färg.

            //Hade koden varit klar hade den första If-satsen kollat igenom en lista av alla koordinater som det finns en båt på istället för detta
            if (this.GetType() == typeof(Boat))
            {
                Console.ForegroundColor = Color.Beige;
                Console.Write("+");
            }
            else if(this.selected == true)
            {
                Console.ForegroundColor = Color.Red;
                Console.Write("*");
            }
            else if (this.preview == true)
            {
                Console.ForegroundColor = Color.Yellow;
                Console.Write("*");
            }
            else
            {
                Console.ForegroundColor = Color.Lavender;
                Console.Write("*");
            }
            //I slutet så sätts Foregroundcolor tillbaka till vit vilket är standarden för konsollen.
            Console.ForegroundColor = Color.White;

        }
    }
    class FriendlyTile : Tile
    {
        public FriendlyTile(int x, int y) : base(x, y)
        {

        }
        public override void Print()
        {
            //Identiskt till "EnemyTile" förutom att den använder sig av andra färger
            if (this.GetType() == typeof(Boat))
            {
                Console.ForegroundColor = Color.Gray;
                Console.Write("+");
            }
            else if (this.selected == true)
            {
                Console.ForegroundColor = Color.Purple;
                Console.Write("*");
            }
            else if (this.preview == true)
            {
                Console.ForegroundColor = Color.Yellow;
                Console.Write("*");
            }
            else
            {
                Console.ForegroundColor = Color.Aqua;
                Console.Write("*");
            }
            Console.ForegroundColor = Color.White;

        }
    }
}
