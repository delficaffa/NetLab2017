using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Cola <T>
    {
        
            private List<T> cola = new List<T>();

            public void Agregar(T Elemento)
            {
                cola.Add(Elemento);
            }

            public T Devolver()
            {
                var UltimoElemento = cola.First();
                cola.Remove(UltimoElemento);
                return UltimoElemento;

            }
            public int Cantidad()
            {
                return cola.Count();
            }
        }
    }
}
