using ChessGameConsoleApp;
using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using ChessGameConsoleApp.Board.Exceptions;
using ChessGameConsoleApp.Chess;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

try
{
    ChessMatch chessMatch = new ChessMatch();
    while (!chessMatch.Finished)
    {
        Console.Clear();
        Display.DisplayGameBoard(chessMatch.GameBoard!);

        Console.WriteLine();
        Console.Write("Origem: ");
        Position source = Display.ReadChessPosition().ToPosition();

        bool[,] possiblePositions = chessMatch.GameBoard!.Piece(source).PossibleMoves();

        Console.Clear();
        Display.DisplayGameBoard(chessMatch.GameBoard!, possiblePositions);

        Console.Write("Destino: ");
        Position target = Display.ReadChessPosition().ToPosition();

        chessMatch.ExecuteMove(source, target);
    }
}
catch (GameBoardException e)
{
    Console.WriteLine(e.Message);
}
