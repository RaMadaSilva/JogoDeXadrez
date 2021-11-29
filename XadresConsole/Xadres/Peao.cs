using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadresConsole.Mesa;
using XadresConsole.Mesa.Enums;

namespace XadresConsole.Xadres
{
    class Peao : Peca
    {
        private PartidaXadres _Partida; 
        public Peao(Cor cor, Taboleiro tab, PartidaXadres partida) : base(cor, tab)
        {
            _Partida = partida; 

        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Taboleiro.TabuleiroJogo(pos);
            return p != null && p.Cor != Cor; 
        }

        private bool Livre(Posicao pos)
        {
            return Taboleiro.TabuleiroJogo(pos) == null; 
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Taboleiro.Linhas, Taboleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Taboleiro.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Taboleiro.PosicaoValida(p2) && Livre(p2) && Taboleiro.PosicaoValida(pos) && Livre(pos) && QtdMoviemento == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Taboleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Taboleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //#Jogada Especial en passant

                if(Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1); 
                    if(Taboleiro.PosicaoValida(esquerda)&& ExisteInimigo(esquerda) && Taboleiro.TabuleiroJogo(esquerda) == _Partida.VulneraravelEnPassant)
                    {
                        mat[esquerda.Linha -1, esquerda.Coluna] = true; 
                    }
                }

                if (Posicao.Linha == 3)
                {
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Taboleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Taboleiro.TabuleiroJogo(direita) == _Partida.VulneraravelEnPassant)
                    {
                        mat[direita.Linha -1 , direita.Coluna] = true;
                    }
                }

            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Taboleiro.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Taboleiro.PosicaoValida(p2) && Livre(p2) && Taboleiro.PosicaoValida(pos) && Livre(pos) && QtdMoviemento == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Taboleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Taboleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //#Jogada Especial en passant

                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Taboleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Taboleiro.TabuleiroJogo(esquerda) == _Partida.VulneraravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                }

                if (Posicao.Linha == 4)
                {
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Taboleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Taboleiro.TabuleiroJogo(direita) == _Partida.VulneraravelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
