using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {


        static void Main(string[] args)
        {
            int num1, num2,resultado;
            Console.WriteLine("n1");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("n2");
            num2 = Convert.ToInt32(Console.ReadLine());
            try
            {
                resultado = calcular(num1, num2);
                Console.WriteLine(resultado);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hubo un error");
            }
        }
        public static int calcular(int n1, int n2)
        {
            return (n1/n2);
       
        }
    }
}
