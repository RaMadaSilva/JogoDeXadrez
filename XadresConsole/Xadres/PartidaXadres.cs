using System;
using System.Collections.Generic;
using XadresConsole.Mesa;
using XadresConsole.Mesa.Enums;

namespace XadresConsole.Xadres
{
    class PartidaXadres
    {
        public int Turno { get; private set; }
        public Cor JogadorActual { get; private set; }
        public Taboleiro Taboleiro { get; private set; }
        public bool Terminada { get; private set; }

        public bool Xeque { get; private set; }

        private HashSet<Peca> _pecas;
        private HashSet<Peca> _pecasCapturadas;

        public PartidaXadres()
        {
            Taboleiro = new Taboleiro(8, 8);
            Turno = 1;
            JogadorActual = Cor.Branca;
            _pecas = new HashSet<Peca>();
            _pecasCapturadas = new HashSet<Peca>();

            ColocarPeca();
            Terminada = false;
            Xeque = false;
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in _pecasCapturadas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in _pecas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Taboleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            _pecas.Add(peca);

        }

        private void ColocarPeca()
        {

            ColocarNovaPeca('a', 1, new Torre(Cor.Branca, Taboleiro));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branca, Taboleiro));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branca, Taboleiro));
            ColocarNovaPeca('d', 1, new Dama(Cor.Branca, Taboleiro));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branca, Taboleiro, this));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branca, Taboleiro));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branca, Taboleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branca, Taboleiro));
            ColocarNovaPeca('a', 2, new Peao(Cor.Branca, Taboleiro, this));
            ColocarNovaPeca('b', 2, new Peao(Cor.Branca, Taboleiro, this));
            ColocarNovaPeca('c', 2, new Peao(Cor.Branca, Taboleiro, this));
            ColocarNovaPeca('d', 2, new Peao(Cor.Branca, Taboleiro, this));
            ColocarNovaPeca('e', 2, new Peao(Cor.Branca, Taboleiro, this));
            ColocarNovaPeca('f', 2, new Peao(Cor.Branca, Taboleiro, this));
            ColocarNovaPeca('g', 2, new Peao(Cor.Branca, Taboleiro, this));
            ColocarNovaPeca('h', 2, new Peao(Cor.Branca, Taboleiro, this));

            ColocarNovaPeca('a', 8, new Torre(Cor.Preta, Taboleiro));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Preta, Taboleiro));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Preta, Taboleiro));
            ColocarNovaPeca('d', 8, new Dama(Cor.Preta, Taboleiro));
            ColocarNovaPeca('e', 8, new Rei(Cor.Preta, Taboleiro, this));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Preta, Taboleiro));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Preta, Taboleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.Preta, Taboleiro));
            ColocarNovaPeca('a', 7, new Peao(Cor.Preta, Taboleiro, this));
            ColocarNovaPeca('b', 7, new Peao(Cor.Preta, Taboleiro, this));
            ColocarNovaPeca('c', 7, new Peao(Cor.Preta, Taboleiro, this));
            ColocarNovaPeca('d', 7, new Peao(Cor.Preta, Taboleiro, this));
            ColocarNovaPeca('e', 7, new Peao(Cor.Preta, Taboleiro, this));
            ColocarNovaPeca('f', 7, new Peao(Cor.Preta, Taboleiro, this));
            ColocarNovaPeca('g', 7, new Peao(Cor.Preta, Taboleiro, this));
            ColocarNovaPeca('h', 7, new Peao(Cor.Preta, Taboleiro, this));
        }

        public Peca ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Taboleiro.RemoverPeca(origem);
            peca.IncrementarMovimento();
            Peca pecaCapturada = Taboleiro.RemoverPeca(destino);
            Taboleiro.ColocarPeca(peca, destino);

            if (pecaCapturada != null)
            {
                _pecasCapturadas.Add(pecaCapturada);
            }

            //#Jogada Especial Roque Pequeno
            if(peca is Rei && destino.Coluna ==origem.Coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);

                Peca T = Taboleiro.RemoverPeca(origemTorre);
                T.IncrementarMovimento();
                Taboleiro.ColocarPeca(T, destinoTorre); 
            }


            //#Jogada Especial Roque Grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);

                Peca T = Taboleiro.RemoverPeca(origemTorre);
                T.IncrementarMovimento();
                Taboleiro.ColocarPeca(T, destinoTorre);
            }

            return pecaCapturada;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca PecaRei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = PecaRei(cor);

            if (R == null)
            {
                throw new TaboleiroExcepton("Não tem rei da cor " + cor + "no taboleiro");
            }

            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {

                bool[,] mat = x.MovimentosPossiveis();

                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }

            return false;
        }
        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Taboleiro.RemoverPeca(destino);
            p.DecrementarMovimento();
            if (pecaCapturada != null)
            {
                Taboleiro.ColocarPeca(pecaCapturada, destino);
                _pecasCapturadas.Remove(pecaCapturada);
            }
            Taboleiro.ColocarPeca(p, origem);

            //#Jogada Especial Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);

                Peca T = Taboleiro.RemoverPeca(destinoTorre);
                T.DecrementarMovimento();
                Taboleiro.ColocarPeca(T, origemTorre);
            }

            //#Jogada Especial Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);

                Peca T = Taboleiro.RemoverPeca(destinoTorre);
                T.IncrementarMovimento();
                Taboleiro.ColocarPeca(T, origemTorre);

            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutarMovimento(origem, destino);

            if (EstaEmXeque(JogadorActual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TaboleiroExcepton("Voce não pode se colocar em xeque! ");
            }
            if (EstaEmXeque(Adversaria(JogadorActual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false; 
            }

            if (TesteXequeMate(Adversaria(JogadorActual)))
            {
                Terminada = true; 
            }

            Turno++;
            MudaJogador();

        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Taboleiro.TabuleiroJogo(pos) == null)
            {
                throw new TaboleiroExcepton("Não existe peça na posição origem escolhida!");
            }
            if (JogadorActual != Taboleiro.TabuleiroJogo(pos).Cor)
            {
                throw new TaboleiroExcepton("A peça de Origem escolhida não é tua!");
            }
            if (!Taboleiro.TabuleiroJogo(pos).ExisteMovimetosPossiveis(pos))
            {
                throw new TaboleiroExcepton("Não há movimentos possivies para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Taboleiro.TabuleiroJogo(origem).MovimentoPossivel(destino))
            {
                throw new TaboleiroExcepton("Posição Invalida!");
            }
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false; 
            }
            foreach(Peca p in PecasEmJogo(cor))
            {
                bool[,] mat = p.MovimentosPossiveis(); 
                for(int i=0; i<Taboleiro.Linhas; i++)
                {
                    for(int j=0; j<Taboleiro.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = p.Posicao; 
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutarMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false; 
                            }
                        }
                    }
                }

            }

            return true; 
        }

        private void MudaJogador()
        {
            if (JogadorActual == Cor.Branca)
            {
                JogadorActual = Cor.Preta;
            }
            else
            {
                JogadorActual = Cor.Branca;
            }
        }
    }
}
