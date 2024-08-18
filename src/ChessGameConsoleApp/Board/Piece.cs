using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Board;

internal class Piece(Position position, Color color, Board board)
{
    public Position? Position { get; set; } = position;
    public Color Color { get; protected set; } = color;
    public int Moves { get; protected set; }
    public Board? Board { get; protected set; } = board;
}
