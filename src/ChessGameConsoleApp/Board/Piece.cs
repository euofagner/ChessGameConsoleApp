using System;
using ChessGameConsoleApp.Board.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Board;

internal abstract  class Piece(Color color, GameBoard board)
{
    public Position? Position { get; set; } = null;
    public Color Color { get; protected set; } = color;
    public int Moves { get; protected set; }
    public GameBoard? GameBoard { get; protected set; } = board;

    public void IncrementMoves()
    {
        Moves++;
    }

    public abstract bool[,] PossibleMoves();
}
