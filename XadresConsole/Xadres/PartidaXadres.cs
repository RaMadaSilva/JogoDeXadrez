using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadresConsole.taboleiro;
using XadresConsole.taboleiro.Enums; 

namespace XadresConsole.Xadres
{
    class PartidaXadres
    {
        private int _turno;
        private Cor _jogadorActual;
        public Taboleiro  Taboleiro{ get; private set; }
        public bool Terminada { get; private set;  }

        public PartidaXadres()
        {
            Taboleiro = new Taboleiro(8, 8);
            _turno = 1;
            _jogadorActual = Cor.Branca;
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

       
    }
}
