using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using ChessGameConsoleApp.Board.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace ChessGameConsoleApp.Chess;

internal class ChessMatch //test primary constructor
{
    private HashSet<Piece> _pieces;
    private HashSet<Piece> _capturedPieces;
    public int Shift { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public GameBoard? GameBoard { get; private set; }
    public bool Finished { get; private set; }
    public bool Check {  get; private set; }
    
    public ChessMatch()
    {
        GameBoard = new GameBoard(8, 8);
        Shift = 1;
        CurrentPlayer = Color.White;
        Finished = false;
        Check = false;
        _pieces = new HashSet<Piece>();
        _capturedPieces = new HashSet<Piece>();
        PlacePieces();
    }

    public Piece ExecuteMove(Position source, Position target)
    {
        Piece piece = GameBoard!.RemovePiece(source);
        piece.IncrementMoves(); //Talvez precise retirar esta chamada junto com a implementação na classe
        Piece capturedPiece = GameBoard.RemovePiece(target);
        GameBoard.PlacePiece(piece, target);

        if(capturedPiece != null)
            _capturedPieces.Add(capturedPiece);

        return capturedPiece;
    }

    public void UndoMove(Position source, Position target, Piece capturedPiece)
    {
        Piece piece = GameBoard.RemovePiece(target);
        piece.DecreasesMoves();
        
        if (capturedPiece != null)
        {
            GameBoard.PlacePiece(capturedPiece, target);
            _capturedPieces.Remove(capturedPiece);
        }

        GameBoard.PlacePiece(piece, source);
    }

    public void ExecutePlay(Position source, Position target)
    {
        Piece capturedPiece = ExecuteMove(source, target);

        if(InCheck(CurrentPlayer))
        {
            UndoMove(source, target, capturedPiece);
            throw new GameBoardException("Você não pode se colocar em xeque!");
        }

        if (InCheck(Opponent(CurrentPlayer)))
            Check = true;

        if (CheckMateTest(Opponent(CurrentPlayer)))
            Finished = true;
        else
        {
            Shift++;
            ChangePlayer();
        }
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

    public HashSet<Piece> CapturedPieces(Color color)
    {
        HashSet<Piece> aux = new();
        foreach(Piece piece in _capturedPieces)
        {
            if (piece.Color == color)
                aux.Add(piece);
        }
        return aux;
    }

    public HashSet<Piece> PiecesInGame(Color color)
    {
        HashSet<Piece> aux = new HashSet<Piece>();
        foreach (Piece piece in _pieces)
        {
            if (piece.Color == color)
                aux.Add(piece);
        }
        aux.ExceptWith(CapturedPieces(color)); 
        return aux;
    }

    public bool InCheck(Color color)
    {
        Piece k = King(color);

        if (k == null)
            throw new GameBoardException("Não tem rei no tabuleiro!"); 

        foreach(Piece pieces in PiecesInGame(Opponent(color)))
        {
            bool[,] mat = pieces.PossibleMoves();
            if (mat[k.Position.Line, k.Position.Column]) 
                return true;
        }
        return false;
    }

    public bool CheckMateTest(Color color)
    {
        if (!InCheck(color))
            return false;

        foreach(Piece piece in PiecesInGame(color))
        {
            bool[,] mat = piece.PossibleMoves();
            for (int i = 0; i < GameBoard.Lines; i++)
            {
                for (int j = 0; j < GameBoard.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        Position source = piece.Position;
                        Position target = new Position(i, j);
                        Piece capturedPiece = ExecuteMove(source, target);
                        bool checkTest = InCheck(color);
                        UndoMove(source, target, capturedPiece);
                        if (!checkTest)
                            return false;
                    } 
                }
            }
        }
        return true;
    }

    private Piece King(Color color)
    {
        foreach (Piece piece in PiecesInGame(color))
        {
            if (piece is King)
                return piece;
        }
        return null;
    }

    private Color Opponent(Color color)
    {
        if (color == Color.White)
            return Color.Black;

        return Color.White;
    }

    public void PlaceNewPiece(char column, int line, Piece piece)
    {
        GameBoard.PlacePiece(piece, new ChessPosition(column, line).ToPosition());
        _pieces.Add(piece);
    }

    private void PlacePieces()
    {
        PlaceNewPiece('a', 1, new Tower(Color.White, GameBoard));
        PlaceNewPiece('b', 1, new Horse(Color.White, GameBoard));
        PlaceNewPiece('c', 1, new Bishop(Color.White, GameBoard));
        PlaceNewPiece('d', 1, new Queen(Color.White, GameBoard));
        PlaceNewPiece('e', 1, new King(Color.White, GameBoard));
        PlaceNewPiece('f', 1, new Bishop(Color.White, GameBoard));
        PlaceNewPiece('g', 1, new Horse(Color.White, GameBoard));
        PlaceNewPiece('h', 1, new Tower(Color.White, GameBoard));
        PlaceNewPiece('a', 2, new Pawn(Color.White, GameBoard));
        PlaceNewPiece('b', 2, new Pawn(Color.White, GameBoard));
        PlaceNewPiece('c', 2, new Pawn(Color.White, GameBoard));
        PlaceNewPiece('d', 2, new Pawn(Color.White, GameBoard));
        PlaceNewPiece('e', 2, new Pawn(Color.White, GameBoard));
        PlaceNewPiece('f', 2, new Pawn(Color.White, GameBoard));
        PlaceNewPiece('g', 2, new Pawn(Color.White, GameBoard));
        PlaceNewPiece('h', 2, new Pawn(Color.White, GameBoard));

        PlaceNewPiece('a', 8, new Tower(Color.Black, GameBoard));
        PlaceNewPiece('b', 8, new Horse(Color.Black, GameBoard));
        PlaceNewPiece('c', 8, new Bishop(Color.Black, GameBoard));
        PlaceNewPiece('d', 8, new Queen(Color.Black, GameBoard));
        PlaceNewPiece('e', 8, new King(Color.Black, GameBoard));
        PlaceNewPiece('f', 8, new Bishop(Color.Black, GameBoard));
        PlaceNewPiece('g', 8, new Horse(Color.Black, GameBoard));
        PlaceNewPiece('h', 8, new Tower(Color.Black, GameBoard));
        PlaceNewPiece('a', 7, new Pawn(Color.Black, GameBoard));
        PlaceNewPiece('b', 7, new Pawn(Color.Black, GameBoard));
        PlaceNewPiece('c', 7, new Pawn(Color.Black, GameBoard));
        PlaceNewPiece('d', 7, new Pawn(Color.Black, GameBoard));
        PlaceNewPiece('e', 7, new Pawn(Color.Black, GameBoard));
        PlaceNewPiece('f', 7, new Pawn(Color.Black, GameBoard));
        PlaceNewPiece('g', 7, new Pawn(Color.Black, GameBoard));
        PlaceNewPiece('h', 7, new Pawn(Color.Black, GameBoard));
    }
}
