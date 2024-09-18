using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Chess;

internal class Queen(Color color, GameBoard gameBoard) : Piece(color, gameBoard)
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

        //Left
        pos.SetValues(Position.Line, Position.Column - 1);
        while (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
            if (gameBoard.Piece(pos) != null || gameBoard.Piece(pos).Color != color)
                break;

            pos.SetValues(pos.Line, pos.Column - 1);
        }

        //Right
        pos.SetValues(Position.Line, Position.Column + 1);
        while (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
            if (gameBoard.Piece(pos) != null || gameBoard.Piece(pos).Color != color)
                break;

            pos.SetValues(pos.Line, pos.Column + 1);
        }

        //Up
        pos.SetValues(Position.Line - 1, Position.Column);
        while (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
            if (gameBoard.Piece(pos) != null || gameBoard.Piece(pos).Color != color)
                break;

            pos.SetValues(pos.Line - 1, pos.Column);
        }

        //Down
        pos.SetValues(Position.Line + 1, Position.Column);
        while (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
            if (gameBoard.Piece(pos) != null || gameBoard.Piece(pos).Color != color)
                break;

            pos.SetValues(pos.Line + 1, pos.Column);
        }

        //NO
        pos.SetValues(Position.Line - 1, Position.Column - 1);
        while (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
            if (gameBoard.Piece(pos) != null || gameBoard.Piece(pos).Color != color)
                break;

            pos.SetValues(pos.Line - 1, pos.Column - 1);
        }

        //NE
        pos.SetValues(Position.Line - 1, Position.Column + 1);
        while (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
            if (gameBoard.Piece(pos) != null || gameBoard.Piece(pos).Color != color)
                break;

            pos.SetValues(pos.Line - 1, pos.Column + 1);
        }

        //SE
        pos.SetValues(Position.Line + 1, Position.Column + 1);
        while (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
            if (gameBoard.Piece(pos) != null || gameBoard.Piece(pos).Color != color)
                break;

            pos.SetValues(pos.Line + 1, pos.Column + 1);
        }

        //SO
        pos.SetValues(Position.Line + 1, Position.Column - 1);
        while (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
            if (gameBoard.Piece(pos) != null || gameBoard.Piece(pos).Color != color)
                break;

            pos.SetValues(pos.Line + 1, pos.Column - 1);
        }

        return mat;
    }

    public override string ToString()
    {
        return "D";
    }
}
