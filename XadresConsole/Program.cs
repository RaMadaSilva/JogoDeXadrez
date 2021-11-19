using System;
using XadresConsole.taboleiro; 

namespace XadresConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Taboleiro taboleiro = new Taboleiro(8, 8);
          
            Tela.ImprimirTaboleiro(taboleiro);

            Console.ReadLine();


             
            
        }
    }
}
