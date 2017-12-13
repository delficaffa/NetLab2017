using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    public class Abs<T>
    {
   
    public  void Retorno(T elem, T elem2)
    {
            //if (elem.ToString() == elem2.ToString())
            //{
            //    Console.WriteLine(elem.ToString());
            //}
            //else
            //{
            //    Console.WriteLine("Distintos");
            //}
           if( elem.Equals(elem2))
            {
                   Console.WriteLine(elem.ToString());
                }
                else
                {
                    Console.WriteLine("Distintos");
                }
            }
        }
}
