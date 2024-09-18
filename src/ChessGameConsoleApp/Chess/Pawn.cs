using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Chess
{
    internal class Pawn(Color color, GameBoard gameBoard) : Piece(color, gameBoard)
    {
        private bool ExistOpponent(Position pos)
        {
            Piece piece = gameBoard.Piece(pos);
            return piece != null && piece.Color != color;
        }

        private bool CanMove(Position pos)
        {
            return gameBoard.Piece(pos) == null;
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[gameBoard.Lines, gameBoard.Columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.SetValues(pos.Line - 1, pos.Column);
                if (gameBoard.ValidPosition(pos) && CanMove(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(pos.Line - 2, pos.Column);
                if (gameBoard.ValidPosition(pos) && CanMove(pos) && Moves == 0)
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(pos.Line - 1, pos.Column - 1);
                if (gameBoard.ValidPosition(pos) && ExistOpponent(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(pos.Line - 1, pos.Column + 1);
                if (gameBoard.ValidPosition(pos) && ExistOpponent(pos))
                    mat[pos.Line, pos.Column] = true;
            }
            else
            {
                pos.SetValues(pos.Line + 1, pos.Column);
                if (gameBoard.ValidPosition(pos) && CanMove(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(pos.Line + 2, pos.Column);
                if (gameBoard.ValidPosition(pos) && CanMove(pos) && Moves == 0)
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(pos.Line + 1, pos.Column - 1);
                if (gameBoard.ValidPosition(pos) && ExistOpponent(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(pos.Line + 1, pos.Column + 1);
                if (gameBoard.ValidPosition(pos) && ExistOpponent(pos))
                    mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
