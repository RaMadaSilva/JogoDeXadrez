using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadresConsole.Mesa.Enums; 

namespace XadresConsole.Mesa
{
    abstract class  Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMoviemento { get; protected set; }
        public Taboleiro Taboleiro { get; protected set; }

        public Peca(Cor cor, Taboleiro tab)
        {
            Posicao = null;
            Cor = cor;
            Taboleiro = tab;
            QtdMoviemento = 0; 
        }

        public void IncrementarMovimento()
        {
            QtdMoviemento++; 
        }


        public bool PodeMover(Posicao pos)
        {
            bool move; 
            Peca p = Taboleiro.TabuleiroJogo(pos);
            move = (p == null || p.Cor != Cor); 
            return move ;
        }

        public abstract bool[,] MovimentosPossiveis(Posicao posicao); 
    }
}
