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

        public override bool[,] MovimentosPossiveis(Posicao posicao)
        {
            bool[,] movimentosPossiveisTorre = new bool[Taboleiro.Linhas, Taboleiro.Colunas];

           // Posicao posicao = new Posicao(0, 0);

            // acima 
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            while (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisTorre[posicao.Linha, posicao.Coluna] = true; 
                if(Taboleiro.TabuleiroJogo(posicao)!=null && Taboleiro.TabuleiroJogo(posicao).Cor != Cor)
                {
                    break; 
                }
                posicao.Linha = posicao.Linha -1; 
            }

            // Baixo 
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            while (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisTorre[posicao.Linha, posicao.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(posicao) != null && Taboleiro.TabuleiroJogo(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Linha = posicao.Linha + 1 ;
            }

            // Direita 
            posicao.DefinirValores(posicao.Linha, posicao.Coluna +1);
            while (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisTorre[posicao.Linha, posicao.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(posicao) != null && Taboleiro.TabuleiroJogo(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna = posicao.Coluna +1;
            }

            // Esquerda 
            posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            while (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisTorre[posicao.Linha, posicao.Coluna] = true;
                if (Taboleiro.TabuleiroJogo(posicao) != null && Taboleiro.TabuleiroJogo(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna = posicao.Coluna - 1;
            }

            return movimentosPossiveisTorre; 
        }
 
        public override string ToString()
        {
            return "T"; 
        }
    }
}
