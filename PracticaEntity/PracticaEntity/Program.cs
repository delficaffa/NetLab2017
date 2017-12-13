using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEntity
{
    class Program
    {
        static void Main(string[] args)
        {

           var custormers= CustomerRepository.GetAll();
            foreach (var c in custormers) {
                Console.WriteLine(c.ContactName);
            }
            Console.ReadKey();
        }
    }
}
