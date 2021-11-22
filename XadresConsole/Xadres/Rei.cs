using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadresConsole.taboleiro;
using XadresConsole.taboleiro.Enums;

namespace XadresConsole.Xadres 
{
    class Rei : Peca
    {
        public Rei(Cor cor, Taboleiro taboleiro) : base(cor, taboleiro)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
