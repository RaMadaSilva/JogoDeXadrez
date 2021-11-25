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

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveisRei = new bool[Taboleiro.Linhas, Taboleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //  ao Norte  
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);

            if (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosPossiveisRei[pos.Linha, pos.Coluna] = true;
            }

            //posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);

            // ao Sul   
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosPossiveisRei[pos.Linha, pos.Coluna] = true;
            }

            //posicao.DefinirValores(posicao.Linha -1, posicao.Coluna);

            // Ao Este  
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosPossiveisRei[pos.Linha, pos.Coluna] = true;
            }

            //posicao.DefinirValores(posicao.Linha, posicao.Coluna -1); 

            // ao Oeste  
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosPossiveisRei[pos.Linha, pos.Coluna] = true;
            }

            //posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);

            //  Ao Nordeste  
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosPossiveisRei[pos.Linha, pos.Coluna] = true;
            }

            //posicao.DefinirValores(posicao.Linha +1, posicao.Coluna -1);


            //  Ao Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosPossiveisRei[pos.Linha, pos.Coluna] = true;
            }

            //posicao.DefinirValores(posicao.Linha -1, posicao.Coluna-1);

            //  Ao Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosPossiveisRei[pos.Linha, pos.Coluna] = true;
            }

            //posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);

            //  Ao Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Taboleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                movimentosPossiveisRei[pos.Linha, pos.Coluna] = true;
            }

            return movimentosPossiveisRei;

        }


        public override string ToString()
        {
            return "R";
        }
    }
}
