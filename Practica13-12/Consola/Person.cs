using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    public class Person
    {
        public string Name{ get; set; }
        public string Surname { get; set; }

        public void Saludar()
        {
            Console.WriteLine("Hola soy una persona");
        }
        public void Caminar()
        {
            Console.WriteLine("Estoy caminando");
        }

    }

    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public void Saludar()
        {
            Console.WriteLine("Hola soy una persona");
        }
        public void Caminar()
        {
            Console.WriteLine("Estoy caminando");
        }
    }
}
