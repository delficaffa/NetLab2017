
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista1 = new List<int>(); ;
            List<int> lista2 = new List<int>(); ;
            int listaMostrar;
            lista1.Add(1);
            lista1.Add(2);
            lista1.Add(3);
            lista1.Add(4);
            lista2.Add(3);
            lista2.Add(4);
            lista2.Add(5);

            listaMostrar=Generica<int>.Retorno(lista1, lista2);
           
                Console.WriteLine(listaMostrar);
                
            
            Console.ReadKey();



        }
    }
}
