using System;
using XadresConsole.Mesa;
using XadresConsole.Mesa.Enums;

namespace XadresConsole.Xadres
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Taboleiro tab) : base(cor, tab)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Taboleiro.Linhas, Taboleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1); 
            while(Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true; 
                if(Taboleiro.TabuleiroJogo(pos)!=null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break; 
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            //Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            //Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            //Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }
            return mat; 
        }

        public override string ToString()
        {
            return "B"; 
        }


    }
}
