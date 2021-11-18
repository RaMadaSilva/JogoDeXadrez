using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadresConsole.Taboleiro
{
    class Posicao
    {
        public int Coluna { get; set; }
        public int Linha { get; set; }

        public Posicao(int coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public override string ToString()
        {
            return Coluna + ", " + Linha; 
        }
    }
}
