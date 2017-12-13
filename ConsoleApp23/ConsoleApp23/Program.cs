using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            var genc1 = new Abs<int>();
            var genc2 = new Abs<decimal>();
            var genc3 = new Abs<string>();

            genc1.Retorno(1);
            genc2.Retorno(1.55m);
            genc3.Retorno("HOLA");

        }
    }
}
