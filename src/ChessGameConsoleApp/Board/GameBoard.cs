using ChessGameConsoleApp.Board.Exceptions;
using ChessGameConsoleApp.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Board;

internal class GameBoard(int lines, int columns)
{
    private Piece[,]? _pieces = new Piece[lines, columns];
    public int Lines { get; set; } = lines;
    public int Columns { get; set; } = columns;

    public Piece Piece(int line, int column)
    {
        return _pieces![line, column];
    }

    public Piece Piece(Position pos)
    {
        return _pieces![pos.Line, pos.Column];
    }

    public bool ExistPiece(Position pos)
    {
        ValidatePosition(pos);
        return Piece(pos) != null;
    }

    public void PlacePiece(Piece piece, Position pos)
    {
        if (ExistPiece(pos))
            throw new GameBoardException("Já existe peça nessa posição!");

        _pieces![pos.Line, pos.Column] = piece;
        piece.Position = pos;
    }

    public Piece RemovePiece(Position pos)
    {
        if (Piece(pos) == null)
            return null;

        Piece aux = Piece(pos);
        aux.Position = null;
        _pieces![pos.Line, pos.Column] = null;
        return aux;
    }

    public bool ValidPosition(Position pos)
    {
        if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            return false;

        return true;
    }

    public void ValidatePosition(Position pos)
    {
        if (!ValidPosition(pos))
            throw new GameBoardException("Posição inválida!");
    }
}
