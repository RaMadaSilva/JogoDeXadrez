using System;
using XadresConsole.Mesa;
using XadresConsole.Mesa.Enums;

namespace XadresConsole.Xadres
{
    class Rei : Peca
    {
        private PartidaXadres _partida; 
        public Rei(Cor cor, Taboleiro taboleiro, PartidaXadres partida) : base(cor, taboleiro)
        {
            _partida = partida; 
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Taboleiro.TabuleiroJogo(pos);
            return p != null && p is Torre && p.Cor == Cor & p.QtdMoviemento == 0; 
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

            //#Jogada Especial roque
            if(QtdMoviemento ==0 && !_partida.Xeque)
            {
                //Jogada Especial Roque Pequeno 
                Posicao posicaoTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posicaoTorre1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2); 
                    if(Taboleiro.TabuleiroJogo(p1)==null && Taboleiro.TabuleiroJogo(p2) == null)
                    {
                        movimentosPossiveisRei[Posicao.Linha, Posicao.Coluna + 2] = true; 
                    }
                }

                //Jogada Especial Roque Grande 
                Posicao posicaoTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna -4);
                if (TesteTorreParaRoque(posicaoTorre1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna -3);
                    if (Taboleiro.TabuleiroJogo(p1) == null && Taboleiro.TabuleiroJogo(p2) == null && Taboleiro.TabuleiroJogo(p3) == null)
                    {
                        movimentosPossiveisRei[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }


            }

            return movimentosPossiveisRei;

        }


        public override string ToString()
        {
            return "R";
        }
    }
}
