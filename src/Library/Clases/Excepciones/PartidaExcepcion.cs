using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PartidaNoComenzadaException : Exception
    {
        public PartidaNoComenzadaException(string message)
        :base(message)
        {
            
        }
    }
}
