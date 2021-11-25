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
                    try
                    {

                        Console.Clear();
                        Tela.ImprimirTaboleiro(partida.Taboleiro);
                        Console.WriteLine();

                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando Jogada: " + partida.JogadorActual);

                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicao().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Taboleiro.TabuleiroJogo(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTaboleiro(partida.Taboleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicao().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino); 

                        partida.RealizaJogada(origem, destino);
                    }catch(TaboleiroExcepton e)
                    {
                        Console.WriteLine("erro: " + e.Message);
                        Console.ReadLine(); 
                    }

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
