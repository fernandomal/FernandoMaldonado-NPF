using System;

namespace PascalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valor N = ");

            int n = int.Parse(Console.ReadLine());

            int final = Prova(n);

            Console.WriteLine("Final: " + final);

            Console.ReadLine();
        }


        public static int Prova(int n)
        {
            int valor = 0;

            if (n != 0)
                valor = n * 2 - 1 + Prova(n - 1);

            Console.WriteLine(valor.ToString());

            return valor;
        }
    }
}
