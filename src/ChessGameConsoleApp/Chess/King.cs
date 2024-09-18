using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Chess;

internal class King(Color color, GameBoard gameBoard, ChessMatch match) : Piece(color, gameBoard)
{
    private ChessMatch _match = match;

    private bool CanMove(Position pos)
    {
        Piece piece = gameBoard.Piece(pos);
        return piece == null || piece.Color != color;
    }

    private bool TestTowerToRock(Position pos)
    {
        Piece piece = GameBoard.Piece(pos);
        return piece != null && piece is Tower && piece.Color == color && Moves == 0;  
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] mat = new bool[gameBoard.Lines, gameBoard.Columns];

        Position pos = new Position(0, 0);

        //up
        pos.SetValues(Position.Line - 1, Position.Column);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line - 1, Position.Column + 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line, Position.Column + 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line + 1, Position.Column + 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line + 1, Position.Column);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line + 1, Position.Column - 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line, Position.Column - 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line - 1, Position.Column - 1);
        if (gameBoard.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        //Special move
        if (Moves == 0 && !_match.Check)
        {
            //Small rock
            Position smallRockTowerPosition = new Position(Position.Line, Position.Column + 3);
            if (TestTowerToRock(smallRockTowerPosition))
            {
                Position pos1 = new(Position.Line, Position.Column + 1);
                Position pos2 = new(Position.Line, Position.Column + 2);

                if (GameBoard.Piece(pos1) == null && GameBoard.Piece(pos2) == null)
                {
                    mat[Position.Line, Position.Column + 2] = true;
                }
            }

            //Big rock
            Position bigRockTowerPosition = new Position(Position.Line, Position.Column - 4);
            if (TestTowerToRock(bigRockTowerPosition))
            {
                Position pos1 = new(Position.Line, Position.Column - 1);
                Position pos2 = new(Position.Line, Position.Column - 2);
                Position pos3 = new(Position.Line, Position.Column - 3);

                if (GameBoard.Piece(pos1) == null && GameBoard.Piece(pos2) == null && GameBoard.Piece(pos3) == null)
                {
                    mat[Position.Line, Position.Column - 2] = true;
                }
            }
        }

        return mat;
    }

    public override string ToString()
    {
        return "R";
    }
}
