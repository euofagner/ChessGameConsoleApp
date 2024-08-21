using ChessGameConsoleApp;
using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using ChessGameConsoleApp.Board.Exceptions;
using ChessGameConsoleApp.Chess;

try
{
    GameBoard gameBoard = new(8, 8);
    gameBoard.PlacePiece(new Tower(Color.White, gameBoard), new Position(0, 0));
    gameBoard.PlacePiece(new Tower(Color.White, gameBoard), new Position(1, 5));
    gameBoard.PlacePiece(new King(Color.Black, gameBoard), new Position(0, 2));
    gameBoard.PlacePiece(new King(Color.Black, gameBoard), new Position(3, 7));

    Display.DisplayGameBoard(gameBoard);
}
catch (GameBoardException e)
{
    Console.WriteLine(e.Message);
}
