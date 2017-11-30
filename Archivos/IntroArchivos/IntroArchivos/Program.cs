using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"mytest.txt";
            FileStream fileStr = File.Create(fileName);
        }
    }
}
