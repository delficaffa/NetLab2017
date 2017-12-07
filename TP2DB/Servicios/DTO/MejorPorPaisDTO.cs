using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DTO
{
    public class MejorPorPaisDTO
    {

        public string Name { get; set; }

        public decimal Total { get; set; }

        public string Country { get; set; }
        
    }
    public class ProductoMasVendidoDTO
    {
        public string ProductName { get; set; }

        public string Country { get; set; }

    }
}
