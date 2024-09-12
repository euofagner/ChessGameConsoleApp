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
        try
        {
            Console.Clear();
            Display.PrintChessMatch(chessMatch);

            Console.WriteLine();
            Console.Write("Origem: ");
            Position source = Display.ReadChessPosition().ToPosition();
            chessMatch.ValidateSourcePosition(source);

            bool[,] possiblePositions = chessMatch.GameBoard!.Piece(source).PossibleMoves();

            Console.Clear();
            Display.DisplayGameBoard(chessMatch.GameBoard!, possiblePositions);

            Console.WriteLine();
            Console.Write("Destino: ");
            Position target = Display.ReadChessPosition().ToPosition();
            chessMatch.ValidateTargetPosition(source, target);

            chessMatch.ExecutePlay(source, target);
        }
        catch(GameBoardException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
    Console.Clear();
    Display.PrintChessMatch(chessMatch);
}
catch (GameBoardException e)
{
    Console.WriteLine(e.Message);
}
