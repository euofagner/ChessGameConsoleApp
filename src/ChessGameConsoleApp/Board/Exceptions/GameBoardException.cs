using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Board.Exceptions;

internal class GameBoardException : Exception
{
    public GameBoardException(string msg) : base(msg) { }
}
