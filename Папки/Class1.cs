using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Папки
{
    internal class Class1
    {
        public static int strelka(int position, int minStrelocka, int maxStrelochka)
        {
            ConsoleKeyInfo knopka;
            do
            {

                knopka = Console.ReadKey();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                if (knopka.Key == ConsoleKey.UpArrow && position != minStrelocka)
                {
                    position--;

                }
                else if (knopka.Key == ConsoleKey.DownArrow && position != maxStrelochka)
                {
                    position++;

                }
                else if (knopka.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");

            } while (knopka.Key != ConsoleKey.Enter);
            return position;
        }
    }
}
