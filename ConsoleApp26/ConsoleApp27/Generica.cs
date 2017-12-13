using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
   public class Generica<T>:IConvertible
       
    {

       

        public static T Retorno(IEnumerable<T> lista1, IComparable<T> lista2)
       {
            
            return lista1.Intersect(lista2).FirstOrDefault();
            

        }
}
}
