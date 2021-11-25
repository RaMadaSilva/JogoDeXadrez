using System;
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

        public PartidaXadres()
        {
            Taboleiro = new Taboleiro(8, 8);
            Turno = 1;
            JogadorActual = Cor.Branca;
            ColocarPeca();
            Terminada = false; 
        }

        private void ColocarPeca()
        {

            Taboleiro.ColocarPeca(new Torre(Cor.Branca, Taboleiro), new PosicaoXadrez('c', 1).ToPosicao());
            Taboleiro.ColocarPeca(new Torre(Cor.Branca, Taboleiro), new PosicaoXadrez('c', 2).ToPosicao());
            Taboleiro.ColocarPeca(new Torre(Cor.Branca, Taboleiro), new PosicaoXadrez('d', 2).ToPosicao());
            Taboleiro.ColocarPeca(new Torre(Cor.Branca, Taboleiro), new PosicaoXadrez('e', 2).ToPosicao());
            Taboleiro.ColocarPeca(new Torre(Cor.Branca, Taboleiro), new PosicaoXadrez('e', 1).ToPosicao());
            Taboleiro.ColocarPeca(new Rei(Cor.Branca, Taboleiro), new PosicaoXadrez('d', 1).ToPosicao());

            Taboleiro.ColocarPeca(new Torre(Cor.Preta, Taboleiro), new PosicaoXadrez('c', 7).ToPosicao());
            Taboleiro.ColocarPeca(new Torre(Cor.Preta, Taboleiro), new PosicaoXadrez('c', 8).ToPosicao());
            Taboleiro.ColocarPeca(new Torre(Cor.Preta, Taboleiro), new PosicaoXadrez('d', 7).ToPosicao());
            Taboleiro.ColocarPeca(new Torre(Cor.Preta, Taboleiro), new PosicaoXadrez('e', 7).ToPosicao());
            Taboleiro.ColocarPeca(new Torre(Cor.Preta, Taboleiro), new PosicaoXadrez('e', 8).ToPosicao());
            Taboleiro.ColocarPeca(new Rei(Cor.Preta, Taboleiro), new PosicaoXadrez('d', 8).ToPosicao());

        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Taboleiro.RemoverPeca(origem);
            peca.IncrementarMovimento();
            Peca pecaCapturada = Taboleiro.RemoverPeca(destino);
            Taboleiro.ColocarPeca(peca, destino); 
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
