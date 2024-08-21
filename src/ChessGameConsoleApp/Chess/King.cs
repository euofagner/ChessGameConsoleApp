using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Chess;

internal class King : Piece
{
    public King(Color color, GameBoard gameBoard) : base(color, gameBoard) { }

    public override string ToString()
    {
        return "R";
    }
}
