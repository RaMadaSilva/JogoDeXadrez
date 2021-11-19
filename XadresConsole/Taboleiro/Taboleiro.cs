using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadresConsole.taboleiro
{
    class Taboleiro
    {
        private Peca[,] _pecas;
        public int Linhas { get; set; }
        public int Colunas { get; set; }
      

        public Taboleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;

            _pecas = new Peca[Linhas, Colunas]; 
        }

        public Peca TabueliroJogo(int linha, int coluna)
        {

            return _pecas[linha, coluna]; 
        }
    }
}
