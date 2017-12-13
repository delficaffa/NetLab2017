using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
   public class Generica<T,X>
       where T:IConvertible
       where X:IComparable
    {

       

        public  T Retorno(T lista1, X lista2)          
        {

            return lista1;


        }
}
}
