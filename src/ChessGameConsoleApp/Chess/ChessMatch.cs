using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Chess;

internal class ChessMatch //test primary constructor
{
    private int _shift;
    private Color _currentPlayer;
    public GameBoard? GameBoard { get; private set; }
    public bool Finished { get; private set; }
    
    public ChessMatch()
    {
        GameBoard = new GameBoard(8, 8);
        _shift = 1;
        _currentPlayer = Color.White;
        Finished = false;
        PlacePieces();
    }

    public void ExecuteMove(Position source, Position target)
    {
        Piece piece = GameBoard!.RemovePiece(source);
        piece.IncrementMoves();
        Piece capturedPiece = GameBoard.RemovePiece(target);
        GameBoard.PlacePiece(piece, target);
    }

    private void PlacePieces()
    {
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('c', 1).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('c', 2).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('d', 2).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('e', 2).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('e', 1).ToPosition());
        GameBoard.PlacePiece(new King(Color.Black, GameBoard), new ChessPosition('d', 1).ToPosition());
    }
}
