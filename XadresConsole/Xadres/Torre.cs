using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadresConsole.Mesa;
using XadresConsole.Mesa.Enums; 

namespace XadresConsole.Xadres
{
    class Torre : Peca
    {
        public Torre(Cor cor, Taboleiro taboleiro) : base(cor, taboleiro)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosTorre = new bool[Taboleiro.Linhas, Taboleiro.Colunas];

           Posicao pos = new Posicao(0, 0);

            // acima 
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosTorre[pos.Linha, pos.Coluna] = true; 
                if(Taboleiro.TabuleiroJogo(pos)!=null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break; 
                }
                pos.Linha = pos.Linha -1; 
            }

            // Baixo 
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosTorre[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1 ;
            }

            // Direita 
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna +1);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosTorre[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna +1;
            }

            // Esquerda 
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosTorre[pos.Linha, pos.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(pos) != null && Taboleiro.TabuleiroJogo(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return movimentosTorre; 
        }
 
        public override string ToString()
        {
            return "T"; 
        }
    }
}
