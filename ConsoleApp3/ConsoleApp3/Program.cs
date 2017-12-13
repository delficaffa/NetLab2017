using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)

        {
            //List<int> numeros = new List<int>();
            //    int i = 1;
            //    while (numeros.Count() < 100){
            //        numeros.Add(i);
            //    i++;
            //    }

            //foreach (var n in numeros) {
            //    if (n % 2 != 0) {

            //        Console.WriteLine(n);
            //    }
            //}

            //Console.ReadLine();
            //foreach (var n in numeros) {
            //    if (n % 2 == 0) {

            //        Console.WriteLine(n);
            //    }
            //}
            //Console.ReadLine();

            //foreach (var n in numeros)
            //{
            //    if (n % 3 == 0)
            //    {

            //        Console.WriteLine(n);
            //    }
            //}
            //Console.ReadLine();

            //foreach (var n in numeros)
            //{
            //    if ((n % 3 == 0)&& (n % 2==0))
            //    {

            //        Console.WriteLine(n);
            //    }
            //}
            //Console.ReadLine();

            //int ing;
            //int sum = 0;
            //Console.WriteLine("ingrese número");
            //ing=Convert.ToInt32(Console.ReadLine());
            //foreach (var n in numeros)
            //{
            //    if (n<= ing)
            //    {
            //        sum = sum + n;

            //    }

            //}
            //Console.WriteLine(sum);
            //Console.ReadLine();


            //int ing;
            //int sum = 0;
            //Console.WriteLine("ingrese número");
            //ing = Convert.ToInt32(Console.ReadLine());
            //foreach (var n in numeros)
            //{
            //    if (n <= ing)
            //    {
            //        Console.WriteLine(n);

            //    }

            //}

            //Console.ReadLine();


            //int ing;

            //Console.WriteLine("ingrese número");
            //ing = Convert.ToInt32(Console.ReadLine());
            //foreach (var n in numeros)
            //{
            //    if (n <= ing)
            //    {
            //        if(n%3==0)
            //        Console.WriteLine(n);

            //    }

            //}

            //Console.ReadLine();



            //8
            //List<int> numeros = new List<int>();
            //int i;
            //int sum = 0;
            //while (numeros.Count() < 10)
            //{
            //    i = Convert.ToInt32(Console.ReadLine());
            //    numeros.Add(i);
            //    i++;
            //}

            //foreach (var n in numeros)
            //{
            //    if (n < 0)
            //        sum = sum * n;
            //    else
            //        if (n > 0)
            //    {
            //        sum = sum + n;
            //    }
            //}

            //Console.WriteLine(sum);
            //Console.ReadLine();

            //int n1, n2, aux;

            //n1=Convert.ToInt32(Console.ReadLine());
            //n2 = Convert.ToInt32(Console.ReadLine());
            //aux = n1;
            //n1 = n2;
            //n2 = aux;
            //Console.WriteLine(n1);
            //Console.WriteLine(n2);
            //Console.ReadLine();

            //    int n1;

            //    n1 = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("cuadrado");
            //    Console.WriteLine(Math.Pow(n1,2));
            //    Console.WriteLine("cubo");
            //    Console.WriteLine(Math.Pow(n1, 3));
            //    Console.ReadLine();


            //List<int> pesos = new List<int>();
            //int i=0;

            //int sumas = 0;
            //int sumenos = 0;
            //i= Convert.ToInt32(Console.ReadLine());

            //while (i!=0)
            //{

            //    i = Convert.ToInt32(Console.ReadLine());
            //    pesos.Add(i);

            //}

            //foreach (var n in pesos)
            //{
            //    if (n > 80)
            //        sumas++;
            //    else

            //    {
            //        sumenos++;
            //    }
            //}
            //Console.WriteLine("Mayores");
            //Console.WriteLine(sumas);

            //Console.WriteLine("Menos");
            //Console.WriteLine(sumenos);

            //Console.ReadLine();



            //    int l1, l2,l3;

            //    l1 = Convert.ToInt32(Console.ReadLine());
            //    l2 = Convert.ToInt32(Console.ReadLine());
            //    l3 = Convert.ToInt32(Console.ReadLine());


            //    if ((l1 == l2) && (l1 == l3)&&(l1==l3)) {
            //        Console.WriteLine("equilatero");
            //    }
            //    else if (((l1 == l2) && ((l2 != l3)|| (l1 != l3)) && (l1+l2>l3))){
            //        Console.WriteLine("isósceles");
            //    }
            //    else if (l1 + l2 > l3)
            //    {
            //        Console.WriteLine("escaleno");
            //    }


            //    Console.ReadLine();



            //int l1, l2, l3;

            //l1 = Convert.ToInt32(Console.ReadLine());
            //l2 = Convert.ToInt32(Console.ReadLine());
            //l3 = Convert.ToInt32(Console.ReadLine());

            //if ((l3 > l1) && (l3 < l2))
            //{
            //    Console.WriteLine("Está dentro");

            //}
            //else {
            //    Console.WriteLine("Está afuera");
            //}
            //Console.ReadLine();


            int l1;

            l1 = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++) {
                Console.WriteLine(l1+" x "+i+"= "+l1*i);
            }
            Console.ReadLine();
        }
    }
}