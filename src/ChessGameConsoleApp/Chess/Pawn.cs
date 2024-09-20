using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Chess
{
    internal class Pawn(Color color, GameBoard gameBoard, ChessMatch match) : Piece(color, gameBoard)
    {
        private ChessMatch _match = match;

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
                pos.SetValues(Position.Line - 1, Position.Column);
                if (gameBoard.ValidPosition(pos) && CanMove(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(Position.Line - 2, Position.Column); 
                if (gameBoard.ValidPosition(pos) && CanMove(pos) && Moves == 0)
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(Position.Line - 1, Position.Column - 1);
                if (gameBoard.ValidPosition(pos) && ExistOpponent(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(Position.Line - 1, Position.Column + 1);
                if (gameBoard.ValidPosition(pos) && ExistOpponent(pos))
                    mat[pos.Line, pos.Column] = true;

                //Special move En Passant
                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if(gameBoard.ValidPosition(left) && ExistOpponent(left) && gameBoard.Piece(left) == _match.VulnerableEnPassant)
                    { 
                        mat[left.Line - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (gameBoard.ValidPosition(right) && ExistOpponent(right) && gameBoard.Piece(right) == _match.VulnerableEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.SetValues(Position.Line + 1, Position.Column);
                if (gameBoard.ValidPosition(pos) && CanMove(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(Position.Line + 2, Position.Column);
                if (gameBoard.ValidPosition(pos) && CanMove(pos) && Moves == 0)
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(Position.Line + 1, Position.Column - 1);
                if (gameBoard.ValidPosition(pos) && ExistOpponent(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetValues(Position.Line + 1, Position.Column + 1);
                if (gameBoard.ValidPosition(pos) && ExistOpponent(pos))
                    mat[pos.Line, pos.Column] = true;

                //Special move En Passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (gameBoard.ValidPosition(left) && ExistOpponent(left) && gameBoard.Piece(left) == _match.VulnerableEnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (gameBoard.ValidPosition(right) && ExistOpponent(right) && gameBoard.Piece(right) == _match.VulnerableEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }
            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
