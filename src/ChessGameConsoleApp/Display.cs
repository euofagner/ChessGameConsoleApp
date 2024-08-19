using System;
using ChessGameConsoleApp.Board;
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
            for (int j = 0; j < gameBoard.Columns; j++)
            {
                if (gameBoard.Piece(i, j) == null)
                    Console.Write("- ");
                else
                    Console.Write($"{gameBoard.Piece(i, j)} ");
            }
            Console.WriteLine();
        }
    }
}
