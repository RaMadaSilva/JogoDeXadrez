using System;
using System.Collections.Generic;
using XadresConsole.Mesa;
using XadresConsole.Mesa.Enums; 

namespace XadresConsole.Xadres
{
    class PartidaXadres
    {
        public int Turno { get; private set;  }
        public Cor JogadorActual { get; private set; }
        public Taboleiro  Taboleiro{ get; private set; }
        public bool Terminada { get; private set;  }

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
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>(); 
            foreach(Peca peca in _pecasCapturadas)
            {
                if(peca.Cor == cor)
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

            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Taboleiro));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branca, Taboleiro));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branca, Taboleiro));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branca, Taboleiro));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branca, Taboleiro));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Taboleiro));

            ColocarNovaPeca('c', 7, new Torre(Cor.Preta, Taboleiro));
            ColocarNovaPeca('c', 8, new Torre(Cor.Preta, Taboleiro));
            ColocarNovaPeca('d', 7, new Torre(Cor.Preta, Taboleiro));
            ColocarNovaPeca('e', 7, new Torre(Cor.Preta, Taboleiro));
            ColocarNovaPeca('e', 8, new Torre(Cor.Preta, Taboleiro));
            ColocarNovaPeca('d', 8, new Rei(Cor.Preta, Taboleiro));

        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Taboleiro.RemoverPeca(origem);
            peca.IncrementarMovimento();
            Peca pecaCapturada = Taboleiro.RemoverPeca(destino);
            Taboleiro.ColocarPeca(peca, destino); 

            if(pecaCapturada!= null)
            {
                _pecasCapturadas.Add(pecaCapturada); 
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudaJogador(); 

        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if(Taboleiro.TabuleiroJogo(pos)== null)
            {
                throw new TaboleiroExcepton("Não existe peça na posição origem escolhida!"); 
            }
            if(JogadorActual != Taboleiro.TabuleiroJogo(pos).Cor)
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
            if (!Taboleiro.TabuleiroJogo(origem).PodeMoverPara(destino))
            {
                throw new TaboleiroExcepton("Posição Invalida!"); 
            }
        }

        private void MudaJogador()
        {
            if(JogadorActual == Cor.Branca)
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
