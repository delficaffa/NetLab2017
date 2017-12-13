using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    class Program

    {
        static void Main(string[] args)
        {

            var persona = new Person
            {
                Name = "Delfina",
                Surname = "Caffa"
            };

            var std = new Student();

            var studentType = std.GetType();
            var pType = persona.GetType();
            foreach (var prop in persona.GetType().GetProperties())
            {
                var getProperty = pType.GetProperty(prop.Name);

                studentType.GetProperty(prop.Name)
                    .SetValue(std, prop.GetValue(persona));
            }

            Console.WriteLine("Caminar o Saludar?");
            var accion = Console.ReadLine();
            var method = persona.GetType().GetMethod(accion);
            method.Invoke(persona, null);
            

            //var person = new Person
            //{
            //    Name = "Delfina",
            //    Surname = "Caffa"
            //};

            //Console.WriteLine("Desea crear un Person o un Student?");
            //var value = Console.ReadLine();

            //var dynamicType = typeof(Program).Assembly.GetTypes().First(c => c.Name == value);
            //var person = Activator.CreateInstance(dynamicType);

            //Console.WriteLine("Ingrese el nombre");
            //var nombre = Console.ReadLine();
            //Console.WriteLine("Ingrese el apellido");
            //var apellido = Console.ReadLine();

            //var property = person.GetType().GetProperty("Name");
            //property.SetValue(person, nombre);

            //var property2 = person.GetType().GetProperty("Surname");
            //property.SetValue(person, apellido);

            //------------------------------------------------------------

            //Console.WriteLine("Ingrese la propiedad que desea cambiar");
            //var propiedad = Console.ReadLine();
            //Console.WriteLine("Ingrese el nuevo valor");
            //var valor = Console.ReadLine();

            //var typo = person.GetType(); //typeof(Person);
            //typo.GetProperty(propiedad).SetValue(person, valor);

            //Console.WriteLine($"Nuevo {propiedad}: {typo.GetProperty(propiedad).GetValue(person)}");
            Console.ReadLine();
        }
    }
}
