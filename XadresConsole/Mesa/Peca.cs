using System;
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

        public bool ExisteMovimetosPossiveis(Posicao pos)
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i=0; i<Taboleiro.Linhas; i++)
            {
                for(int j=0; j<Taboleiro.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true; 
                    }
                }
            }

            return false; 
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna]; 
        }

        public abstract bool[,] MovimentosPossiveis(); 
    }
}
