using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace ChessGameConsoleApp.Board;

internal class Position(int line, int column)
{
    public int Line { get; set; } = line;
    public int Column { get; set; } = column;

    public override string ToString()
    {
        return $"{Line}, {Column}";
    }
}
