using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            var genc1 = new  Generica<IConvertible>();
            var generica1 = new Generica<int>();

            genc1.Retorno(generica1);
        }
    }
}
