using System;
using XadresConsole.Mesa;
using XadresConsole.Mesa.Enums;

namespace XadresConsole.Xadres
{
    class Rei : Peca
    {
        public Rei(Cor cor, Taboleiro taboleiro) : base(cor, taboleiro)
        {

        }

        public override bool[,] MovimentosPossiveis(Posicao posicao)
        {
            bool[,] movimentosPossiveisRei = new bool[Taboleiro.Linhas, Taboleiro.Colunas];

            //Posicao posicao = new Posicao(0, 0);

            //  ao Norte  
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);

            if (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisRei[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);

            // ao Sul   
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            if (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisRei[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha -1, posicao.Coluna);

            // Ao Este  
            posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            if (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisRei[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha, posicao.Coluna -1); 

            // ao Oeste  
            posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            if (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisRei[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);

            //  Ao Nordeste  
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            if (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisRei[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha +1, posicao.Coluna -1);


            //  Ao Sudeste
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
            if (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisRei[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha -1, posicao.Coluna-1);

            //  Ao Sudoeste
            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            if (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisRei[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            //  Ao Noroeste
            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
            if (Taboleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveisRei[posicao.Linha, posicao.Coluna] = true;
            }

            return movimentosPossiveisRei;

        }


        public override string ToString()
        {
            return "R";
        }
    }
}
