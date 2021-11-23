using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadresConsole.taboleiro;
using XadresConsole.taboleiro.Enums;
using XadresConsole.Xadres; 

namespace XadresConsole
{
    class Tela
    {
        public static void ImprimirTaboleiro(Taboleiro taboleiro)
        {
            for (int i = 0; i < taboleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < taboleiro.Colunas; j++)
                {
                    if (taboleiro.TabuleiroJogo(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(taboleiro.TabuleiroJogo(i, j)); 
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);

                Console.ForegroundColor = aux;

            }
        }

        public static PosicaoXadrez LerPosicao()
        {
            
            string s = Console.ReadLine();
            char colina = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(colina, linha); 
        }
    }
}
