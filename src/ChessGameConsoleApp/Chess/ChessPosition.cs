using ChessGameConsoleApp.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Chess;

internal class ChessPosition(char column, int line)
{
    public char Column { get; private set; } = column;
    public int Line { get; private set; } = line;
    
    public Position ToPosition()
    {
        return new Position(8 - Line, Column - 'a');
    }

    public override string ToString()
    {
        return $"{Column}{Line}";
    }
}
