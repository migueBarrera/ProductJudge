using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Main
    {
        internal void Start() 
        {
            Console.WriteLine("Hola");
            Console.WriteLine("Esto comienza...");


            Console.WriteLine("¿Como te llamas?");

            var nombre = Console.ReadLine();

            if (nombre == "Miguel")
            {
                Console.WriteLine("Valla nombre way");
            }
            else
            {
                Console.WriteLine("bahh ese nombre no mola tanto");
            }
        }


        internal void EvitarCierreDeConsola()
        {
            Console.ReadLine();
        }
    }
}
