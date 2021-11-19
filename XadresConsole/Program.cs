using System;
using XadresConsole.taboleiro; 

namespace XadresConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao posicao = new Posicao(3, 4); 
            Console.WriteLine(posicao);

            Taboleiro taboleiro = new Taboleiro(8, 9);
            Console.ReadLine(); 
             
            
        }
    }
}
