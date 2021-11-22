using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadresConsole.taboleiro
{
    class TaboleiroExcepton : Exception
    {
        public TaboleiroExcepton(string smg) : base(smg)
        {

        }
    }
}
