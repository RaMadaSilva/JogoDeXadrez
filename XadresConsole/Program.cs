using System;
using XadresConsole.Mesa;
using XadresConsole.Xadres;
using XadresConsole.Mesa.Enums;


namespace XadresConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            PartidaXadres partida = new PartidaXadres();

            try
            {
                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTaboleiro(partida.Taboleiro);
                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicao().ToPosicao();

                    bool[,] posicoesPossiveis = partida.Taboleiro.TabuleiroJogo(origem).MovimentosPossiveis(origem); 

                    Console.Clear();
                    Tela.ImprimirTaboleiro(partida.Taboleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicao().ToPosicao();

                    partida.ExecutarMovimento(origem, destino); 

                }

            }
            catch (TaboleiroExcepton e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            //PosicaoXadrez xadrez = new PosicaoXadrez('c', 2);
            //Console.WriteLine(xadrez.ToPosicao());

        }
    }
}
