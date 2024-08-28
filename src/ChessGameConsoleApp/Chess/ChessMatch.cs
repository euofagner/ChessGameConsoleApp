using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using ChessGameConsoleApp.Board.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChessGameConsoleApp.Chess;

internal class ChessMatch //test primary constructor
{
    public int Shift { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public GameBoard? GameBoard { get; private set; }
    public bool Finished { get; private set; }
    
    public ChessMatch()
    {
        GameBoard = new GameBoard(8, 8);
        Shift = 1;
        CurrentPlayer = Color.White;
        Finished = false;
        PlacePieces();
    }

    public void ExecuteMove(Position source, Position target)
    {
        Piece piece = GameBoard!.RemovePiece(source);
        piece.IncrementMoves(); //Talvez precise retirar esta chamada junto com a implementação na classe
        Piece capturedPiece = GameBoard.RemovePiece(target);
        GameBoard.PlacePiece(piece, target);
    }

    public void ExecutePlay(Position source, Position target)
    {
        ExecuteMove(source, target);
        Shift++;
        ChangePlayer();
    }

    public void ValidateSourcePosition(Position pos) 
    {
        if (GameBoard.Piece(pos) == null)
            throw new GameBoardException("Não existe peça na posição de origem escolhida!");

        if (CurrentPlayer != GameBoard.Piece(pos).Color)
            throw new GameBoardException("A peça de origem escolhida não é sua!");

        if (!GameBoard.Piece(pos).ExistPossibleMoves())
            throw new GameBoardException("Não há movimentos possíveis para a peça de origem escolhida!");
    }

    public void ValidateTargetPosition(Position source, Position target)
    {
        if (!GameBoard.Piece(source).CanMoveTo(target))
            throw new GameBoardException("Posição de destino inválida!");
    }   

    private void ChangePlayer()
    {
        if(CurrentPlayer == Color.White)
            CurrentPlayer = Color.Black;
        else 
            CurrentPlayer = Color.White;
    }

    private void PlacePieces()
    {
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('c', 1).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('c', 2).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('d', 2).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('e', 2).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.White, GameBoard), new ChessPosition('e', 1).ToPosition());
        GameBoard.PlacePiece(new King(Color.White, GameBoard), new ChessPosition('d', 1).ToPosition());

        GameBoard.PlacePiece(new Tower(Color.Black, GameBoard), new ChessPosition('c', 8).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.Black, GameBoard), new ChessPosition('c', 7).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.Black, GameBoard), new ChessPosition('d', 7).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.Black, GameBoard), new ChessPosition('e', 7).ToPosition());
        GameBoard.PlacePiece(new Tower(Color.Black, GameBoard), new ChessPosition('e', 8).ToPosition());
        GameBoard.PlacePiece(new King(Color.Black, GameBoard), new ChessPosition('d', 8).ToPosition());
    }
}
