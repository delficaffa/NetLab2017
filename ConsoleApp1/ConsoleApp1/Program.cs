using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            
            int.TryParse(Console.ReadLine(), out int num1);
            int.TryParse(Console.ReadLine(), out int result);
            bool validar = true;
            string y = null;

            

            while (validar)
                y = Console.ReadLine();
            {
                switch (y.ToLower())
                {
                    case "s":
                        result = num1 + result;
                        break;
                    case "r":
                        result = num1 - result;
                        break;
                    case "m":
                        result = num1 * result;
                        break;
                    case "d":
                        if (result == 0)
                        {
                            validar = false;
                            Console.WriteLine("no se puede dividir por 0");
                            break;
                        }
                        else
                        {
                            result = num1 / result;
                        }
                        break;
                }
                Console.WriteLine(result);
                int.TryParse(Console.ReadLine(), out int num3);
                
            }
            

            Console.ReadLine();
        }

        
    }
}
