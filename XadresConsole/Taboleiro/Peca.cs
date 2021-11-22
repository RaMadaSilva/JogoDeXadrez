using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadresConsole.taboleiro.Enums; 

namespace XadresConsole.taboleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMoviemento { get; protected set; }
        public Taboleiro Taboleiro { get; protected set; }

        public Peca(Cor cor, Taboleiro taboleiro)
        {
            Posicao = null;
            Cor = cor;
            Taboleiro = taboleiro;
            QtdMoviemento = 0; 
        }
    }
}
