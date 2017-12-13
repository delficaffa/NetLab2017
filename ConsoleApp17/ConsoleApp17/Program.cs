using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            var mayoresAHoy  = new List<DateTime> { };
            var mesOctubre = new List<DateTime> { };
            var menores = new List<DateTime> { };

            var dates = new List<DateTime> { new DateTime(2017, 1, 21), new DateTime(2014, 2, 17), new DateTime(2013, 3, 20), new DateTime(2012, 4, 2), new DateTime(2010, 10, 7), new DateTime(2018, 6, 8), new DateTime(2025, 7, 9), new DateTime(2022, 8, 11), new DateTime(1980, 9, 12), new DateTime(1970, 10, 13), new DateTime(2099, 11, 18), new DateTime(1945, 12, 15), };

            mayoresAHoy = dates.Where(d => d > DateTime.Today).ToList();
            print(mayoresAHoy
                );


            mesOctubre = dates.Where(d => d.Month==10).ToList();
            print(mesOctubre);

            menores = dates.Where(d => d.Year <= 2000).ToList();
            print(menores);

           

            
        }
        private static void print(List<DateTime> lista) {
            foreach (var e in lista)
            {
                Console.WriteLine(e);
              
            }
            Console.WriteLine("===============================================");
            Console.ReadKey();
        }
    }
}
