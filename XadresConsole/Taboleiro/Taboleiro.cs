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

        public Peca TabuleiroJogo(int linha, int coluna)
        {

            return _pecas[linha, coluna]; 
        }

        public Peca TabuleiroJogo(Posicao posicao)
        {
            return _pecas[posicao.Linha, posicao.Coluna]; 
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao); 
            return TabuleiroJogo(posicao) != null; 
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TaboleiroExcepton("Já Existe peça nesta posição!"); 
            }
            _pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao; 
        }

        public Peca RemoverPeca(Posicao posicao)
        {
            if(TabuleiroJogo(posicao) == null)
            {
                return null; 
            }

            Peca aux = TabuleiroJogo(posicao);
            aux.Posicao = null;
            _pecas[posicao.Linha, posicao.Coluna] = null;

            return aux; 
        }

        public bool PosicaoValida(Posicao posicao)
        {
            if(posicao.Linha<0 || posicao.Linha >= Linhas || posicao.Coluna <0 ||posicao.Coluna >= Colunas)
            {
                return false; 
            }
            return true; 
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
            {
                throw new TaboleiroExcepton("Posicao Invalida"); 
            }
        }
    }
}
