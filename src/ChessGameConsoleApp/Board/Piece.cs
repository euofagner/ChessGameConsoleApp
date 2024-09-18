using System;
using ChessGameConsoleApp.Board.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Board;

internal abstract  class Piece(Color color, GameBoard gameBoard)
{
    public Position? Position { get; set; } = null;
    public Color Color { get; protected set; } = color;
    public int Moves { get; protected set; }
    public GameBoard? GameBoard { get; protected set; } = gameBoard;

    public void IncrementMoves()
    {
        Moves++;
    }

    public void DecreasesMoves()
    {
        Moves--;
    }

    public bool ExistPossibleMoves()
    {
        bool[,] mat = PossibleMoves();

        for (int i = 0; i < GameBoard.Lines; i++)
        {
            for (int j = 0; j < GameBoard.Columns; j++)
            {
                if (mat[i, j])
                    return true;
            }
        }
        return false;
    }

    public bool CanMoveTo(Position pos)
    {
        return PossibleMoves()[pos.Line, pos.Column];
    }

    public abstract bool[,] PossibleMoves();
}
