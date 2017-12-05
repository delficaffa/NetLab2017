using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"Escritorio\mytest.txt";

            if (!File.Exists(file))
            {
                File.Create(file);
            }

            
        }
    }
}
