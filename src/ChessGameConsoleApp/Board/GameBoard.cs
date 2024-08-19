using System;
using System.Collections.Generic;
using System.Linq;
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
        return _pieces[line, column];
    }

    public void PlacePiece(Piece piece, Position position)
    {
        _pieces![position.Line, position.Column] = piece;
        piece.Position = position;
    }
}
