using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadresConsole.taboleiro;

namespace XadresConsole
{
    class Tela
    {
        public static void ImprimirTaboleiro(Taboleiro taboleiro)
        {
            for (int i = 0; i < taboleiro.Linhas; i++)
            {
                for (int j = 0; j < taboleiro.Colunas; j++)
                {
                    if (taboleiro.TabueliroJogo(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(taboleiro.TabueliroJogo(i, j) + " ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
