using System;
using XadresConsole.taboleiro;
using XadresConsole.Xadres;
using XadresConsole.taboleiro.Enums;

namespace XadresConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Taboleiro taboleiro = new Taboleiro(8, 8);

            try
            {

                taboleiro.ColocarPeca(new Torre(Cor.Preta, taboleiro), new Posicao(0, 0));
                taboleiro.ColocarPeca(new Torre(Cor.Preta, taboleiro), new Posicao(1, 3));
                taboleiro.ColocarPeca(new Rei(Cor.Preta, taboleiro), new Posicao(0, 8));

                Tela.ImprimirTaboleiro(taboleiro);

                Console.ReadLine();


            }
            catch (TaboleiroExcepton e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

        }
    }
}
