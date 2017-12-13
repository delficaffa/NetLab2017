using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ConsoleApp5
{
    class Pila<T>
    {
        private List<T> pila = new List<T>();

        public void Agregar(T Elemento)
        {
            pila.Add(Elemento);
        }

        public T Devolver()
        {
            var PrimerElemento=pila.Last();
            pila.Remove(PrimerElemento);
            return PrimerElemento;

        }
        public int Cantidad() {
            return pila.Count();
        }
    }
}
