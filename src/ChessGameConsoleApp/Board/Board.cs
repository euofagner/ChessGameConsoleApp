using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Board;

internal class Board(int lines, int columns)
{
    private Piece[,]? _pieces = new Piece[lines, columns];
    public int Lines { get; set; } = lines;
    public int Columns { get; set; } = columns;
}
