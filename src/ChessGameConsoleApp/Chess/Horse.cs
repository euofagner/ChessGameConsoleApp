using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Chess;

internal class Horse(Color color, GameBoard gameBoard) : Piece(color, gameBoard)
{
    private bool CanMove(Position pos)
    {
        Piece piece = gameBoard.Piece(pos);
        return piece == null || piece.Color != color;
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] mat = new bool[gameBoard.Lines, gameBoard.Columns];

        Position pos = new Position(0, 0);

        pos.SetValues(Position.Line - 1, Position.Column - 2);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
            mat[pos.Line, pos.Column] = true;

        pos.SetValues(Position.Line - 2, Position.Column - 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
            mat[pos.Line, pos.Column] = true;

        pos.SetValues(Position.Line - 2, Position.Column + 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
            mat[pos.Line, pos.Column] = true;

        pos.SetValues(Position.Line - 1, Position.Column + 2);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
            mat[pos.Line, pos.Column] = true;

        pos.SetValues(Position.Line + 1, Position.Column + 2);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
            mat[pos.Line, pos.Column] = true;

        pos.SetValues(Position.Line + 2, Position.Column + 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
            mat[pos.Line, pos.Column] = true;

        pos.SetValues(Position.Line + 2, Position.Column - 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
            mat[pos.Line, pos.Column] = true;

        pos.SetValues(Position.Line +1, Position.Column - 2);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
            mat[pos.Line, pos.Column] = true;

        return mat;
    }

    public override string ToString()
    {
        return "C";
    }
}
