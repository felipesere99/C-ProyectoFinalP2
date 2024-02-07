using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class PartidaLlenaException : Exception
{
    public PartidaLlenaException(string message) : base(message)
    {
    }
}