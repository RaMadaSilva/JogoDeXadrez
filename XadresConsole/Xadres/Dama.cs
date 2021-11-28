using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadresConsole.Mesa;
using XadresConsole.Mesa.Enums;

namespace XadresConsole.Xadres
{
    class Dama : Peca
    {
        public Dama(Cor cor, Taboleiro tab): base(cor, tab)
        {
                
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Taboleiro.Linhas, Taboleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            // esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha, pos.Coluna - 1);
            }

            // direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha, pos.Coluna + 1);
            }

            // acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna);
            }

            // abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna);
            }

            // NO
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // NE
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

            // SE
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

            // SO
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
            return "D";
        }
    }
}
