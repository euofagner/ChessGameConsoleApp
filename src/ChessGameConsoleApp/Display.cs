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
