using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Gato gato = new Gato();
            Perro perro = new Perro();
            Pajaro pajaro = new Pajaro();

            Console.WriteLine(gato.Hablar());
            Console.WriteLine(perro.Hablar());
            Console.WriteLine(pajaro.Hablar());
            Console.ReadKey();
        }
    }
}
