using System;
using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using ChessGameConsoleApp.Chess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApp;

internal class Display 
{
    public static void PrintChessMatch(ChessMatch chessMatch)
    {
        DisplayGameBoard(chessMatch.GameBoard);
        Console.WriteLine();
        PrintCapturedPieces(chessMatch);
        Console.WriteLine();
        Console.WriteLine($"Turno: {chessMatch.Shift}");

        if (!chessMatch.Finished)
        {
            if (chessMatch.CurrentPlayer == Color.Black)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.Write($"Aguardando jogada: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(chessMatch.CurrentPlayer);
                Console.ForegroundColor = aux;
            }
            else
                Console.WriteLine($"Aguardando jogada: {chessMatch.CurrentPlayer}");

            if (chessMatch.Check)
                Console.WriteLine("XEQUE!");
        } 
        else
        {
            Console.WriteLine("XEQUEMATE!");
            Console.WriteLine($"Vencedor: {chessMatch.CurrentPlayer}");
        }
    }

    public static void PrintCapturedPieces(ChessMatch chessMatch)
    {
        Console.WriteLine("Peças capturadas:");
        Console.Write("Brancas: ");
        PrintSetPieces(chessMatch.CapturedPieces(Color.White));
        Console.WriteLine();
        Console.Write("Pretas: ");
        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintSetPieces(chessMatch.CapturedPieces(Color.Black));
        Console.ForegroundColor = aux;  
        Console.WriteLine();
    }

    public static void PrintSetPieces(HashSet<Piece> setPieces)
    {
        Console.Write("[");
        foreach(Piece piece in setPieces)
        {
            Console.Write($"{piece} ");
        }
        Console.Write("]");
    }

    public static void DisplayGameBoard(GameBoard gameBoard)
    {
        for (int i = 0; i < gameBoard.Lines; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < gameBoard.Columns; j++)
            {
                PrintPiece(gameBoard.Piece(i, j)); 
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static void DisplayGameBoard(GameBoard gameBoard, bool[,] possiblePositions)
    {
        ConsoleColor originalBackground = Console.BackgroundColor;
        ConsoleColor changedBackground = ConsoleColor.DarkGray;

        for (int i = 0; i < gameBoard.Lines; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < gameBoard.Columns; j++)
            {
                if (possiblePositions[i, j])
                    Console.BackgroundColor = changedBackground;
                else
                    Console.BackgroundColor = originalBackground;

                PrintPiece(gameBoard.Piece(i, j));
                Console.BackgroundColor = originalBackground;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.BackgroundColor = originalBackground;
    }

    public static ChessPosition ReadChessPosition()
    {
        string s = Console.ReadLine()!;
        char column = s[0];
        int line = int.Parse(s[1] + "");
        return new ChessPosition(column, line);
    }

    public static void PrintPiece(Piece piece)
    {
        if (piece == null)
            Console.Write("- ");
        else
        {
            if (piece.Color == Color.White)
                Console.Write(piece);
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
            Console.Write(" ");
        }
    }
}
