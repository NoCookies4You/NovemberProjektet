using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sänkaskepp
{
    class Boat : Tile
    {
        //Boat använder sig av Tile's konstruktor, men Visual studio ger ett felmedellande ifall denna bit av kod inte existerar.
        //vet ärligt talat inte riktigt varför, det var ett tag sedan jag skrev koden. Kommer ihåg att jag diskuterade med ett flertal personer om varför denna kod fungerar
        public Boat(int x, int y) : base(x, y)
        {

        }

        //Boat klassen används aldrig då spelet inte är klart. Ideen var att varje instans av en Boat skulle ha en lista av alla koordinater den ligger på. Därför finns en list av int[]
        List<int[]> boatCoords = new List<int[]>();

        //Här skulle metoden för att placera ut Boat's i Tile nätet vara.
        //Väl färdig skulle denna metod tagit in koordinater, kolla att dem inte redan är upptagna, och sedan göra om dem tilesen i brädet till boats
        //Sedan skulle en instans av Boat skapas där en lista med alla koordinater båten tar upp sparas
        public void PlaceBoat(int[] startingPoint, int direction, int length, Tile[,] selectedBoard)
        {



        }


    }
}
